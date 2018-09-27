using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DodgyService
{
    public static class BookService
    {
        static IEnumerable<Book> _books = new List<Book>
        {
            new Book
            {
                Id = 1,
                Title = "The Dark Tower Series",
                Author = "Steven King",
                Publisher = "Random House"
            },
            new Book
            {
                Id = 2,
                Title = "The Thief of Always",
                Author = "Clive Barker",
                Publisher = "Penguin"
            }
        };


        public static IEnumerable<Book> FetchBooks()
        {
            return _books;
        }

        public static async Task RequestBooks(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            if (DateTime.Now.Second % 3 == 0)
            {
                context.Response.StatusCode = 500;
            }
            else
            {
                context.Response.StatusCode = 200;
                await context.Response.WriteAsync(JsonConvert.SerializeObject(BookService.FetchBooks()));
            }

        }
    }
}
