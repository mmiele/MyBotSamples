// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

const { ActivityHandler } = require('botbuilder');
const { ActivityTypes } = require('botbuilder-core');

class EchoBot extends ActivityHandler {
    constructor() {
        super();
        // See https://aka.ms/about-bot-activity-message to learn more about the message and other activity types.
        this.onMessage(async (context, next) => {
            if (context.activity.text === 'wait') {
                await context.sendActivities([
                    { type: ActivityTypes.Typing },
                    { type: 'delay', value: 3000 },
                    { type: ActivityTypes.Message, text: 'Finished typing' }
                ]);
            } else {
                await context.sendActivity(`You said '${ context.activity.text }'. Say "wait" to watch me type.`);
            }
            await next();
        });
        this.onMembersAdded(async (context, next) => {
            const membersAdded = context.activity.membersAdded;
            for (let cnt = 0; cnt < membersAdded.length; ++cnt) {
                if (membersAdded[cnt].id !== context.activity.recipient.id) {
                    await context.sendActivity('Hello and welcome!');
                }
            }
            // By calling next() you ensure that the next BotHandler is run.
            await next();
        });
    }
}

module.exports.EchoBot = EchoBot;
