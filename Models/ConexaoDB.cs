﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace FazendaAPI.Models
{
    public class ConexaoDB
    {
        private readonly MySqlConnection conexao;
        public ConexaoDB()
        {
            conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["conexao"].ConnectionString);
            conexao.Open();
        }

        public void ExecutaComando(string StrQuery)
        {
            var vComando = new MySqlCommand
            {
                CommandText = StrQuery,
                CommandType = System.Data.CommandType.Text,
                Connection = conexao
            };
            vComando.ExecuteNonQuery();
        }

        public MySqlDataReader RetornaRegistro(string StrQuery)
        {
            var vComando = new MySqlCommand
            {
                CommandText = StrQuery,
                CommandType = System.Data.CommandType.Text,
                Connection = conexao
            };
            return vComando.ExecuteReader();
        }

        public string RetornaDado(string StrQuery)
        {
            var vComando = new MySqlCommand
            {
                CommandText = StrQuery,
                CommandType = System.Data.CommandType.Text,
                Connection = conexao
            };
            string result;
            result = (string)vComando.ExecuteScalar();

            if (result == null)
                return result = "";

            return result;
        }

        public void Dispose()
        {
            if (conexao.State == System.Data.ConnectionState.Open)
                conexao.Close();
        }
    }
}