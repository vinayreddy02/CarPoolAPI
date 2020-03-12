using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;


namespace CarPoolApplication.Services
{
    public static class AutoMapping<T,U>
        {
        public static IMapper Mapper = new MapperConfiguration(cfg => cfg.CreateMap<T,U>().ReverseMap()).CreateMapper();
        }
}
