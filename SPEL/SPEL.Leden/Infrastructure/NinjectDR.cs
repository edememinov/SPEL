using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SPEL.Domain.Abstract;
using SPEL.Domain.Concrete;
using SPEL.Domain.Entities;

namespace SPEL.Leden.Infrastructure
{
    public class NinjectDR : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDR(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(System.Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(System.Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            // put bindings here

            kernel.Bind<IRepository<Sport>>().To<SportRepository>();
            kernel.Bind<IRepository<Lid>>().To<LidRepository>();






        }
    }
}