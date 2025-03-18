using System.Diagnostics.Tracing;

namespace JogoDeAdvinhação.ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // loop principal 
            while (true)
            {
                string opcaoDificuldade = ExibirMenu();
                int totalTentativas = QualDificuldade(opcaoDificuldade);
                if (totalTentativas == 0)
                    continue;

                // gerar um número secreto aleatório
                Random geradorDeNumeros = new Random();
                int NumeroSecreto = geradorDeNumeros.Next(1, 21);
                
                Console.WriteLine("---------------------------------");
                //logica do jogo
                for (int tentativas = 1; tentativas <= totalTentativas; tentativas++)
                {
                    int NumeroDigitado = Tentativas(totalTentativas, tentativas);
                    tentativas = MaiorMenorIgual(NumeroDigitado, NumeroSecreto, totalTentativas, tentativas);
                }
                string opcaoContinuar = DesejaContinuar();

                while (opcaoContinuar != "S" && opcaoContinuar != "N")
                {
                    Console.Clear();
                    Console.WriteLine("Comando Inválido, Digite Novamente", "\n");
                    opcaoContinuar = DesejaContinuar();
                }
                if (opcaoContinuar != "S")
                {
                    Console.WriteLine("Obrigado pela presença!!");
                    break;
                }
            }
        }


        static string ExibirMenu()
        {
            Console.Clear();
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Jogo de Advinhação");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Em qual modo de dificuldade você gostaria de jogar?");
            Console.WriteLine("1 - Fácil ");
            Console.WriteLine("2 - Médio");
            Console.WriteLine("3 - Difícil");

            string opcaoDificuldade = Console.ReadLine()!;
            return opcaoDificuldade;
        }

        static int QualDificuldade(string opcaoDificuldade)
        {
            int totalTentativas;
            if (opcaoDificuldade == "1")
            {
                Console.WriteLine("Ótimo, Você escolheu o Modo Fácil");
                totalTentativas = 7;
                Console.WriteLine("Nesse modo, você terá 7 tentativas para acertar");
                return totalTentativas;
            }
            else if (opcaoDificuldade == "2")
            {
                Console.WriteLine("Ótimo, Você escolheu o Modo Médio");
                totalTentativas = 5;
                Console.WriteLine("Nesse modo, você terá 5 tentativas para acertar");
                return totalTentativas;
            }
            else if (opcaoDificuldade == "3")
            {
                Console.WriteLine("Ótimo, Você escolheu o Modo Difícil");
                totalTentativas = 3;
                Console.WriteLine("Nesse modo, você terá 3 tentativas para acertar");
                return totalTentativas;
            }

            else
            {
                Console.WriteLine("Comando Inválido, Retornando ao Menu principal");
                Console.ReadLine();
                totalTentativas = 0;
                return totalTentativas;
            }
        }
        static int Tentativas(int totalTentativas, int tentativas)
        {
            Console.WriteLine($"Tentativa {tentativas} de {totalTentativas} tentativas totais");
            Console.WriteLine("---------------------------------");

            Console.WriteLine("Digite um número entre 1 e 20: ");
            int NumeroDigitado = Convert.ToInt32(Console.ReadLine());
            while (NumeroDigitado > 20 || NumeroDigitado < 1)
            {
                Console.WriteLine("Número Inválido, digite novamente");
                NumeroDigitado = Convert.ToInt32(Console.ReadLine());
                return NumeroDigitado;
            }

            Console.WriteLine("Você digitou o número " + NumeroDigitado);
            return NumeroDigitado;

        }
        static int MaiorMenorIgual(int NumeroDigitado, int NumeroSecreto, int totalTentativas, int tentativas)
        {
            if (NumeroDigitado == NumeroSecreto)
            {
                Console.WriteLine("---------------------------------");
                Console.WriteLine("Parabéns, você ganhou o jogo!!");
                Console.WriteLine("---------------------------------");
                tentativas = totalTentativas;
                return tentativas;
            }

            else if (NumeroDigitado < NumeroSecreto)
            {
                Console.WriteLine("---------------------------------");
                Console.WriteLine($"O numero secreto é maior que {NumeroDigitado} ");
                Console.WriteLine("---------------------------------");
                return tentativas;
            }
            else if (NumeroDigitado > NumeroSecreto)
            {
                Console.WriteLine("---------------------------------");
                Console.WriteLine($"O numero secreto é menor que {NumeroDigitado} ");
                Console.WriteLine("---------------------------------");
                return tentativas;
            }
            if (totalTentativas == tentativas && NumeroSecreto != NumeroDigitado)
            {
                Console.WriteLine("Que Pena, você não conseguiu acertar o número secreto", "/n");
                Console.WriteLine($"O número secreto era {NumeroSecreto}", "/n");
                return totalTentativas;
            }
            return tentativas;
        }
        static string DesejaContinuar()
        {
            Console.WriteLine("Deseja continuar (s/n) ", "/n");
            string opcaoContinuar = Console.ReadLine()!.ToUpper();
            return opcaoContinuar;
        }
    }
}

