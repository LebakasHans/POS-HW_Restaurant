namespace Restaurant.Controllers;

public record struct OkStatus(bool IsOk, int Nr, string? Error = null);

[Route("[controller]")]
[ApiController]
public class ValuesController(RestaurantsContext db) : ControllerBase
{	
  
  [HttpGet("Categories")]
  public OkStatus GetCategories()
  {
    this.Log();
    try
    {
  	  int nr = db.Categories.Count();
  	  return new OkStatus(true, nr);
    }
    catch (Exception exc)
    {
  	  return new OkStatus(false, -1, exc.Message);
    }
  }
}
