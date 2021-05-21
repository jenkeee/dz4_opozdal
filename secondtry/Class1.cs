using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2DoubleArray
{
    /// <summary>
    /// Класс работы с двумерным массивом
    /// </summary>
    public class DoubleArray
    {
        private int[,] twoDimArr;
        /// <summary>
        /// Конструктор с заполнением массива случайными числами
        /// </summary>
        /// <param name="sizeCol">число колонок</param>
        /// <param name="sizeRow">число строк</param>
        public DoubleArray(int sizeCol, int sizeRow)
        {
            Random rnd = new Random();
            twoDimArr = new int[sizeCol, sizeRow];
            for (int i = 0; i < sizeCol; i++)
            {
                for (int j = 0; j < sizeRow; j++)
                {
                    twoDimArr[i, j] = rnd.Next(0, 1001);
                }
            }
        }
        /// <summary>
        /// Конструктор с загрузкой из файла
        /// </summary>
        /// <param name="fileName"></param>
        public DoubleArray(string fileName)
        {
            LoadFromFile(fileName);
        }

        /// <summary>
        /// Сумма всех элементов массива
        /// </summary>
        public int Sum()
        {
            int sum = 0;
            foreach (var item in twoDimArr)
            {
                sum += item;
            }
            return sum;
        }
        /// <summary>
        /// Сумма всех элементов больше заданного
        /// </summary>
        /// <param name="valMin">минимальное значение числа</param>
        /// <returns></returns>
        public int Sum(int valMin)
        {
            int sum = 0;
            foreach (var item in twoDimArr)
            {
                if (item > valMin)
                {
                    sum += item;
                }
            }
            return sum;
        }
        /// <summary>
        /// Минимальное число в массиве
        /// </summary>
        public int Min
        {
            get
            {
                int min = int.MaxValue;
                foreach (var item in twoDimArr)
                {
                    if (item < min)
                    {
                        min = item;
                    }
                }
                return min;
            }
        }
        /// <summary>
        /// Максимальное число в массиве
        /// </summary>
        public int Max
        {
            get
            {
                int max = int.MinValue;
                foreach (var item in twoDimArr)
                {
                    if (item > max)
                    {
                        max = item;
                    }
                }
                return max;
            }
        }
        /// <summary>
        /// Получение позиции элемента по значению
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public (bool, int, int) GetIndexForValue(int value)
        {
            for (int i = 0; i < twoDimArr.GetLength(1); i++)
            {
                for (int j = 0; j < twoDimArr.GetLength(0); j++)
                {
                    if (twoDimArr[j, i] == value)
                    {
                        return (true, j, i);
                    }
                }
            }
            return (false, default, default);
        }
        /// <summary>
        /// Сохранение массива в файл
        /// </summary>
        /// <param name="fileName"></param>
        public void SaveToFile(string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.WriteLine($"{twoDimArr.GetLength(0)},{twoDimArr.GetLength(1)}"); //запись размера массива
                for (int i = 0; i < twoDimArr.GetLength(1); i++)
                {
                    for (int j = 0; j < twoDimArr.GetLength(0); j++)
                    {
                        writer.Write($"{twoDimArr[j, i]}");
                        if (j < twoDimArr.GetLength(0) - 1)
                        {
                            writer.Write($",");
                        }
                    }
                    writer.WriteLine();
                }
                writer.Close();
            }
        }
        /// <summary>
        /// Чтение массива из файла
        /// </summary>
        /// <param name="fileName"></param>
        public void LoadFromFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    string sSize = reader.ReadLine();
                    string[] arrSize = sSize.Split(',');
                    int sizeCol = int.Parse(arrSize[0]);
                    int sizeRow = int.Parse(arrSize[1]);
                    twoDimArr = new int[sizeCol, sizeRow];
                    int i = 0;
                    while (!reader.EndOfStream)
                    {
                        string ss = reader.ReadLine();
                        string[] arrStr = ss.Split(',');
                        for (int j = 0; j < arrStr.Length; j++)
                        {
                            twoDimArr[j, i] = int.Parse(arrStr[j]);
                        }
                        i++;
                    }
                    reader.Close();
                }
            }
            else
            {
                throw new Exception($"Такой файл \"{fileName}\" не найден!");
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < twoDimArr.GetLength(1); i++)
            {
                for (int j = 0; j < twoDimArr.GetLength(0); j++)
                {
                    sb.Append(twoDimArr[j, i] + " ");
                }
                sb.Append("\n");
            }
            return sb.ToString();
        }
    }
}