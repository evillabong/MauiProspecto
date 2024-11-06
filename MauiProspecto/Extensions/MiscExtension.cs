using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiProspecto.Extensions
{
    public static class MiscExtension
    {
        public static string GetQueryString(this Dictionary<string, string>? query)
        {
            if (query != null)
            {
                StringBuilder builder = new StringBuilder();
                foreach (var item in query)
                {
                    if (!string.IsNullOrEmpty(item.Key) && !string.IsNullOrEmpty(item.Value))
                    {
                        if (builder.Length == 0)
                        {
                            builder.Append($"{item.Key}={item.Value}");
                        }
                        else
                        {
                            builder.Append($"&{item.Key}={item.Value}");
                        }
                    }
                }
                if (builder.Length != 0)
                {
                    return $"?{builder.ToString()}";
                }
            }
            return string.Empty;
        }
    }
}
