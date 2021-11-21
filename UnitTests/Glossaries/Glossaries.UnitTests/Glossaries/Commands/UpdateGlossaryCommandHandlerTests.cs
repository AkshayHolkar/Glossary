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
using Glossaries.Application.Features.Glossaries.Commands.UpdateGlossary;

namespace Glossaries.UnitTests.Glossaries.Commands
{
    public class UpdateGlossaryCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IGlossaryRepository> _mockRepository;
        private readonly ILogger<UpdateGlossaryCommandHandler> _logger = Mock.Of<ILogger<UpdateGlossaryCommandHandler>>();
        private readonly UpdateGlossaryCommand _updateGlossaryCommand;

        public UpdateGlossaryCommandHandlerTests()
        {
            _mockRepository = MockGlossaryRepository.GetGlossaryRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _updateGlossaryCommand = new UpdateGlossaryCommand
            {
                Id = 1,
                Term = "Test",
                Definition = "Test Definition"
            };

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task UpdateGlossaryTest()
        {
            var handler = new UpdateGlossaryCommandHandler(_mockRepository.Object, _mapper, _logger);

            await handler.Handle(new UpdateGlossaryCommand() { Id = _updateGlossaryCommand.Id, Term = _updateGlossaryCommand.Term, Definition = _updateGlossaryCommand.Definition }, CancellationToken.None);

            var glossaries = await _mockRepository.Object.GetAllAsync();

            glossaries[_updateGlossaryCommand.Id].Term.ShouldBe("Test");
        }
    }
}
