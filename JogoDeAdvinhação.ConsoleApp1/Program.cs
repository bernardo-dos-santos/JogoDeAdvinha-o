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
                Console.Clear();
                Console.WriteLine("---------------------------------");
                Console.WriteLine("Jogo de Advinhação");
                Console.WriteLine("---------------------------------");
                Console.WriteLine("Em qual modo de dificuldade você gostaria de jogar?");
                Console.WriteLine("1 - Fácil ");
                Console.WriteLine("2 - Médio");
                Console.WriteLine("3 - Difícil");

                
                string opcaoDificuldade = Console.ReadLine();
                int TotalTentativas;
                if (opcaoDificuldade == "1")
                {
                    Console.WriteLine("Ótimo, Você escolheu o Modo Fácil");
                    TotalTentativas = 7;
                    Console.WriteLine("Nesse modo, você terá 7 tentativas para acertar");
                } else if (opcaoDificuldade == "2")
                {
                    Console.WriteLine("Ótimo, Você escolheu o Modo Médio");
                    TotalTentativas = 5;
                    Console.WriteLine("Nesse modo, você terá 5 tentativas para acertar");
                }
                else if (opcaoDificuldade == "3")
                {
                    Console.WriteLine("Ótimo, Você escolheu o Modo Difícil");
                    TotalTentativas = 3;
                    Console.WriteLine("Nesse modo, você terá 3 tentativas para acertar");
                } else
                {
                    Console.WriteLine("Comando Inválido, Retornando ao Menu principal");
                    continue;
                }


                    // gerar um número secreto aleatório
                    Random geradorDeNumeros = new Random();
                int NumeroSecreto = geradorDeNumeros.Next(1, 21);

                //logica do jogo 
                Console.WriteLine("---------------------------------");
                for (int tentativas = 1; tentativas <= TotalTentativas; tentativas++ )
              {
                    
                    Console.WriteLine($"Tentativa {tentativas} de {TotalTentativas} tentativas totais");
                    Console.WriteLine("---------------------------------");

                    Console.WriteLine("Digite um número entre 1 e 20: ");
                    int NumeroDigitado = Convert.ToInt32(Console.ReadLine());
                    while (NumeroDigitado > 20 || NumeroDigitado < 1)
                    {
                        Console.WriteLine("Número Inválido, digite novamente");
                        NumeroDigitado = Convert.ToInt32(Console.ReadLine());
                    }

                Console.WriteLine("Você digitou o número "+ NumeroDigitado);

                if (NumeroDigitado == NumeroSecreto)
                {
                    Console.WriteLine("---------------------------------");
                    Console.WriteLine("Parabéns, você ganhou o jogo!!");
                    Console.WriteLine("---------------------------------");
                        TotalTentativas = tentativas;
                }

                else if (NumeroDigitado < NumeroSecreto)
                {
                    Console.WriteLine("---------------------------------");
                    Console.WriteLine("O numero digitado é menor que o numero secreto ");
                    Console.WriteLine("---------------------------------");

                }
                else if (NumeroDigitado > NumeroSecreto)
                {
                    Console.WriteLine("---------------------------------");
                    Console.WriteLine("O numero digitado é maior que o numero secreto");
                    Console.WriteLine("---------------------------------");
                }
                    if(TotalTentativas == tentativas && NumeroSecreto != NumeroDigitado)
                    {
                        Console.WriteLine("Que Pena, você não conseguiu acertar o número secreto", "/n");
                        Console.WriteLine($"O número secreto era {NumeroSecreto}", "/n");
                    }
              }

                Console.WriteLine("Deseja continuar (s/n) ", "/n");
                string opcaoContinuar = Console.ReadLine().ToUpper();               
                if (opcaoContinuar != "S")
                {
                    Console.WriteLine("Obrigado Pela Presença");
                    break;
                } 

            }
        }
    }
}
