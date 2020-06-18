using Kolokwium2.DTOs.Requests;
using Kolokwium2.DTOs.Responses;
using Kolokwium2.Exceptions;
using Kolokwium2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium2.Services
{
    public class DbService : IDbService
    {
        s18923Context context;
        public DbService(s18923Context context)
        {
            this.context = context;
        }

        public void AddPLayerToTeam(int id, PlayerRequest request)
        {
            var searchingPlayer = context.Player.FirstOrDefault(e => e.FirstName == request.FirstName && e.LastName == request.LastName);

            if (searchingPlayer == null)
            {
                throw new PlayerDoesNotExistException("Such a player does not exist"); ///// ''''nie ma takiego zawodniaka'''''
            }

            var additionalInfo = context.PlayerTeam.FirstOrDefault(e => e.IdPlayer == searchingPlayer.IdPlayer);


            //var playerToAdd = new PlayerRequest()
            //{
            //    FirstName = searchingPlayer.FirstName,
            //    LastName = searchingPlayer.LastName,
            //    DateOfBirth = searchingPlayer.DateOfBirth,
            //    NumOfShirt = additionalInfo.NumOnShirt,
            //    Comment = additionalInfo.Comment
            //};

            var team = context.Team.FirstOrDefault(e => e.IdTeam == id);

            DateTime zeroTime = new DateTime(1, 1, 1);

            TimeSpan timeSpan= request.DateOfBirth - DateTime.Now;

            int years = (zeroTime + timeSpan).Year - 1;


            if (years > team.MaxAge)
            {
                throw new TooOldException("Player is too old to play for that team");    ////'''za stary'
            }

            var result = new PlayerTeam()
            {
                IdPlayer = searchingPlayer.IdPlayer,
                IdTeam = id,
                NumOnShirt = request.NumOfShirt,
                Comment = request.Comment
            };

            context.PlayerTeam.Add(result);
            context.SaveChanges();
        }

        public List<TeamResponse> GetChampionshipInfo(int Id)
        {
            List<TeamResponse> listOfTeams = new List<TeamResponse>();

            var ifExist = context.ChampionshipTeam.Any(e => e.IdChampionship == Id);

            if (ifExist == false)
            {
                return null;
            }

            var listOfId = context.ChampionshipTeam.Where(e => e.IdChampionship == Id).Select(e => e.IdTeam).ToList();

            foreach (var item in listOfId)
            {
                var teamName = context.Team.FirstOrDefault(e => e.IdTeam == item);
                var score = context.ChampionshipTeam.FirstOrDefault(e => e.IdTeam == item);

                var teamResponse = new TeamResponse()
                {
                    Score = score.Score,
                    TeamName = teamName.TeamName
                };
                listOfTeams.Add(teamResponse);
            }
            return listOfTeams;
        }
    }
}
