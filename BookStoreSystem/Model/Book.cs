using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreSystem
{
    public class Book
    {
        private int id, pages;
        private string title, author, genre, description;
        private double price;
        private DateTime publication;

        public Book() { }
        public Book(string idString, string pagesString, string priceString)
        {
            int.TryParse(idString, out id);
            int.TryParse(pagesString, out pages);
            double.TryParse(priceString, out price);
        }

        public int Id { get { return id; } set {  id = value; } }
        public string Title { get { return title; } set { title = value; } }
        public string Author { get { return author; } set { author = value; } }
        public string Genre { get {  return genre; } set {  genre = value; } }
        public string Description { get { return description; } set { description = value; } }
        public int Pages { get { return pages; } set { pages = value; } }
        public double Price { get { return price; } set { price = value; } }
        public DateTime Publication { get {  return publication; } set {  publication = value; } }

        public string[] ToArray()
        {
            return new string[] { id.ToString(), title, author, genre, description, pages.ToString(), price.ToString(), publication.ToString() };
        }
    }
}
