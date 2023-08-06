using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/ac-fan")]
public class ACFanController : ControllerBase
{
    [HttpGet]
    public ActionResult<bool> GetStatus()
    {
        return DeviceStatus.ACFanIsOn;
    }

    [HttpPost]
    public void PostStatus([FromBody] bool status)
    {
        DeviceStatus.ACFanIsOn = status;
    }
}
