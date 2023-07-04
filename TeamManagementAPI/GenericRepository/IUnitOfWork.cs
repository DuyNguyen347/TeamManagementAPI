using TeamManagementAPI.Models;

namespace TeamManagementAPI.GenericRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Team> TeamRepo { get; }
        IGenericRepository<League> LeagueRepo { get; }
        IGenericRepository<Stadium> StadiumRepo { get; }
        IGenericRepository<Player> PlayerRepo { get; }
        void Save();
    }
}
