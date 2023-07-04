using TeamManagementAPI.Models;
using TeamManagementAPI.ViewModels;

namespace TeamManagementAPI.Repositories
{
    public interface ITeamRepository
    {
        public List<Team> GetAllShort();
        public List<Team> GetAll();
        public Team GetById(int id);
        public bool DeleteById(int id);
        public bool UpdateTeam(Team team);
        public bool AddTeam(Team team);
    }
}
