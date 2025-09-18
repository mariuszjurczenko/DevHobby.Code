using DevHobby.Code.RPG.Application.Interfaces;
using DevHobby.Code.RPG.Core.Entities;
using DevHobby.Code.RPG.Core.Interfaces;

namespace DevHobby.Code.RPG.Application;

public class GameService : IGameService
{
    private readonly IPostacRepository _postacRepository;
    private readonly IBattleService _battleService;
    private List<Postac> _postacie = new();

    public IReadOnlyList<Postac> Postacie => _postacie.AsReadOnly();

    public GameService(IPostacRepository postacRepository, IBattleService battleService)
    {
        _postacRepository = postacRepository;
        _battleService = battleService;
    }

    public void PobierzPostacie(string sciezkaPliku)
    {
        // Walidacja parametrów
        if (string.IsNullOrWhiteSpace(sciezkaPliku))
            throw new ArgumentException("Ścieżka pliku nie może być pusta", nameof(sciezkaPliku));

        if (!File.Exists(sciezkaPliku))
            throw new FileNotFoundException($"Nie znaleziono pliku: {sciezkaPliku}");

        // Wczytanie postaci
        _postacie = _postacRepository.PobierzPostacie(sciezkaPliku).ToList();

        // Walidacja biznesowa
        if (_postacie.Count < 2)
            throw new InvalidOperationException("Za mało postaci do gry.");
    }

    public Postac Start()
    {
        return _battleService.Symuluj(_postacie);
    }

    public void WyswietlStatusy()
    {
        _postacie.ForEach(p => p.PokazStatus());
    }
}
