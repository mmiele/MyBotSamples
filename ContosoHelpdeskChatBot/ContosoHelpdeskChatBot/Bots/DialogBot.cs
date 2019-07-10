// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
//
// Generated with Bot Builder V4 SDK Template for Visual Studio EchoBot v4.3.0

using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Schema;
using System.Threading;
using System.Threading.Tasks; 

namespace ContosoHelpdeskChatBot.Bots
{
    public class DialogBot<T> : ActivityHandler where T : Dialog 
    {
        protected readonly Dialog _dialog;
        protected readonly BotState _conversationState;

        public DialogBot(ConversationState conversationState, T dialog)
        {
            _conversationState = conversationState;
            _dialog = dialog;
        }

        public override async Task OnTurnAsync(ITurnContext turnContext, CancellationToken cancellationToken)
        {
            await base.OnTurnAsync(turnContext, cancellationToken);

            // Save any state changes that might have occured during the turn.
            await _conversationState.SaveChangesAsync(turnContext, false, cancellationToken);
        }

        protected override async Task OnMessageActivityAsync(
            ITurnContext<IMessageActivity> turnContext,
            CancellationToken cancellationToken)
        {
            // Run the Dialog with the new message Activity.
            await _dialog.Run(
                turnContext,
                _conversationState.CreateProperty<DialogState>("DialogState"),
                cancellationToken);
        }
    }
}
