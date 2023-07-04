using Microsoft.EntityFrameworkCore;
using TeamManagementAPI.Models;

namespace TeamManagementAPI.GenericRepository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyDbContext dbContext; 
        public IGenericRepository<Team>? teamRepo;
        public IGenericRepository<League>? leagueRepo;
        public IGenericRepository<Stadium>? stadiumRepo;
        public IGenericRepository<Player>? playerRepo;
        public UnitOfWork(MyDbContext db)
        {
            this.dbContext = db;
        }

        public IGenericRepository<Team> TeamRepo => teamRepo ??= new GenericRepository<Team>(dbContext);
        public IGenericRepository<League> LeagueRepo => leagueRepo ??= new GenericRepository<League>(dbContext);
        public IGenericRepository<Stadium> StadiumRepo => stadiumRepo ??= new GenericRepository<Stadium>(dbContext);
        public IGenericRepository<Player> PlayerRepo => playerRepo ??= new GenericRepository<Player>(dbContext);


        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }
    }
}
