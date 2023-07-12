using housefyBackend.Data;
using housefyBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

[ApiController]
[Route("api/feedback")]
public class FeedbackController : ControllerBase
{
    private readonly housefyBackendDbContext _context;

    public FeedbackController(housefyBackendDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> CreateFeedback([FromBody] Feedback feedback)
    {
        if(feedback.User != null && feedback.User.UserId != 0) {
            var user = await _context.Users.FindAsync(feedback.User.UserId);
            if(user != null) {
                user.FullName = feedback.User.FullName;
                user.Email = feedback.User.Email;
                user.PhoneModel = feedback.User.PhoneModel;
            } else {
                _context.Users.Add(feedback.User);
            }
        } else {
            _context.Users.Add(feedback.User);
        }

        _context.Feedbacks.Add(feedback);
        await _context.SaveChangesAsync();

        return Ok();
    }
}
