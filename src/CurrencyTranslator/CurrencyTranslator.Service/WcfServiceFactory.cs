using CurrencyTranslator.Business.Contracts;
using Microsoft.Practices.Unity;
using Unity.Wcf;

namespace CurrencyTranslator.Service
{
	public class WcfServiceFactory : UnityServiceHostFactory
    {
        protected override void ConfigureContainer(IUnityContainer container)
        {
            container.RegisterTypes(
                AllClasses.FromAssemblies(typeof(ICurrencyTranslator).Assembly, typeof(ICurrencyService).Assembly),
                WithMappings.FromMatchingInterface,
                WithName.Default,
                WithLifetime.ContainerControlled);
        }
    }    
}