using AutoMapper;

using Core.Dal.Models;
using Core.Dto;
using Core.Dto.Register;

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
            .ForMember(dest => dest.FirstName,
                opt => opt.MapFrom(src => src.Profile.FirstName))
            .ForMember(dest => dest.LastName,
                opt => opt.MapFrom(src => src.Profile.LastName))
            .ForMember(dest => dest.Birthday,
                opt => opt.MapFrom(src => src.Profile.Birthday))
            .ForMember(dest => dest.Phone,
                opt => opt.MapFrom(src => src.Profile.Phone))
            .ForMember(dest => dest.Products,
                opt => opt.MapFrom(src => src.Profile.Products));

        CreateMap<RegisterRequest, User>()
            .ForMember(dest => dest.Profile,
                opt => opt.MapFrom(src => new UserProfile()
                {
                    FirstName = src.FirstName,
                    LastName = src.LastName,
                    Phone = src.Phone
                }))
            .ForMember(dest => dest.Email,
                opt => opt.MapFrom(src => src.Email));

    }
}
