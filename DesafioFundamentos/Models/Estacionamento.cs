using System.Diagnostics.Contracts;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:"); 
            veiculos.Add(Console.ReadLine().ToUpper());
        }

        public void RemoverVeiculo()
        {
            ListarVeiculos();
            Console.WriteLine("\nDigite a placa do veículo para remover:");
            string placa = Console.ReadLine();

            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                if(int.TryParse(Console.ReadLine(), out int horas))
                {
                    decimal valorTotal = precoInicial + precoPorHora * horas; 
                    Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
                    veiculos.Remove(placa);
                }
                else
                {
                    Console.WriteLine("\nErro - Número digitado não é um numero válido. Digite um número");
                }
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                int cont = 1;
                foreach(string valor in veiculos)
                {
                     Console.WriteLine($"{cont}º = Placa - {valor}");
                     cont++;
                }
              
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
