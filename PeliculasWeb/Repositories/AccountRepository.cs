using Newtonsoft.Json;
using PeliculasWeb.Models;
using PeliculasWeb.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PeliculasWeb.Repositories
{
    public class AccountRepository : Repository<UsuarioM>, IAccountRepository
    {
        private readonly IHttpClientFactory _clientFactory;
        public AccountRepository(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<UsuarioM> LoginAsync(string url, UsuarioM itemCrear)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            if (itemCrear!=null)
            {
                request.Content = new StringContent(
                        JsonConvert.SerializeObject(itemCrear), Encoding.UTF8, "application/json"
                    );
            }
            else
            {
                return new UsuarioM();
            }

            var cliente = _clientFactory.CreateClient();
            HttpResponseMessage respuesta = await cliente.SendAsync(request);

            if (respuesta.StatusCode == System.Net.HttpStatusCode.OK)    //retorna 200
            {
                var jsonString = await respuesta.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<UsuarioM>(jsonString);
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> RegisterAsync(string url, UsuarioM itemCrear)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            if (itemCrear != null)
            {
                request.Content = new StringContent(
                        JsonConvert.SerializeObject(itemCrear), Encoding.UTF8, "application/json"
                    );
            }
            else
            {
                return false;
            }

            var cliente = _clientFactory.CreateClient();
            HttpResponseMessage respuesta = await cliente.SendAsync(request);

            if (respuesta.StatusCode == System.Net.HttpStatusCode.OK)    //retorna 200
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
