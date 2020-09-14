using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EfCore_Produtos.Domains;
using EfCore_Produtos.Interfaces;
using EfCore_Produtos.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EfCore_Produtos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutosController()
        {
            _produtoRepository = new ProdutoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var produtos = _produtoRepository.Listar();

                if (produtos.Count == 0)
                    return NoContent();

                return Ok(new
                {
                    totalCount = produtos.Count,
                    data = produtos

                });

                return Ok(produtos);
            }
            catch (Exception ex)
            {

                return BadRequest(new {
                 StatusCode = 400,  
                 error = "Ocoorreu um erro no endpoint Get/produtos, envie um e-mail para miniqui10@gmail.com"
                });
            }
        }

        // GET api/<RacaController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                Produto produto = _produtoRepository.BuscarPorId(id);
                if (produto == null)
                    return NotFound();

                return Ok(produto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<RacaController>
        [HttpPost]
        public IActionResult Post(Produto produto)
        {
            try
            {
                _produtoRepository.Adicionar(produto);

                return Ok(produto);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }


        }

        // PUT api/<RacaController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Produto produto)
        {
            try
            {
                _produtoRepository.Editar(produto);

                return Ok(produto);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<RacaController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var produto = _produtoRepository.BuscarPorId(id);

                if (produto == null)
                    return NotFound();

                _produtoRepository.Remover(id);

                return Ok(id);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
