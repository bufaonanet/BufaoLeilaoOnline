using Bufao.LeilaoOnline.WebApp.Models;

namespace Bufao.LeilaoOnline.WebApp.Services;

public interface IAdminService
{
    IEnumerable<Categoria> ConsultaCategorias();
    IEnumerable<Leilao> ConsultaLeiloes();
    Leilao ConsultaLeilaoPorId(int id);
    void CadastraLeilao(Leilao leilao);
    void ModificaLeilao(Leilao leilao);
    void RemoveLeilao(Leilao leilao);
    void IniciaPregaoDoLeilaoComId(int id);
    void FinalizaPregaoDoLeilaoComId(int id);
}