using System;
using System.Collections.Generic;
using System.Text;

namespace noxLogger.src.modules
{
    /// <summary>
    /// Mother class for other modules.
    /// </summary>
    public class Module : IModule
    {
        #region Fields

        /// <summary>
        /// Name of the developer that developed the module.
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// Lastname of the developer that developed the module.
        /// </summary>
        public string lastname { get; set; }
        /// <summary>
        /// Creation month of the module.
        /// </summary>
        public string month { get ; set; }
        /// <summary>
        /// Creation year of the module.
        /// </summary>
        public string year { get; set ; }

        #endregion

        #region Constructor

        /// <summary>
        /// Method that allow you to create a new Module.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="lastName"></param>
        /// <param name="month"></param>
        /// <param name="year"></param>
        protected Module(string name, string lastName, string month, string year)
        {
            this.name = name;
            this.lastname = lastname.ToUpper();
            this.month = month;
            this.year = year;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Method that allow the user to get module author's information.
        /// </summary>
        /// <returns></returns>
        public string GetAuthor()
        {
            return("Module developed by " + this.name + " " + this.lastname + " " + this.month + " " + this.year);
        }

        /// <summary>
        /// Method that allow the user to disable this mpodule.
        /// Useful when an official module is still in development even if the librarie has been released.
        /// </summary>
        public void Disable()
        {
            //Disable the module inside the moduleManager / Add to blackList
            throw new NotImplementedException("Pas encore dev");
        }

        #endregion
    }
}
