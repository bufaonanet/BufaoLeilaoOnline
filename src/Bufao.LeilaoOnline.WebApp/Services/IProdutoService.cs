using Bufao.LeilaoOnline.WebApp.Models;

namespace Bufao.LeilaoOnline.WebApp.Services;

public interface IProdutoService
{
    IEnumerable<Leilao> PesquisaLeiloesEmPregaoPorTermo(string termo);
    IEnumerable<CategoriaComInfoLeilao> ConsultaCategoriasComTotalDeLeiloesEmPregao();
    Categoria ConsultaCategoriaPorIdComLeiloesEmPregao(int id);
}
