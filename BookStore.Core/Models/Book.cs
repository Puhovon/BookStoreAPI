namespace BookStore.Core.Models
{
    public class Book
    {
        public const int MAX_TITLE_LENGTH = 250;
        public const int MAX_DESCRIPTION_LENGTH = 500;
        public const int MAX_PRICE= 100_000;

        private Book(Guid id, string title, string description, decimal price)
        {
            Id = id;
            Title = title;
            Description = description;
            Price = price;
        }

        public Guid Id { get; }
        public string Title { get; } = string.Empty;
        public string Description { get; } = string.Empty;

        public decimal Price { get; }

        public static (Book book, string Error) Create(Guid id, string title, string description, decimal price)
        {
            var error = string.Empty;

            if (string.IsNullOrEmpty(title) || title.Length > MAX_TITLE_LENGTH)
            {
                error = "Title can not be empty or longer then 250 symbols";
            }
            else if (string.IsNullOrEmpty(description) || description.Length > MAX_DESCRIPTION_LENGTH)
            {
                error = "Description can not be empty or longer then 500 symbols";
            }
            else if (price < 0 || price > MAX_PRICE) {
                error = "Price can not be less 0 or over 100_000";
            }

            var book = new Book(id, title, description, price);
            return (book, error); 
        }
    }
}
