using Microsoft.AspNetCore.Mvc;
using TJRJ.Application.Interfaces;
using TJRJ.Application.Model;

namespace TJRJ.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : BasicController
    {

        private IAppAutor _appAutor;
        private ILogger _logger;

        public AutorController(IAppAutor appAutor,
                               ILogger<AutorController> logger)
        {
            _appAutor = appAutor;
            _logger = logger;
        }

        [HttpGet]
        [Route("ObterAutores")]
        public async Task<IActionResult> ObterAutores()
        {
            try
            {
                var result = await _appAutor.ObterAutores();
                return RetornoRequest(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"ObterAutores => {ex.Message}");
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("ObterAutorPorId")]
        public async Task<IActionResult> ObterAutorPorId(int id)
        {
            try
            {
                var result = await _appAutor.ObterAutorPorId(id);
                return RetornoRequest(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"ObterAutorPorId => {ex.Message}");
                return BadRequest();
            }
        }


        [HttpPost]
        [Route("IncluirAutor")]
        public async Task<IActionResult> IncluirAutor([FromBody] AutorModel model)
        {
            try
            {
                var autor = await _appAutor.IncluirAutor(model);
                return RetornoRequest(autor, autor.ListaErros);
            }
            catch (Exception ex)
            {
                _logger.LogError($"IncluirAutor => {ex.Message}");
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("AlterarAutor")]
        public async Task<IActionResult> AlterarAutor([FromBody] AutorModel model)
        {
            try
            {
                var autor = await _appAutor.AlterarAutor(model);
                return RetornoRequest(autor, autor.ListaErros);
            }
            catch (Exception ex)
            {
                _logger.LogError($"AlterarAutor => {ex.Message}");
                return BadRequest();
            }
        }


        [HttpDelete]
        [Route("ExcluirAutor")]
        public async Task<IActionResult> ExcluirAutor(int codAu)
        {
            try
            {
                var autor = await _appAutor.ExcluirAutor(codAu);
                return RetornoRequest(autor, autor.ListaErros);
            }
            catch (Exception ex)
            {
                _logger.LogError($"ExcluirAutor => {ex.Message}");
                return BadRequest();
            }
        }



    }
}
