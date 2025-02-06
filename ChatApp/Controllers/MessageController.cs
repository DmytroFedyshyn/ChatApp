using ChatApp.Models;
using ChatApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ChatApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        // GET: api/message
        [HttpGet]
        public async Task<IActionResult> GetMessages()
        {
            var messages = await _messageService.GetAllMessagesAsync();
            return Ok(messages);
        }

        // GET: api/message/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMessage(int id)
        {
            var message = await _messageService.GetMessageByIdAsync(id);
            if (message == null)
                return NotFound();
            return Ok(message);
        }

        // POST: api/message
        [HttpPost]
        public async Task<IActionResult> CreateMessage([FromBody] Message message)
        {
            var created = await _messageService.CreateMessageAsync(message);
            return CreatedAtAction(nameof(GetMessage), new { id = created.Id }, created);
        }

        // PUT: api/message/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMessage(int id, [FromBody] Message message)
        {
            var updated = await _messageService.UpdateMessageAsync(id, message);
            if (updated == null)
                return NotFound();
            return Ok(updated);
        }

        // DELETE: api/message/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMessage(int id)
        {
            var success = await _messageService.DeleteMessageAsync(id);
            if (!success)
                return NotFound();
            return NoContent();
        }

        // POST: api/message/{id}/reaction
        [HttpPost("{id}/reaction")]
        public async Task<IActionResult> AddReaction(int id, [FromBody] Reaction reaction)
        {
            var added = await _messageService.AddReactionAsync(id, reaction);
            if (added == null)
                return NotFound("Message not found");
            return Ok(added);
        }

        // DELETE: api/message/reaction/{reactionId}
        [HttpDelete("reaction/{reactionId}")]
        public async Task<IActionResult> DeleteReaction(int reactionId)
        {
            var success = await _messageService.RemoveReactionAsync(reactionId);
            if (!success)
                return NotFound();
            return NoContent();
        }
    }
}