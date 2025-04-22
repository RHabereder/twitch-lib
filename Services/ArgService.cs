using Streamer.bot.Plugin.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLith.TwitchLib.Services
{
    public class ArgService
    {
        IInlineInvokeProxy CPH;
        public ArgService(IInlineInvokeProxy _CPH) 
        { 
            this.CPH = _CPH;
        }


        /// <summary>
        ///     Gets the input from the redeemed Command
        /// </summary>
        /// <returns></returns>
        public string GetCommandArgument(Dictionary<string, object> args)
        {
            if (args["rawInputEscaped"] != null)
                return args["rawInputEscaped"].ToString();
            return null;
        }

        /// <summary>
        ///     Streamerbot translates a command into an array and every position is available in the args-Dictionary
        ///     Gets a positional input from the Command
        /// </summary>
        /// <param name="position">Position of the String Token to return</param>
        /// <returns></returns>
        public string GetCommandArgumentAtPosition(Dictionary<string, object> args, int position)
        {
            string key = "input" + position;

            if (args.ContainsKey(key))
            {
                if (args[key] != null)
                    return args["input" + position].ToString();
            }
            else
            {
                CPH.LogError($"Key {key} does not exist!");
            }

            return null;
        }
    }
}
