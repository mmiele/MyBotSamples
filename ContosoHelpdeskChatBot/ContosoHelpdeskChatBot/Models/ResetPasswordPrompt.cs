using Bot.Builder.Community.Dialogs.FormFlow;
using System;

namespace ContosoHelpdeskChatBot.Models
{
    [Serializable]
    public class ResetPasswordPrompt
    {
        [Prompt("Please provide four digit pass code")]
        public int PassCode { get; set; }
    }
}