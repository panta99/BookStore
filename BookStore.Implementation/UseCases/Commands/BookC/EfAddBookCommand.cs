using BookStore.Application.Uploads;
using BookStore.Application.UseCases.Commands.BookC;
using BookStore.Application.UseCases.DTO.BookDTOs;
using BookStore.DataAccess;
using BookStore.Domain.Entites;
using BookStore.Implementation.Validators.BookValidators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Implementation.UseCases.Commands.BookC
{
    public class EfAddBookCommand : EfUseCase, IAddBookCommand
    {
        private readonly AddBookValidator _validator;
        private readonly IBase64FileUploader _fileuploader;
        public EfAddBookCommand(BookStoreContext context, AddBookValidator validator, IBase64FileUploader uploader) 
            : base(context)
        {
            _validator = validator;
            _fileuploader = uploader;
        }

        public int Id => 21;

        public string Name => "Add book";

        public string Description => "Add book with image";

        public void Execute(AddBookDto request)
        {
            _validator.ValidateAndThrow(request);
            var filePath = "default.jpg";
            if(request.BookImageFile != null)
            {
                filePath = _fileuploader.Upload(request.BookImageFile, UploadType.BookImage);
            }
            byte[] bytes = Convert.FromBase64String(request.BookImageFile);
            double sizeInMb = Math.Round((double)bytes.Length / (1024 * 1024), 2);
            var book = new Book
            {
                Name = request.BookName,
                NumberOfPages = request.NumberOfPages,
                Description = request.Description,
                QuantityInStock = request.QuantityInStock,
                Price = request.Price,
                PublisherId = request.PublisherId,
                PublishYearId = request.PublishYearId,
                CoverId = request.CoverId,
                Image = new Image
                {
                     Path = filePath,
                     Size = sizeInMb
                } 
            };
            Context.Add(book);
            Context.SaveChanges();
            var authors = request.AuthorIds.Select(x => new BookAuthor
            {
                AuthorId = x,
                BookId = book.Id
            });
            var genres = request.GenreIds.Select(x => new BookGenre
            {
                BookId = book.Id,
                GenreId = x
            });
            Context.BookAuthors.AddRange(authors);
            Context.BookGenres.AddRange(genres);
            Context.SaveChanges();
            
        }
    }
}
