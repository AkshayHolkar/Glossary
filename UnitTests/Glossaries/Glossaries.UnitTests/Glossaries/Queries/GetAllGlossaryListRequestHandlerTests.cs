using AutoMapper;
using Glossaries.Application.Features.Glossaries.Queries.GetGlossariesList;
using Glossaries.Application.Contracts.Persistence;
using Glossaries.Application.Mappings;
using Glossaries.UnitTests.Mocks;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using System.Threading;
using Shouldly;

namespace Glossaries.UnitTests.Glossaries.Queries
{
    public class GetAllGlossaryListRequestHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IGlossaryRepository> _mockRepository;

        public GetAllGlossaryListRequestHandlerTests()
        {
            _mockRepository = MockGlossaryRepository.GetGlossaryRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

        }

        [Fact]
        public async Task GetGlossaryListTest()
        {
            var handler = new GetGlossariesListQueryHandler(_mockRepository.Object, _mapper);

            var result = await handler.Handle(new GetGlossariesListQuery(), CancellationToken.None);

            result.ShouldBeOfType<List<GlossaryDto>>();

            result.Count.ShouldBe(3);
        }
    }
}
