using System;
using System.Collections.Generic;
using System.Text;

namespace noxLogger.src
{
    public partial class Logger
    {
        /// <summary>
        /// Method that allow the user to log a sql query. This one is parsed before insert.
        /// </summary>
        /// <param name="query"></param>
        public void LogSQL(string query)
        {
            //Don't forget to parse the sql
            this.Log(LogType.info, query);
        }
    }
}
