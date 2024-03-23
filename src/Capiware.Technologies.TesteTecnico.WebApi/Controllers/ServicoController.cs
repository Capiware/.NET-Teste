using Capiware.Technologies.TesteTecnico.WebApi.Data;
using Capiware.Technologies.TesteTecnico.WebApi.Domain;
using Capiware.Technologies.TesteTecnico.WebApi.ViewModel;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System;
using System.Drawing;


namespace Capiware.Technologies.TesteTecnico.WebApi.Controllers
{
    [ApiController]
    [Route("servicos")]
    public class ServicoController : ControllerBase
    {


        //POST - Criar servico OK
        [HttpPost("criar")]
        public async Task<IActionResult> CriarServico(
            [FromServices] AppDbContext context,
            [FromBody] ServicoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var servico = new Servico
            {
                Id = Guid.NewGuid(),
                Nome = model.Nome,
                Status = model.Status,
                Valor = model.Valor,
                Data = model.Data

            };

            try
            {
                await context.Servicos.AddAsync(servico);
                await context.SaveChangesAsync();
                return Ok(servico.Id);
            }
            catch (Exception ex)
            {
                return BadRequest("Falha ao cadastrar");
            }

        }


        //POST - Finalizar servico OK
        //obs: mudei para PUT pois assim o cliente da api não precisará alterar pelo body

        [HttpPut("finalizar/{id}")]
        public async Task<IActionResult> FinalizarServico(
            [FromServices] AppDbContext context,
            [FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var servico = await context.Servicos.FirstOrDefaultAsync(x => x.Id == id);

            if (servico == null)
            {
                return BadRequest($"Servico não existe!");
            }

            if (servico.Status.Equals(StatusEnum.Finalizado))
            {
                return Ok("Ja esta finalizado");
            }

            servico.Status = StatusEnum.Finalizado;
            await context.SaveChangesAsync();

            return Ok("Finalizado com sucesso!");
        }


        //PUT - Atualizar informacoes de servico OK
        [HttpPut("atualizar/{id}")]
        public async Task<IActionResult> AtualizarServicoAsync(
            [FromServices] AppDbContext context,
            [FromBody] ServicoViewModel model,
            [FromRoute] Guid id)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var servico = await context.Servicos.FirstOrDefaultAsync(x => x.Id == id);

            try
            {
                servico.Nome = model.Nome;
                servico.Status = model.Status;
                servico.Valor = model.Valor;
                servico.Data = model.Data;

                context.Servicos.Update(servico);
                await context.SaveChangesAsync();

                return Ok(servico);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


        //GET - Listar servicos nao concluídos OK
        [HttpGet("naoConcluidos")]
        public async Task<IActionResult> GetAllServicos([FromServices] AppDbContext context)
        {
            var servicos = context.Servicos.Where(x => !x.Status.Equals(StatusEnum.Finalizado)).ToList();

            return Ok(servicos);
        }


        //GET - Consultar servico OK
        [HttpGet("{id}")]
        public async Task<IActionResult> GetServicosById([FromServices] AppDbContext context, [FromRoute] Guid id)
        {
            var servico = context.Servicos.Where(x => x.Id == id);

            if (servico == null)
            {
                return NotFound();
            }

            return Ok(servico);

        }


        //GET - Resumo do dia OK
        [HttpGet("resumo/{data}")]
        public async Task<IActionResult> GetServicosByDate(
            [FromServices] AppDbContext context,
            [FromRoute] DateTime data)
        {
            var servicos = context.Servicos.Where(x => x.Data.Day == data.Day).ToList();

            Decimal count = 0;

            foreach (var servico in servicos)
            {
                count += servico.Valor;
            }

            if (servicos == null)
            {
                return NotFound();
            }


            return Ok($"Quantidade de servicos no dia: {servicos.Count} , Total arrecadado: {count}");

        }



        //DELETE - Excluir Servico OK
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteServico(
            [FromServices] AppDbContext context,
            [FromRoute] Guid id)
        {
            var servico = await context.Servicos.FirstOrDefaultAsync(x => x.Id == id);

            try
            {
                context.Servicos.Remove(servico);
                await context.SaveChangesAsync();
                return Ok("Excluido");
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

    }
}