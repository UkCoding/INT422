
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace Assignment2
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            // Add map creation statements here
            // Mapper.CreateMap< FROM , TO >();

            Mapper.Initialize(cfg => cfg.CreateMap<Controllers.EmployeeAdd, Models.Employee>());
            Mapper.Initialize(cfg => cfg.CreateMap<Models.Employee, Controllers.EmployeeBase>());
        }
    }
}