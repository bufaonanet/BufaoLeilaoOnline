using Bufao.LeilaoOnline.WebApp.Models;
using Bufao.LeilaoOnline.WebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bufao.LeilaoOnline.WebApp.Controllers;

[ApiController]
[Route("/api/leiloes")]
public class LeilaoApiController : ControllerBase
{
    private readonly IAdminService _service;

    public LeilaoApiController(IAdminService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult EndpointGetLeiloes()
    {
        var leiloes = _service.ConsultaLeiloes();
        return Ok(leiloes);
    }

    [HttpGet("{id}")]
    public IActionResult EndpointGetLeilaoById(int id)
    {
        var leilao = _service.ConsultaLeilaoPorId(id);
        if (leilao == null)
            return NotFound();

        return Ok(leilao);
    }

    [HttpPost]
    public IActionResult EndpointPostLeilao(Leilao leilao)
    {
        _service.CadastraLeilao(leilao);
        return Ok(leilao);
    }

    [HttpPut]
    public IActionResult EndpointPutLeilao(Leilao leilao)
    {
        if (_service.ConsultaLeilaoPorId(leilao.Id) == null)
            return NotFound();

        _service.ModificaLeilao(leilao);

        return Ok(leilao);
    }

    [HttpDelete("{id}")]
    public IActionResult EndpointDeleteLeilao(int id)
    {
        var leilao = _service.ConsultaLeilaoPorId(id);
        if (leilao == null)
            return NotFound();

        _service.RemoveLeilao(leilao);

        return NoContent();
    }

    [HttpPost("{id}/pregao")]
    public IActionResult EndpointIniciaPregao(int id)
    {
        var leilao = _service.ConsultaLeilaoPorId(id);
        if (leilao == null)
            return NotFound();

        _service.IniciaPregaoDoLeilaoComId(id);

        return Ok();
    }

    [HttpDelete("{id}/pregao")]
    public IActionResult EndpointFinalizaPregao(int id)
    {
        var leilao = _service.ConsultaLeilaoPorId(id);
        if (leilao == null)
            return NotFound();

        if (leilao.Situacao != SituacaoLeilao.Pregao)
            return StatusCode(405);

        _service.FinalizaPregaoDoLeilaoComId(id);

        return Ok();
    }
}