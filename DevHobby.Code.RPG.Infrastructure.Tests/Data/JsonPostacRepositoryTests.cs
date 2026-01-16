using DevHobby.Code.RPG.Core.Entities;
using DevHobby.Code.RPG.Core.Interfaces;
using DevHobby.Code.RPG.Infrastructure.Data;
using DevHobby.Code.RPG.Infrastructure.Interfaces;
using FluentAssertions;
using Moq;

namespace DevHobby.Code.RPG.Infrastructure.Tests.Data;

public class JsonPostacRepositoryTests
{
    [Fact]
    public void PobierzPostacie_WithValidJson_ShouldReturnCharacters()
    {
        // Arrange
        var json = """
        [
            { "Kategoria": "Bohater", "Typ": "Wojownik", "Imie": "Aragorn" },
            { "Kategoria": "Potwor", "Typ": "Ork" }
        ]
        """;


        var fileRedearMock = new Mock<IFileReader>();
        fileRedearMock.Setup(r => r.ReadAllText("path"))
            .Returns(json);

        var aragon = new Wojownik("Aragorn");
        var ork = new Ork();

        var factoryMock = new Mock<IPostacFactory>();
        factoryMock.Setup(f => f.StworzBohatera("Wojownik", "Aragorn")).Returns(aragon);
        factoryMock.Setup(f => f.StworzPotwora("Ork")).Returns(ork);

        var repository = new JsonPostacRepository(
            factoryMock.Object,
            fileRedearMock.Object);

        // Act
        var result = repository.PobierzPostacie("path");

        // Assert
        result.Should().HaveCount(2);
        result.Should().Contain(aragon);
        result.Should().Contain(ork);
    }
}
