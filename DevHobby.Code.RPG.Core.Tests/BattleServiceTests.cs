using DevHobby.Code.RPG.Core.Entities;
using DevHobby.Code.RPG.Core.Services;
using FluentAssertions;

namespace DevHobby.Code.RPG.Core.Tests;

/// <summary>
/// Testy dla BattleService - logika walki
/// To są UNIT TESTS - testujemy BattleService w izolacji
/// </summary>
public class BattleServiceTests
{
    // SUT (System Under Test) - obiekt który testujemy
    private readonly BattleService _battleService;

    // Constructor - wykonuje się przed KAŻDYM testem
    public BattleServiceTests()
    {
        _battleService = new BattleService();
    }

    [Fact]  // [Fact] oznacza "to jest test"
    public void Symuluj_WithTwoCharacters_ShouldReturnWinner()
    {
        // ARRANGE - Przygotuj scenę
        var wojownik = new Wojownik("Testowy Wojownik");
        var goblin = new Goblin();
        var participants = new List<Postac> { wojownik, goblin };

        // ACT - Wykonaj akcję
        var winner = _battleService.Symuluj(participants);

        // ASSERT - Sprawdź rezultat
        winner.Should().NotBeNull();
        winner.PunktyZycia.Should().BeGreaterThan(0);
        participants.Count(p => p.PunktyZycia > 0).Should().Be(1);
    }

    [Fact]
    public void Symuluj_WithOneCharacter_ShouldReturnThatCharacter()
    {
        // ARRANGE   
        var wojownik = new Wojownik("Samotny Wojownik");
        var participants = new List<Postac> { wojownik };

        // ACT
        var winner = _battleService.Symuluj(participants);

        // ASSERT
        winner.Should().Be(wojownik);
        winner.PunktyZycia.Should().Be(100);
    }

    [Fact]
    public void Symuluj_WithMultipleCharacters_ShouldHaveOnlyOneWinner()
    {
        // ARRANGE     
        var wojownik = new Wojownik("Wojownik");
        var mag = new Mag("Mag");
        var ork = new Ork();
        var goblin = new Goblin();
        var participants = new List<Postac> { wojownik, mag, ork, goblin };

        // ACT
        var winner = _battleService.Symuluj(participants);

        // ASSERT
        winner.Should().NotBeNull();
        participants.Count(p => p.PunktyZycia > 0).Should().Be(1);
        participants.Should().Contain(winner);
    }

    [Fact]
    public void Symuluj_WithEmptyList_ShouldThrowException()
    {
        // ARRANGE
        var participants = new List<Postac>();

        // ACT
        var action = () => _battleService.Symuluj(participants);

        // ASSERT
        action.Should().Throw<InvalidOperationException>();
    }

    [Fact]
    public void Symuluj_WithDeadCharacters_ShouldHandleCorrectly()
    {
        // ARRANGE      
        var martwy = new Zombi("Martwy Wojownik");
        var goblin = new Goblin();
        var participants = new List<Postac> { martwy, goblin };

        // ACT
        var winner = _battleService.Symuluj(participants);

        // ASSERT
        winner.Should().Be(goblin);
    }

    private class Zombi : Bohater
    {
        public Zombi(string imie) : base(imie, 0, 30)
        {
        }
    }
}
