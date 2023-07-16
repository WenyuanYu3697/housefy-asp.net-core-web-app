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
        if (feedback.User != null)
        {
            // Find the user by email
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == feedback.User.Email);

            if (user != null)
            {
                // Update the user details
                user.FullName = feedback.User.FullName;
                user.PhoneModel = feedback.User.PhoneModel;
                user.PhoneNumber = feedback.User.PhoneNumber;
                _context.Entry(user).State = EntityState.Modified; // Set the user state to Modified
            }
            else
            {
                // If user doesn't exist, create a new one
                user = feedback.User;
                _context.Users.Add(user);
            }

            await _context.SaveChangesAsync();

            feedback.User = user;
            feedback.UserId = user.UserId;

            _context.Feedbacks.Add(feedback);
            await _context.SaveChangesAsync();

            return Ok();
        }
        else
        {
            return BadRequest("User cannot be null.");
        }
    }
}
