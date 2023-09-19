using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace par_Ou_Impar
{
    internal class Program
    {
        const int RANGEESCOLHIDOPELOCOMPUTADOR = 100;
        const string PAR = "p", IMPAR = "i";


        static void Main(string[] args)
        {
            int contadorDePontosPorRodadaJogador = 0;

            int contadorDePontosPorRodadaComputador = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("------Bem vindo ao jogo do Par ou Ímpar------");
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("");

                var opcaoParOuImpar = escolhaParOuImpar();
                int numeroEscolhidoJogador = escolhaNumeroJogado();
                int numeroEscolhidoComputador = numeroAleatorio();

                Console.WriteLine($"O número inteiro escolhido pelo jogador é o: {numeroEscolhidoJogador}");
                Console.WriteLine($"O número inteiro escolhido pelo computador é o: {numeroEscolhidoComputador}");

                int somaJogadorComputador = numeroEscolhidoComputador + numeroEscolhidoJogador;
                Console.WriteLine($"A soma dos números é igual a: {somaJogadorComputador}");

                int resultadoParOuImpar = somaJogadorComputador % 2;
                resultadoDaRodada(resultadoParOuImpar, opcaoParOuImpar, ref contadorDePontosPorRodadaJogador, ref contadorDePontosPorRodadaComputador);

                Console.ReadLine();
            } while (jogarNovamente() == true);

            mostrarResultadoFinal(contadorDePontosPorRodadaJogador, contadorDePontosPorRodadaComputador);

            }
        static string escolhaParOuImpar() 
        {
            while (true) { 
            try { 
                Console.WriteLine("Escolha (p) para par ou (i) para ímpar");
                string opcaoJogador = Console.ReadLine().ToLower();

                if (opcaoJogador == PAR)
                    return opcaoJogador = PAR;
            
                else if (opcaoJogador == IMPAR)
                    return opcaoJogador = IMPAR;

                throw new ArgumentException("Escolha inválida, favor, insíra novamente.");
                }
            catch (ArgumentException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ResetColor();
                }
            }
        }
        static int escolhaNumeroJogado() 
        {
            Console.Clear();
            while(true) 
            {
                try 
                {     
                Console.Write("Escolha o número inteiro: ");
                return int.Parse(Console.ReadLine());

                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Escolha inválida, digite apenas números inteiros.");
                    Console.ResetColor();
                }
            }
        }
        static int numeroAleatorio() 
        {
            Random roleta = new Random();
            int numeroComputador = 0;

            return numeroComputador = roleta.Next(RANGEESCOLHIDOPELOCOMPUTADOR);
        }

        static void resultadoDaRodada(int resultadoParOuImpar, string opcaoJogador, ref int contadorDePontosPorRodadaJogador, ref int contadorDePontosPorRodadaComputador)
        {

            switch (opcaoJogador)
            {
                case (PAR):
                    if (resultadoParOuImpar == 0)
                    {
                    Console.WriteLine("Você Ganhou está rodada!");
                    contadorDePontosPorRodadaJogador++;
                    }
                    else
                    {
                    Console.WriteLine("Você Perdeu está rodada!");
                    contadorDePontosPorRodadaComputador++;
                    }
                    break;
                case (IMPAR):
                    if (resultadoParOuImpar != 0)
                    {
                        Console.WriteLine("Você Ganhou está rodada!");
                        contadorDePontosPorRodadaJogador++;
                    }
                    else
                    {
                        Console.WriteLine("Você Perdeu está rodada!");
                        contadorDePontosPorRodadaComputador++;
                    }
                    break;
            }
    }

        static bool jogarNovamente() 
        {
            while (true) 
            {

                try {
            Console.WriteLine("Deseja jogar novamente? (Sim - s / Não - n)");
            var opcaoJogarNovamente = Console.ReadLine().ToLower();

            if (opcaoJogarNovamente.Equals("s"))
                return true;
            else if (opcaoJogarNovamente.Equals("n"))
                return false;

                    throw new ArgumentException("Opção não encontrada, digite novamente.");             
                }
                catch (ArgumentException ex) 
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ResetColor();
                }

            }
        }

        static void mostrarResultadoFinal(int contadorDePontosPorRodadaJogador, int contadorDePontosPorRodadaComputador) 
        {
            if (contadorDePontosPorRodadaJogador > contadorDePontosPorRodadaComputador)
            {
                Console.WriteLine($"Jogador: {contadorDePontosPorRodadaJogador} x Computador: {contadorDePontosPorRodadaComputador} \nJogador GANHOU!");
            }
            else if (contadorDePontosPorRodadaComputador > contadorDePontosPorRodadaJogador)
            {
                Console.WriteLine($"Jogador: {contadorDePontosPorRodadaJogador} x Computador: {contadorDePontosPorRodadaComputador} \nComputador GANHOU!");
            }
            else
            {
                Console.WriteLine($"Jogador: {contadorDePontosPorRodadaJogador} x Computador: {contadorDePontosPorRodadaComputador} \nEmpatou!!");
            }
            Console.ReadLine();
        }
    }
}
