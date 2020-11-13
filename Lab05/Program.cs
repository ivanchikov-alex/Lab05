using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab05
{
    public class PublishingHouse
    {
        public string PublisherName { get; set; }
    }
    public abstract class PrintedEdition : PublishingHouse
    {
        public enum EditionType { Journal, Book, Manual }
    }
    public class Journal : PrintedEdition, IShow
    {
        public EditionType Type { get; protected set; }
        public string JournalName { get; set; }

        public Journal()
        {
            Type = EditionType.Journal;
        }
        public override string ToString()
        {
            return EditionType.Journal + JournalName;
        }
        public override bool Equals(object obj)
        {
            return ToString() == obj.ToString();
        }

        public override int GetHashCode()
        {
            return ToString().Length;
        }
        public string ShowInfo()
        {
            return "Тип издания: " + Type + "\nНазвание: " + JournalName;
        }
    }
    public class Book : PrintedEdition, IShow
    {
        public EditionType Type { get; protected set; }
        public string BookName { get; set; }
        public Book()
        {
            Type = EditionType.Book;
        }
        public override string ToString()
        {
            return EditionType.Book + BookName;
        }
        public override bool Equals(object obj)
        {
            return ToString() == obj.ToString();
        }

        public override int GetHashCode()
        {
            return ToString().Length;
        }

        public string ShowInfo()
        {
            return "Тип издания: " + Type + "\nНазвание: " + BookName;
        }
    }
    public class Manual : PrintedEdition, IShow
    {
        public EditionType Type { get; protected set; }
        public string ManualName { get; set; }
        public Manual()
        {
            Type = EditionType.Manual;
        }
        public override string ToString()
        {
            return EditionType.Manual + ManualName;
        }
        public override bool Equals(object obj)
        {
            return ToString() == obj.ToString();
        }

        public override int GetHashCode()
        {
            return ToString().Length;
        }

        public string ShowInfo()
        {
            return "Тип издания: " + Type + "\nНазвание: " + ManualName;
        }
    }
    public class Printer
    {
        public static void IAmPrinting(Person newPers)
        {
            if(newPers is Author)
            {
                Console.WriteLine(newPers.ToString());
            }
            else
            {
                Author newAuthor = newPers as Author;
                Console.WriteLine(newPers.ToString());
            }
        }

        public static void IAmPrinting(PrintedEdition printedEdition)
        {
            Console.WriteLine(printedEdition.ToString());
        }
    }
    public abstract class Person
    {
        public enum Talents {JournalWriter,BookWriter,ManualWriter,Talentless }
        protected string PersonName { get; set; }
        
        public Person(string name)
        {
            PersonName = name;
        }
        public virtual void ChangePerson(string newName)
        {
            PersonName = newName;
        }
    }
    public sealed class Author : Person, IShow
    {
        public string Nickname { get; set; }
        public Talents Talent { get; set; }
        public Author(string name, string nickame = "") : base(name)
        {
            PersonName = name;
            Nickname = nickame;
            Talent = Talents.Talentless;
        }
        public void ChangePerson(string newName, Person.Talents talent)
        {
            base.ChangePerson(newName);
            Talent = talent;
        }

        public override void ChangePerson(string nickname)
        {
            Nickname = nickname;
        }
        public string ShowInfo()
        {
            return "Имя: " + PersonName + "\nПсевдоним: " + Nickname;
        }
    }
    public interface IShow
    {
        public string ShowInfo();
    }

    class Program
    {
        static void Main(string[] args)
        {
            Journal newJournal = new Journal
            {
                JournalName = "",
                PublisherName = ""
            };

            IShow showBook = new Book();
            Console.WriteLine(showBook.ShowInfo());
            Author newAuthor = new Author("name");
            Person person = newAuthor as Person;
            person.ChangePerson("newName");
            Console.WriteLine(person.ToString());

            PrintedEdition [] printedEditions = { new Book(), new Manual(), newJournal };
            for(int i=0;i<3;i++)
            {
                Printer.IAmPrinting(printedEditions[i]);
            }
        }
    }
}
