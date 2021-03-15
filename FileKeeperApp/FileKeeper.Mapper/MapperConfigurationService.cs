using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileKeeper.Mapper
{
    public static class MapperConfigurationService
    {
        private static IMapper mapper;

        static MapperConfigurationService()
        {
            MapperConfiguration config = new MapperConfiguration(cfg => cfg.AddProfile<MapperProfile>());
            mapper = config.CreateMapper();
        }
    }
}
