using Pr._05.Logger.v2.Interfaces;
using System;
using System.Linq;
using System.Reflection;

namespace Pr._05.Logger.v2.Factories
{
    public class AppenderFactory
    {
        public IAppender CreateAppender(string appenderType, ILayout layout)
        {
            Type type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(a => a.Name == appenderType);
            return (IAppender)Activator.CreateInstance(type, layout);
        }
    }
}
