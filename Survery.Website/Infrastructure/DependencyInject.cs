using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Survery.Website.Infrastructure
{
    public class DependencyInject
    {
        private static ContainerBuilder builder = new ContainerBuilder();
        public static void Inject()
        {
            builder.RegisterControllers(typeof(Global).Assembly);
            builder.RegisterFilterProvider();
            DependencyRegister.Regsister(builder);
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}