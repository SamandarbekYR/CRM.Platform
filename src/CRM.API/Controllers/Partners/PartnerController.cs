using CRM.API.Attribute;
using CRM.BizLogicLayer.Services.Partners;
using CRM.DataAccess.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace CRM.API.Controllers.Partners
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PartnerController : ControllerBase
    {
        private readonly IPartnerService _servicePartner;

        public PartnerController(IPartnerService servicePartner)
        {
            _servicePartner = servicePartner;
        }
        [HttpPost]
        [ValidateApiKeyUsage]
        public async Task<ActionResult> CreatePartner([FromBody] AddPartner createPartnerDto)
        {
            var res = await _servicePartner.Add(createPartnerDto);
            if (_servicePartner.IsValid)
                return Ok(new { result = res });

            _servicePartner.CopyErrorsToModelState(ModelState);

            return ValidationProblem(ModelState);
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var res =  _servicePartner.GetAll();
            if (_servicePartner.IsValid)
                return Ok(new { result = res });
            _servicePartner.CopyErrorsToModelState(ModelState);
            return ValidationProblem(ModelState);
        }
    }
}
