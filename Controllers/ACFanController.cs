using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/ac-fan")]
public class ACFanController : ControllerBase
{
    [HttpGet]
    public ActionResult<DeviceStatus.ACFanStatus> GetStatus()
    {
        return DeviceStatus.Fan;
    }

    [HttpPost]
    public void PostStatus([FromBody] DeviceStatus.ACFanStatus fanStatus)
    {
        DeviceStatus.Fan.IsOn = fanStatus.IsOn;
        DeviceStatus.Fan.Speed = fanStatus.Speed;
    }
}
