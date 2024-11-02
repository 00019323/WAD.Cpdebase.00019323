using AutoMapper;
using WAD.Codebase._00019323.DTOs;
using WAD.Codebase._00019323.Models;

namespace WAD.Codebase._00019323.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Newspaper mappings
            CreateMap<Newspaper, NewspaperCreateDto>().ReverseMap();
            CreateMap<Newspaper, NewspaperEditDto>().ReverseMap();
            CreateMap<Newspaper, NewspaperDto>();  // Main DTO mapping for get operations

            // Article mappings
            CreateMap<Article, ArticleCreateDto>().ReverseMap();
            CreateMap<Article, ArticleEditDto>().ReverseMap();
            CreateMap<Article, ArticleDto>()  // Main DTO mapping for get operations
                .ForMember(dest => dest.NewspaperName, opt => opt.MapFrom(src => src.Newspaper.Name));
        }
    }
}
