using OOP___Workshop.Attributes;
using OOP___Workshop.Modules;
using System;
using System.Reflection;

namespace OOP___Workshop.Injectors
{
    public class Injector
    {
        private IModule module;

        //[Inject]
        public Injector(IModule module)
        {
            this.module = module;
        }

        public TClass Inject<TClass>()
        {
            Type classType = typeof(TClass);

            ConstructorInfo[] constructors = classType.GetConstructors();

            foreach (var constructor in constructors)
            {
                if (constructor.GetCustomAttribute(typeof(Inject)) == null)
                {
                    continue;
                }
                ParameterInfo[] ctorParams = constructor.GetParameters();

                object[] implementationsParams = new object[ctorParams.Length];
                int i = 0;

                foreach (var ctorParam in ctorParams)
                {
                    Named namedAttribute = ctorParam.GetCustomAttribute(typeof(Named)) as Named;
                    Type implementationType = module.GetMapping(ctorParam.ParameterType, namedAttribute);


                    if (implementationType == null)
                    {
                        implementationsParams[i++] = null;
                    }
                    else
                    {
                        implementationsParams[i++] = Activator.CreateInstance(implementationType);
                    }
                }

                return (TClass)Activator.CreateInstance(classType, implementationsParams);
            }

            return default(TClass);
        }
    }
}
