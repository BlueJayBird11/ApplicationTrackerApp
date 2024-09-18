using ApplicationTrackerApp.Dto;
using ApplicationTrackerApp.Models;
using AutoMapper;

namespace ApplicationTrackerApp.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() 
        {
            CreateMap<JobApplication, JobApplicationDto>();
            CreateMap<JobApplicationDto, JobApplication>();
            CreateMap<JobApplication, JobApplicationFullDto>();
            CreateMap<JobApplicationFullDto, JobApplication>();
            CreateMap<ClosedReason, ClosedReasonDto>();
            CreateMap<ClosedReasonDto, ClosedReason>();
            CreateMap<JobType, JobTypeDto>();
            CreateMap<JobTypeDto, JobType>();
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<User, CreateUserDto>();
            CreateMap<CreateUserDto, User>();
        }
    }
}
