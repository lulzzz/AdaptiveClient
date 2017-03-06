﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac.Builder;

namespace LeaderAnalytics.AdaptiveClient
{
    public interface IRegistrationHelper
    {
        IRegistrationHelper RegisterEndPoints(IEnumerable<IEndPointConfiguration> endPoints);
        IRegistrationHelper Register<TClient, TInterface>(string endPointType, string api_name);
        IRegistrationHelper RegisterEndPointValidator<TValidator>(string endPointType) where TValidator : IEndPointValidator;
        IRegistrationHelper RegisterLogger(Action<string> logger);
    }
}
