using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Theme_01
{
    class Program
    {
        static void Main(string[] args)
        {
            #region exercices
            // Заказчик просит написать программу «Записная книжка». Оплата фиксированная - $ 120.

            // В данной программе, должна быть возможность изменения значений нескольких переменных для того,
            // чтобы персонифецировать вывод данных, под конкретного пользователя.

            // Для этого нужно: 
            // 1. Создать несколько переменных разных типов, в которых могут храниться данные
            //    - имя;
            //    - возраст;
            //    - рост;
            //    - баллы по трем предметам: история, математика, русский язык;

            // 2. Реализовать в системе автоматический подсчёт среднего балла по трем предметам, 
            //    указанным в пункте 1.

            // 3. Реализовать возможность печатки информации на консоли при помощи 
            //    - обычного вывода;
            //    - форматированного вывода;
            //    - использования интерполяции строк;

            // 4. Весь код должен быть откомментирован с использованием обычных и хml-комментариев

            // **
            // 5. В качестве бонусной части, за дополнительную оплату $50, заказчик просит реализовать 
            //    возможность вывода данных в центре консоли.
            #endregion

            
            string name = "Oleg"; // имя
            int age = 16; // возраст
            double height = 190.1; // рост в сантиметрах
            int scoreMath = 10; // оценка математика
            int scoreHystory = 8; // оценка история
            int scoreRus = 7; // оценка русский

            double averageScore = GetAverageScore(scoreMath, scoreHystory, scoreRus); // запись среднего в переменную

            Console.WriteLine(name + age + height + scoreMath + scoreHystory + scoreRus + averageScore + '\n'); // обычный вывод

            Console.WriteLine(
                "\nИмя: " + name +
                "\nВозраст: " + age +
                " лет\nВысота: " + height +
                " см\nБалл по математике: " + scoreMath +
                "\nБалл по истории: " + scoreHystory +
                "\nБалл по русскому языку: " + scoreRus +
                "\nСредний балл: " + averageScore + '\n'); //форматированный вывод

            Console.WriteLine(
                $"Имя: {name}\n" +
                $"Возраст: {age} лет\n" +
                $"Высота: {height} см\n" +
                $"Балл по математике: {scoreMath}\n" +
                $"Балл по истории: {scoreHystory}\n" +
                $"Балл по русскому языку: {scoreRus}\n" +
                $"Средний балл: {averageScore}"); //форматированный вывод с интерполяцией строк

            PrintCenteredInfo(name, age, height, scoreMath, scoreHystory, scoreRus, averageScore);


        }

        /// <summary>
        /// Средняя оценка по трём предметам
        /// </summary>
        /// <param name="subj1"> Оценка по первому предмету </param>
        /// <param name="subj2"> Оценка по второму предмету </param>
        /// <param name="subj3"> Оценка по третьему предмету </param>
        /// <returns> Возвращает среднее по трём предметам </returns>
        public static double GetAverageScore(int subj1, int subj2, int subj3)
        {
            return ((subj1 + subj2 + subj3) / 3.0); // подсчёт среднего
        }

        /// <summary>
        /// Вывести данные по центру консоли
        /// </summary>        
        public static void PrintCenteredInfo(string name, int age, double height, int scoreMath, int scoreHystory, int scoreRus, double averageScore)
        {
            List<string> bufferStr = new List<string>(7)
            {
                name,
                age.ToString(),
                height.ToString(),
                scoreMath.ToString(),
                scoreHystory.ToString(),
                scoreRus.ToString(),
                averageScore.ToString()
            }; // список строк, которые будут выведены в центре консоли
            int centerX; // переменная для центра по X
            int centerY; // переменная для центра по Y
            for (int i = 0; i < 7; i++) // цикл на 7 итераций
            {
                centerX = (Console.WindowWidth / 2) - (bufferStr[i].Length / 2); // вычисление положения по центру консоли по Х
                centerY = (Console.WindowHeight / 2) - 1; // вычисление положения по центру консоли по Y
                Console.SetCursorPosition(centerX, centerY + i); // переместить курсор в центр
                Console.Write(bufferStr[i]); // вывод в центр консоли
            }

        }
    }
}
