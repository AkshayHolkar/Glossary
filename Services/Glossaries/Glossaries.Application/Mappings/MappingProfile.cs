using AutoMapper;
using Glossaries.Application.Features.Glossaries.Commands.CreateGlossary;
using Glossaries.Application.Features.Glossaries.Commands.UpdateGlossary;
using Glossaries.Application.Features.Glossaries.Queries.GetGlossariesList;
using Glossaries.Domain.Entities;

namespace Glossaries.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Glossary, GlossaryDto>().ReverseMap();
            CreateMap<Glossary, CreateGlossaryCommand>().ReverseMap();
            CreateMap<Glossary, UpdateGlossaryCommand>().ReverseMap();
        }
    }
}
