using TeamManagementAPI.Models;
using AutoMapper;
using TeamManagementAPI.ViewModels;

namespace TeamManagementAPI.Helper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // ReverseMap giúp ánh xạ hai chiều
            
            CreateMap<Player, PlayerVM>()
                .ForMember(des => des.NameTeam, options => options.MapFrom(source => source.Team.Name));
            CreateMap<TeamVM,Team>()
                .ForMember(dest => dest.CreateOn, opt => opt.Ignore()).ReverseMap();
            CreateMap<LeagueVM, League>()
                .ForMember(dest => dest.CreateOn, opt => opt.Ignore()).ReverseMap();
            CreateMap<StadiumVM, Stadium>()
                .ForMember(dest => dest.CreateOn, opt => opt.Ignore()).ReverseMap();
            CreateMap<PlayerVM, Player>()
                .ForMember(dest => dest.CreateOn, opt => opt.Ignore()).ReverseMap();
            CreateMap<Team, TeamVM>()
                .ForMember(des => des.NameStadium, options => options.MapFrom(source => source.Stadium.Name))
                .ForMember(des => des.NameLeague, options => options.MapFrom(source => source.League.Name));
        }
    }
}
