using housefyBackend.Models;  // Import the namespace of the Feedback class
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Microsoft.AspNetCore.Components.Route("api/feedback")]
public class FeedbackController : ControllerBase
{
    [HttpPost]
    public IActionResult CreateFeedback([FromBody] Feedback feedback)
    {
        // Access the properties of the feedback object
        string fullName = feedback.FullName;
        string phoneNumber = feedback.PhoneNumber;
        string email = feedback.Email;
        int rate = feedback.Rate;
        string comment = feedback.Comment;

        return Ok();
    }
}
