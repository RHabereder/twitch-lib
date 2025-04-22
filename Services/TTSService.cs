using NLith.TwitchLib.Models;
using Streamer.bot.Plugin.Interface;

namespace NLith.TwitchLib.Services
{
    public class TTSService
    {

        IInlineInvokeProxy CPH;
        public TTSService(IInlineInvokeProxy _CPH)
        {
            CPH = _CPH;
        }


        /// <summary>
        ///     Convenience Function to trigger the Speaker.bot TTS
        /// </summary>
        /// <param name="voiceID">Voice-ID to use in the TTS</param>
        /// <param name="announcement">Announcement Text</param>
        /// <param name="isPaidAnnouncement">Boolean flag to mark an announcement as paid</param>
        /// <param name="playername">Nullable Name of a play that needs to be referenced, in case of a refund</param>
        /// <param name="runThroughProfanityFilter">Optional Parameter to disable the Profanity-Filter</param>
        public void CallTTS(string voiceID, string announcement, bool runThroughProfanityFilter = true)
        {
            CPH.TtsSpeak(voiceID, announcement, runThroughProfanityFilter);                    
        }

        /// <summary>
        ///     Convenience Function to trigger the Speaker.bot TTS
        /// </summary>
        /// <param name="voiceID">Voice-ID to use in the TTS</param>
        /// <param name="announcement">Announcement Text</param>
        /// <param name="isPaidAnnouncement">Boolean flag to mark an announcement as paid</param>
        /// <param name="playername">Nullable Name of a play that needs to be referenced, in case of a refund</param>
        /// <param name="runThroughProfanityFilter">Optional Parameter to disable the Profanity-Filter</param>
        public void CallTTSAndWait(string voiceID, string announcement, bool runThroughProfanityFilter = true)
        {
            CPH.LogDebug($"Calling TTS with voiceID {voiceID} and runThroughProfanityFilter {runThroughProfanityFilter}");
            CPH.TtsSpeak(voiceID, announcement);
            // The average reader can read about 238 Words per Minute, which means about 4 words per second.
            // We used a very slow narrator, so we can assume about 2 words per second.
            // Since the TTS Function is non-blocking and just keeps running, we need to calculate how long we need to wait
            // This is a rough estimate, but should be good enough for most cases
            int wordCount = announcement.Split(' ').Length;
            int waitTime = (int)((wordCount / 2) * 1000); // in ms
            CPH.LogDebug($"Waiting {waitTime}ms for TTS to finish, based on {wordCount} words in the announcement '{announcement}'");
            //CPH.Wait(1000); // Wait 1 additional second to make sure the TTS is finished
            CPH.Wait(waitTime);
        }
    }
}
