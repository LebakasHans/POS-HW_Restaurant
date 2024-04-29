using Microsoft.AspNetCore.Mvc;

namespace Restaurant.Controllers;

[ApiController]
[Route]
public class WaiterController(RestaurantsContext db) : ControllerBase
{
    public List<WaiterDto> GetAllWaiters()
    {
        return View();
    }
}
