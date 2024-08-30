using ApplicationTrackerApp.Dto;
using ApplicationTrackerApp.Models;
using AutoMapper;

namespace ApplicationTrackerApp.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() 
        {
            CreateMap<Application, ApplicationDto>();
            CreateMap<ApplicationDto, Application>();
            CreateMap<ClosedReason, ClosedReasonDto>();
            CreateMap<ClosedReasonDto, ClosedReason>();
            CreateMap<JobType, JobTypeDto>();
            CreateMap<JobTypeDto, JobType>();
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}
