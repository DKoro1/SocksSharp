using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SocksSharp.Extensions
{
    internal static class HttpHeadersExtensions
    {
        public static string GetHeaderString(this HttpHeaders headers, string key)
        {
            if (headers == null)
            {
                throw new ArgumentNullException(nameof(headers));
            }

            if (String.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key));
            }

            IEnumerable<string> values;
            string value = String.Empty;

            headers.TryGetValues(key, out values);

            string separator = key.Equals("User-Agent") ? " " : ", ";

            if (values != null && values.Count() > 1)
            {
                value = String.Join(separator, values.ToArray());
            }

            return value;
        }
    }
}
