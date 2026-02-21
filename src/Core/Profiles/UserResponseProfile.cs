using AutoMapper;

using Core.Dal.Models;
using Core.Dto;

namespace Core.Profiles;

public class UserResponseProfile : Profile
{
    public UserResponseProfile()
    {
        CreateMap<User, UserResponse>()
            .ForMember(dest => dest.Email,
                opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.Id,
                opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name,
                opt => opt.MapFrom(src => src.Profile.Name))
            .ForMember(dest => dest.Birthday,
                opt => opt.MapFrom(src => src.Profile.Birthday))
            .ForMember(dest => dest.Phone,
                opt => opt.MapFrom(src => src.Profile.Phone))
            .ForMember(dest => dest.Products,
                opt => opt.MapFrom(src => src.Profile.Products));

    }
}
