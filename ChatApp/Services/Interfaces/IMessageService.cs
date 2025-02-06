using ChatApp.Models;

namespace ChatApp.Services.Interfaces
{
    public interface IMessageService
    {
        Task<IEnumerable<Message>> GetAllMessagesAsync();
        Task<Message> GetMessageByIdAsync(int id);
        Task<Message> CreateMessageAsync(Message message);
        Task<Message> UpdateMessageAsync(int id, Message message);
        Task<bool> DeleteMessageAsync(int id);
        Task<Reaction> AddReactionAsync(int messageId, Reaction reaction);
        Task<bool> RemoveReactionAsync(int reactionId);
    }
}
