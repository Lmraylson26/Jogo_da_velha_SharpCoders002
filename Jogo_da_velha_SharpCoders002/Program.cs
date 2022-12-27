using System;
using System.ComponentModel;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using static System.Collections.Specialized.BitVector32;

namespace Jogo_da_velha_SharpCoders002
{
    public class Program
    {
        public static void Velha(List<string> options)
        {

            Console.WriteLine("");
            Console.WriteLine("           |          |");

            if (options[0] == "X")
                Console.ForegroundColor = ConsoleColor.Cyan;
            else if (options[0] == "O")
                Console.ForegroundColor = ConsoleColor.Magenta;

            Console.Write($"      {options[0]}"); Console.ResetColor(); Console.Write("    |     ");

            if (options[1] == "X")
                Console.ForegroundColor = ConsoleColor.Cyan;
            else if (options[1] == "O")
                Console.ForegroundColor = ConsoleColor.Magenta;

            Console.Write($"{options[1]}    "); Console.ResetColor(); Console.Write("|     ");

            if (options[2] == "X")
                Console.ForegroundColor = ConsoleColor.Cyan;
            else if (options[2] == "O")
                Console.ForegroundColor = ConsoleColor.Magenta;

            Console.WriteLine(options[2]); Console.ResetColor();

            Console.WriteLine(" __________|__________|__________");
            Console.WriteLine("           |          |");

            if (options[3] == "X")
                Console.ForegroundColor = ConsoleColor.Cyan;
            else if (options[3] == "O")
                Console.ForegroundColor = ConsoleColor.Magenta;

            Console.Write($"      {options[3]}"); Console.ResetColor(); Console.Write("    |     ");

            if (options[4] == "X")
                Console.ForegroundColor = ConsoleColor.Cyan;
            else if (options[4] == "O")
                Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write($"{options[4]}    "); Console.ResetColor(); Console.Write("|     ");

            if (options[5] == "X")
                Console.ForegroundColor = ConsoleColor.Cyan;
            else if (options[5] == "O")
                Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(options[5]); Console.ResetColor();


            Console.WriteLine(" __________|__________|__________");
            Console.WriteLine("           |          |");

            if (options[6] == "X")
                Console.ForegroundColor = ConsoleColor.Cyan;
            else if (options[6] == "O")
                Console.ForegroundColor = ConsoleColor.Magenta;

            Console.Write($"      {options[6]}"); Console.ResetColor(); Console.Write("    |     ");

            if (options[7] == "X")
                Console.ForegroundColor = ConsoleColor.Cyan;
            else if (options[7] == "O")
                Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write($"{options[7]}    "); Console.ResetColor(); Console.Write("|     ");

            if (options[8] == "X")
                Console.ForegroundColor = ConsoleColor.Cyan;
            else if (options[8] == "O")
                Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(options[8]); Console.ResetColor();

            Console.WriteLine("           |          |");
            Console.WriteLine("");
        }
        public static string WrongEntry(string input, List<string> wrong)
        {
            for(bool i = true; i == true;)
            {
                if (wrong.IndexOf(input) == -1)
                {
                    Console.Write("Essa Jogada é inválida, favor digitar um número válido: ");
                    input = Console.ReadLine();
                }
                else
                {
                    wrong.Remove(input);
                    i = false;
                }
            }

            return input;
        }
        public static void NewMove(List<string> options, string move, string mark)
        {
            
            int movement = int.Parse(move) - 1;
            options[movement] = mark;
        }

        public static bool Winner(List<string> options)
        {
            bool result = false;

            string[,] win = new string[8, 3] { { "1", "2", "3" }, { "4", "5", "6" }, { "7", "8", "9" }, { "1", "5", "9" }, { "3", "5", "7" }, { "1", "4", "7" }, { "2", "5", "8" }, { "3", "6", "9" } };
            for (int i = 0; i < 8; i++)
            {
                if (options.Contains(win[i, 0]) == true &&
                    options.Contains(win[i, 1]) == true &&
                    options.Contains(win[i, 2]) == true)
                    result = true;
            }
            return result;
        }

        public static bool Menu(string action, bool i, List<string> options, string player1, int winnerPlayer1, string player2, int winnerPlayer2, int draw)
        {
            
            Console.WriteLine("Para iniciar uma nova partida digite ---- [1]");
            Console.WriteLine("Para ver o placar atual digite ---------- [2]");
            Console.WriteLine("Para encerrar digite -------------------- [3]");
            Console.Write("Insira uma opção: ");
            string optionMenu = Console.ReadLine();

            switch (optionMenu) {
                case "1":
                    Velha(options);
                    i = true;
                    return i;

                case "2":
                    i = true;
                    i = ScoreBoard(action, i, options, player1, winnerPlayer1, player2, winnerPlayer2, draw);                   
                    return i;

                case "3":
                    i = false;
                    action = "final";
                    ScoreBoard(action, i, options, player1, winnerPlayer1, player2, winnerPlayer2, draw);           
                    return i;
                    
                default:
                    i = false;
                    Console.WriteLine("Essa opção é inválida, o programa será finalizado");
                    return i;
            }
        }
        public static bool ScoreBoard(string action, bool i, List<string> options, string player1, int winnerPlayer1, string player2, int winnerPlayer2, int draw)
        {

            Console.WriteLine("");
            Console.WriteLine($"- {player1} venceu {winnerPlayer1} veze(s)");
            Console.WriteLine($"- {player2} venceu {winnerPlayer2} veze(s)");
            Console.WriteLine($"- houve(ram) {draw} empate(s)");
            Console.WriteLine("");

            if (action != "final"){
              i = Menu(action, i, options, player1, winnerPlayer1, player2, winnerPlayer2, draw);
            }

            else {
                i = false;
            }                 
            
            return i;
            
        }
        public static List<string> Restart(List<string> var)
        {
            string[] arr = new string[9] {"1", "2", "3", "4", "5", "6", "7", "8", "9"};
            var.Clear();
            var.AddRange(arr);
            return var;
        }
        public static List<string> Reset(List<string> var)
        { 
            var.Clear();
            return var;
        }
        public static void Main()
        {
            Console.WriteLine(" --------------------------------- ");      
            Console.WriteLine("| Seja Bem vindo ao jogo da velha |");
            Console.WriteLine(" --------------------------------- ");
            Console.WriteLine("");
            Console.WriteLine("------------------------------------------------------------------------------------------------------ \n" +
                " O objetivo do jogo é fazer uma sequência de três símbolos iguais, \n" +
                "seja em linha vertical, horizontal ou diagonal, enquanto tenta impedir que seu adversário faça o mesmo" +
                "\n------------------------------------------------------------------------------------------------------");
            Console.WriteLine("");
            Console.Write("Digite o nome do Jogador 1: ");
            string player1 = Console.ReadLine();
            List<string> optionsPlay1 = new List<string>();
            string x = "X";
            int winnerPlayer1 = 0;
            
            Console.Write("Digite o nome do Jogador 2: ");
            string player2 = Console.ReadLine();
            List<string> optionsPlay2 = new List<string>();
            string circle = "O";
            int winnerPlayer2 = 0;

            int draw = 0;
            string action = "";

            List<string> wrongEntry = new List<string>() {"1", "2", "3", "4", "5", "6", "7", "8", "9"};

            List<string> options = new List<string>() { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            Velha(options);


            for( bool i = true; i == true;)
            {
                Console.Write($"{player1}, é sua vez, digite um dos números disponíveis acima: ");
                string move = Console.ReadLine();
                move = WrongEntry(move, wrongEntry);
                optionsPlay1.Add(move);
                NewMove(options, move,x);
                Velha(options);                

                if (optionsPlay1.Count >= 3) {


                    if (Winner(optionsPlay1) == true){

                        Reset(optionsPlay1); Reset(optionsPlay2);
                        Restart(wrongEntry); Restart(options);
                        Console.WriteLine($"{player1} é o(a) vencedor(a)!");
                        Console.WriteLine("");
                        winnerPlayer1++;
                        i = Menu(action, i, options,player1, winnerPlayer1, player2, winnerPlayer2, draw);
                       
                    }
                    else if (Winner(optionsPlay2) == true){

                        Reset(optionsPlay1); Reset(optionsPlay2);
                        Restart(wrongEntry); Restart(options);
                        Console.WriteLine($"{player2} é o(a) vencedor(a)!");
                        Console.WriteLine("");
                        winnerPlayer2++;
                        i = Menu(action, i, options, player1, winnerPlayer1, player2, winnerPlayer2, draw);
                        
                    }
                    else if (optionsPlay1.Count == 5 && optionsPlay2.Count == 4){

                        Reset(optionsPlay1); Reset(optionsPlay2);
                        Restart(wrongEntry); Restart(options);
                        Console.WriteLine($"{player1} e {player2} empataram!");
                        Console.WriteLine("");
                        draw++;
                        i = Menu(action, i, options, player1, winnerPlayer1, player2, winnerPlayer2, draw);
                       
                    } 

                }

                if (optionsPlay2.Count < 4 && i == true) {

                    Console.Write($"{player2}, é sua vez, digite um dos números disponíveis acima: ");
                    move = Console.ReadLine();
                    move = WrongEntry(move, wrongEntry);
                    optionsPlay2.Add(move);
                    NewMove(options, move, circle);

                    Velha(options);
                   
                }

                if (optionsPlay2.Count >= 3){

                    if (Winner(optionsPlay1) == true) {

                        Console.WriteLine($"{player1} é o(a) vencedor(a)!");
                        Console.WriteLine("");
                        winnerPlayer1++;
                        Reset(optionsPlay1); Reset(optionsPlay2);
                        Restart(wrongEntry); Restart(options);
                        i = Menu(action, i, options, player1, winnerPlayer1, player2, winnerPlayer2, draw);
                    }
                    else if (Winner(optionsPlay2) == true) {

                        Reset(optionsPlay1); Reset(optionsPlay2);
                        Restart(wrongEntry); Restart(options);
                        Console.WriteLine($"{player2} é o(a) vencedor(a)!");
                        Console.WriteLine("");
                        winnerPlayer2++;
                        i = Menu(action, i, options, player1, winnerPlayer1, player2, winnerPlayer2, draw);
                    }
                    else if (optionsPlay1.Count == 5 && optionsPlay2.Count == 4) {

                        Reset(optionsPlay1); Reset(optionsPlay2);
                        Restart(wrongEntry); Restart(options);
                        Console.WriteLine($"{player1} e {player2} empataram!");
                        Console.WriteLine("");
                        draw++;
                        i = Menu(action, i, options, player1, winnerPlayer1, player2, winnerPlayer2, draw);
                        
                    }                   
                }    
            }
        }
    }
}