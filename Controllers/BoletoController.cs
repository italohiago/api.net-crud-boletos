using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using boletos_banco.Data;
using boletos_banco.Data.Models;
using System;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Annotations;

namespace boletos_banco.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoletoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BoletoController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cria um novo boleto")]
        [SwaggerResponse(StatusCodes.Status201Created, "Boleto criado com sucesso")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Requisição inválida")]
        public async Task<IActionResult> CreateBoleto([FromBody] Boleto boleto)
        {
            if (boleto == null)
            {
                return BadRequest("Requisição inválida. Verifique os dados do boleto.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                boleto.DataVencimento = boleto.DataVencimento.ToUniversalTime();
                _context.Boletos.Add(boleto);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetBoleto), new { id = boleto.Id }, boleto);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao criar o boleto: " + ex.Message);
            }
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obter detalhes do boleto pelo ID")]
        [SwaggerResponse(StatusCodes.Status200OK, "Detalhes do boleto retornado com sucesso")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Boleto não encontrado")]
        public async Task<ActionResult<Boleto>> GetBoleto(int id)
        {
            var boleto = await _context.Boletos.FindAsync(id);
            if (boleto == null)
            {
                return NotFound();
            }

            // Verifica se a data de vencimento já passou
            if (boleto.DataVencimento < DateTime.Now)
            {
                // Buscar o banco associado ao boleto
                var banco = await _context.Bancos.FindAsync(boleto.BancoId);
                if (banco != null)
                {
                    // Aplicar a taxa de juros ao valor do boleto
                    boleto.Valor += boleto.Valor * (banco.PercentualJuros / 100);
                }
            }

            return boleto;
        }

    }
}
