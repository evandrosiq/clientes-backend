using ControleClientes.Entities;
using ControleClientes.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleClientes.Services
{
    public class ReportService
    {

        public int GetLegalAgeClients()
        {
            var ReportRepository = new ReportRepository();
            return ReportRepository.GetLegalAgeClients();
        }

        public Classe GetClass()
        {
            var ClienteRepository = new ClienteRepository();

            var Clientes = ClienteRepository.GetAll();
            var Classe = new Classe();
            var CA = 0;
            var CB = 0;
            var CC = 0;


            foreach (var client in Clientes)
            {
                if (client.RendaFamiliar <= 980)
                    CA++;

                if (client.RendaFamiliar > 980 && client.RendaFamiliar >= 2500)
                    CB++;

                if (client.RendaFamiliar > 2500)
                    CC++;
            }
            Classe.ClasseA = CA;
            Classe.ClasseB = CB;
            Classe.ClasseC = CC;

            return Classe;
        }

        public Registro GetRegistro()
        {
            var ClienteRepository = new ClienteRepository();

            var Clientes = ClienteRepository.GetAll();
            var Registro = new Registro();
            var Rhoje = 0;
            var RSemana = 0;
            var RMes = 0;

            foreach (var client in Clientes)
            {
                if (client.DataCadastro == DateTime.Now)
                    Rhoje++;

                var diaDaSemana = (int)DateTime.Now.DayOfWeek;
                var diasPassados = 6 - (int)DateTime.Now.DayOfWeek;
                var primeiroDia = DateTime.Now.AddDays(-diaDaSemana);
                var ultimoDia = DateTime.Now.AddDays(diasPassados);

                if (client.DataCadastro.Date >= primeiroDia.Date && client.DataCadastro.Date <= ultimoDia.Date)
                    RSemana++;

                if (client.DataCadastro.Month == DateTime.Now.Month)
                    RMes++;
            }
            Registro.CadastroHoje = Rhoje;
            Registro.CadastroSemana = RSemana;
            Registro.CadastroMes = RMes;

            return Registro;
        }

        public Relatorio CreateReport()
        {
            var registros = GetRegistro();
            var classes = GetClass();
            var maiorDeIdade = GetLegalAgeClients();

            var relatorio = new Relatorio();

            relatorio.Registro = new Registro();
            relatorio.Registro.CadastroHoje = registros.CadastroHoje;
            relatorio.Registro.CadastroSemana = registros.CadastroSemana;
            relatorio.Registro.CadastroMes = registros.CadastroMes;

            relatorio.ClasseCount = new Classe();
            relatorio.ClasseCount.ClasseA = classes.ClasseA;
            relatorio.ClasseCount.ClasseB = classes.ClasseB;
            relatorio.ClasseCount.ClasseC = classes.ClasseC;

            relatorio.LegalAgeCount = maiorDeIdade;

            return relatorio;
        }
    }
}
