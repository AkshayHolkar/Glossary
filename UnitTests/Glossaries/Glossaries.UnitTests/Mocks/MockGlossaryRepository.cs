using Glossaries.Application.Contracts.Persistence;
using Glossaries.Domain.Entities;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace Glossaries.UnitTests.Mocks
{
    public static class MockGlossaryRepository
    {
        public static Mock<IGlossaryRepository> GetGlossaryRepository()
        {
            var glossaries = new List<Glossary>
            {
                new Glossary
                {
                    Id = 1,
                    Term = "abyssal plain",
                    Definition = "The ocean floor offshore from the continental margin, usually very flat with a slight slope."
                },

                 new Glossary
                {
                    Id = 2,
                    Term = "accrete",
                    Definition = "v. To add terranes (small land masses or pieces of crust) to another, usually larger, land mass."
                },

                  new Glossary
                {
                    Id = 3,
                    Term = "alkaline",
                    Definition = "Term pertaining to a highly basic, as opposed to acidic, subtance. For example, hydroxide or carbonate of sodium or potassium."
                }
            };

            var mockRepository = new Mock<IGlossaryRepository>();

            mockRepository.Setup(r => r.GetAllAsync())
                .ReturnsAsync(glossaries);

            mockRepository.Setup(r => r.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync((int id) => glossaries.Single(g => g.Id == id));

            mockRepository.Setup(r => r.CreateAsync(It.IsAny<Glossary>()))
                .ReturnsAsync((Glossary glossary) =>
                {
                    glossaries.Add(glossary);
                    return glossary;
                });

            mockRepository.Setup(r => r.DeleteAsync(It.IsAny<int>()))
                .Callback((int id) => glossaries.RemoveAt(id));

            mockRepository.Setup(r => r.UpdateAsync(It.IsAny<Glossary>()))
                .Callback((Glossary glossary) =>
                {
                    glossaries[glossary.Id] = glossary;
                });

            return mockRepository;
        }
    }
}
