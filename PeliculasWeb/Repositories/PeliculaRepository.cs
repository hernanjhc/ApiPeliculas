using PeliculasWeb.Models;
using PeliculasWeb.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PeliculasWeb.Repositories
{
    public class PeliculaRepository : Repository<Pelicula>, IPeliculaRepository
    {
        private readonly IHttpClientFactory _clientFactory;
        public PeliculaRepository(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }
    }
}
