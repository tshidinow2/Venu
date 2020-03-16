﻿using AutoMapper;
using Venu.Events.API.Domain;
using Venu.Events.API.Queries.Dtos;
using EventAddress = Venu.Events.API.Domain.Address;
using EventInputAddress = Venu.Events.API.Commands.Dtos.Address;

namespace Venu.Events.API.Extensions.Converters
{
    /// <summary>
    /// AutoMapper configuration
    /// </summary>
    public class AutoMapperConfiguration
    {
        /// <summary>
        /// Mapper
        /// </summary>
        public static IMapper Mapper { get; set; }

        static AutoMapperConfiguration()
        {
            var config =
                new MapperConfiguration(
                    cfg =>
                    {
                        cfg.CreateMap<EventDto, Event>().ReverseMap();
                        cfg.CreateMap<EventInputAddress, EventAddress>();
                    });

            Mapper = config.CreateMapper();
        }
    }
}
