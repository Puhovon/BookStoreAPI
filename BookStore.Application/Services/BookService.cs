using BookStore.Core.Abstractions;
using BookStore.Core.Models;

namespace BookStore.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBooksRepository _booksRepoitory;
        public BookService(IBooksRepository repository)
        {
            _booksRepoitory = repository;
        }

        public async Task<List<Book>> GetAllBooks()
        {
            return await _booksRepoitory.Get();
        }

        public async Task<Guid> CreateBook(Book book)
        {
            return await _booksRepoitory.Create(book);
        }

        public async Task<Guid> UpdateBook(Guid id, string title, string description, decimal price)
        {
            return await _booksRepoitory.Update(id, title, description, price);
        }

        public async Task<Guid> DeleteBook(Guid id)
        {
            return await _booksRepoitory.Delete(id);
        }
    }
}
