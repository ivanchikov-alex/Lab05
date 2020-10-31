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
    public class PrintedEdition : PublishingHouse
    {
        public enum EditionType { Journal, Book, Manual }
    }
    public class Journal : PrintedEdition
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
    }
    public class Book : PrintedEdition
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
    }
    public class Manual : PrintedEdition
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
    }
    public abstract class Person
    {
        public string PersonName { get; set; }
        public Person(string name)
        {
            PersonName = name;
        }
    }
    public sealed class Author : Person
    {
        public string Nickname { get; set; }
        public Author(string name, string nickame = "") : base(name)
        {
            PersonName = name;
            Nickname = nickame;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var newJournal = new Journal();
            newJournal.JournalName = "";
            newJournal.PublisherName = "";

        }
    }
}
