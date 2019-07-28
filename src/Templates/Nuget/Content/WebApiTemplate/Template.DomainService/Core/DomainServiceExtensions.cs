using System;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Template.DomainService.Core
{
    public static class DomainServiceExtensions
    {
        public static IServiceCollection AddDomainService(this IServiceCollection serviceCollection)
        {
            if (serviceCollection == null) throw new ArgumentNullException(nameof(serviceCollection));

            var types = Assembly.GetAssembly(typeof(SampleDomainService)).GetTypes().Where(w => w.Name.EndsWith("DomainService") && w.IsClass && !w.IsAbstract);

            foreach (var type in types)
            {
                var interfaceType = type.GetInterfaces().FirstOrDefault(w => w.Name == $"I{type.Name}");
                if (interfaceType == null) throw new NotImplementedException($"Not found Interface:{nameof(type)}");

                serviceCollection.AddSingleton(interfaceType, type);
            }
            return serviceCollection;
        }
    }
}
