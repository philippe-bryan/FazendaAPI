using FazendaAPI.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FazendaAPI.Controllers
{
    public class ClienteController : ApiController
    {
        List<Cliente> clientes = new List<Cliente>(new Cliente[] {
            new Cliente(1, "Fazenda.ltda", "Harry Fazenda", "112233445566-55", "sobe sobe esqurda desce", "4002-8922", "91234-5678", "harry42@gmail.com", "harrizinhosemvarinha123"),
            new Cliente(2, "Rooster Teth", "RWBY", "123513264625162-53", "Remenent", "9999=9999", "90000-0000", "ruby.rose@beacon.com", "volume8saiu")
        });


        // GET: api/Cliente
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Cliente/5
        [HttpGet]
        [ActionName("getCliente")]
        public Cliente Get(int idCliente)
        {
            //    var objcliente = new Cliente();
            //    var ListaCliente = objcliente.SelectCliente();
            //    var cliente = ListaCliente.FirstOrDefault((p) => p.IdCliente == idCliente);
            var cliente = clientes.FirstOrDefault((p) => p.IdCliente == idCliente);
            if (cliente == null)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound);
                throw new HttpResponseException(resp);
            }
            return cliente;
        }

        [HttpGet]
        [ActionName("getAll")]
        public List<Cliente> GetAllClientes()
        {
            var objcliente = new Cliente();
            var ListaCliente = objcliente.SelectCliente();
            if (ListaCliente == null)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound);
                throw new HttpResponseException(resp);
            }
            return ListaCliente;
        }

        // POST: api/Cliente
        public void Post([FromBody]Cliente cliente)
        {
            var objcliente = new Cliente();
            objcliente.InsertCliente(cliente);
        }

        // PUT: api/Cliente/5
        public void Put([FromBody] Cliente cliente)
        {
            var objedit = new Cliente();
            objedit.UpdateCliente(cliente);
        }

        // DELETE: api/Cliente/5
        [HttpDelete]
        [ActionName("delete")]
        public Cliente Delete(int idCliente)
        {
            var cliente = new Cliente();
            cliente.DeleteCliente(idCliente);
            return cliente;
        }
    }
}
