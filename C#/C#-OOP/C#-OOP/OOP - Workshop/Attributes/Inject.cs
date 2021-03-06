using System;

namespace OOP___Workshop.Attributes
{
    [AttributeUsage(AttributeTargets.Constructor, AllowMultiple = false)]
    public class Inject : Attribute
    {
    }
}
