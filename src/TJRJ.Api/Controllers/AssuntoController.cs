using Microsoft.AspNetCore.Mvc;
using TJRJ.Application.Interfaces;

namespace TJRJ.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssuntoController : BasicController
    {

        private IAppAssunto _appAssunto;
        private ILogger _logger;

        public AssuntoController(IAppAssunto appAssunto,
                                 ILogger<AssuntoController> logger)
        {
            _appAssunto = appAssunto;
            _logger = logger;
        }

        [HttpGet]
        [Route("ObterAssuntos")]
        public async Task<IActionResult> ObterAssuntos()
        {
            try
            {
                var result = await _appAssunto.ObterAssuntos();
                return RetornoRequest(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"ObterAssuntos => {ex.Message}");
                return BadRequest();
            }
        }

    }
}
