using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coolfromtyrnet
{
    /// <summary>
    /// Класс массива
    /// </summary>
    public class CoolLibArray
    {
        private int[] arr;
        Random rnd = new Random();
        public CoolLibArray(int size)
        {
            arr = new int[size];
            for (int i = 0; i < size; i++)
            {
                arr[i] = rnd.Next(1, 101);
            }
        }
        /// <summary>
        /// Конструтор, создающий массив введенного размера и заполняющий масив числами от начального значения с введенным шагом
        /// </summary>
        /// <param name="size">массив</param>
        /// <param name="step">шаг</param>
        public CoolLibArray(int size, int step)
        {
            arr = new int[size];
            for (int i = 0; i < size; i++)
            {
                arr[i] = i * step;
            }
        }
        public CoolLibArray(string fileName)
        {
            if (File.Exists(fileName))
            {
                string[] ss = File.ReadAllLines(fileName);
                arr = new int[ss.Length];
                for (int i = 0; i < ss.Length; i++)
                {
                    arr[i] = int.Parse(ss[i]);
                }
            }
        }
        /// <summary>
        /// Получение максимального значения
        /// </summary>
        public int Max
        {
            get => arr.Max();
        }
        /// <summary>
        /// Сумма значений
        /// </summary>
        public int Sum
        {
            get => arr.Sum();
        }
        /// <summary>
        /// Получение массива с измененными знаками у всех элементов массива
        /// </summary>
        /// <returns></returns>
        public int[] Inverse()
        {
            int[] returnMe = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                returnMe[i] = -arr[i];
            }
            return returnMe;
        }
        /// <summary>
        /// Умножение каждого элемента массива на определенное число
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="value"></param>
        public static void Multi(int[] arr, int value)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] *= value;
            }
        }
        /// <summary>
        /// Количество максимальных элементов
        /// </summary>
        public int MaxCount
        {
            get
            {
                int max = Max;
                int count = 0;
                foreach (var item in arr)
                {
                    if (item == max)
                    {
                        count++;
                    }
                }
                return count;
            }
        }
        public int this[int i]
        {
            get => arr[i];
            set => arr[i] = value;
        }

        public int Length
        {
            get => arr.Length;
        }
        public string Print()
        {
            StringBuilder sb = new StringBuilder();
            Array.ForEach(arr, i => sb.Append($"{i,4} "));
            return sb.ToString();
        }
    }

}