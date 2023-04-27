using OpenAI_API;
using OpenAI_API.Chat;

namespace CopperStudios.OpenAI
{

public class ConversationBot
{
    public async void Test(OpenAIAPI api)
    {
        Conversation chat = api.Chat.CreateConversation();


        ConversationStart start = new ConversationStart();
    
        // instruction
        start.AddStartChat(new ConversationChat("You are a teacher who helps children understand if things are animals or not.  If the user tells you an animal, you say \"yes\".  If the user tells you something that is not an animal, you say \"no\".  You only ever respond with \"yes\" or \"no\".  You do not say anything else.", ChatSender.System));

        // premessages
        start.AddStartChat(new ConversationChat("Is this an animal? Cat", ChatSender.User));
        start.AddStartChat(new ConversationChat("Yes", ChatSender.Bot));
        start.AddStartChat(new ConversationChat("Is this an animal? House", ChatSender.User));
        start.AddStartChat(new ConversationChat("No", ChatSender.Bot));

        ConversationTools.SendPreConversation(chat, start);



        // now let's ask it a question'
        chat.AppendUserInput("Is this an animal? Dog");
        // and get the response
        string response = await chat.GetResponseFromChatbot();
        Console.WriteLine(response); // "Yes"

        // and continue the conversation by asking another
        chat.AppendUserInput("Is this an animal? Chair");
        // and get another response
        response = await chat.GetResponseFromChatbot();
        Console.WriteLine(response); // "No"




        // the entire chat history is available in chat.Messages
        foreach (ChatMessage msg in chat.Messages)
        {
            Console.WriteLine($"{msg.Role}: {msg.Content}");
        }
    }
}

}