using TeamManagementAPI.Models;

namespace TeamManagementAPI.Repositories
{
    public class StadiumRepository : IStadiumRepository
    {
        private readonly MyDbContext _db;
        public StadiumRepository(MyDbContext db)
        {
            _db = db;
        }
        public void Add(Stadium stadium)
        {
            _db.Stadiums.Add(stadium);
            _db.SaveChanges();
        }

        public bool Delete(int id)
        {
            var stadium = _db.Stadiums.FirstOrDefault(s => s.Id == id);
            if(stadium != null)
            {
                _db.Stadiums.Remove(stadium);
                _db.SaveChanges();
                return true;
            }
            return false;
        }

        public Stadium Get(int id)
        {
            return _db.Stadiums.FirstOrDefault(s => s.Id == id);
        }

        public List<Stadium> GetAll()
        {
            return _db.Stadiums.ToList();
        }

        public void Update(Stadium stadium)
        {
            _db.Entry(stadium).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _db.SaveChanges();
        }
    }
}
