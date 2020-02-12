using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Oracle;
using Oracle.ManagedDataAccess.Client;

namespace webAPI_Zurich.Models
{
    public class DAO
    {
        private static string GetConnectionString()
        {
            String connString = "User Id =SYSTEM; Password =123456; Data Source =localhost:1521/xe ";
            return connString;
        }

        public static List<Seguro> BuscaSeguros()
        {
            string connectionString = GetConnectionString();
            List<Seguro> lstseguro = new List<Seguro>();
            using (OracleConnection connection = new OracleConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();

                OracleCommand command = connection.CreateCommand();
                string sql = "SELECT * FROM SEGURO";
                command.CommandText = sql;

                OracleDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Seguro seguro = new Seguro();
                    seguro.Cpf = reader["CPF"].ToString();
                    seguro.Segurado.cpf= reader["CPF"].ToString();
                    seguro.Segurado.idade = (int)reader["IDADE"];
                    seguro.Segurado.Nome = reader["NOME"].ToString();
                    seguro.Veic.Modelo = reader["MODELO"].ToString();
                    seguro.Veic.Valor = (double)reader["VALOR"];

                    lstseguro.Add(seguro);
                    
                }
                return lstseguro;
            }
        }
        public static bool SalvaSeguro(Seguro seg, double Valor)
        {
            string connectionString = GetConnectionString();
            List<Seguro> lstseguro = new List<Seguro>();
            using (OracleConnection connection = new OracleConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();

                string cpf = seg.Cpf;
                int idVeic = seg.Veic.idVeic;
                double valor = Valor;

                OracleCommand command = connection.CreateCommand();
                string sql = "INSERT INTO SEGURO VALUES(" + seg.idSeguro + ",'" + cpf + "'," + idVeic + "," + valor + ")";
                command.CommandText = sql;

                OracleDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Seguro seguro = new Seguro();
                    seguro.Cpf = reader["CPF"].ToString();
                    seguro.Segurado.cpf = reader["CPF"].ToString();
                    seguro.Segurado.idade = (int)reader["IDADE"];
                    seguro.Segurado.Nome = reader["NOME"].ToString();
                    seguro.Veic.Modelo = reader["MODELO"].ToString();
                    seguro.Veic.Valor = (double)reader["VALOR"];

                    lstseguro.Add(seguro);

                }
                return true;
            }
        }
        public static bool SalvaVeiculo(Seguro seg, double Valor)
        {
            string connectionString = GetConnectionString();
            List<Seguro> lstseguro = new List<Seguro>();
            using (OracleConnection connection = new OracleConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();

                string cpf = seg.Cpf;
                int idVeic = seg.Veic.idVeic;
                double valor = seg.Veic.Valor;

                OracleCommand command = connection.CreateCommand();
                string sql = "INSERT INTO VEICULO VALUES("+"'" + seg.Veic.Modelo + "'," + seg.Veic.Modelo + "," + valor + ")";
                command.CommandText = sql;

                OracleDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Seguro seguro = new Seguro();
                    seguro.Cpf = reader["CPF"].ToString();
                    seguro.Segurado.cpf = reader["CPF"].ToString();
                    seguro.Segurado.idade = (int)reader["IDADE"];
                    seguro.Segurado.Nome = reader["NOME"].ToString();
                    seguro.Veic.Modelo = reader["MODELO"].ToString();
                    seguro.Veic.Valor = (double)reader["VALOR"];

                    lstseguro.Add(seguro);

                }
                return true;
            }
        }
        public static bool SalvaUsuario(Seguro seg, double Valor)
        {
            string connectionString = GetConnectionString();
            List<Seguro> lstseguro = new List<Seguro>();
            using (OracleConnection connection = new OracleConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();

                string cpf = seg.Cpf;
                int idVeic = seg.Veic.idVeic;
                double valor = Valor;

                OracleCommand command = connection.CreateCommand();
                string sql = "INSERT INTO SEGURADO VALUES("+"'" + cpf + "','" + seg.Segurado.Nome + "'," + seg.Segurado.idade + ")";
                command.CommandText = sql;

                OracleDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Seguro seguro = new Seguro();
                    seguro.Cpf = reader["CPF"].ToString();
                    seguro.Segurado.cpf = reader["CPF"].ToString();
                    seguro.Segurado.idade = (int)reader["IDADE"];
                    seguro.Segurado.Nome = reader["NOME"].ToString();
                    seguro.Veic.Modelo = reader["MODELO"].ToString();
                    seguro.Veic.Valor = (double)reader["VALOR"];

                    lstseguro.Add(seguro);

                }
                return true;
            }
        }
    }
}