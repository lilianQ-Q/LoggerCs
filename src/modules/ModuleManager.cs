using System;
using System.Collections.Generic;
using System.Text;

namespace noxLogger.src.modules
{
    public class ModuleManager
    {
        #region Fields

        private List<Module> blackList { get; set; }

        #endregion

        #region Singleton

        private static ModuleManager instance;
        
        public static ModuleManager GetInstance
        {
            get
            {
                if(instance == null)
                {
                    instance = new ModuleManager();
                }
                return (instance);
            }
        }

        #endregion

        #region Constructor

        private ModuleManager()
        {

        }

        #endregion

        #region Methods

        /// <summary>
        /// Method that allow the user to blacklist a module.
        /// </summary>
        /// <param name="moduleType"></param>
        public void AddToBlackList(Module moduleType)
        {
            this.blackList.Add(moduleType);
        }

        #endregion
    }
}
