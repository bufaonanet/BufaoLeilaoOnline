namespace Bufao.LeilaoOnline.WebApp.Dados;

public interface IQuery<T>
{
    IEnumerable<T> BuscarTodos();
    T BuscarPorId(int id);
}