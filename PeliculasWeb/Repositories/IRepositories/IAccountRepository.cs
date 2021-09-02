using PeliculasWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeliculasWeb.Repositories.IRepositories
{
    public interface IAccountRepository : IRepository<UsuarioM>
    {
        Task<UsuarioM> LoginAsync(string url, UsuarioM itemCrear);
        Task<bool> RegisterAsync(string url, UsuarioM itemCrear);
    }
}
