using AutoMapper;
using SpaceXLaunchService.Application.DTOs;
using SpaceXLaunchService.Domain.Entities;

namespace SpaceXLaunchService.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Launch, LaunchDTO>().ReverseMap();
            CreateMap<Core, CoreDTO>().ReverseMap();
            CreateMap<Fairings, FairingsDTO>().ReverseMap();
            CreateMap<FirstStage, FirstStageDTO>().ReverseMap();
            CreateMap<LaunchFailureDetails, LaunchFailureDetailsDTO>().ReverseMap();
            CreateMap<LaunchSite, LaunchSiteDTO>().ReverseMap();
            CreateMap<Links, LinksDTO>().ReverseMap();
            CreateMap<OrbitParams, OrbitParamsDTO>().ReverseMap();
            CreateMap<Payload, PayloadDTO>().ReverseMap();
            CreateMap<Rocket, RocketDTO>().ReverseMap();
            CreateMap<SecondStage, SecondStageDTO>().ReverseMap();
            CreateMap<Telemetry, TelemetryDTO>().ReverseMap();
            CreateMap<Timeline, TimelineDTO>().ReverseMap();
        }
    }
}
