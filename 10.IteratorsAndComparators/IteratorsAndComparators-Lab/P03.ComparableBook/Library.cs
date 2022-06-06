using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        private SortedSet<Book> books;

        public Library(params Book[] books)
        {
            this.books = new SortedSet<Book>(books);
        }

        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(this.books);
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        private class LibraryIterator : IEnumerator<Book>
        {
            private List<Book> books;
            private int currentIndex;

            public LibraryIterator(SortedSet<Book> books)
            {
                currentIndex = -1;
                this.books = new List<Book>(books);
            }
            public void Dispose() { }

            public bool MoveNext() => ++this.currentIndex < this.books.Count;

            public void Reset() { }

            public Book Current => this.books[this.currentIndex];

            object IEnumerator.Current => this.Current;

        }
    }
}


