# DevHobby.Code

Repozytorium zawierające kody źródłowe do tutoriali z mojego kanału YouTube. Z każdym nowym projektem, w tym miejscu pojawi się jego krótki opis.

## Projekty

---

### `DevHobby.Code.Lego`

**Tutorial na YouTube:** [OBIEKTY w C# to KLOCKI LEGO?! MÓJ MÓZG EKSPLODOWAŁ! Zobacz Dlaczego!](https://www.youtube.com/watch?v=EqcVh0dif4Y&t)

Projekt ten w przystępny sposób wyjaśnia podstawy programowania obiektowego (OOP) w C#, używając kreatywnej analogii do klocków LEGO.

**Najważniejsze informacje:**
*   **Cel:** Pokazanie, że klasy i obiekty można traktować jak instrukcje i gotowe budowle z klocków.
*   **Koncepcje:** Praktyczne wprowadzenie do klas, obiektów, właściwości (properties) i metod.
*   **Dla kogo:** Idealny materiał dla początkujących, którzy chcą zrozumieć OOP w wizualny sposób, bez skomplikowanej teorii.

---

### DevHobby.Code.RPG

#### Tutorial na YouTube: [C# OOP na przykładzie gry RPG – Klasy, Obiekty, Właściwości [C# OOP Kurs cz.1]](https://www.youtube.com/watch?v=ij-MdPW1BvI)

Projekt ten przedstawia praktyczne zastosowanie klas i obiektów poprzez stworzenie prostego systemu RPG w C#. Gracz poznaje fundamenty OOP, tworząc drużynę bohaterów z własnymi statystykami.

📚  Najważniejsze informacje:
*	**Cel:** Pokazać, jak za pomocą klas i właściwości modelować rzeczywiste obiekty (np. bohaterów w grze).
*	**Koncepcje:** Prywatne pola, publiczne właściwości, enkapsulacja (hermetyzacja), walidacja danych, konstruktor.
*	**Dla kogo:** Dla początkujących, którzy chcą przełożyć teorię obiektów na działający kod w stylu fantasy.

#### Tutorial na YouTube: [C# OOP na przykładzie gry RPG – System Walki, Obiekty Atakują! [C# OOP Kurs cz.2]](https://www.youtube.com/watch?v=Ng46ahMikvw)

W tym odcinku rozwijamy naszą grę RPG w C#! 💥
Tworzymy kompletny system walki, gdzie bohaterowie atakują się nawzajem, leczą, otrzymują obrażenia i pokazują swój status w epickiej pętli gry! 

📚 Nauczysz się:
- Jak pisać zwięzły i profesjonalny kod z auto-properties
- Jak używać Math.Clamp i operatora ?: do walidacji
- Jak obiekty mogą współpracować (atak, obrażenia, leczenie)
- Jak stworzyć konsolowy pasek życia w ASCII 🎮
- Jak zbudować pętlę walki i system zwycięzcy

#### Tutorial na YouTube: [C# OOP na przykładzie gry RPG Dziedziczenie i Polimorfizm Tworzymy różne postacie [C# OOP Kurs cz.3]](https://www.youtube.com/watch?v=NoqnFotNPA4)

W tym odcinku rozwijamy naszą grę RPG, wkraczając w świat dziedziczenia i polimorfizmu. Pokażę Ci, jak stworzyć profesjonalny, rozszerzalny system postaci, unikając powielania kodu. Zamiast tworzyć osobne klasy dla każdego bohatera i potwora, nauczysz się projektować eleganckie i elastyczne struktury klas.

📚 CZEGO SIĘ NAUCZYSZ:
- Czym jest dziedziczenie w C# i jak go używać.
- Jak stworzyć uniwersalną klasę bazową 
- Postac dla wszystkich bohaterów i potworów.
- Jak używać klas abstrakcyjnych, aby budować solidne fundamenty kodu.
- Na czym polega polimorfizm i jak pozwala on na unikalne zachowania (np. różne ataki).
- Kluczowe słowa takie jak  virtual i override do nadpisywania metod.

#### Tutorial na YouTube: [C# Factory Pattern w praktyce – Twórz postacie do gry RPG jak zawodowiec! - [C# OOP Kurs cz.4]](https://www.youtube.com/watch?v=6fOQkmlyGvs)

W tej części kursu C# pokażę Ci, jak zastosować wzorzec projektowy Factory w praktyce, tworząc system generowania bohaterów i potworów do gry RPG.

📚 CZEGO SIĘ NAUCZYSZ:
- Jak uporządkować kod i oddzielić logikę tworzenia od logiki gry
- Jak tworzyć nowe postacie jedną linijką kodu
- Jak wczytywać bohaterów i potwory z plików TXT i JSON
- Dlaczego polimorfizm to Twój najlepszy przyjaciel w programowaniu obiektowym

#### Tutorial na YouTube: [C# RPG Refactor – Oddzielenie Domeny od UI | Event-Driven w praktyce - [C# OOP Kurs cz.5]](https://www.youtube.com/watch?v=AiCmmLZrSnc)

W piątej części naszej serii RPG w C# wchodzimy na wyższy poziom architektury. Do tej pory nasza logika była mocno „przyspawana” do konsoli, ale to już przeszłość!

📚 CZEGO SIĘ NAUCZYSZ:
- Usuwamy Console.WriteLine z domeny.
- Wprowadzamy zdarzenia domenowe (KomunikatWygenerowany).
- Uczymy się jak UI subskrybuje komunikaty i sam decyduje, co z nimi zrobić.
- Robimy krok w stronę event-driven architecture i Clean Architecture.

#### Tutorial na YouTube: [C# Refaktoring do Clean Architecture – Podział na Warstwy [ 1/6 ] - [ C# OOP Kurs cz.6 ]](https://www.youtube.com/watch?v=v5vaqILZGHI)

W tym odcinku rozpoczynamy serię refaktoringu naszego projektu RPG do Clean Architecture / Onion Architecture. Pokażę Ci krok po kroku, jak pozbyć się spaghetti kodu i zbudować solidne fundamenty aplikacji.

📚 CZEGO SIĘ NAUCZYSZ:
- Rozbijemy monolit na warstwy (Core, Application, Infrastructure, UI)
- Zrozumiemy zasadę Dependency Rule
- Uporządkujemy kod, zachowując jego dotychczasowe działanie
- Stworzymy czysty fundament pod dalsze refaktoringi

#### Tutorial na YouTube: [C# Refaktoring do Clean Architecture – Repository Pattern [ 2/6 ] - [ C# OOP Kurs cz.7 ]](https://www.youtube.com/watch?v=yiHNAJQmU3o)

W tym odcinku serii refaktoryzujemy naszą grę RPG do Clean Architecture i wdrażamy Repository Pattern. Oddzielamy domenę biznesową od szczegółów technicznych, dzięki czemu kod staje się czystszy, łatwiejszy w testowaniu i rozszerzaniu.

📚 CZEGO SIĘ NAUCZYSZ:
- Dlaczego PostacFactory miała za dużo odpowiedzialności
- Jak zastosować Single Responsibility Principle i Open/Closed Principle w praktyce
- Jak stworzyć IPostacRepository i jego implementacje dla TXT i JSON
- Jak przygotować kod pod przyszłe rozszerzenia (np. baza danych, API)


#### Tutorial na YouTube: [C# Refaktoring do Clean Architecture – Service Layer (BattleService) [ 3/6 ] - [ C# OOP Kurs cz.8 ]](https://www.youtube.com/watch?v=mYTsNjrK1oM)

W tym odcinku refaktoryzacji RPG do Clean Architecture wydzielamy logikę biznesową z Program.cs i przenosimy ją do Service Layer.

📚 CZEGO SIĘ NAUCZYSZ:
- Jak stworzyć IBattleService i BattleService
- Jak oczyścić kod i sprawić, że stanie się testowalny, czytelny i reużywalny
- Jak przygotować grunt pod kolejne warstwy (Application Service)
To praktyczny przykład refaktoryzacji krok po kroku – z chaosu w Program.cs do czystej architektury!


#### Tutorial na YouTube: [C# Refaktoring do Clean Architecture – Application Service (GameService) [ 4/6 ] - [ C# OOP Kurs cz.9 ]](https://www.youtube.com/watch?v=yNtKHnNPtbE&t)

W tym odcinku serii Refaktoryzacja do Clean Architecture przenosimy logikę z Program.cs do dedykowanego Application Service – GameService.

📚 CZEGO SIĘ NAUCZYSZ:
- Jak wydzielić use case’y aplikacji,
- Jak zastosować Dependency Injection,
- Jak dodać walidację biznesową,
- Jak wyciągnąć interfejs IGameService,
- Jak i przygotować kod pod pełną integrację z Dependency Injection Container.
- To praktyczny przykład, jak zasada Dependency Rule działa w prawdziwym projekcie C#/.NET! 🚀


#### Tutorial na YouTube: [C# Refaktoring do Clean Architecture – Dependency Injection w .NET [ 5/6 ][ C# OOP Kurs cz.10 ]](https://www.youtube.com/watch?v=j5Pqjc__OUU)