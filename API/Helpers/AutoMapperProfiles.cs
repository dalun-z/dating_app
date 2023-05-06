using API.DTOs;
using API.Entities;
using API.Extensions;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            // mapping the duplicate items in these 2 classes, and then return to client
            CreateMap<AppUser, MemberDto>()
                .ForMember(dest => dest.PhotoUrl, opt => opt.MapFrom(src => src.Photos.FirstOrDefault(x => x.IsMain).Url))  // return main photo to client  
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.DateOfBirth.CalculatAge()));                     // return age of the user
            CreateMap<Photo, PhotoDto>();
        }
    }
}