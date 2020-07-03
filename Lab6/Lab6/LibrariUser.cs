using System;
using System.Collections.Generic;

namespace Lab6
{
    public class LibrariUser:ILibraryUser
    {
        private string firstName;
        private string lastName;
        private int id;
        private int bookLimit;
        private string phone;
        private List<string> bookList = new List<string>();

        public LibrariUser()
        {
            firstName = "Vlad";
            lastName = "Cooper";
            id = 1;
            bookLimit = 5;
            phone = "123456789";
        }

        public LibrariUser(string first, string last, int id, int booklimit, string phone)
        {
            firstName = first;
            lastName = last;
            this.id = id;
            bookLimit = booklimit;
            this.phone = phone;
        }

        public string FirstName
        {
            get => firstName;
        }

        public string LastName
        {
            get => lastName;
        }

        public int Id
        {
            get => id;
        }

        public int BookLimit
        {
            get => bookLimit;
        }

        public string Phone
        {
            get => phone;
            set => phone = value;
        }

        public void AddBook()
        {
            Console.Clear();
            if (bookList.Count < BookLimit)
            {
                Console.Write("Write book name: ");
                string newBook = Console.ReadLine();
                bookList.Add(newBook);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You can`t add new book. Please remove another book");
                Console.ResetColor();
            }
            Console.WriteLine();
        }
        
        public void RemoveBook()
        {
            Console.Clear();
            if (bookList.Count == 0)
            {
                Console.WriteLine("You have 0 book and can`t remove something");
            }
            else
            {
                Console.Write("Write book name: ");
                string unnecessaryBook = Console.ReadLine();
                if (bookList.Remove(unnecessaryBook))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Success");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You doesn`t have this book and can`t remove it");
                    Console.ResetColor();
                }
            }
            Console.WriteLine();
        }

        public void BookInfo()
        {
            Console.Clear();
            for (int i = 0; i < bookList.Count;i++)
            {
                Console.WriteLine($"{i+1}.{bookList[i]}");
            }
            Console.WriteLine();
        }

        public void BookCount()
        {
            Console.Clear();
            Console.WriteLine($"You have {bookList.Count} books");
            Console.WriteLine();
        }
    }
}
