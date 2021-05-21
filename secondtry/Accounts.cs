using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace secondtry
{
    /// <summary>
    /// Аккаунты пользователей
    /// </summary>
    public class Accounts
    {
        private Account[] accounts;
        /// <summary>
        /// Аккаутны пользователя из файла
        /// </summary>
        /// <param name="fileName">имя файла</param>
        public Accounts(string fileName)
        {
            accounts = new Account[0];
            using (StreamReader reader = new StreamReader(fileName))
            {
                while (!reader.EndOfStream)
                {
                    string s = reader.ReadLine();
                    string[] strs = s.Split(',');
                    Array.Resize(ref accounts, accounts.Length + 1);
                    accounts[accounts.Length - 1] = new Account(strs[0], strs[1]);
                }
            }
        }
        /// <summary>
        /// Проверка на правильность логина
        /// </summary>
        /// <param name="login">логин</param>
        /// <returns>правильный логин</returns>
        public bool IsValidLogin(string login)
        {
            foreach (Account item in accounts)
            {
                if (item.Login == login)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Проверка на правильность логина и пароля
        /// </summary>
        /// <param name="login">логин</param>
        /// <param name="password">пароль</param>
        /// <returns>правильная пара логин пароль</returns>
        public bool IsValidLoginPassword(string login, string password)
        {
            foreach (Account item in accounts)
            {
                if (item.IsValid(login, password))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Аккаунт пользователя
        /// </summary>
        internal struct Account
        {
            private string login;
            private string password;
            //установка первоначальных значений
            public Account(string login, string password)
            {
                this.login = login;
                this.password = password;
            }
            //правильность логин пароля
            public bool IsValid(string login, string password)
            {
                return (this.login == login && this.password == password);
            }
            //логин пользователя
            public string Login => login;
        }



        /// <summary>
        /// Вход с консоли с проверкой логина пароля
        /// </summary>
        /// <param name="accounts">аккаунты имеющиеся</param>
        /// <returns>признак входа и логин</returns>
        internal static (bool, string) AuthLoginFromConsole(Accounts accounts)
        {
            int countTry = 3;
            string login = default;
            while (countTry > 0)
            {
                Console.Write("Введите свой логин:> ");
                login = Console.ReadLine();
                if (accounts.IsValidLogin(login))
                {
                    break;
                }
                Console.WriteLine($"Такой логин отсутствует в списке. У вас осталось {countTry} попыток.");
                Console.Beep(500, 500);
                countTry--;
            }
            while (countTry > 0)
            {
                Console.Write("Введите пароль:> ");
                string password = Console.ReadLine();
                if (accounts.IsValidLoginPassword(login, password))
                {
                    return (true, login);
                }
                Console.WriteLine($"Неправильный пароль! У вас осталось {countTry} попыток.");
                Console.Beep(500, 500);
                countTry--;
            }
            return (false, default);

        }

    }
}