using FazendaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FazendaAPI.Controllers
{
    public class ProdutoController : ApiController
    {
        // GET: api/Produto
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Cliente/5
        [HttpGet]
        [ActionName("getCliente")]
        public Produto Get(int idProd)
        {
            var objprod = new Produto();
            var ListaProd = objprod.SelectProd();
            var produto = ListaProd.FirstOrDefault((p) => p.IdProd == idProd);
            if (produto == null)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound);
                throw new HttpResponseException(resp);
            }
            return produto;
        }

        [HttpGet]
        [ActionName("getAll")]
        public List<Produto> GetAllClientes()
        {
            var objprod = new Produto();
            var ListaProd = objprod.SelectProd();
            if (ListaProd == null)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound);
                throw new HttpResponseException(resp);
            }
            return ListaProd;
        }

        // POST: api/Cliente
        public void Post([FromBody] Produto produto)
        {
            var objprod = new Produto();
            objprod.InsertProd(produto);
        }

        // PUT: api/Cliente/5
        public void Put([FromBody] Produto produto)
        {
            var objprod = new Produto();
            objprod.UpdateProd(produto);
        }

        // DELETE: api/Cliente/5
        [HttpDelete]
        [ActionName("delete")]
        public Produto Delete(int idProd)
        {
            var produto = new Produto();
            produto.DeleteProd(idProd);
            return produto;
        }
    }
}
