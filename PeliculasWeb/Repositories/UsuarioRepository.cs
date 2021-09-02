using PeliculasWeb.Models;
using PeliculasWeb.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PeliculasWeb.Repositories
{
    public class UsuarioRepository : Repository<UsuarioU>, IUsuarioRepository
    {
        private readonly IHttpClientFactory _clientFactory;
        public UsuarioRepository(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }
    }
}
