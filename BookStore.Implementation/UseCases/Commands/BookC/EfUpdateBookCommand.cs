using BookStore.Application.Uploads;
using BookStore.Application.UseCases.Commands.BookC;
using BookStore.Application.UseCases.DTO.BookDTOs;
using BookStore.Application.UseCases.Exceptions;
using BookStore.DataAccess;
using BookStore.Domain.Entites;
using Grpc.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Implementation.UseCases.Commands.BookC
{
    public class EfUpdateBookCommand : EfUseCase, IUpdateBookCommand
    {
        private readonly IBase64FileUploader _fileuploader;
        public EfUpdateBookCommand(BookStoreContext context, IBase64FileUploader uploader) : base(context)
        {
            _fileuploader = uploader;
        }

        public int Id => 22;

        public string Name => "Update book";

        public string Description => "Update book by id";

        public void Execute(UpdateBookDto request)
        {
            var book = Context.Books
                                    .Include(b => b.BookAuthors).ThenInclude(b => b.Author)
                                    .Include(b => b.BookGenres).ThenInclude(b => b.Genre)
                                    .Include(b => b.YearPublished)
                                    .Include(b => b.Publisher)
                                    .Include(b => b.Cover)
                                    .Include(b => b.Image)
                                    .FirstOrDefault(x => x.Id == request.Id);
            var entry1 = EntityState.Unchanged;
            var entry2 = EntityState.Unchanged;
            if (book == null)
            {
                throw new EntityNotFoundException(request.Id, nameof(Book));
            }
            if(request.BookName != null && request.BookName != book.Name)
            {
                book.Name = request.BookName;
            }
            if (request.NumberOfPages != null && request.NumberOfPages != book.NumberOfPages)
            {
                book.NumberOfPages = (int)request.NumberOfPages;
            }
            if(request.Description != null && request.Description !=book.Description)
            {
                book.Description = request.Description;
            }
            if(request.Price != null && request.Price != book.Price)
            {
                book.Price = (decimal)request.Price;
            }
            if(request.PublisherId != null && request.PublisherId != book.PublisherId)
            {
                book.PublisherId = (int)request.PublisherId;
            }
            if(request.CoverId != null && request.CoverId != book.CoverId)
            {
                book.CoverId = (int)request.CoverId;
            }
            var filepath = "default.jpg";
            if(request.BookImageFile != null)
            {
                filepath = _fileuploader.Upload(request.BookImageFile, UploadType.BookImage);
                byte[] bytes = Convert.FromBase64String(request.BookImageFile);
                double sizeInMb = Math.Round((double)bytes.Length / (1024 * 1024), 2);
                book.Image = new Image
                {
                    Path = filepath,
                    Size = sizeInMb,
                    CreatedAt = DateTime.UtcNow
                };
            }
            if (request.IsActive.HasValue)
            {
                book.IsActive = (bool)request.IsActive;
            }
            if(request.AuthorIds != null && request.AuthorIds.Any())
            {
                var authors = request.AuthorIds.Select(x => new BookAuthor
                {
                    AuthorId = x,
                    BookId = book.Id
                });
                var forRemove = book.BookAuthors.Where(x => x.BookId == book.Id).ToList();
                foreach(var ba in forRemove)
                {
                    book.BookAuthors.Remove(ba);
                }
                foreach(var ba in authors)
                {
                    book.BookAuthors.Add(ba);
                }
                entry1 = EntityState.Modified;
            }
            if (request.GenreIds != null && request.GenreIds.Any())
            {
                var genres = request.GenreIds.Select(x => new BookGenre
                {
                    BookId = book.Id,
                    GenreId = x
                });
                var forRemove = book.BookGenres.Where(x => x.BookId == book.Id).ToList();
                foreach (var g in forRemove)
                {
                    book.BookGenres.Remove(g);
                }
                foreach (var g in genres)
                {
                    book.BookGenres.Add(g);
                }
                entry2 = EntityState.Modified;
            }
            var entry = Context.Entry(book);
            if (entry.State == EntityState.Modified || entry1 == EntityState.Modified || 
                entry2 == EntityState.Modified)
            {
                book.ModifiedAt = DateTime.UtcNow;
                Context.SaveChanges();
            }
        }
    }
}
