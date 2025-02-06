using ChatApp.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChatApp.Models
{
    public class MessageModel
    {
        public int Id { get; set; }
        public string Sender { get; set; }
        public string Content { get; set; } 
        public DateTime SentAt { get; set; }

        public ICollection<ReactionModel> Reactions { get; set; }

        [NotMapped]
        public int LikesCount => Reactions?.Count(r => r.ReactionType == ReactionType.Like) ?? 0;

        [NotMapped]
        public int DislikesCount => Reactions?.Count(r => r.ReactionType == ReactionType.Dislike) ?? 0;
    }
}
