using Api.Errors;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuggyController : BaseApiController
    {

        private readonly StoreContext _context;

        public BuggyController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet("notfoundd")]
        public IActionResult GetNotFoundReq()
        {

            var thing = _context.Products.Find(50);

            if(thing == null)
            {
                return NotFound( new ApiResponse(404));
            }

            return Ok(thing);

        }

        [HttpGet("servererror")]
        public IActionResult GetServerError()
        {

            var thing = _context.Products.Find(50);

            var thingToReturn = thing.ToString();

            return Ok(thingToReturn);

        }

        [HttpGet("badrequestt")]
        public IActionResult GetBadReq() {

            return BadRequest(new ApiResponse(400));
        
        }

        [HttpGet("badrequest/{id}")]
        public IActionResult GetNotFoundRequest(int id)
        {

            return Ok();
        }
    }
}
