# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

from botbuilder.core import ActivityHandler, MessageFactory, TurnContext
from botbuilder.schema import ChannelAccount
from botbuilder.schema import Activity, ActivityTypes

class EchoBot(ActivityHandler):
    async def on_members_added_activity(
        self, members_added: [ChannelAccount], turn_context: TurnContext
    ):
        for member in members_added:
            if member.id != turn_context.activity.recipient.id:
                await turn_context.send_activity("Hello and welcome!")

    async def on_message_activity(self, turn_context: TurnContext):
        if turn_context.activity.text == "wait":
            return await turn_context.send_activities([
                Activity(
                    type=ActivityTypes.typing
                ),
                Activity(
                    type="delay",
                    value=3000
                ),
                Activity(
                    type=ActivityTypes.message,
                    text="Finished Typing"
                )
            ])
        else:
            return await turn_context.send_activity(
                f"You said {turn_context.activity.text}.  Say 'wait' to watch me type."
            )
