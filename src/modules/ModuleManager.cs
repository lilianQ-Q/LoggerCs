using System;
using System.Collections.Generic;
using System.Text;

namespace noxLogger.src.modules
{
    public class ModuleManager
    {
        #region Fields

        /// <summary>
        /// String list of loadModules in the Logger.
        /// </summary>
        public static List<string> loadedModules = new List<string>();

        #endregion

        #region Singleton

        private static ModuleManager _instance;

        /// <summary>
        /// Allow the user to get the Instance of the ModuleManager.
        /// </summary>
        public static ModuleManager Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new ModuleManager();
                }
                return (_instance);
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Main Constructor of the Module class.
        /// </summary>
        private ModuleManager()
        {
            //blabla
        }

        /// <summary>
        /// Auxiliary constructor of the Module class.
        /// </summary>
        /// <param name="modulName"></param>
        public ModuleManager(string modulName)
        {
            loadedModules.Add(modulName);
        }

        #endregion
    }
}
