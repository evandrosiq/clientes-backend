using ControleClientes.Entities;
using ControleClientes.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Valida.CPF.CNPJ;

namespace ControleClientes.Services
{
    public class ClienteService
    {
        public void Create(Cliente Cliente)
        {
            var ClienteRepository = new ClienteRepository();
            var isValid = ValidaCPFCNPJ.ValidaCPF(Cliente.CPF);

            if (!isValid)
            {
                throw new Exception("Esse CPF é inválido!");
            }

            var AlreadyCliente = ClienteRepository.GetByCPF(Cliente.CPF);
            if (AlreadyCliente != null)
            {
                throw new Exception("Esse CPF já está cadastro em nosso banco de dados!");
            }

            var DataNascimento = Cliente.DataNascimento;
            if (DataNascimento > DateTime.Now)
            {
                throw new Exception("Essa data de nascimento é inválida!");
            }

            Cliente.DataCadastro = DateTime.Now;
            ClienteRepository.Save(Cliente);
        }

        public void Update(Cliente Cliente)
        {
            var ClienteRepository = new ClienteRepository();
            var cliente = new Cliente();

            var isValid = ValidaCPFCNPJ.ValidaCPF(Cliente.CPF);

            if (!isValid)
            {
                throw new Exception("Esse CPF é inválido!");
            }

            var DataNascimento = Cliente.DataNascimento;
            if (DataNascimento > DateTime.Now)
            {
                throw new Exception("Essa data de nascimento é inválida!");
            }

            cliente.Id = Cliente.Id;
            cliente.Nome = Cliente.Nome;
            cliente.CPF = Cliente.CPF;
            cliente.DataNascimento = Cliente.DataNascimento;
            cliente.DataCadastro = Cliente.DataCadastro;
            cliente.RendaFamiliar = Cliente.RendaFamiliar;

            ClienteRepository.Update(cliente);
        }

        public void Delete(int id)
        {
            var ClienteRepository = new ClienteRepository();
            ClienteRepository.DeleteById(id);
        }

        public List<Cliente> GetALL()
        {
            var ClienteRepository = new ClienteRepository();
            return ClienteRepository.GetAll();
        }

        public List<Cliente> GetByNome(string Nome)
        {
            var ClienteRepository = new ClienteRepository();
            return ClienteRepository.GetByNome(Nome);
        }
    }
}
