using System;
using System.Collections.Generic;
using System.Web.Mvc;
using MyRadio.Domain.Repositories;
using Ninject;

namespace MyRadio.Infraestructure
{
    public class NinjectDependencyResolver : IDependencyResolver 
    {
        private IKernel kernel;

        public NinjectDependencyResolver()
        {
            kernel = new StandardKernel();
            CreateBindings();
        }

        public void CreateBindings()
        {
            kernel.Bind<IPlaylistRepository>().To<PlaylistRepository>();
            kernel.Bind<IMediaRepository>().To<MediaRepository>();
        }


        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
    }
}