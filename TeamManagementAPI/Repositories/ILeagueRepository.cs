using TeamManagementAPI.Models;

namespace TeamManagementAPI.Repositories
{
    public interface ILeagueRepository
    {
        public List<League> GetAll();
        public League GetById(int id);
        public void Update(League league);
        public bool Delete(int id);
        public void Add(League league);

    }
}
