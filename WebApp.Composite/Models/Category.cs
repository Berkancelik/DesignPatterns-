using System.Collections;
using System.Collections.Generic;

namespace WebApp.Composite.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
        public ICollection<Book> Books;
        public int ReferenceId { get; set; }
    }
}
