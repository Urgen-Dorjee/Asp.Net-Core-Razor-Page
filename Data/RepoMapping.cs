using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Urgen.Website.Data.Entities;
using static Urgen.Website.Pages.Tech.IndexModel;
using AutoMapper;

namespace Urgen.Website.Data
{
    public class RepoMapping : Profile
    {
        public RepoMapping()
        {
            //CreateMap<User, UserDto>()
            //             .ForMember(dest => dest.Name, opt =>opt.MapFrom(src =>
            //              $"{src.FirstName} {src.LastName}"));
            //    CreateMap<UserForCreationDto, User>();

            CreateMap<TechPost, TechPostDto>()
                          .ForMember(dest => dest.Name, opt => opt.MapFrom(src =>
                             $"{src.User.FirstName} {src.User.LastName}"));
             CreateMap<TechPostDto, TechPost>();

            //    CreateMap<TravelPost, TravelPostDto>();       
        }



    }
}
