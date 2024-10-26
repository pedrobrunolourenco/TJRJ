using Microsoft.AspNetCore.Mvc;
using TJRJ.Application.Interfaces;
using TJRJ.Application.Model;

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

        [HttpGet]
        [Route("ObterAssuntoPorId")]
        public async Task<IActionResult> ObterAssuntoPorId(int id)
        {
            try
            {
                var result = await _appAssunto.ObterAssuntoPorId(id);
                return RetornoRequest(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"ObterAssuntoPorId => {ex.Message}");
                return BadRequest();
            }
        }


        [HttpPost]
        [Route("IncluirAssunto")]
        public async Task<IActionResult> IncluirAssunto([FromBody] AssuntoModel model)
        {
            try
            {
                var assunto = await _appAssunto.IncluirAssunto(model);
                return RetornoRequest(assunto, assunto.ListaErros);
            }
            catch (Exception ex)
            {
                _logger.LogError($"IncluirAssunto => {ex.Message}");
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("AlterarAssunto")]
        public async Task<IActionResult> AlterarAssunto([FromBody] AssuntoModel model)
        {
            try
            {
                var assunto = await _appAssunto.AlterarAssunto(model);
                return RetornoRequest(assunto, assunto.ListaErros);
            }
            catch (Exception ex)
            {
                _logger.LogError($"AlterarAssunto => {ex.Message}");
                return BadRequest();
            }
        }


        [HttpDelete]
        [Route("ExcluirAssunto")]
        public async Task<IActionResult> ExcluirAssunto(int codAs)
        {
            try
            {
                var assunto = await _appAssunto.ExcluirAssunto(codAs);
                return RetornoRequest(assunto, assunto.ListaErros);
            }
            catch (Exception ex)
            {
                _logger.LogError($"ExcluirAssunto => {ex.Message}");
                return BadRequest();
            }
        }



    }
}
