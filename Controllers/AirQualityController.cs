using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/air-quality-fan")]
public class AirQualityFanController : ControllerBase
{
    [HttpGet]
    public ActionResult<bool> GetStatus()
    {
        return DeviceStatus.AirQualityFanIsOn;
    }

    [HttpPost]
    public void PostStatus([FromBody] bool status)
    {
        DeviceStatus.AirQualityFanIsOn = status;
    }
}
