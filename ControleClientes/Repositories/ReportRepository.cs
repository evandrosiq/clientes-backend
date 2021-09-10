using ControleClientes.Entities;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleClientes.Repositories
{
    public class ReportRepository
    {
        private static string Host = "127.0.0.1";
        private static string User = "postgres";
        private static string DBname = "clientes";
        private static string Password = "1";
        private static string Port = "5432";

        string connString =
             String.Format(
                 "Server={0};Username={1};Database={2};Port={3};Password={4};SSLMode=Prefer",
                 Host,
                 User,
                 DBname,
                 Port,
                 Password);

        public int GetLegalAgeClients()
        {
            int cnt = 0;
            using (var conn = new NpgsqlConnection(connString))

            {
                conn.Open();

                using (var command = new NpgsqlCommand("select COUNT(*) as cnt from cliente where extract(year from age(datanascimento)) >= 18", conn))
                {
                    NpgsqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    if (reader.HasRows)
                    {
                        cnt = Convert.ToInt32(reader["cnt"]);
                    }
                }

                conn.Close();
            }
            return cnt;
        }
    }
}
