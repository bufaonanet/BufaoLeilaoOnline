using Bufao.LeilaoOnline.WebApp.Models;

namespace Bufao.LeilaoOnline.WebApp.Dados;

public interface ICategoriaDao : IQuery<Categoria>
{   
    IEnumerable<CategoriaComInfoLeilao> BuscarTodasCategoriasComLeiloes();   
}
