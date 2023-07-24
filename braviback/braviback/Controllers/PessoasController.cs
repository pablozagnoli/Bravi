using Microsoft.AspNetCore.Mvc;
using Models;
using Repository;

namespace braviback.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoasController : ControllerBase
    {

        private string _connectionString;
        private PessoaRepository _pessoaRepository;

        public PessoasController()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            _pessoaRepository = new PessoaRepository(_connectionString);
        }

        [HttpGet("ObterTodasPessoas")]
        public ActionResult Get()
        {
            var pessoas = _pessoaRepository.ObterTodasPessoas();
            return Ok(pessoas);
        }

        [HttpGet("ObterPessoaPorId/{id}")]
        public ActionResult Get(int id)
        {
            var pessoa = _pessoaRepository.ObterPessoaPorId(id);
            if (pessoa == null)
            {
                return NotFound();
            }
            return Ok(pessoa);
        }

        [HttpPost("InserirPessoa")]
        public ActionResult Post([FromBody] Pessoa pessoa)
        {
            _pessoaRepository.InserirPessoa(pessoa);
            return CreatedAtRoute("DefaultApi", new { id = pessoa.Id }, pessoa);
        }

        [HttpPut("AtualizarPessoa")]
        public ActionResult Put(int id, [FromBody] Pessoa pessoa)
        {
            if (id != pessoa.Id)
            {
                return BadRequest();
            }

            var existingPessoa = _pessoaRepository.ObterPessoaPorId(id);
            if (existingPessoa == null)
            {
                return NotFound();
            }

            _pessoaRepository.AtualizarPessoa(pessoa);
            return Ok();
        }


        [HttpDelete("ExcluirPessoa/{id}")]
        public ActionResult Delete(int id)
        {
            var pessoa = _pessoaRepository.ObterPessoaPorId(id);
            if (pessoa == null)
            {
                return NotFound();
            }

            _pessoaRepository.ExcluirPessoa(id);
            return Ok();
        }

    }
}
