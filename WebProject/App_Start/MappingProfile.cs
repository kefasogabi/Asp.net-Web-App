using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebProject.Models;
using WebProject.Dtos;

namespace WebProject.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Movies, MovieDto>();
            Mapper.CreateMap<Customers, CustomerDto>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<Genre, GenreDto>();

            Mapper.CreateMap<CustomerDto, Customers>().ForMember(m => m.Id, opt => opt.Ignore());
            Mapper.CreateMap<MovieDto, Movies>().ForMember(m => m.Id, opt => opt.Ignore());
           
         
        }

    }
}