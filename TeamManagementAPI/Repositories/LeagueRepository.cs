//using TeamManagementAPI.Migrations;
using TeamManagementAPI.Models;

namespace TeamManagementAPI.Repositories
{
    public class LeagueRepository : ILeagueRepository
    {
        private readonly MyDbContext _db;
        public LeagueRepository(MyDbContext db)
        {
            _db = db;
        }
        public void Add(League league)
        {
            _db.Leagues.Add(league);
            _db.SaveChanges();
        }

        public bool Delete(int id)
        {
            var league = _db.Leagues.FirstOrDefault(l =>  l.Id == id);
            if (league != null)
            {
                _db.Leagues.Remove(league);
                return true;
            }
            return false;
        }

        public List<League> GetAll()
        {
            return _db.Leagues.ToList();
        }

        public League GetById(int id)
        {
            return _db.Leagues.FirstOrDefault(l => l.Id == id);
        }

        public void Update(League league)
        {
            _db.Entry(league).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _db.SaveChanges();
        }
    }
}
