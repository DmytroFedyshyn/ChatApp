using ChatApp.Models;

namespace ChatApp.Services.Interfaces
{
    public interface IMessageService
    {
        Task<IEnumerable<MessageModel>> GetAllMessagesAsync();
        Task<MessageModel> GetMessageByIdAsync(int id);
        Task<MessageModel> CreateMessageAsync(MessageModel message);
        Task<MessageModel> UpdateMessageAsync(int id, MessageModel message);
        Task<bool> DeleteMessageAsync(int id);
        Task<ReactionModel> AddReactionAsync(int messageId, ReactionModel reaction);
        Task<bool> RemoveReactionAsync(int reactionId);
    }
}
