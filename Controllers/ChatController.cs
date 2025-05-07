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
        private readonly ILogger<ChatController> _logger;

        public ChatController(ChatService aiService, ILogger<ChatController> logger)
        {
            _aiService = aiService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> GetAIResponse([FromBody] MyRequestDTO request)
        {
            _logger.LogInformation(request.ToString());
            if (string.IsNullOrEmpty(request.Content))
            {
                _logger.LogWarning("Received empty or null prompt.");
               
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
