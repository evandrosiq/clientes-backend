using ControleClientes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;

namespace ControleClientes.Repositories
{
    public class ClienteRepository
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

        public List<Cliente> GetAll()
        {
            var Clientes = new List<Cliente>();
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();

                using (var command = new NpgsqlCommand("select * from cliente", conn))
                {
                    NpgsqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var Cliente = new Cliente();

                        Cliente.Id = Convert.ToInt32(reader["id"]);
                        Cliente.Nome = Convert.ToString(reader["nome"]);
                        Cliente.CPF = Convert.ToString(reader["cpf"]);
                        Cliente.DataNascimento = Convert.ToDateTime(reader["dataNascimento"]);
                        Cliente.DataCadastro = Convert.ToDateTime(reader["dataCadastro"]);
                        Cliente.RendaFamiliar = Convert.ToDecimal(reader["rendaFamiliar"]);

                        Clientes.Add(Cliente);
                    }
                }
                conn.Close();
            }
            return Clientes;
        }
        public void Save(Cliente Cliente)
        {
            using (var conn = new NpgsqlConnection(connString))

            {
                conn.Open();

                using (var command = new NpgsqlCommand("insert into cliente (nome, cpf, dataNascimento, dataCadastro, rendaFamiliar) values (@nome,@cpf,@dataNascimento,@dataCadastro,@rendaFamiliar)", conn))
                {
                    command.Parameters.AddWithValue("nome", Cliente.Nome);
                    command.Parameters.AddWithValue("cpf", Cliente.CPF);
                    command.Parameters.AddWithValue("dataNascimento", Cliente.DataNascimento);
                    command.Parameters.AddWithValue("dataCadastro", Cliente.DataCadastro);
                    command.Parameters.AddWithValue("rendaFamiliar", Cliente.RendaFamiliar);
                    command.ExecuteNonQuery();
                }

                conn.Close();
            }
        }

        public void Update(Cliente Cliente)
        {
            using (var conn = new NpgsqlConnection(connString))

            {
                conn.Open();

                using (var command = new NpgsqlCommand("update cliente set nome = @nome, cpf = @cpf, dataNascimento = @dataNascimento, dataCadastro = @dataCadastro, rendaFamiliar = @rendaFamiliar where id = @id", conn))
                {
                    command.Parameters.AddWithValue("nome", Cliente.Nome);
                    command.Parameters.AddWithValue("cpf", Cliente.CPF);
                    command.Parameters.AddWithValue("dataNascimento", Cliente.DataNascimento);
                    command.Parameters.AddWithValue("dataCadastro", Cliente.DataCadastro);
                    command.Parameters.AddWithValue("rendaFamiliar", Cliente.RendaFamiliar);
                    command.Parameters.AddWithValue("id", Cliente.Id);
                    command.ExecuteNonQuery();
                }

                conn.Close();
            }
        }

        public void DeleteById(int id)
        {
            using (var conn = new NpgsqlConnection(connString))

            {
                conn.Open();

                using (var command = new NpgsqlCommand("delete from cliente where id = @id", conn))
                {
                    command.Parameters.AddWithValue("id", id);
                    command.ExecuteNonQuery();
                }

                conn.Close();
            }
        }

        public Cliente GetByCPF(string CPF)
        {
            Cliente Cliente = null;
            using (var conn = new NpgsqlConnection(connString))

            {
                conn.Open();

                using (var command = new NpgsqlCommand("select * from cliente where cpf = @cpf", conn))
                {
                    command.Parameters.AddWithValue("cpf", CPF);
                    NpgsqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    if (reader.HasRows)
                    {
                        Cliente = new Cliente();
                        Cliente.Id = Convert.ToInt32(reader["id"]);
                        Cliente.Nome = Convert.ToString(reader["nome"]);
                        Cliente.CPF = Convert.ToString(reader["cpf"]);
                        Cliente.DataNascimento = Convert.ToDateTime(reader["dataNascimento"]);
                        Cliente.DataCadastro = Convert.ToDateTime(reader["dataCadastro"]);
                        Cliente.RendaFamiliar = Convert.ToDecimal(reader["rendaFamiliar"]);

                    }
                }

                conn.Close();
            }
            return Cliente;
        }

        public List<Cliente> GetByNome(string Nome)
        {
            Cliente Cliente = null;
            var Clientes = new List<Cliente>();
            using (var conn = new NpgsqlConnection(connString))

            {
                conn.Open();

                using (var command = new NpgsqlCommand("select * from cliente where nome like @nome", conn))
                {
                    command.Parameters.AddWithValue("nome", "%" + Nome + "%");
                    NpgsqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Cliente = new Cliente();
                        Cliente.Id = Convert.ToInt32(reader["id"]);
                        Cliente.Nome = Convert.ToString(reader["nome"]);
                        Cliente.CPF = Convert.ToString(reader["cpf"]);
                        Cliente.DataNascimento = Convert.ToDateTime(reader["dataNascimento"]);
                        Cliente.DataCadastro = Convert.ToDateTime(reader["dataCadastro"]);
                        Cliente.RendaFamiliar = Convert.ToDecimal(reader["rendaFamiliar"]);

                        Clientes.Add(Cliente);

                    }
                }

                conn.Close();
            }
            return Clientes;
        }
    }
}
