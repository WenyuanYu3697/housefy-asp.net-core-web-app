using housefyBackend.Models;
using Microsoft.AspNetCore.Mvc;
using FirebaseAdmin;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Linq;
using Microsoft.Extensions.Configuration;

[ApiController]
[Route("api/environment")]
public class EnvironmentController : ControllerBase
{
    private readonly FirebaseClient _client;

    public EnvironmentController(IConfiguration config)
    {
        string firebaseUrl = config["Firebase:Url"] ?? throw new Exception("Firebase:Url is not set in the configuration.");
        _client = new FirebaseClient(firebaseUrl);
    }

    [HttpGet]
public async Task<IActionResult> GetEnvironmentData()
{
    try
    {
        // Fetch the last record from the 'sensor' node
        var lastEnvironmentData = await _client.Child("sensor")
            .OrderByKey()
            .LimitToLast(1)
            .OnceAsync<EnvironmentData>();

        // Since LimitToLast(1) returns a collection of one item, extract that item
        var lastRecord = lastEnvironmentData.FirstOrDefault()?.Object;

        if (lastRecord == null)
        {
            return NotFound("No data available.");
        }

        return Ok(lastRecord);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred: {ex}");
        return StatusCode(500, "Internal Server Error");
    }
}

}
