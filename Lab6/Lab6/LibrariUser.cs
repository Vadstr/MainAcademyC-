using System;
using System.Collections.Generic;

namespace Lab6
{
    public class LibrariUser:ILibraryUser
    {
        //private string firstName;
        //private string lastName;
        //private int id;
        //private int bookLimit;
        //private string phone;

        public string FirstName { get; } 
        public string LastName { get; } 
        public int Id { get; } 
        public int BookLimit { get; } 
        public string Phone { get; set; } 
        public List<string> bookList = new List<string>();

        public LibrariUser()
        {
            this.FirstName = "Vlad";
            this.LastName = "Cooper";
            this.Id = 1;
            this.BookLimit = 5;
            this.Phone = "123456789";
        }

        public LibrariUser(string first, string last, int id, int booklimit, string phone)
        {
            this.FirstName = first;
            this.LastName = last;
            this.Id = id;
            this.BookLimit = booklimit;
            this.Phone = phone;
        }
        
        public void AddBook()
        {
            if (bookList.Count < BookLimit)
            {
                Console.Write("Write book name: ");
                string newBook = Console.ReadLine();
                bookList.Add(newBook);
            }
            else
            {
                Console.WriteLine("You can`t add new book. Please remove another book");
            }
            Console.WriteLine();
        }
        
        public void RemoveBook()
        {
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
                    Console.WriteLine("Success");
                }
                else
                {
                    Console.WriteLine("You doesn`t have this book and can`t remove it");
                }
            }
            Console.WriteLine();
        }

        public void BookInfo()
        {
            for(int i = 0; i < bookList.Count;i++)
            {
                Console.WriteLine($"{i+1}.{bookList[i]}");
            }
            Console.WriteLine();
        }

        public void BookCount()
        {
            Console.WriteLine($"You have {bookList.Count} books");
            Console.WriteLine();
        }
    }
}
