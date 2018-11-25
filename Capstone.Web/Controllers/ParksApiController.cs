using Capstone.Web.DAL;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Web.Controllers
{
    [Route("api")]
    [ApiController]
    public class ParksApiController : ControllerBase
    {
        private readonly IParksDAL _parksDal;

        public ParksApiController(IParksDAL parksDal)
        {
            _parksDal = parksDal;
        }

        [Route("getparks")]
        public IActionResult GetParks()
        {
            var parks = _parksDal.GetParks();

            if (parks == null) { return NotFound(); }

            return Ok(parks);
        }
    }
}