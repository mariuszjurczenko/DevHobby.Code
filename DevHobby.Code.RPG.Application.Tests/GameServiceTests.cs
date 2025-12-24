using DevHobby.Code.RPG.Application;
using DevHobby.Code.RPG.Core.Entities;
using DevHobby.Code.RPG.Core.Interfaces;
using FluentAssertions;
using Moq;

namespace DevHobby.Code.RPG.Tests.Application;

/// <summary>
/// Testy dla GameService - orkiestracja use case'ów
/// To są UNIT TESTS z MOCKAMI - testujemy GameService w izolacji
/// </summary>
public class GameServiceTests
{
    private readonly Mock<IPostacRepository> _mockRepository;
    private readonly Mock<IBattleService> _mockBattleService;
    private readonly GameService _gameService;

    public GameServiceTests()
    {
        _mockRepository = new Mock<IPostacRepository>();
        _mockBattleService = new Mock<IBattleService>();
        _gameService = new GameService(_mockRepository.Object, _mockBattleService.Object);
    }

    [Fact]
    public void PobierzPostacie_WithValidPath_ShouldLoadCharacters()
    {
        // Arrange
        var expectedCharacters = new List<Postac>
        {
            new Wojownik("Test Warrior"),
            new Mag("Test Mage")
        };

        var testFilePath = Path.GetTempFileName();

        _mockRepository.Setup(r => r.PobierzPostacie(testFilePath))
            .Returns(expectedCharacters);

        // Act
        _gameService.PobierzPostacie(testFilePath);

        // Assert
        _gameService.Postacie.Should().HaveCount(2);
        _gameService.Postacie.Should().BeEquivalentTo(expectedCharacters);

        _mockRepository.Verify(r => r.PobierzPostacie(testFilePath), Times.Once());

        // Cleanup
        File.Delete(testFilePath);
    }

    [Fact]
    public void PobierzPostacie_WithEmptyPath_ShouldThrowArgumentException()
    {
        // ACT & ASSERT
        var action = () => _gameService.PobierzPostacie("");
        action.Should().Throw<ArgumentException>()
              .WithParameterName("sciezkaPliku");
    }

    [Fact]
    public void PobierzPostacie_WithNonExistentFile_ShouldThrowFileNotFoundException()
    {
        // ARRANGE
        var nonExistentPath = "definitely_does_not_exist_xyz123.json";

        // ACT & ASSERT
        var action = () => _gameService.PobierzPostacie(nonExistentPath);
        action.Should().Throw<FileNotFoundException>();

        // Repository NIE POWINIEN być wywołany, bo walidacja rzuciła wyjątek wcześniej
        _mockRepository.Verify(
            r => r.PobierzPostacie(It.IsAny<string>()),
            Times.Never);
    }

    [Fact]
    public void PobierzPostacie_WithLessThanTwoCharacters_ShouldThrowInvalidOperationException()
    {
        // ARRANGE
        var testFilePath = Path.GetTempFileName();
        var singleCharacter = new List<Postac> { new Wojownik("Solo") };

        _mockRepository
            .Setup(r => r.PobierzPostacie(testFilePath))
            .Returns(singleCharacter);

        // ACT & ASSERT
        var action = () => _gameService.PobierzPostacie(testFilePath);
        action.Should().Throw<InvalidOperationException>()
              .WithMessage("Za mało postaci do gry.");

        // Cleanup
        File.Delete(testFilePath);
    }

    [Fact]
    public void Start_WithLoadedCharacters_ShouldReturnWinner()
    {
        // ARRANGE
        var testFilePath = Path.GetTempFileName();

        var characters = new List<Postac>
        {
            new Wojownik("Warrior"),
            new Ork()
        };
        var expectedWinner = characters[0];

        _mockRepository
            .Setup(r => r.PobierzPostacie(testFilePath))
            .Returns(characters);

        _mockBattleService
            .Setup(b => b.Symuluj(It.IsAny<IList<Postac>>()))
            .Returns(expectedWinner);

        _gameService.PobierzPostacie(testFilePath);

        // ACT
        var winner = _gameService.Start();

        // ASSERT
        winner.Should().Be(expectedWinner);

        // Sprawdź czy BattleService dostał właściwą listę postaci
        _mockBattleService.Verify(
            b => b.Symuluj(It.Is<IList<Postac>>(list =>
                list.Count == 2 &&
                list.Contains(characters[0]) &&
                list.Contains(characters[1]))),
            Times.Once);

        // Cleanup
        File.Delete(testFilePath);
    }

    [Fact]
    public void WyswietlStatusy_ShouldCallPokazStatusOnAllCharacters()
    {
        // ARRANGE
        var testFilePath = Path.GetTempFileName();

        // Dla tego testu musimy użyć Mock<Postac> żeby sprawdzić wywołania
        var mockWarrior = new Mock<Wojownik>("Warrior") { CallBase = true };
        var mockMage = new Mock<Mag>("Mag") { CallBase = true };

        var characters = new List<Postac>
        {
            mockWarrior.Object,
            mockMage.Object
        };

        _mockRepository
            .Setup(r => r.PobierzPostacie(testFilePath))
            .Returns(characters);

        _gameService.PobierzPostacie(testFilePath);

        // ACT
        _gameService.WyswietlStatusy();

        // ASSERT
        mockWarrior.Verify(w => w.PokazStatus(), Times.Once);
        mockMage.Verify(m => m.PokazStatus(), Times.Once);

        // Cleanup
        File.Delete(testFilePath);
    }
}
