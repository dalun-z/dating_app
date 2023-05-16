using API.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ServiceFilter(typeof(LogUserActivity))]
    [ApiController]
    [Route("api/[controller]")] // localhost:$port/api/users 
    public class BaseAPIController : ControllerBase
    {
        
    }
}