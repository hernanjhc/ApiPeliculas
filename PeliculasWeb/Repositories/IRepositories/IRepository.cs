using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeliculasWeb.Repositories.IRepositories
{
    //Clase generica para los 3 repositorios
    //entonces <T> where T : class
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable> GetTodoAsync(string url);
        Task<IEnumerable> GetPeliculasEnCategoriaAsync(string url, int categoriaId);
        Task<IEnumerable> Buscar(string url, string nombre);
        Task<T> GetAsync(string url, int Id);
        Task<bool> CrearAsync(string url, T itemCrear, string token);
        Task<bool> ActualizarAsync(string url, T itemActualizar, string token);
        Task<bool> BorrarAsync(string url, int Id, string token);
    }
}
