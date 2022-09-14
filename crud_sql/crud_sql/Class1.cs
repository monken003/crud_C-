﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace crud_sql
{
    internal class Class1
    {
        private MySqlConnection conn;
        private string resposta;
        public void conexaobd()
        {
            conn = new MySqlConnection("persist security info= false;" + "server = localhost;" + "database = bdcadastro;" + "uid = root;" + "password = ;" + "sslmood = none");
            conn.Open();
        }

        private string noquery(string sql)
        {

            conexaobd();
            MySqlCommand comando = new MySqlCommand(sql, conn);
            try
            {
                int finy = comando.ExecuteNonQuery();
                if (finy > 0)
                {
                    resposta = "ação realizada com sucesso";
                }
            }
            catch (Exception ex)
            {
                resposta = "erro" + ex.ToString();
            }
            finally
            {
                conn.Close();
            }
            return resposta;
        }
        public MySqlDataReader query(string sql)
        {
            conexaobd();
            MySqlCommand comando = new MySqlCommand(sql, conn);
            comando.CommandType = System.Data.CommandType.Text;
            MySqlDataReader reader = comando.ExecuteReader();
            return reader;
        } 
    }


}
