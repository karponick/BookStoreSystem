using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreSystem.Utils
{
    public class CostCalculator
    {
        private readonly List<Book> books;

        public CostCalculator(List<Book> books)
        {
            this.books = books;
        }

        public double GetTotalCost()
        {
            double total = 0;

            foreach (var book in books)
            {
                total += book.Price;
            }

            //add tax assume it is 6%
            double tax = total * 0.06;
            total += tax;

            return total;
        }
    }
}
