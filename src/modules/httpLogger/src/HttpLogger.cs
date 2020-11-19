using System;
using System.Collections.Generic;
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

        private string lastname = "Damiens";
        private string firstname = "Lilian";
        private string date = "19.11.2020";

        #endregion

        #region Constructor

        /// <summary>
        /// Main constructor of the HttpLogger class.
        /// </summary>
        /// <param name="token"></param>
        public HttpLogger(string token)
        {
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
            return ("Lilian Damiens - 2020");
        }

        #endregion
    }
}
