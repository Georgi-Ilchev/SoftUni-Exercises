using OOP___Workshop.Attributes;
using System;

namespace OOP___Workshop.Modules
{
    public interface IModule
    {
        public void Configure();

        public Type GetMapping(Type interfaceType, Named namedAttribute = null);

        public void CreateMapping<TInterface, TImplementation>();
    }
}
