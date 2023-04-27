using OpenAI_API;
using OpenAI_API.Chat;

namespace CopperStudios.OpenAI
{

public static class ConversationTools
{
    public static void SendPreConversation(Conversation chat, ConversationStart start)
    {
        foreach (var item in start.messages)
        {
            if(item.isUserMessage)
                chat.AppendUserInput(item.message);

            if(item.isSystemMessage)
                chat.AppendSystemMessage(item.message);

            if(item.isBotMessage)
                chat.AppendExampleChatbotOutput(item.message);


        }
    }

}

}