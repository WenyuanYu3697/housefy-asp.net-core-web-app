using housefyBackend.Models;
using Microsoft.AspNetCore.Mvc;
using FirebaseAdmin;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Linq;

[ApiController]
[Route("api/environment")]
public class EnvironmentController : ControllerBase
{
    private static readonly Random random = new Random();
    
    private const string FirebaseUrl = "https://housefybackend-environment-default-rtdb.firebaseio.com/";
    private readonly FirebaseClient _client;

    public EnvironmentController()
    {
        _client = new FirebaseClient(FirebaseUrl);
    }

    [HttpGet]
   public async Task<IActionResult> GetEnvironmentData()
   {
    try
    {
        var environmentData = await _client.Child("EnvironmentData")
          .OrderByKey()
          .OnceAsync<EnvironmentData>();

        Console.WriteLine($"Retrieved {environmentData.Count} items");

        return Ok(environmentData.Select(item => item.Object));
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred: {ex}");
        throw;
    }
   }


    private double GetRandomDouble(double min, double max)
    {
        return random.NextDouble() * (max - min) + min;
    }
}
