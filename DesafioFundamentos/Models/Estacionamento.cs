using System.ComponentModel;

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
            var placa = ReadConsole();
            veiculos.Add(placa);
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            var placa = ReadConsole();

            if (veiculos.Any(x => x == placa))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                var horas = Convert.ToDecimal(ReadConsole());
                var valorTotal = (precoInicial + precoPorHora) * horas;
                veiculos.Remove(placa);
                Console.WriteLine(
                    $"O veículo {placa} foi removido e o preço total foi de: R$ {decimal.Floor(valorTotal)}.");
            }
            else
            {
                Console.WriteLine(
                    "Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine($" - {veiculo}");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }

        private string ReadConsole()
        {
            bool inputValidadte = false;
            do
            {
                var input = Console.ReadLine().ToUpper();
                if (input == "")
                {
                    Console.WriteLine("Opção inválida, Tente novamente!");
                }
                else
                {
                    inputValidadte = true;
                    return input;
                }
            } while (!inputValidadte);

            return null;
        }
    }
}