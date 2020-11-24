using System;
using System.Collections.Generic;
using System.Text;

namespace noxLogger.src.modules.sqlLogger.src.core
{
    /// <summary>
    /// DEPRECATED, call it SqlParser instead.
    /// </summary>
    public class SqlLogger : Module
    {
        #region Fields

        private string query { get; set; }

        #endregion

        #region Constructor

        public SqlLogger(string query) : base ("Lilian", "Damiens", "November", "2020")
        {
            this.query = query;
        }

        #endregion

        #region Methods

        public string ParseSql()
        {
            throw new NotImplementedException("Pas encore dev");
            return ("oui");
        }

        #endregion
    }
}
