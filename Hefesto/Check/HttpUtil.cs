using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Hefesto.Check
{
    /// <summary>
    /// Esta clase permite realizar validaciones HTTP
    /// </summary>
    /// <summary lang="en-US">
    /// This class allows to perform HTTP validations
    /// </summary>
    public class HttpUtil
    {
        /// <summary>
        /// Comprueba si la URL ingresada existe
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static bool urlExist(string url)
        {
            try
            {
                var request = WebRequest.Create(url) as HttpWebRequest;
                request.Method = "HEAD";
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    return response.StatusCode == HttpStatusCode.OK;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
