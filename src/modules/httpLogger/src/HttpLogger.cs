using noxLogger.src.core.entities;
using noxLogger.src.core.exceptions;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace noxLogger.src.modules.httpLogger.src
{
    /// <summary>
    /// Module that is used to send logs to an external api.
    /// Developped by Lilian DAMIENS - 2020
    /// </summary>
    public class HttpLogger : Module
    {
        #region Fields

        /// <summary>
        /// This is the token of the httpLogger.
        /// </summary>
        private string token { get; set; }
        /// <summary>
        /// Url of the api you want to insert data in. 
        /// TODO : Make a list of apiUrl for multi insert
        /// </summary>
        private string apiUrl { get; set; }
        /// <summary>
        /// Api url list that you want to insert data in.
        /// </summary>
        private List<string> apiUrlList { get; set; } = new List<string>();

        #endregion

        #region Constructor

        /// <summary>
        /// Main constructor of the HttpLogger class.
        /// </summary>
        /// <param name="token"></param>
        /// <param name="apiUrl"></param>
        public HttpLogger(string token, string apiUrl = "https://liliandamiens.fr/") : base("Lilian", "Damiens", "November", "2020")
        {
            this.apiUrl = apiUrl;
            this.token = token;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Method that allow the user to send data to the default api.
        /// Default api : logcenter.liliandamiens.fr
        /// </summary>
        /// <param name="logData"></param>
        /// <param name="apiUrl"></param>
        /// <param name="waitHttpResponse"></param>
        /// <returns></returns>
        public bool PostLog(string logData, string apiUrl, bool waitHttpResponse = false)
        {
            apiUrl = String.IsNullOrEmpty(apiUrl) ? this.apiUrl : apiUrl;
            bool isOk = true;
            if (this.urlReachable(apiUrl))
            {
                if (waitHttpResponse)
                {
                    //Send post data and wait for a response, may causes few performance problems.
                    throw new NotImplementedException("Pas encore dev");
                }
                else
                {
                    throw new NotImplementedException("Pas encore dev");
                    isOk = true;
                }
            }
            else
            {
                if (Logger.enabledException)
                {
                    throw new IncorrectUrlException("Host unreachable. Please check that this one is up or if the url is valid");
                }
                isOk = false;
            }
            return (isOk);
        }

        /// <summary>
        /// DEPRECATED
        /// Method that allow the user to check if the current Url is reachable or not.
        /// </summary>
        /// <returns></returns>
        private bool urlReachable()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(this.apiUrl);
            request.Timeout = 2000;
            request.Method = "HEAD";
            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    return response.StatusCode == HttpStatusCode.OK;
                }
            }
            catch (WebException)
            {
                return false;
            }
        }

        /// <summary>
        /// Method that allow the user to check if a Url is reachable or not.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private bool urlReachable(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Timeout = 2000;
            request.Method = "HEAD";
            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    return response.StatusCode == HttpStatusCode.OK;
                }
            }
            catch (WebException)
            {
                return false;
            }
        }

        #endregion
    }
}
