

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Practika
{
    [Serializable]
    class WrongLoginException : Exception
    {
        public WrongLoginException() { }
        public WrongLoginException(string message) : base(message) { }
        public WrongLoginException(string message, Exception ex) : base(message) { }
        protected WrongLoginException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext contex)
            : base(info, contex) { }
    }
    [Serializable]
    class WrongPasswordException : Exception
    {
        public WrongPasswordException() { }
        public WrongPasswordException(string message) : base(message) { }
        public WrongPasswordException(string message, Exception ex) : base(message) { }
        protected WrongPasswordException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext contex)
            : base(info, contex) { }
    }
    internal class Program
    {
        
        static bool Registration(string login, string password, string confirmPassword)
        {
            bool isCharactersValid = System.Text.RegularExpressions.Regex.IsMatch(password, @"^[A-Za-z0-9_]+$");
            if ((login.Length > 20) && isCharactersValid)
            {
                WrongLoginException exc = new WrongLoginException("Ошибка! Неверный формат ввода LOGIN");
                exc.HelpLink = "https://ww.ithub.bulgakov.app";
                exc.Data.Add("Время возникновения", DateTime.Now);
                exc.Data.Add("Причина", "Не корректное значение");
                throw exc;
            }
            if ((password.Length > 20) || (password != confirmPassword) && isCharactersValid)
            {
                WrongPasswordException exc = new WrongPasswordException("Ошибка! Неверный формат ввода PASSWORD или подтверждение пороля введен неверно");
                exc.HelpLink = "https://ww.ithub.bulgakov.app";
                exc.Data.Add("Время возникновения", DateTime.Now);
                exc.Data.Add("Причина", "Не корректное значение");
                throw exc;
            }
                return true;


        }
        static void Gray()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        static void Green()
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }

        static void Red()
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }


        static void Main()
        {
            try
            {
                Console.Write("Введите login :");
                string x = Console.ReadLine();
                Console.Write("Введите password:");
                string y = Console.ReadLine();
                Console.Write("Подтвердите password:");
                string z = Console.ReadLine();


               bool result = Registration(x, y, z);
                Console.WriteLine("Готово " + result);

                Console.ReadLine();
            }
            catch (WrongLoginException ex)
            {
                Red();
                Console.WriteLine("\n Error !   \n");
                Gray();
                Console.WriteLine("\n Ошибка : \n");
                Gray();
                Console.Write(ex.Message);
                Green();
                Console.Write("Метод ");
                Gray();

                Console.Write(ex.TargetSite);
                Green();
                Console.WriteLine("Вывод стека");
                Gray();
                Console.WriteLine("Подробности на сайте:");
                Green();
                Console.WriteLine(ex.HelpLink + "\n\n");
                if (ex.Data != null)
                {
                    Console.WriteLine("Сввединия :\n");
                    Gray();
                    foreach (DictionaryEntry d in ex.Data)
                        Console.WriteLine("-> {0} {1} ", d.Key, d.Value);
                    Console.WriteLine("\n\n");
                }
                Gray();
                Main();
            }
            catch (WrongPasswordException ex)
            {
                Red();
                Console.WriteLine("\n Error !   \n");
                Gray();
                Console.WriteLine("\n Ошибка : \n");
                Gray();
                Console.Write(ex.Message);
                Green();
                Console.Write("Метод ");
                Gray();

                Console.Write(ex.TargetSite);
                Green();
                Console.WriteLine("Вывод стека");
                Gray();
                Console.WriteLine("Подробности на сайте:");
                Green();
                Console.WriteLine(ex.HelpLink + "\n\n");
                if (ex.Data != null)
                {
                    Console.WriteLine("Сввединия :\n");
                    Gray();
                    foreach (DictionaryEntry d in ex.Data)
                        Console.WriteLine("-> {0} {1} ", d.Key, d.Value);
                    Console.WriteLine("\n\n");
                }
                Gray();
                Main();
            }
        }
    }
    
}