using AutoMapper;
using MyTasksAction.Core.DTO;
using MyTasksAction.Core.Entities;
using MyTasksAction.Web.ViewModels;

namespace MyTasksAction.Web.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<TaskAction, TaskActionViewModel>().ReverseMap();
        CreateMap<DashboardTasks, DashboardTaskViewModel>().ReverseMap();
    }
}
