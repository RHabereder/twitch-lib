using Streamer.bot.Plugin.Interface;
using System;

namespace NLith.TwitchLib.Services
{
    public class VarService
    {
        IInlineInvokeProxy CPH;
        public VarService(IInlineInvokeProxy _CPH) 
        { 
            this.CPH = _CPH;
        }
       

        /// <summary>
        ///     Abstraction for GetGlobalVar for better persistence-control. 
        ///     Presets persistence from Settings
        /// </summary>
        /// <typeparam name="T">Can be anything that is serializable</typeparam>
        /// <param name="name">Name of the value to pull from the Globals</param>
        /// <returns>Deserialized Global-Scope Variable</returns>
        public T GetGlobalVariable<T>(string name, bool isGamePersistent = false)
        {
            return CPH.GetGlobalVar<T>(name, isGamePersistent);
        }

        /// <summary>
        ///     Abstraction for SetGlobalVar for better persistence-control. 
        ///     Presets persistence from Settings
        /// </summary>
        /// <typeparam name="T">Can be anything that is serializable</typeparam>
        /// <param name="name">Name of the Global-Var to set</param>
        /// <param name="value">New Value of the Global-Var</param>
        public void SetGlobalVariable<T>(string name, T value, bool isGamePersistent = false)
        {
            CPH.SetGlobalVar(name, value, isGamePersistent);
        }

        /// <summary>
        ///     Unsets a global Var
        /// </summary>
        /// <param name="varName">Name of the variable to unset</param>
        public void UnsetGlobalVariable(string varName, bool isGamePersistent = false)
        {
            CPH.UnsetGlobalVar(varName, isGamePersistent);
        }

        /// <summary>
        ///     Abstraction for GetUserVar for better persistence-control. Presets persistence from Settings
        /// </summary>
        /// <typeparam name="T">Can be anything that is serializable</typeparam>
        /// <param name="username">Name of the user to load the var from</param>
        /// <param name="varname">Name of the var to load</param>
        /// <param name="isPersistent">Flag to decide if the value should be persistent (Default true)</param>
        /// <returns>Deserialized User-Scope Variable</returns>
        public T GetUserVariable<T>(string username, string varname, bool isPersistent = true)
        {
            return CPH.GetTwitchUserVar<T>(username, varname, isPersistent);
        }

        /// <summary>
        ///     Abstraction for SetUserVar for better persistence-control. 
        ///     Presets persistence from Settings
        /// </summary>
        /// <typeparam name="T">Can be anything that is serializable</typeparam>
        /// <param name="username">Name of the User to set the var for</param>
        /// <param name="varname">Name of the var to set the value for</param>
        /// <param name="value">New value to be set</param>
        /// <param name="isPersistent">Flag to decide if the value should be persistent (Default true)</param>
        public void SetUserVariable<T>(string username, string varname, T value, bool isPersistent = true)
        {
            CPH.SetTwitchUserVar(username, varname, value, isPersistent);
        }

    }
}
