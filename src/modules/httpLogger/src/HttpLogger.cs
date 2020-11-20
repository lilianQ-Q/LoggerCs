using noxLogger.src.core.entities;
using noxLogger.src.core.exceptions;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace noxLogger.src.modules.httpLogger.src
{
    public class HttpLogger : IModule
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

        private string lastname = "Damiens";
        private string firstname = "Lilian";
        private string date = "19.11.2020";

        #endregion

        #region Constructor

        /// <summary>
        /// Main constructor of the HttpLogger class.
        /// </summary>
        /// <param name="token"></param>
        public HttpLogger(string token, string apiUrl = "https://liliandamiens.fr/")
        {
            this.apiUrl = apiUrl;
            this.token = token;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Method that allow the user to get the author of the module.
        /// </summary>
        /// <returns></returns>
        public string GetAuthor()
        {
            return (this.firstname + " " + this.lastname + " " + this.date);
        }

        public bool PostLog(string logData)
        {
            bool isOk = true;
            if (this.urlReachable())
            {
                //Do some stuff here.
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

        public bool PostLog(Log log)
        {
            return (new Log());
        }

        private bool urlReachable()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(this.apiUrl);
            request.Timeout = 2000;
            request.Method = "HEAD"; // As per Lasse's comment
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
