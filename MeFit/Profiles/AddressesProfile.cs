using AutoMapper;
using MeFit.Models;
using MeFit.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeFit.Profiles
{
    public class AddressesProfile : Profile
    {
        public AddressesProfile()
        {
            CreateMap<Address, AddressesDTO>()
           // Turning related movies into int arrays
           .ForMember(cdto => cdto.Profiles, opt => opt
           .MapFrom(c => c.Profiles.Select(c => c.Id).ToList()))
           .ReverseMap(); ;
        }
       
    }
}
