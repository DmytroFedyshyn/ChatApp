using Microsoft.EntityFrameworkCore;
using ChatApp.Models;

namespace ChatApp.Data
{
    public class ChatContext : DbContext
    {
        public ChatContext(DbContextOptions<ChatContext> options) : base(options)
        {
        }

        public DbSet<MessageModel> Messages { get; set; }
        public DbSet<ReactionModel> Reactions { get; set; }
        public DbSet<UserModel> Users { get; set; }
    }
}