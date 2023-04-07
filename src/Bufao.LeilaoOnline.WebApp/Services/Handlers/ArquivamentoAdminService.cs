using Bufao.LeilaoOnline.WebApp.Dados;
using Bufao.LeilaoOnline.WebApp.Models;

namespace Bufao.LeilaoOnline.WebApp.Services.Handlers;

public class ArquivamentoAdminService : IAdminService
{
    private readonly IAdminService _dafaultService;

    public ArquivamentoAdminService(ILeilaoDao leilaoDao, ICategoriaDao categoriaDao)
    {
        _dafaultService = new DefaultAdminService(leilaoDao, categoriaDao);
    }

    public void CadastraLeilao(Leilao leilao)
    {
        _dafaultService.CadastraLeilao(leilao);
    }

    public IEnumerable<Categoria> ConsultaCategorias()
    {
        return _dafaultService.ConsultaCategorias();
    }

    public Leilao ConsultaLeilaoPorId(int id)
    {
        return _dafaultService.ConsultaLeilaoPorId(id);
    }

    public IEnumerable<Leilao> ConsultaLeiloes()
    {
        return _dafaultService
            .ConsultaLeiloes()
            .Where(l => l.Situacao != SituacaoLeilao.Arquivado);
    }

    public void FinalizaPregaoDoLeilaoComId(int id)
    {
        _dafaultService.FinalizaPregaoDoLeilaoComId(id);
    }

    public void IniciaPregaoDoLeilaoComId(int id)
    {
        _dafaultService.IniciaPregaoDoLeilaoComId(id);
    }

    public void ModificaLeilao(Leilao leilao)
    {
        _dafaultService.ModificaLeilao(leilao);
    }

    public void RemoveLeilao(Leilao leilao)
    {
        if (leilao != null && leilao.Situacao != SituacaoLeilao.Pregao)
        {
            leilao.Situacao = SituacaoLeilao.Arquivado;
            _dafaultService.ModificaLeilao(leilao);
        }
    }
}