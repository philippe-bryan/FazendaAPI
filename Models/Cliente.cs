using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FazendaAPI.Models
{
    public class Cliente
    {
        private ConexaoDB db = new ConexaoDB();

        public int IdCliente { get; set; }
        public string RazaoSocial { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public Cliente()
        {
        }

        public Cliente(int idCliente, string razaoSocial, string nome, string cnpj, string endereco, 
                       string telefone, string celular, string email, string senha)
        {
            IdCliente = idCliente;
            RazaoSocial = razaoSocial;
            Nome = nome;
            CNPJ = cnpj;
            Endereco = endereco;
            Telefone = telefone;
            Celular = celular;
            Email = email;
            Senha = senha;
        }

        public void InsertCliente(Cliente cliente)
        {
            string StrQuery = string.Format("insert into Cliente(Nome_Cli, CNPJ_Cli, Cel_Cli, Tel_Cli, End_Cli, Razao_Social_Cli, Email_Cli, Senha_Cli)" +
            "values('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}'); ", cliente.Nome, cliente.CNPJ, cliente.Endereco,
            cliente.Telefone, cliente.Celular, cliente.RazaoSocial, cliente.Email, cliente.Senha);

            db.ExecutaComando(StrQuery);
        }

        public List<Cliente> SelectCliente()
        {
            string StrQuery = "select * from cliente;";
            MySqlDataReader myReader = db.RetornaRegistro(StrQuery);
            var ListaCliente = new List<Cliente>();

            while (myReader.Read())
            {
                var objCliente = new Cliente()
                {
                    IdCliente = int.Parse(myReader["Id_Cliente"].ToString()),
                    Nome = myReader["Nome_Cli"].ToString(),
                    CNPJ = myReader["CNPJ_Cli"].ToString(),
                    Endereco = myReader["Cel_Cli"].ToString(),
                    Telefone = myReader["Tel_Cli"].ToString(),
                    Celular = myReader["End_Cli"].ToString(),
                    RazaoSocial = myReader["Razao_Social_Cli"].ToString(),
                    Email = myReader["Email_Cli"].ToString(),
                    Senha = myReader["Senha_Cli"].ToString(),
                };
                ListaCliente.Add(objCliente);
            }
            myReader.Close();
            return ListaCliente;
        }

        public void UpdateCliente(Cliente cliente)
        {
            string StrQuery = string.Format("update Cliente set Nome_Cli = '{0}', CNPJ_Cli = '{1}', Cel_Cli = '{2}', Tel_Cli = '{3}', End_Cli = '{4}', Razao_Social_Cli = '{5}', Email_Cli = '{6}', Senha_Cli = '{7}' where Id_Cliente = {8}; ",
                                            cliente.Nome, cliente.CNPJ, cliente.Endereco, cliente.Telefone, cliente.Celular, cliente.RazaoSocial, cliente.Email, cliente.Senha, cliente.IdCliente);
            db.ExecutaComando(StrQuery);
        }

        public void DeleteCliente(int id)
        {
            string StrQuery = string.Format("delete from Cliente Where Id_Cliente = " + id);

            db.ExecutaComando(StrQuery);
        }

    }
}