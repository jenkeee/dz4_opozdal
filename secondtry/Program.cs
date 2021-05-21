using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using ClassLibrary2DoubleArray; // и еще раз
using coolfromtyrnet;  // мне нужен класс из другого неймспейса //для примера



namespace secondtry
{
    class Program
    {
        #region menu
        ///////////////////////////cсоздадим метод проверки ввода
        static int Checktoparse(string message)
        {
            string num_before;
            bool flag_ornum;
            int num_after;
            do
            {
                                num_before = Console.ReadLine();

                flag_ornum = int.TryParse(num_before, out num_after);
            } while (!flag_ornum);
            return num_after;

        }
        static void Main(string[] args)
        {
            int value;
            do
            {
                Console.Title = ("Меню");
                Console.Clear();
                HelpCS.MyHeader(text: "Главное меню.");
                Console.WriteLine("Введите номер задачи от 1 до 5. принимаются только целые числа.");
                value = Checktoparse(""); // даем значение велью методом GetValue // и там метод уже либо пропустит int32 либо будет бесконечно вызыватся, пока ты не напишиш цифры удовлетворяющие условия
                // гет валью дает нам проверку на вводимы знаки, а диапазон мы сдесь даже не ставили У НАС ВСЕГО 3 КЕЙСА

                HelpCS.MyFooter();
                switch (value)
                {
                    case 1:
                        dz1();
                        break;
                    case 2:
                        dz2();
                        break;
                    case 3:
                        dz3();
                        break;
                    case 4:
                        dz4();
                        break;
                    case 5:
                        dz5();
                        break;

                }
            } while (true);
            #endregion
        }
        #region задание 1
        /// <summary>
        ///1.	Дан  целочисленный  массив  из 20 элементов.  Элементы  массива  могут принимать  целые  значения  от –10 000 до 10 000 включительно. 
        ///Заполнить случайными числами.  Написать программу, позволяющую найти и вывести количество пар элементов массива, в которых только одно число делится на 3. 
        ///В данной задаче под парой подразумевается два подряд идущих элемента массива. Например, для массива из пяти элементов: 6; 2; 9; –3; 6 ответ — 2. 
        /// </summary>
        /// 
        /// 
        /// <summary>Метод подсчёта количества пар элементов массива, в которых хотя бы одно число делится на 3</summary>
        /// <param name="array">Массив элементов</param>
        /// <param name="length">Длинна массива элементов</param>
        /// <returns></returns>
        static int GetNumberOfPairs(int[] array, int length)
        {
            int amountOfPairs = 0;
            for (int i = 0; i < length - 1; i++)
            {
                if (array[i] % 3 == 0 || array[i + 1] % 3 == 0)
                {
                    amountOfPairs++;
                }
            }
            return amountOfPairs;
        }
        static void dz1()
        {
            Console.Clear();
            
            HelpCS.MyHeader(text: "1.Дан  целочисленный массив  из 20 элементов.");
            const int arrayLength = 20;
            int[] myArray = new int[arrayLength];
            Random random = new Random();
            int result;

            Console.WriteLine("Привет, сейчас мы посчитаем масив из 20ти элементов, и условие проверки будет. (array[i] % 3 == 0 || array[i + 1] % 3 == 0) делится на 3 без остатка");
            Console.Write("\nПолучаем масив в диапазоне (-10000, 10001) \n [");
            for (int i = 0; i < arrayLength; i++)
            {
                myArray[i] = random.Next(-10000, 10001); // от включая идет, а до не включа, поэтому +1 
                Console.Write(myArray[i] + ", ");
            }
            Console.WriteLine("\b\b ]\n");

            result = GetNumberOfPairs(myArray, arrayLength);

            Console.WriteLine($"Количество пар удовлетворяющих условие: {result}");
            HelpCS.MyFooter();
            Console.ReadKey();
        }
        #endregion
        #region задание 2
        /// <summary>
        ///2.	Реализуйте задачу 1 в виде статического класса StaticClass;
        ///а) Класс должен содержать статический метод, который принимает на вход массив и решает задачу 1;
        ///б) *Добавьте статический метод для считывания массива из текстового файла.Метод должен возвращать массив целых чисел;
        ///в)**Добавьте обработку ситуации отсутствия файла на диске.
        /// </summary>
        static void dz2() // работа так или иначе принесет плоды, я наконецто понял что такое классы и как ими пользоватся подглядев решение  
        {
            Console.Clear();
            HelpCS.MyHeader(text: "Задача 2. Добавление статического класса StaticClass."); // так получилось что нашел интиресную библиотеку Myhelper, буду использовать дальше
                                                                                              // и дорабатывать в чем я сомневаюсь если конечно надо туда лезть
                                                                                              // очень понравился хелпер,
            //Console.Title = "Реализуйте задачу 1 в виде статического класса StaticClass;";
           
            WriteLine("Пункт А. Статический класс решения поставленной задачи.");
            int[] arrInts = StaticClass.GetArrayWithRandomNum(20); //получить массив
            WriteLine("Массив элементов из случайных чисел:");
            Array.ForEach(arrInts, WriteLine); //вывод массива
            WriteLine();
            int count = StaticClass.GetCountGoodNumbers(arrInts); //получить количество пар
            WriteLine($"Кол-во пар элементов массива, в которых только одно число делится на три = {count}");
            HelpCS.MyPause();
            ///////////////////////////////////////////////////////////////////////////////////
            WriteLine("Пункт Б. Статический метод считывания массива из текстового файла.");
            int[] arrLoaded = StaticClass.LoadArrayFromFile(@"..\..\data.txt");
            WriteLine("Массив загруженных элементов из файла:");
            Array.ForEach(arrLoaded, WriteLine); //вывод массива
            WriteLine();
            HelpCS.MyPause();
            ///////////////////////////////////////////////////////////////////////////////////
            WriteLine("Пункт В. Обработка ситуации отсутствия файла на диске.");
            HelpCS.MyPause("Начинаю считывать данные из файла 'не существует.txt'. Нажмите любую кнопку...");

            int[] arrNoLoaded = default; // инициалиируем 
            
                try
                {
                    arrNoLoaded = StaticClass.LoadArrayFromFile(AppDomain.CurrentDomain.BaseDirectory + "data2.txt");
                }
                catch (Exception error) when (error.Data != null)
            {

                HelpCS.MyPause(error.Message + "\nДальнейшая работа программы невозможна. Нажмите любую кнопку ...");               
                
               }
          ///////////////////////////////// пытаюсь понять как не выходить из метода а перейти к следующим инструкциям // это клнечно if
            WriteLine("Массив загруженных элементов из файла:");
            if (arrNoLoaded != arrNoLoaded) Array.ForEach(arrNoLoaded, WriteLine); //вывод массива  // добавил if что оно есть вобще 
            WriteLine(arrNoLoaded);
            HelpCS.MyFooter();
            ReadKey();

        }
        #endregion
        #region задание 3
        /// <summary>
        /// Задача 3
        /// а) Дописать класс для работы с одномерным массивом. Реализовать конструктор, создающий массив
        /// определенного размера и заполняющий массив числами от начального значения с заданным шагом.
        /// Создать свойство Sum, которое возвращает сумму элементов массива, метод Inverse, возвращающий
        /// новый массив с измененными знаками у всех элементов массива (старый массив, остается без
        /// изменений), метод Multi, умножающий каждый элемент массива на определённое число, свойство
        /// MaxCount, возвращающее количество максимальных элементов. 
        /// б)** Создать библиотеку содержащую класс для работы с массивом. Продемонстрировать работу библиотеки
        /// </summary>
        static void dz3()
        {
           Console.Clear();
            HelpCS.MyHeader(text: "Задача 3. Класс для работы с одномерным массивом.");
            ///////////////////////////////////////////////////////////////////////////////////
            WriteLine("Пункт А. Добавленные члены в класс для работы с одномерным массивом.");
            HelpCS.GetNumberFromConsole(out int size, "Размер массива (int)", cancelEnable: false);
            HelpCS.GetNumberFromConsole(out int step, "Шаг заполнения массива (int)", cancelEnable: false);
            CoolArray coolArray = new CoolArray(size, step);
            WriteLine("Сгенерированный массив:");
            for (int i = 0; i < coolArray.Length; i++)
            {
                Write($"{coolArray[i]} ");
            }
            WriteLine();
            int sum = coolArray.Sum;
            WriteLine($"Сумма элементов массива = {sum}");
            int[] arrInverse = coolArray.Inverse();
            WriteLine("Измененный массив с измененными знаками у всех элементов:");
            for (int i = 0; i < arrInverse.Length; i++)
            {
                Write($"{arrInverse[i]} ");
            }
            WriteLine();
            CoolArray.Multi(arrInverse, 2);
            WriteLine("Этот же массив со значениями, перемноженными на число 2:");
            for (int i = 0; i < arrInverse.Length; i++)
            {
                Write($"{arrInverse[i]} ");
            }
            WriteLine();
            int maxCount = coolArray.MaxCount;
            WriteLine($"Количество максимальных элементов: {maxCount}");
            HelpCS.MyPause();
            ///////////////////////////////////////////////////////////////////////////////////
            WriteLine("Пункт Б. Библиотека с классом для работы с массивом.");
            CoolLibArray coolLibArray = new CoolLibArray(30);
            WriteLine("Сгенерированный массив с помощью библиотеки:");
            for (int i = 0; i < coolLibArray.Length; i++)
            {
                Write($"{coolLibArray[i]} ");
            }
            WriteLine();
            WriteLine($"Сумма элементов массива = {coolLibArray.Sum}");
            WriteLine($"Количество максимальных элементов: {coolLibArray.MaxCount}");
            HelpCS.MyPause();
            HelpCS.MyFooter();
        }
        /// <summary>
        /// Получение словаря с чатотой вхождения каждого элемента
        /// </summary>
        /// <param name="array">массив</param>
        /// <returns>словарь</returns>
        static Dictionary<int, int> getDictionary(CoolArray array)
        {
            Dictionary<int, int> returnMe = new Dictionary<int, int>();
            for (int i = 0; i < array.Length; i++)
            {
                if (returnMe.ContainsKey(array[i]))
                {
                    returnMe[array[i]]++;
                }
                else
                {
                    returnMe.Add(array[i], 1);
                }
            }
            return returnMe;
        }
        #endregion
        #region 4
        /// <summary>
        /// Задача 4
        /// Решить задачу с логинами из урока 2, только логины и пароли считать из файла в массив.
        /// Создайте структуру Account, содержащую Login и Password.
        /// </summary>
        static void dz4()
        {
            Console.Clear();
            HelpCS.MyHeader(text: "Задача 4. Логины и пароли из файла. ");
            ///////////////////////////////////////////////////////////////////////////////////
            Accounts accounts = new Accounts(@"..\..\TextFileLoginPassword.txt"); //получение логин паролей из файла
            var (authYes, login) = Accounts.AuthLoginFromConsole(accounts); 
            if (authYes) //вход по логину и паролю ползователя
            {
                WriteLine($"Здравствуйте, {login}! Вы успешно вошли в всистему! Логин пароль правильные.");
                Beep(3000, 100);
            }
            else
            {
                WriteLine("Прощайте! Вам не удалось войти в систему. Кончились попытки ввода логина и пароля.");
                Beep(300, 2000);
            }
            ///////////////////////////////////////////////////////////////////////////////////
            HelpCS.MyFooter();
        }

        #endregion
        #region задание 5
        /// <summary>
        /// 5.
        /// а) Реализовать библиотеку с классом для работы с двумерным массивом.Реализовать конструктор, заполняющий массив случайными числами.Создать методы, которые возвращают 
        /// сумму всех элементов массива, сумму всех элементов массива больше заданного, свойство, возвращающее минимальный элемент массива, свойство, возвращающее максимальный элемент массива, метод, 
        /// возвращающий номер максимального элемента массива(через параметры, используя модификатор ref или out).
        /// *б) Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.
        /// ** в) Обработать возможные исключительные ситуации при работе с файлами.
        /// </summary>
        static void dz5()
                    {
            Console.Clear();
            HelpCS.MyHeader(text: "Задача 5. Библиотека с классом для работы с двумерным массивом. ");
            ///////////////////////////////////////////////////////////////////////////////////
            WriteLine("Пункт А. Реализовать библиотеку с классами для работы с массивом.");
            if (HelpCS.GetNumberFromConsole(out int colCount, "Введите число колонок у массива (int) (q-отмена)"))
            {
                if (HelpCS.GetNumberFromConsole(out int rowCount, "Введите число строк у массива (int) (q-отмена)"))
                {
                    DoubleArray doubleArray = new DoubleArray(colCount, rowCount);
                    WriteLine("Массив заполненный случайными числами:");
                    WriteLine(doubleArray);
                    WriteLine($"Сумма всех элементов массива = {doubleArray.Sum()}");
                    WriteLine("Сумма всех элементов массива больше заданного:");
                    if (HelpCS.GetNumberFromConsole(out int minValue, "Введите заданное число (int) (q-отмена)"))
                    {
                        WriteLine($"Сумма всех элементов массива больше заданного = {doubleArray.Sum(minValue)}");
                        WriteLine($"Минимальный элемент массива равен {doubleArray.Min}");
                        int max = doubleArray.Max;
                        WriteLine($"Максимальный элемент массива равен {max}");
                        var (_, numCol, numRow) = doubleArray.GetIndexForValue(max);
                        WriteLine($"Он находится в колонке {numCol + 1} и строке {numRow + 1}");
                        HelpCS.MyPause();
                    }
                }
            }
            ///////////////////////////////////////////////////////////////////////////////////
            WriteLine("Пункт Б. Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.");
            DoubleArray loadDoubleArray = new DoubleArray(@"..\..\DoubleArrayFile.txt");
            WriteLine("\nСконструированный массив по файлу:");
            WriteLine(loadDoubleArray);
            WriteLine("-> Новый массив");
            DoubleArray newDoubleArray = new DoubleArray(10, 5);
            WriteLine("-> Запись нового массива в файл");
            newDoubleArray.SaveToFile(@"..\..\NewDoubleArrayFile.txt");
            WriteLine("-> Чтение нового массива из файла");
            newDoubleArray.LoadFromFile(@"..\..\NewDoubleArrayFile.txt");
            WriteLine("\nНовый массив прочитанный из файла:");
            WriteLine(newDoubleArray);
            HelpCS.MyPause();
            ///////////////////////////////////////////////////////////////////////////////////
            WriteLine("Пункт В. Обработать возможные исключительные ситуации при работе с файлами.");
            HelpCS.MyPause("\nЧтение несуществующего файла ->");
            try
            {
                DoubleArray nonDoubleArray = new DoubleArray("НетТакогоФайла.txt");
            }
            catch (Exception e)
            {
                WriteLine("Исключение: " + e.Message);
            }
            HelpCS.MyPause("\nПопытка записи в уже открытый файл ->");
            DoubleArray hackDoubleArray = new DoubleArray(3, 3);
            try
            {
                hackDoubleArray.SaveToFile("ConsoleApp5DoubleArray.exe");
            }
            catch (Exception e)
            {
                WriteLine("Исключение: " + e.Message);
            }
            ///////////////////////////////////////////////////////////////////////////////////
            HelpCS.MyFooter();
        }
        #endregion
    }
    #region мои классы
    class Mymassiv
    {
        int[] a; // создадим переменную для масива.


        //  Создание массива и заполненим его случайными числами от min до max
        public Mymassiv(int n, int min, int max)
        {
            a = new int[n];
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
                a[i] = rnd.Next(min, max);
        }
    }
    #endregion


}
