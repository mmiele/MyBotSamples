// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
//
// Generated with Bot Builder V4 SDK Template for Visual Studio EchoBot v4.3.0

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;

namespace HelloWorld.Bots
{
    public class EchoBot : ActivityHandler
    {

        // Called at each interaction by the Bot.
        protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext,
            CancellationToken cancellationToken)
        {
            // Read incoming message.
            string incomingMsg = turnContext.Activity.Text;

            // Create outgoing message.
            string outgoingMsg = $"You said: {turnContext.Activity.Text}";

            // Get user name.
            if (incomingMsg.ToLower().StartsWith("my name is"))
                outgoingMsg = $"Your name is: {incomingMsg.Substring(10, (incomingMsg.Length - 10))}";

            await turnContext.SendActivityAsync(MessageFactory.Text(outgoingMsg), cancellationToken);
        }

        // Called when a new user is detected.
        protected override async Task OnMembersAddedAsync(IList<ChannelAccount> membersAdded,
            ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken)
        {
            foreach (var member in membersAdded)
            {
                if (member.Id != turnContext.Activity.Recipient.Id)
                {
                    await turnContext.SendActivityAsync(MessageFactory.Text($"Hello and Welcome!"), cancellationToken);
                }
            }
        }
    }
}
