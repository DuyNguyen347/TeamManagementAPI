using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;
using TeamManagementAPI.Models;
using System.Linq.Dynamic.Core;

namespace TeamManagementAPI.GenericRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        internal MyDbContext _db;
        internal DbSet<T> _dbSet;
        public GenericRepository(MyDbContext db)
        {
            _db = db;
            this._dbSet = _db.Set<T>();
        }
        public bool Add(T t)
        {
            try
            {
                _dbSet.Add(t);
                return true;
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }
        public bool Delete(object id)
        {
            try
            {
                T objectDelete = _dbSet.Find(id);
                if(objectDelete != null)
                {
                    objectDelete.GetType().GetProperty("isDeleted").SetValue(objectDelete,true);
                    _db.Entry(objectDelete).State = EntityState.Modified;
                    return true;
                }
                return false;
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }
        public List<T> GetAll()
        {
            return _dbSet.ToList();
        }
        public IQueryable<T> GetWithReference()
        {
            return _dbSet;
        }
        public T GetById(object id)
        {
            return _dbSet.Find(id);
        }
        public bool Update(T t)
        {
            try
            {
                _dbSet.Attach(t);
                _db.Entry(t).State = EntityState.Modified;
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
        }
    }
}