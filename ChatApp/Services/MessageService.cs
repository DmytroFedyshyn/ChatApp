using ChatApp.Data;
using ChatApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ChatApp.Services
{
    public class MessageService : IMessageService
    {
        private readonly ChatContext _context;

        public MessageService(ChatContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Message>> GetAllMessagesAsync()
        {
            return await _context.Messages
                .Include(m => m.Reactions)
                .ToListAsync();
        }

        public async Task<Message> GetMessageByIdAsync(int id)
        {
            return await _context.Messages
                .Include(m => m.Reactions)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Message> CreateMessageAsync(Message message)
        {
            message.SentAt = DateTime.UtcNow;
            _context.Messages.Add(message);
            await _context.SaveChangesAsync();
            return message;
        }

        public async Task<Message> UpdateMessageAsync(int id, Message updatedMessage)
        {
            var message = await _context.Messages.FindAsync(id);
            if (message == null)
                return null;

            message.Content = updatedMessage.Content;
            await _context.SaveChangesAsync();
            return message;
        }

        public async Task<bool> DeleteMessageAsync(int id)
        {
            var message = await _context.Messages.FindAsync(id);
            if (message == null)
                return false;

            _context.Messages.Remove(message);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Reaction> AddReactionAsync(int messageId, Reaction reaction)
        {
            var message = await _context.Messages.FindAsync(messageId);
            if (message == null)
                return null;

            reaction.MessageId = messageId;
            _context.Reactions.Add(reaction);
            await _context.SaveChangesAsync();
            return reaction;
        }

        public async Task<bool> RemoveReactionAsync(int reactionId)
        {
            var reaction = await _context.Reactions.FindAsync(reactionId);
            if (reaction == null)
                return false;

            _context.Reactions.Remove(reaction);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}