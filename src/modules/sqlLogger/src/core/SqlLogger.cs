using System;
using System.Collections.Generic;
using System.Text;

namespace noxLogger.src.modules.sqlLogger.src.core
{
    public class SqlLogger : IModule
    {
        #region Fields

        private string query { get; set; }

        #endregion

        #region Constructor

        public SqlLogger(string query)
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

        public string GetAuthor()
        {
            return ("Lilian Damiens - 2020");
        }

        #endregion
    }
}
