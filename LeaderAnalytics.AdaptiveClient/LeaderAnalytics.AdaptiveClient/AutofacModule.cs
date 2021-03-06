﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using LeaderAnalytics.AdaptiveClient.Autofac;

namespace LeaderAnalytics.AdaptiveClient
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterGeneric(typeof(AdaptiveClient<>)).As(typeof(IAdaptiveClient<>)).InstancePerLifetimeScope();
            builder.RegisterType<NetworkUtilities>().As<INetworkUtilities>();
            builder.Register<Func<IEndPointConfiguration>>(c => { IComponentContext cxt = c.Resolve<IComponentContext>(); return () => cxt.Resolve<EndPointContext>().CurrentEndPoint; });
            builder.Register<Func<Type, IPerimeter>>(c => { IComponentContext cxt = c.Resolve<IComponentContext>(); return t => ResolutionHelper.ResolvePerimeter(cxt, t); });
            builder.Register<Func<string, string, IEndPointValidator>>(c => { IComponentContext cxt = c.Resolve<IComponentContext>(); return (eptype, providerName) => ResolutionHelper.ResolveValidator(cxt, eptype, providerName); });
            builder.RegisterType<EndPointContext>().InstancePerLifetimeScope();     // per lifetimescope - see notes in EndPointContext.cs
            builder.RegisterType<EndPointCache>().SingleInstance();                 // singleton
            builder.RegisterGeneric(typeof(ClientFactory<>)).As(typeof(IClientFactory<>));
            builder.RegisterGeneric(typeof(ClientEvaluator<>)).As(typeof(IClientEvaluator<>));
            builder.RegisterInstance<Action<string>>(msg => { }); // default logger.  User can override by calling RegistrationHelper.RegisterLogger
        }
    }
}

