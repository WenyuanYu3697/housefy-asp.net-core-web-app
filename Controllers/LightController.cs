using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/light")]
public class LightController : ControllerBase
{
    [HttpGet]
    public ActionResult<bool> GetStatus()
    {
        return DeviceStatus.LightIsOn;
    }

    [HttpPost]
    public void PostStatus([FromBody] bool status)
    {
        DeviceStatus.LightIsOn = status;
    }
}
