using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FazendaAPI.Models
{
    public class Produto
    {
        private ConexaoDB db = new ConexaoDB();

        public int IdProd { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string TipoAni { get; set; }
        public DateTime Validade { get; set; }
        public string Quantidade { get; set; }
        public decimal Valor { get; set; }

        public Produto()
        {
        }

        public Produto(int idProd, string nome, string descricao, string tipoAni, DateTime validade, string quantidade, decimal valor)
        {
            IdProd = idProd;
            Nome = nome;
            Descricao = descricao;
            TipoAni = tipoAni;
            Validade = validade;
            Quantidade = quantidade;
            Valor = valor;
        }

        public void InsertProd(Produto produto)
        {
            string StrQuery = string.Format("insert into Produção(Nome_Produc, Descricao_Produc, Tipo_Ani_Produc, Validade_Produc, Quant_Produc, Valor_Produc)" +
            "values('{0}', '{1}', '{2}', '{3}', '{4}', '{5}'); ", produto.Nome, produto.Descricao, produto.TipoAni, produto.Validade, produto.Quantidade, produto.Valor);

            db.ExecutaComando(StrQuery);
        }

        public List<Produto> SelectProd()
        {
            string StrQuery = "select * from Produção;";
            MySqlDataReader myReader = db.RetornaRegistro(StrQuery);
            var ListaProd = new List<Produto>();

            while (myReader.Read())
            {
                var objCliente = new Produto()
                {
                    IdProd = int.Parse(myReader["Id_Prod"].ToString()),
                    Nome = myReader["Nome_Produc"].ToString(),
                    Descricao = myReader["Descricao_Produc"].ToString(),
                    TipoAni = myReader["Tipo_Ani_Produc"].ToString(),
                    Validade = DateTime.Parse(myReader["Validade_Produc"].ToString()),
                    Quantidade = myReader["Quant_Produc"].ToString(),
                    Valor = decimal.Parse(myReader["Valor_Produc"].ToString())
                };
                ListaProd.Add(objCliente);
            }
            myReader.Close();
            return ListaProd;
        }

        public void UpdateProd(Produto produto)
        {
            string StrQuery = string.Format("update Produção set Nome_Produc = '{0}', Descricao_Produc = '{1}', Tipo_Ani_Produc = '{2}', Validade_Produc = '{3}', Quant_Produc = '{4}', Valor_Produc = '{5}' where Id_Prod = {6}; ",
                                            produto.Nome, produto.Descricao, produto.TipoAni, produto.Validade, produto.Quantidade, produto.Valor, produto.IdProd);
            db.ExecutaComando(StrQuery);
        }

        public void DeleteProd(int id)
        {
            string StrQuery = string.Format("delete from Produção Where Id_Prod = " + id);

            db.ExecutaComando(StrQuery);
        }

    }
}