using AutoMapper;
using System.Collections.Generic;

namespace Books.API.Profiles
{
    public class BooksProfile : Profile
    {
        public BooksProfile()
        {
            CreateMap<Entity.Book, Models.Book>()
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src =>
                    $"{src.Author.FirstName} {src.Author.LastName}"));

            CreateMap<Models.BookForCreation, Entity.Book>();

            CreateMap<Entity.Book, Models.BookWithCovers>()
               .ForMember(dest => dest.Author, opt => opt.MapFrom(src =>
                  $"{src.Author.FirstName} {src.Author.LastName}"));

            CreateMap<IEnumerable<ExternalModels.BookCover>, Models.BookWithCovers>()
                .ForMember(dest => dest.BookCovers, opt => opt.MapFrom(src =>
                   src));

            CreateMap<ExternalModels.BookCover, Models.BookCover>();
        }
    }
}
