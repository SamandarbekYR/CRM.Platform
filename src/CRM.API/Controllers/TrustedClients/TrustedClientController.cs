using CRM.BizLogicLayer.Services.TrustedClients;
using CRM.DataAccess.Extensions;
using CRM.DataAccess.Repositories.TrustedClients;
using Microsoft.AspNetCore.Mvc;

namespace CRM.API.Controllers.TrustedClients
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TrustedClientController : ControllerBase
    {
        private readonly ITrustedClientService _service;

        public TrustedClientController(ITrustedClientService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        => Ok(_service.GetAll());

        [HttpPost]
        public async Task<IActionResult> Add(CreateTrustedClientDto dto)
        {
            var res = await _service.Add(dto);

            if (_service.IsValid)
                return Ok(new { result = res });

            _service.CopyErrorsToModelState(ModelState);

            return ValidationProblem(ModelState);
        }
    }
}
