using AutoMapper;
using BookStore.Application.UseCases.DTO;
using BookStore.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Implementation.AutoMappers
{
    public class Mapper : Profile
    {
        public Mapper()
        {

            CreateMap<Author, GetAuthorDto>().ReverseMap();
            CreateMap<Author, AddAuthorDto>().ReverseMap();
        }
    }
}
