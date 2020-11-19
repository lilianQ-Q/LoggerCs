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
    }
}
