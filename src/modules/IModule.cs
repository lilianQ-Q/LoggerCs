using System;
using System.Collections.Generic;
using System.Text;

namespace noxLogger.src.modules
{
    public interface IModule
    {
        /// <summary>
        /// Method that allow the user to get a Module's author information. should be in static
        /// </summary>
        /// <returns></returns>
        string GetAuthor();

        /// <summary>
        /// Name of the module's author.
        /// </summary>
        string name { get ; set; }
        /// <summary>
        /// Lastname of the module author.
        /// </summary>
        string lastname { get; set; }
        /// <summary>
        /// Creation month of the module.
        /// </summary>
        string month { get; set; }
        /// <summary>
        /// Creation year of the module.
        /// </summary>
        string year { get; set; }
    }
}
