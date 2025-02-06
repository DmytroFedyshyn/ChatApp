using ChatApp.Enums;

namespace ChatApp.Models
{
    public class Reaction
    {
        public int Id { get; set; }
        public int MessageId { get; set; }
        public string User { get; set; }
        public ReactionType ReactionType { get; set; }

        public Message Message { get; set; }
    }
}
