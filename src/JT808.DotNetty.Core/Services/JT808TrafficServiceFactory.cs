﻿using JT808.DotNetty.Core.Enums;
using JT808.DotNetty.Core.Metadata;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace JT808.DotNetty.Core.Services
{
    public class JT808TrafficServiceFactory
    {
        private readonly ConcurrentDictionary<JT808ModeType, JT808TrafficService> cache;

        public JT808TrafficServiceFactory()
        {
            cache = new ConcurrentDictionary<JT808ModeType, JT808TrafficService>();
        }

        public JT808TrafficService Create(JT808ModeType type)
        {
            if (cache.TryGetValue(type, out var service))
            {
                return service;
            }
            else
            {
                var serviceNew = new JT808TrafficService();
                cache.TryAdd(type, serviceNew);
                return serviceNew;
            }
        }
    }
}
