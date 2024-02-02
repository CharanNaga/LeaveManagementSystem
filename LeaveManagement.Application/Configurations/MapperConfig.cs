using AutoMapper;
using LeaveManagement.Data;
using LeaveManagement.Common.Models;

namespace LeaveManagement.Application.Configurations
{
    public class MapperConfig : Profile
    {
        //Establishing a mapping mechanism in ctor to switch b/w two classes (source to destination & viceversa)
        public MapperConfig() 
        {
            CreateMap<LeaveType, LeaveTypeViewModel>().ReverseMap();
            CreateMap<Employee, EmployeeListViewModel>().ReverseMap();
            CreateMap<Employee, EmployeeAllocationViewModel>().ReverseMap();
            CreateMap<LeaveAllocation, LeaveAllocationViewModel>().ReverseMap();
            CreateMap<LeaveAllocation, LeaveAllocationEditViewModel>().ReverseMap();
            CreateMap<LeaveRequest, LeaveRequestCreateViewModel>().ReverseMap();
            CreateMap<LeaveRequest, LeaveRequestViewModel>().ReverseMap();
        }
    }
}
