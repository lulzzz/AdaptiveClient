﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac.Builder;

namespace LeaderAnalytics.AdaptiveClient
{
    public interface IRegistrationHelper
    {
        void RegisterEndPoints(IEnumerable<IEndPointConfiguration> endPoints);
        IRegistrationBuilder<TService, ConcreteReflectionActivatorData, SingleRegistrationStyle> Register<TService, TInterface>(EndPointType endPointType, string api_name);     
    }
}
