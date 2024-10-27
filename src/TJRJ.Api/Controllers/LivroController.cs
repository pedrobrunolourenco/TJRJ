using Microsoft.AspNetCore.Mvc;
using TJRJ.Application.Interfaces;
using TJRJ.Application.Model;

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

        [HttpGet]
        [Route("ObterLivrosPorId")]
        public async Task<IActionResult> ObterLivroPorId(int codLivro)
        {
            try
            {
                var livro = await _appLivro.ObterLivroPorId(codLivro);
                return RetornoRequest(livro);
            }
            catch (Exception ex)
            {
                _logger.LogError($"ObterLivroPorId => {ex.Message}");
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("ObterAssuntosDoLivro")]
        public async Task<IActionResult> ObterAssuntosDoLivro(int codLivro)
        {
            try
            {
                var assuntos = await _appLivro.ObterAssuntosDoLivro(codLivro);
                return RetornoRequest(assuntos);
            }
            catch (Exception ex)
            {
                _logger.LogError($"ObterAssuntosDoLivro => {ex.Message}");
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("ObterAutoresDoLivro")]
        public async Task<IActionResult> ObterAutoresDoLivro(int codLivro)
        {
            try
            {
                var autores = await _appLivro.ObterAutoresDoLivro(codLivro);
                return RetornoRequest(autores);
            }
            catch (Exception ex)
            {
                _logger.LogError($"ObterAutoresDoLivro => {ex.Message}");
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

        [HttpPost]
        [Route("IncluirAutor")]
        public async Task<IActionResult> IncluirAutor([FromBody] LivroAutorModel model)
        {
            try
            {
                var livroAutor = await _appLivro.IncluirAutor(model);
                return RetornoRequest(livroAutor, livroAutor.ListaErros);
            }
            catch (Exception ex)
            {
                _logger.LogError($"IncluirAutor => {ex.Message}");
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("IncluirAssunto")]
        public async Task<IActionResult> IncluirAssunto([FromBody] LivroAssuntoModel model)
        {
            try
            {
                var livroAssunto = await _appLivro.IncluirAssunto(model);
                return RetornoRequest(livroAssunto, livroAssunto.ListaErros);
            }
            catch (Exception ex)
            {
                _logger.LogError($"IncluirAssunto => {ex.Message}");
                return BadRequest();
            }
        }


        [HttpPut]
        [Route("AlterarLivro")]
        public async Task<IActionResult> AlterarLivro([FromBody] LivroAlteracaoModel model)
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
