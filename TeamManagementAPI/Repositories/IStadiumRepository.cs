using TeamManagementAPI.Models;

namespace TeamManagementAPI.Repositories
{
    public interface IStadiumRepository
    {
        public List<Stadium> GetAll();
        public Stadium Get(int id);
        public void Update(Stadium stadium);
        public bool Delete(int id);
        public void Add(Stadium stadium);
    }
}
