using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBLL;
namespace BLL
{
    public class BLLInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            //container.Register(Component.For<IAnimal>().ImplementedBy<Dog>());
            container.Register(Classes.FromThisAssembly().BasedOn<IOCBase>().WithService.DefaultInterfaces().LifestyleTransient());
        }
    }
}
