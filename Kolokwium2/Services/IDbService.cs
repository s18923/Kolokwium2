using Kolokwium2.DTOs.Requests;
using Kolokwium2.DTOs.Responses;
using Kolokwium2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium2.Services
{
    public interface IDbService
    {
        public List<TeamResponse> GetChampionshipInfo(int Id);

        public void AddPLayerToTeam(int id, PlayerRequest request);
    }
}
