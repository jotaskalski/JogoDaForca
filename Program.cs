namespace JogoDaForca
{
    internal class Program
    {
        static int numeroTentativa = 5;
        static string palavraSecreta;

        static List<string> letrasErradas = new List<string>();
        static List<string> letraCertas = new List<string>();

        static string[] palavrasJogos = {"Abacate", "Abacaxi", "Acerola", "Açaí", "Araça", "Bacaba", "Bacuri", "Banana", "Cajá", "Cajú", "Carambola", "Cupuaçu", "graviola", "Goiaba", "Jabuticaba", "Jenipapo", "Maça", "Mangaba", "Manga", "Maracujá", "Murici", "Pequi", "Pitanga", "Pitaya", "Sapoti", "Tangerina", "Umbu", "Uva", "Uvaia"};

        static void Main(string[] args)
        {

            do
            {
                Console.Clear();
                palavraAleatoria();
                inicializarJogo();

            } while (true);
        }
        static void palavraAleatoria()
        {
            Random random = new Random();
            int indexPalavraSecreta = random.Next(0, 29);
            palavraSecreta = palavrasJogos[indexPalavraSecreta];
        }
        static void inicializarJogo()
        {
            letrasErradas = new List<string>();
            letraCertas = new List<string>();
            numeroTentativa = 5;

            do
            {
                Console.Clear();
                string palavraToUpper = palavraSecreta.ToUpper();
                char[] arrayPalavraRandomica = palavraToUpper.ToCharArray();
                int contadorAuxiliar = 0;

                desenharForca();

                if (numeroTentativa <= 0)
                {
                    Console.WriteLine("Você perdeu, mais sorte na próxima...");
                    Console.WriteLine($"A palavra era: {palavraSecreta.ToUpper()}");
                    Console.ReadLine();
                    return;
                }

                foreach (char c in arrayPalavraRandomica)
                {

                    if (letraCertas.Contains(c.ToString()))
                    {
                        Console.Write(c);
                        contadorAuxiliar++;
                    }
                    else
                    {
                        Console.Write("_");
                    }
                }

                Console.WriteLine("\n");

                if (palavraSecreta.Length == contadorAuxiliar)
                {
                    Console.WriteLine("Acertou a palavra!");
                    Console.ReadLine();
                    return;
                }

                mostrarLetrasErradas();

                Console.WriteLine($"Tentativas restantes: {numeroTentativa}");
                Console.Write("Digite uma letra: ");

                string letraChutada = Console.ReadLine();
                letraChutada = letraChutada.ToUpper();
                verificarLetraChutada(letraChutada);

            } while (numeroTentativa != -1);
            Console.ReadLine();
        }
        static void desenharForca()
        {
            Console.WriteLine(" ________");
            Console.WriteLine(" |      |");
            Console.WriteLine(" |      " + (numeroTentativa < 5 ? "O" : ""));
            Console.WriteLine(" |     " + (numeroTentativa < 3 ? "/" : "") + (numeroTentativa < 4 ? "|" : "") + (numeroTentativa < 2 ? "\\" : ""));
            Console.WriteLine(" |     " + (numeroTentativa < 2 ? "/" : "") + " " + (numeroTentativa < 1 ? "\\" : ""));
            Console.WriteLine("_|_");

            Console.WriteLine();

        }
        static void mostrarLetrasErradas()
        {
            Console.Write("Letras erradas: ");
            letrasErradas.ForEach(x => Console.Write($"{x} "));
        }
        static void verificarLetraChutada(string letra)
        {
            string palavrasToUpper = palavraSecreta.ToUpper();
            int index = palavrasToUpper.IndexOf(letra);

            if (index == -1)
            {
                letrasErradas.Add(letra);
                Console.WriteLine("A palavra secreta não possui essa letra");
                numeroTentativa--;
                Console.ReadLine();
                return;
            }
            else
            {
                Console.WriteLine("Você acertou uma letra!");
                letraCertas.Add(letra);
                Console.ReadLine();
                return;
            }

        }
    }
}

