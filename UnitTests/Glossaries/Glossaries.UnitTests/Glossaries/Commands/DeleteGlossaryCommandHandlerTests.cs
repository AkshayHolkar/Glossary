using AutoMapper;
using Glossaries.Application.Contracts.Persistence;
using Glossaries.Application.Mappings;
using Glossaries.UnitTests.Mocks;
using Moq;
using System.Threading.Tasks;
using Xunit;
using System.Threading;
using Shouldly;
using Microsoft.Extensions.Logging;
using Glossaries.Application.Features.Glossaries.Commands.DeleteGlossary;

namespace Glossaries.UnitTests.Glossaries.Commands
{
    public class DeleteGlossaryCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IGlossaryRepository> _mockRepository;
        private readonly ILogger<DeleteGlossaryCommandHandler> _logger = Mock.Of<ILogger<DeleteGlossaryCommandHandler>>();

        public DeleteGlossaryCommandHandlerTests()
        {
            _mockRepository = MockGlossaryRepository.GetGlossaryRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task DeleteGlossaryTest()
        {
            var handler = new DeleteGlossaryCommandHandler(_mockRepository.Object, _mapper, _logger);

            await handler.Handle(new DeleteGlossaryCommand() { Id = 2 }, CancellationToken.None);

            var glossaries = await _mockRepository.Object.GetAllAsync();

            glossaries.Count.ShouldBe(2);
        }
    }
}
