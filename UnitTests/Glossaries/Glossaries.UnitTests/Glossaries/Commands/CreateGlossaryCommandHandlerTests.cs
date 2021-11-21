using AutoMapper;
using Glossaries.Application.Contracts.Persistence;
using Glossaries.Application.Mappings;
using Glossaries.UnitTests.Mocks;
using Moq;
using System.Threading.Tasks;
using Xunit;
using System.Threading;
using Shouldly;
using Glossaries.Application.Features.Glossaries.Commands.CreateGlossary;
using Microsoft.Extensions.Logging;

namespace Glossaries.UnitTests.Glossaries.Commands
{
    public class CreateGlossaryCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IGlossaryRepository> _mockRepository;
        private readonly ILogger<CreateGlossaryCommandHandler> _logger = Mock.Of<ILogger<CreateGlossaryCommandHandler>>();
        private readonly CreateGlossaryCommand _createGlossaryCommand;

        public CreateGlossaryCommandHandlerTests()
        {
            _mockRepository = MockGlossaryRepository.GetGlossaryRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

            _createGlossaryCommand = new CreateGlossaryCommand
            {
                Term = "Test",
                Definition = "Test Definition"
            };

        }

        [Fact]
        public async Task CreateGlossaryTest()
        {
            var handler = new CreateGlossaryCommandHandler(_mockRepository.Object, _mapper, _logger);

            var result = await handler.Handle(new CreateGlossaryCommand() { Term = _createGlossaryCommand.Term, Definition = _createGlossaryCommand.Definition }, CancellationToken.None);

            var glossaries = await _mockRepository.Object.GetAllAsync();

            result.ShouldBeOfType<int>();

            glossaries.Count.ShouldBe(4);
        }
    }
}
