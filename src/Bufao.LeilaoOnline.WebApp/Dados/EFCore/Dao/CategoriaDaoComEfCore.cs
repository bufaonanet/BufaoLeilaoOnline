using Bufao.LeilaoOnline.WebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace Bufao.LeilaoOnline.WebApp.Dados.EFCore.Dao;

public class CategoriaDaoComEfCore : ICategoriaDao
{
    private readonly AppDbContext _context;

    public CategoriaDaoComEfCore(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Categoria> BuscarTodos()
    {
        return _context.Categorias
            .Include(c => c.Leiloes)
            .ToList();
    }

    public Categoria BuscarPorId(int id)
    {
        return _context.Categorias
                .Include(c => c.Leiloes)
                .First(c => c.Id == id);
    }

    public IEnumerable<CategoriaComInfoLeilao> BuscarTodasCategoriasComLeiloes()
    {
        return _context.Categorias
                .Include(c => c.Leiloes)
                .Select(c => new CategoriaComInfoLeilao
                {
                    Id = c.Id,
                    Descricao = c.Descricao,
                    Imagem = c.Imagem,
                    EmRascunho = c.Leiloes.Where(l => l.Situacao == SituacaoLeilao.Rascunho).Count(),
                    EmPregao = c.Leiloes.Where(l => l.Situacao == SituacaoLeilao.Pregao).Count(),
                    Finalizados = c.Leiloes.Where(l => l.Situacao == SituacaoLeilao.Finalizado).Count(),
                });
    }
}