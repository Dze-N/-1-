using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Homework_Theme_03
{
    class Program
    {
        static void Main(string[] args)
        {
            #region ex
            // Просматривая сайты по поиску работы, у вас вызывает интерес следующая вакансия:

            // Требуемый опыт работы: без опыта
            // Частичная занятость, удалённая работа
            //
            // Описание 
            //
            // Стартап «Micarosppoftle» занимающийся разработкой
            // многопользовательских игр ищет разработчиков в свою команду.
            // Компания готова рассмотреть C#-программистов не имеющих опыта в разработке, 
            // но желающих развиваться в сфере разработки игр на платформе .NET.
            //
            // Должность Интерн C#/
            //
            // Основные требования:
            // C#, операторы ввода и вывода данных, управляющие конструкции 
            // 
            // Конкурентным преимуществом будет знание процедурного программирования.
            //
            // Не технические требования: 
            // английский на уровне понимания документации и справочных материалов
            //
            // В качестве тестового задания предлагается решить следующую задачу.
            //
            // Написать игру, в которою могут играть два игрока.
            // При старте, игрокам предлагается ввести свои никнеймы.
            // Никнеймы хранятся до конца игры.
            // Программа загадывает случайное число gameNumber от 12 до 120 сообщая это число игрокам.
            // Игроки ходят по очереди(игра сообщает о ходе текущего игрока)
            // Игрок, ход которого указан вводит число userTry, которое может принимать значения 1, 2, 3 или 4,
            // введенное число вычитается из gameNumber
            // Новое значение gameNumber показывается игрокам на экране.
            // Выигрывает тот игрок, после чьего хода gameNumber обратилась в ноль.
            // Игра поздравляет победителя, предлагая сыграть реванш
            // 
            // * Бонус:
            // Подумать над возможностью реализации разных уровней сложности.
            // В качестве уровней сложности может выступать настраиваемое, в начале игры,
            // значение userTry, изменение диапазона gameNumber, или указание большего количества игроков (3, 4, 5...)

            // *** Сложный бонус
            // Подумать над возможностью реализации однопользовательской игры
            // т е игрок должен играть с компьютером


            // Демонстрация
            // Число: 12,
            // Ход User1: 3
            //
            // Число: 9
            // Ход User2: 4
            //
            // Число: 5
            // Ход User1: 2
            //
            // Число: 3
            // Ход User2: 3
            //
            // User2 победил!
            #endregion

            string input;
            bool startGame = true;
            while (startGame)
            {
                MainLoop(GamemodeChoice());
                Console.WriteLine("If u want a rematch, enter Y");
                input = Console.ReadLine();
                if(input == "Y")
                {
                    Console.WriteLine("You've chosen a rematch");
                }
                else
                {
                    Console.WriteLine("You've chosen exit");
                }

            }
        }
        
        /// <summary>
        /// Основной цикл игры
        /// </summary>
        /// <param name="gamemode">Указывает на количество игроков. 1 - игра с компьютером</param>
        public static void MainLoop(int playersCount)
        {
            int userNo = 1;
            Random rng = new Random();
            int gameNumber = rng.Next(12, 121); // число от 12 до 120, из которого отнимаются ходы-шаги в течение игры
            bool gameInProgress = true;
            if (playersCount == 1)
            {
                Console.WriteLine("You've chosen a game versus computer");
                string username = UserInput();
                
                while (gameInProgress)
                {
                    Console.WriteLine($"Gamenumber is {gameNumber}");
                    UserStep(userNo, ref gameNumber);
                    if (gameNumber <= 0 && userNo == 1)
                    {
                        Console.WriteLine($"GG. Congrats with winning, {username}! Wanna go for another run?");
                        gameInProgress = false;
                    }
                    else if (gameNumber <= 0 && userNo == 0)
                    {
                        Console.WriteLine($"GG. Sorry, but you've lost, {username}! Wanna go for another run?");
                        gameInProgress = false;
                    }

                    if (userNo == 1)
                    {
                        userNo = 0;
                    }
                    else
                    {
                        userNo++;
                    }
                }
            }
            else
            {
                Console.WriteLine($"You've chosen a multiplayer game with {playersCount} users");
                List<string> usernames = new List<string>(10);                                
                for(int i = 0; i < playersCount; i++)
                {
                    Console.WriteLine($"User {i+1} expected.");
                    usernames.Add(UserInput());
                }
                                
                while (gameInProgress)
                {
                    Console.WriteLine($"Gamenumber is {gameNumber}");
                    UserStep(userNo, ref gameNumber);
                    if (gameNumber <= 0)
                    {
                        Console.WriteLine($"GG! Congrats {usernames[userNo-1]}, wanna go for another round?");
                        gameInProgress = false;
                    }

                    if(userNo == playersCount)
                    {
                        userNo = 1;
                    }
                    else
                    {
                        userNo++;
                    }
                }
            }
        }

        /// <summary>
        /// Выбор игрового режима согласно вводу пользователя
        /// </summary>
        /// <returns>Возвращает число от 1 до 10, соответствуя вводу пользователя</returns>
        public static int GamemodeChoice()
        {
            Console.WriteLine(
                "Hello! Before we start the game, choose player count!\n" +
                "1 is a game vs computer.\n" +
                "from 2 to 10 is a game between 2 to 10 players");
            int gamemodeChoice = 0;
            while (true)
            {
                gamemodeChoice = IntegerInput();
                if (gamemodeChoice >= 1 && gamemodeChoice <= 10)
                {
                    return gamemodeChoice;
                }
                else
                {
                    Console.WriteLine("Wrong gamemode input");
                }
            }            
        }

        /// <summary>
        /// Возвращает число от 0 до 99, которое введёт в консоль пользователь
        /// </summary>
        /// <returns>Возвращает int</returns>
        public static int IntegerInput()
        {
            Regex regex = new Regex("\\d{1,2}");
            bool checkDone = false; //ожидание ввода, пока ввод не будет корректен
            while (!checkDone)
            {
                Console.WriteLine("Expected digits:");
                Match match = regex.Match(Console.ReadLine());
                if (match.Value != "")
                {
                    return Convert.ToInt32(match.Value);
                }
                else
                {
                    Console.WriteLine("Wrong input");
                }

            }
            return -666; //ошибка, если каким-то образом  не нашлось числа
        }

        /// <summary>
        ///  Произведение игрового хода
        /// </summary>
        /// <param name="userNo"> № пользователя, 0 если это компьюютер</param>
        /// <param name="gameNumber">игровое число, из которого отнимаются числа-ходы</param>
        public static void UserStep(int userNo, ref int gameNumber)
        {
            int userTry; //число - ход
            if (userNo == 0)
            {
                Random rng = new Random();
                userTry = rng.Next(1, 5);
                Console.WriteLine(
                    "Computer thinking...\n" +
                    $"Computer chooses number: {userTry}"); //ход компьютера от 1 до 4
                gameNumber -= userTry;
            }
            else
            {                
                Console.WriteLine($"Your step, User №{userNo}:");
                while (true)
                {
                    userTry = IntegerInput();
                    if (userTry >= 1 && userTry <= 4)
                    {
                        Console.WriteLine($"Number {userTry} chosen");
                        gameNumber -= userTry;
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Wrong number chosen (expected 1 to 4)");
                    }
                }
            }            
        }
    
        /// <summary>
        /// Ввод юзеров из консоли
        /// </summary>
        /// <returns>Строка содержающая username игрока</returns>
        public static string UserInput()
        {
            Console.WriteLine("Enter Your Username:");
            return Console.ReadLine();
        }
    }


}
