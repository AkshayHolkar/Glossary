using AutoMapper;
using Glossaries.Application.Features.Glossaries.Queries.GetGlossariesList;
using Glossaries.Application.Contracts.Persistence;
using Glossaries.Application.Mappings;
using Glossaries.UnitTests.Mocks;
using Moq;
using System.Threading.Tasks;
using Xunit;
using System.Threading;
using Shouldly;
using Glossaries.Application.Features.Glossaries.Queries.GetGlossaryById;

namespace Glossaries.UnitTests.Glossaries.Queries
{
    public class GetGlossaryRequestHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IGlossaryRepository> _mockRepository;

        public GetGlossaryRequestHandlerTests()
        {
            _mockRepository = MockGlossaryRepository.GetGlossaryRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

        }

        [Fact]
        public async Task ValidId_GetGlossaryByIdTest()
        {
            int glossaryId = 2;
            var handler = new GetGlossaryByIdQueryHandler(_mockRepository.Object, _mapper);

            var result = await handler.Handle(new GetGlossaryByIdQuery(glossaryId), CancellationToken.None);

            result.ShouldBeOfType<GlossaryDto>();

            result.Id.ShouldBe(2);
        }
    }
}
