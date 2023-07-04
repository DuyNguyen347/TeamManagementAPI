using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TeamManagementAPI.Models;
using TeamManagementAPI.ViewModels;

namespace TeamManagementAPI.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly MyDbContext _db;
        private readonly IMapper mapper;
        public TeamRepository(MyDbContext db,IMapper m)
        {

            _db = db;
            mapper = m;
        }
        public bool AddTeam(Team team)
        {
            try
            {
                _db.Teams.Add(team);
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }

        public bool DeleteById(int id)
        {
            var team = _db.Teams.FirstOrDefault(t => t.Id == id);
            if(team != null)
            {
                _db.Teams.Remove(team);
                _db.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Team> GetAllShort()
        {
            return _db.Teams.Include(team => team.Stadium).Include(team => team.League).ToList();
        }
        public List<Team> GetAll()
        {
            return _db.Teams.ToList();
        }
        public Team GetById(int id)
        {
            return _db.Teams.FirstOrDefault(t => t.Id == id);
        }

        public bool UpdateTeam(Team team)
        {
            try
            {
                _db.Entry(team).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _db.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
