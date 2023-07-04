namespace TeamManagementAPI.GenericRepository
{
    public interface IGenericRepository<T> where T : class
    {
        List<T> GetAll();
        IQueryable<T> GetWithReference();
        bool Update(T t);
        bool Delete(object id);
        T GetById(object id);
        bool Add(T t);
    }
}
