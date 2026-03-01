using AutoMapper;

using Core.Dal.Models;
using Core.Dto;
using Core.Dto.Register;

namespace Core.Profiles;

public class UserResponseProfile : Profile
{
    public UserResponseProfile()
    {
        CreateMap<UserProfile, UserResponse>()
            .ForMember(dest => dest.Id,
                opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.FirstName,
                opt => opt.MapFrom(src => src.FirstName))
            .ForMember(dest => dest.LastName,
                opt => opt.MapFrom(src => src.LastName))
            .ForMember(dest => dest.Birthday,
                opt => opt.MapFrom(src => src.Birthday))
            .ForMember(dest => dest.Phone,
                opt => opt.MapFrom(src => src.Phone))
            .ForMember(dest => dest.Passport,
                opt => opt.MapFrom(src => src.PassportNumber))
            .ForMember(dest => dest.Address,
                opt => opt.MapFrom(src => src.RegistrationAddress));

        CreateMap<RegisterRequest, User>()
            .ForMember(dest => dest.Profile,
                opt => opt.MapFrom(src => new UserProfile()
                {
                    FirstName = src.FirstName,
                    LastName = src.LastName,
                    Phone = src.Phone,
                    Birthday = src.Birthday,
                    PassportNumber = src.PassportNumber,
                    RegistrationAddress = src.RegistrationAddress,
                }))
            .ForMember(dest => dest.Email,
                opt => opt.MapFrom(src => src.Email));

    }
}
