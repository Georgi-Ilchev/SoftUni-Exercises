using Pr._05.Logger.v2.Interfaces;
using System;
using System.Linq;
using System.Reflection;

namespace Pr._05.Logger.v2.Factories
{
    public class LayoutFactory
    {
        public ILayout CreateLayout(string layoutType)
        {
            Type type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(l => l.Name == layoutType);
            return (ILayout)Activator.CreateInstance(type);
        }
    }
}
