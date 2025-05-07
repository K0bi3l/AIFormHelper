using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AIFormHelper.Services;
using AIFormHelper.Models;

namespace AIFormHelper.Controllers
{
    [ApiController]
    [Route("/chat")]
    public class ChatController : ControllerBase
    {
        private readonly ChatService _aiService;

        public ChatController(ChatService aiService)
        {
            _aiService = aiService;
        }

        [HttpPost]
        public async Task<IActionResult> GetAIResponse([FromBody] MyRequestDTO request)
        {
            if (string.IsNullOrEmpty(request.Content))
            {
                return BadRequest("Prompt cannot be null or empty.");
            }
            try
            {
                var response = await _aiService.GetAIResponse(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }
    }
}
