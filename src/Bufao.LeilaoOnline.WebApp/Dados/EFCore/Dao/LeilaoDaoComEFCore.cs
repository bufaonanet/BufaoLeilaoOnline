using Bufao.LeilaoOnline.WebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace Bufao.LeilaoOnline.WebApp.Dados.EFCore.Dao;

public class LeilaoDaoComEFCore : ILeilaoDao
{
    private readonly AppDbContext _context;

    public LeilaoDaoComEFCore(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Leilao> BuscarTodos()
    {
        return _context.Leiloes.Include(l => l.Categoria).ToList();
    }

    public Leilao BuscarPorId(int id)
    {
        return _context.Leiloes.Find(id);
    }        

    public void Incluir(Leilao obj)
    {
        _context.Leiloes.Add(obj);
        _context.SaveChanges();
    }

    public void Alterar(Leilao obj)
    {
        _context.Leiloes.Update(obj);
        _context.SaveChanges();
    }

    public void Excluir(Leilao leilao)
    {
        _context.Leiloes.Remove(leilao);
        _context.SaveChanges();
    }    
}