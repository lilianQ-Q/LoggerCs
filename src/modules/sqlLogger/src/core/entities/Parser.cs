using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace noxLogger.src.modules.sqlLogger.src.core.entities
{
    public class Parser
    {
        #region Fields

        #endregion

        #region Singleton

        private static Parser _instance;
        
        /// <summary>
        /// Singleton of the Parser class.
        /// </summary>
        public static Parser Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new Parser();
                }
                return (_instance);
            }
        }

        #endregion

        #region Constructor

        private Parser()
        {
            //Do some stuff here
        }

        #endregion

        #region Methods

        public string StretchParse(string query)
        {
            return (query);
        }

        #endregion
    }
}
