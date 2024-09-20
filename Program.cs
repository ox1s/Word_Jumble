using System;

namespace Word_Jumble
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Игра Словомеска
            const int NUM_WORDS = 10;
            int i = 0;

            string[][] WORDS = new string[NUM_WORDS][];
            WORDS[i++] = new string[] { "гуманитарий", "ненавистник физмата" };
            WORDS[i++] = new string[] { "математик", "любитель вычислений" };
            WORDS[i++] = new string[] { "артист", "играет в театре" };
            WORDS[i++] = new string[] { "философ", "Аристотель, тюк-тюк. БУМАЖКИ!!!" };
            WORDS[i++] = new string[] { "пельмени", "тесто, внутри мясо" };
            WORDS[i++] = new string[] { "клавиатура", "тыкать буквы на" };
            WORDS[i++] = new string[] { "прогулка", "ходишь по улице" };
            WORDS[i++] = new string[] { "наклейка", "лепить на что-нибудь" };
            WORDS[i++] = new string[] { "программист", "Любимая фраза родни: 'Ну ты ж ...'" };
            WORDS[i] = new string[] { "шиншилла", "иностранцы любят это слово" };

            // Создание объекта для генерации чисел
            Random rnd = new Random(); 
            int choice = rnd.Next(NUM_WORDS);

            string theWord = WORDS[choice][(int)Fields.WORD]; // Слово, которое нужно угадать
            string theHint = WORDS[choice][(int)Fields.HINT]; // Подсказка для слова
            
            // Перемешивание букв в слове
            string jumbleWord = Mixing(theWord,rnd); 

            // Вывод инструкций для игры
            Console.WriteLine("\t\tПриветсвуем в СЛОВОМЕСКЕ!");
            Console.WriteLine("Используй буквы для создания слова.");
            Console.WriteLine("Введи 'hint' или 'подсказка', чтобы получить подсказку.");
            Console.WriteLine("Введи 'quit' или 'выход', чтобы выйти из игры.\n");
            Console.WriteLine($"Перемешанное слово: {jumbleWord}");

            // Получение ответа от игрока
            string quess; 
            Console.Write("\n\nТвой ответ: ");
            quess = Console.ReadLine();

            // Количество попыток потраченных на угадываение слова
            int attempt = 1;

            while( (quess != theWord) && (quess != "quit" ) && (quess != "выход"))
            {
                if( quess == "hint" || quess == "подсказка")
                {
                    Console.WriteLine(theHint);
                    attempt++;
                }
                else
                {
                    Console.WriteLine("Это не правильный ответ.");
                    attempt++;
                }
                Console.Write("\n\nТвой ответ: ");
                quess = Console.ReadLine();
            }
            
            // Вывод результата игры
            if( quess == theWord)
            {
                Console.WriteLine("\nДа! Это так! Ты угадал слово.");
                Console.WriteLine("Тебе понадобилась {0} попыток", attempt);
            }
            Console.WriteLine("Спасибо за игру!");
        }

        // Метод для перемешивания букв в слове
        static string Mixing(string word, Random rnd)
        {
            char[] jumble = word.ToCharArray(); // Преобразуем строку в массив символов, т.к. в C# строка является immutable
            int length = jumble.Length;
            
            for (int i = 0; i < length; i++)
            {
                int index1 = (rnd.Next() % length);
                int index2 = (rnd.Next() % length);
                char temp = jumble[index1];
                jumble[index1] = jumble[index2];
                jumble[index2] = temp;
            }

            return new string(jumble); // Здесь идет обратное преобразование массива символов в строку
        }

        // Перечисление чисто по приколу
        enum Fields
        {
            WORD, HINT
        }
    }
}
