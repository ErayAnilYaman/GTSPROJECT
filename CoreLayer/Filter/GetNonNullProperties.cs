
namespace CoreLayer.Filter
{
    #region usings
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    #endregion
    public class GetProperties
    {
        public static Dictionary<string,object> GetNonNullProperties<T>(T obj)
        {
            var propertiesWithValues = typeof(T).GetProperties()
                .Where(p => p.GetValue(obj) != null)
                .ToDictionary(
                    p => p.Name,
                    p => p.GetValue(obj)
                );

            return propertiesWithValues!;
        }

    }
}
