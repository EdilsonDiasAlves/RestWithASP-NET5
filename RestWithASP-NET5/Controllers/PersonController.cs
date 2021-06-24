using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithASP_NET5.Business;
using RestWithASP_NET5.Data.VO;

namespace RestWithASP_NET5.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private IPersonBusiness _PersonBusiness;

        public PersonController(ILogger<PersonController> logger, IPersonBusiness personBusiness)
        {
            _logger = logger;
            _PersonBusiness = personBusiness;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_PersonBusiness.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            PersonVO PersonVO = _PersonBusiness.FindById(id);
            if (PersonVO == null) return NotFound();
            return Ok(PersonVO);
        }

        [HttpPost]
        public IActionResult Post([FromBody] PersonVO PersonVO)
        {
            if (PersonVO == null) return BadRequest();
            return Ok(_PersonBusiness.Create(PersonVO));
        }

        [HttpPut]
        public IActionResult Put([FromBody] PersonVO PersonVO)
        {
            if (PersonVO == null) return BadRequest();
            return Ok(_PersonBusiness.Update(PersonVO));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _PersonBusiness.Delete(id);
            return NoContent();
        }

        private bool IsNumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(
                strNumber, 
                System.Globalization.NumberStyles.Any, 
                System.Globalization.NumberFormatInfo.InvariantInfo, 
                out number);
            return isNumber;
        }

        private decimal ConvertToDecimal(string strValue)
        {
            decimal decimalValue;
            if (decimal.TryParse(strValue, out decimalValue))
            {
                return decimalValue;
            }
            return 0;
        }
    }
}
