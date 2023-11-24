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
            var environmentData = await _client.Child("sensor_data")
                .OrderByKey()
                .OnceAsync<EnvironmentData>();

            return Ok(environmentData.Select(item => item.Object));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex}");
            throw;
        }
    }
}
