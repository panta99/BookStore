using BookStore.Application.Uploads;
using BookStore.Application.UseCases.DTO.BookDTOs;
using BookStore.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Implementation.Validators.BookValidators
{
    public class AddBookValidator : AbstractValidator<AddBookDto>
    {
        public AddBookValidator(BookStoreContext context,IBase64FileUploader uploader)
        {
            RuleFor(x => x.BookName).NotEmpty()
                                   .WithMessage("Book name is required");
            RuleFor(x => x.NumberOfPages).Must(y => y > 0 && y < 10000)
                                         .WithMessage("Number of book pages must be in range 1-10000");
            RuleFor(x => x.Description).NotEmpty()
                                      .WithMessage("Description is required")
                                      .Length(30, 3000)
                                      .WithMessage("Description must have at least 30  and maximum of 3000 characters");
            RuleFor(x => x.QuantityInStock).Must(y => y > 0)
                                           .WithMessage("Quantity in stock can't be 0");
            RuleFor(x => x.Price).Must(pr => pr > 100 && pr < 100000)
                                .WithMessage("Price must be in range of 100 to 100000");
            RuleFor(x => x.PublisherId).Must(y => context.Publishers.Any(x => x.Id == y))
                                      .WithMessage((dto,y)=> $"Publisher with id={y} doesn't exist");
            RuleFor(x => x.PublishYearId).Must(y => context.YearPublished.Any(x => x.Id == y))
                                        .WithMessage((dto,y)=>$"Year with id={y} doesn't exist");
            RuleFor(x => x.CoverId).Must(y => context.Covers.Any(x => x.Id == y))
                                  .WithMessage((dto,y)=>$"Cover with id={y} doesn't exsit");
            RuleFor(x=> x.BookImageFile).NotEmpty()
                                        .WithMessage("Image is required")
                                        .Must(x => uploader.IsExtensionsValid(x) &&
                                                       new List<string> { "jpg", "png" }.Contains(uploader.GetExtension(x)))
                .When(x => x.BookImageFile != null)
                .WithMessage("Invalid file extesion. Allowed are .jpg and .png");
            RuleFor(x => x.AuthorIds).Must(ids => ids.All(id => context.Authors.Any(a => a.Id == id)))
                                     .WithMessage((dto, ids) =>
                                     {
                                         var invalidIds = ids.Where(id => !context.Authors.Any(x => x.Id == id)).ToList();
                                         return $"The following author IDs do not exsit:{string.Join(", ", invalidIds)}";
                                     });
            RuleFor(x => x.GenreIds).Must(ids => ids.All(id => context.Genres.Any(g => g.Id == id)))
                                   .WithMessage((dto, ids) =>
                                   {
                                       var invalidIds = ids.Where(id => !context.Genres.Any(x => x.Id == id)).ToList();
                                       return $"The following genre IDs do not exist {string.Join(", ", invalidIds)}";
                                   });
        }
    }
}
