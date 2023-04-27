using OpenAI_API;
using OpenAI_API.Chat;

namespace CopperStudios.OpenAI
{

public class ConversationStart
{
    public List<ConversationChat> messages = new List<ConversationChat>();

    public void AddStartChat(ConversationChat chat) => messages.Add(chat);
}

public class ConversationChat
{
    public string message = "";
    public ChatSender sender;

    public ConversationChat(string message, ChatSender sender = ChatSender.User)
    {
        this.message = message;
        this.sender = sender;
    }

    public bool isUserMessage
    {
        get
        {
            if(sender == ChatSender.User)
                return true;
            else
                return false;
        }
    }

    public bool isBotMessage
    {
        get
        {
            if(sender == ChatSender.Bot)
                return true;
            else
                return false;
        }
    }

    public bool isSystemMessage
    {
        get
        {
            if(sender == ChatSender.System)
                return true;
            else
                return false;
        }
    }
}

public enum ChatSender
{
    User,
    Bot,
    System
}

}