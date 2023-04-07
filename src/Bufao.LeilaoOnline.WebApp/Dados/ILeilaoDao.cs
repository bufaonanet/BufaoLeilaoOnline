using Bufao.LeilaoOnline.WebApp.Models;

namespace Bufao.LeilaoOnline.WebApp.Dados;

public interface ILeilaoDao : ICommand<Leilao>, IQuery<Leilao>
{

}