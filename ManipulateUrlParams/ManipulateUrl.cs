using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManipulateUrlParams
{
    public class ManipulateUrl
    {
        public static string AddOrChangeUrlParameter(string url, string keyValueParameter)
        {


            string host = url.Contains("?") ? url.Substring(0, url.IndexOf("?")) : url;
            string oldParamString = url.Contains("?") ? url.Substring(url.IndexOf("?") + 1) : null;

            Dictionary<string, string> oldParams = new Dictionary<string, string>();
            if (oldParamString != null)
                oldParams = ParseParams(oldParamString);




            Dictionary<string, string> newParams = new Dictionary<string, string>();
            if (keyValueParameter != null)
                newParams = ParseParams(keyValueParameter);


            string resultUrl = host;

            Dictionary<string, string> resultParams = oldParams;
            foreach (var newParam in newParams)
            {
                if (resultParams.ContainsKey(newParam.Key))
                    resultParams[newParam.Key] = newParam.Value;
                else
                    resultParams.Add(newParam.Key, newParam.Value);

            }

            if (resultParams.Count > 0)
                resultUrl += "?";

            foreach (KeyValuePair<string, string> keyValuePair in resultParams)
            {
                if (resultUrl.LastIndexOf("?", StringComparison.Ordinal) != resultUrl.Length - 1)
                    resultUrl += "&";

                resultUrl += $"{keyValuePair.Key}={keyValuePair.Value}";
            }

            return resultUrl;
        }

        private static Dictionary<string, string> ParseParams(string s)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            string[] pairs = s.Split('&');
            foreach (var pair in pairs)
            {
                var keyValue = pair.Split('=');

                if (keyValue.Length == 2)
                    result.Add(keyValue[0], keyValue[1]);
            }

            return result;
        }
    }
}
