using Microsoft.AspNetCore.Mvc;

namespace Example.Controllers
{
  [Route("Products")]

  public class ProductsController : ControllerBase 
  {
    [Route("Merhaba")]

    public String Merhaba()
    {
      return "Merhaba";

    }
    [Route("Hello")]
    public String Hello()
    {
      return "Hello";

    }
  }
}
