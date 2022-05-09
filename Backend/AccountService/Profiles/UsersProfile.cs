using AccountService.Microservice.DTOs;
using AccountService.Models;
using AutoMapper;

namespace AccountService.Microservice.Profiles
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            //Source -> target
            CreateMap<UserModel, UserReadDTO>();
            CreateMap<UserCreateDTO, UserModel>();
            CreateMap<UserUpdateDTO, UserModel>();
        }
    }
}
