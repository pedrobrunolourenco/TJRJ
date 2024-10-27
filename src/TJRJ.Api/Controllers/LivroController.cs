using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TJRJ.Application.Interfaces;
using TJRJ.Application.Model;
using TJRJ.Application.Services;

namespace TJRJ.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : BasicController
    {
        private IAppLivro _appLivro;
        private ILogger _logger;

        public LivroController(IAppLivro appLivro,
                               ILogger<LivroController> logger)
        {
            _appLivro = appLivro;
            _logger = logger;
        }

        [HttpGet]
        [Route("ObterLivros")]
        public async Task<IActionResult> ObterLivros()
        {
            try
            {
                var livros = await _appLivro.ObterTodosOsLivros();
                return RetornoRequest(livros);
            }
            catch (Exception ex)
            {
                _logger.LogError($"ObterLivros => {ex.Message}");
                return BadRequest();
            }
        }


        [HttpPost]
        [Route("IncluirLivro")]
        public async Task<IActionResult> IncluirLivro([FromBody] LivroModel model)
        {
            try
            {
                var livro = await _appLivro.IncluirLivro(model);
                return RetornoRequest(livro, livro.ListaErros);
            }
            catch (Exception ex)
            {
                _logger.LogError($"IncluirLivro => {ex.Message}");
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("AlterarLivro")]
        public async Task<IActionResult> AlterarLivro([FromBody] LivroModel model)
        {
            try
            {
                var livro = await _appLivro.AlterarLivro(model);
                return RetornoRequest(livro, livro.ListaErros);
            }
            catch (Exception ex)
            {
                _logger.LogError($"AlterarLivro => {ex.Message}");
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("ExcluirLivro")]
        public async Task<IActionResult> AlterarLivro(int codLivro)
        {
            try
            {
                var livro = await _appLivro.ExcluirLivro(codLivro);
                return RetornoRequest(livro, livro.ListaErros);
            }
            catch (Exception ex)
            {
                _logger.LogError($"AlterarLivro => {ex.Message}");
                return BadRequest();
            }
        }


    }
}
