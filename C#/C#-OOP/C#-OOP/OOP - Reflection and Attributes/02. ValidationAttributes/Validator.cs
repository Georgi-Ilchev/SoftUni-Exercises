using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace _02._ValidationAttributes
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            PropertyInfo[] properties = obj.GetType().GetProperties();

            foreach (var property in properties)
            {
                IEnumerable<MyValidationAttribute> customAttrs = property
                    //.GetCustomAttributes()
                    //.Where(x => x is MyValidationAttribute)
                    //.Cast<MyValidationAttribute>();
                .GetCustomAttributes<MyValidationAttribute>();

                foreach (MyValidationAttribute attribute in customAttrs)
                {
                    bool result = attribute.IsValid(property.GetValue(obj));
                    if (!result)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
