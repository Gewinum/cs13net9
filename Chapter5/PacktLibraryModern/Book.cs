using System.Diagnostics.CodeAnalysis;

namespace Packt.Shared
{
    public class Book
    {
        #region Fields
        public required string? Isbn;
        public required string? Title;
        public string? Author;
        public int PageCount;
        #endregion

        #region Constructors
        public Book() { }

        [SetsRequiredMembers]
        public Book(string? isbn, string? title)
        {
            Isbn = isbn;
            Title = title;
        }
        #endregion
    }
}
