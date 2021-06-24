using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithASP_NET5.Business;
using RestWithASP_NET5.Data.VO;

namespace RestWithASP_NET5.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> _logger;
        private IBookBusiness _BookVOBusiness;

        public BookController(ILogger<BookController> logger, IBookBusiness BookVOBusiness)
        {
            _logger = logger;
            _BookVOBusiness = BookVOBusiness;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_BookVOBusiness.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            BookVO BookVO = _BookVOBusiness.FindById(id);
            if (BookVO == null) return NotFound();
            return Ok(BookVO);
        }

        [HttpPost]
        public IActionResult Post([FromBody] BookVO BookVO)
        {
            if (BookVO == null) return BadRequest();
            return Ok(_BookVOBusiness.Create(BookVO));
        }

        [HttpPut]
        public IActionResult Put([FromBody] BookVO BookVO)
        {
            if (BookVO == null) return BadRequest();
            return Ok(_BookVOBusiness.Update(BookVO));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _BookVOBusiness.Delete(id);
            return NoContent();
        }
    }
}
