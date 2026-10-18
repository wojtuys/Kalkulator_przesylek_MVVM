# 📦 Kalkulator Przesyłek Kurierskich – .NET MAUI (MVVM + OOP)
> **Kompendium wiedzy i dokumentacja techniczna do egzaminu zawodowego INF.04**  
> **Środowisko:** Visual Studio 2025 | **Język:** C# / XAML | **Platforma:** .NET MAUI  
> 🔗 **Link do pełnej rozmowy i wyjaśnień krok po kroku:** [TUTAJ_WKLEJ_LINK_DO_ROZMOWY]

---

## 📑 Spis treści
1. [O projekcie](#-1-o-projekcie)
2. [Fundamenty Programowania Obiektowego (OOP)](#-2-fundamenty-programowania-obiektowego-oop)
   - [Klasa vs Obiekt](#21-klasa-class-vs-obiekt-object)
   - [Właściwości, Konstruktory i Metody](#22-anatomia-klasy-właściwości-konstruktor-i-metoda)
   - [Model vs Funkcja (Metoda)](#23-czym-różni-się-model-od-funkcji-metody)
   - [Dziedziczenie, Klasy Abstrakcyjne i Polimorfizm](#24-dziedziczenie-klasy-abstrakcyjne-i-polimorfizm)
   - [Zwykła funkcja vs `virtual` vs `abstract`](#25-trzy-sposoby-definiowania-funkcji-w-klasie-bazowej)
3. [Architektura MVVM (Model-View-ViewModel)](#-3-architektura-mvvm-model-view-viewmodel)
   - [Po co dzielimy aplikację na 3 foldery?](#31-po-co-dzielimy-aplikację-na-3-foldery)
   - [Schemat przepływu danych](#32-schemat-komunikacji-między-warstwami)
4. [Szczegółowa analiza kodu (Krok po kroku)](#-4-szczegółowa-analiza-kodu-krok-po-kroku)
   - [Warstwa 1: Folder `Model` (`Przesylka.cs`)](#41-warstwa-1-folder-model-plik-przesylkacs)
   - [Warstwa 2: Folder `ViewModel` (`PrzesylkaViewModel.cs`)](#42-warstwa-2-folder-viewmodel-plik-przesylkaviewmodelcs)
   - [Warstwa 3: Folder `View` (`MainPage.xaml` i `MainPage.xaml.cs`)](#43-warstwa-3-folder-view-pliki-mainpagexaml-oraz-mainpagexamlcs)
5. [Słownik mechanizmów C# i .NET MAUI (FAQ)](#-5-słownik-mechanizmów-c-i-net-maui-faq)
6. [Najczęstsze błędy i jak je naprawić (Troubleshooting)](#-6-najczęstsze-błędy-i-jak-je-naprawić-troubleshooting)

---

## 🎯 1. O projekcie

Projekt przedstawia wzorcową aplikację okienkową napisaną w technologii **.NET MAUI** z wykorzystaniem wzorca architektonicznego **MVVM (Model-View-ViewModel)** oraz zasad **Programowania Obiektowego (OOP)**. 

Celem projektu jest praktyczne zobrazowanie:
* Tworzenia **klas abstrakcyjnych**, **dziedziczenia** (`: base()`) oraz **przesłaniania metod** (`override`).
* Oddzielenia logiki biznesowej (**Model**) od interfejsu użytkownika (**View**) za pomocą pośrednika (**ViewModel**).
* Działania wiązania danych (**Data Binding**), komend (**`ICommand`**) oraz powiadamiania interfejsu o zmianach (**`INotifyPropertyChanged`**).

---

## 🧱 2. Fundamenty Programowania Obiektowego (OOP)

### 2.1. Klasa (`class`) vs Obiekt (`object`)
* **Klasa (`class`)** to **szablon / projekt architektoniczny / foremka**. Opisuje, jakie cechy (właściwości) i jakie umiejętności (metody/funkcje) będzie miał dany byt, ale sama w sobie nie przechowuje konkretnych danych w pamięci.
* **Obiekt (`object`)** to **konkretny egzemplarz** wyprodukowany w pamięci komputera na podstawie klasy za pomocą słówka kluczowego **`new`**. Z jednej klasy `PaczkaKurierska` możemy stworzyć setki niezależnych obiektów (konkretnych paczek).

### 2.2. Anatomia klasy: Właściwości, Konstruktor i Metoda

```csharp
public abstract class Przesylka // <-- NAGŁÓWEK KLASY (Modelu)
{
    // 1. WŁAŚCIWOŚCI (Properties) - cechy obiektu (rzeczowniki)
    public string Adresat { get; set; }
    public double WagaKg { get; set; }

    // 2. KONSTRUKTOR - metoda startowa budująca obiekt
    public Przesylka(string adresat, double wagaKg)
    {
        Adresat = adresat;
        WagaKg = wagaKg;
    }

    // 3. METODA (Funkcja) - czynność wykonywana przez obiekt (czasownik)
    public abstract double ObliczCene();
}
```

1. **Właściwość (`Property`)**: Zmienna wewnątrz klasy posiadająca akcesory `{ get; set; }`. `get` pozwala odczytać wartość, a `set` pozwala ją zapisać lub zmienić. Zgodnie z konwencją C# piszemy je **Wielką Literą** (`Adresat`, `WagaKg`).
2. **Konstruktor (`Constructor`)**: Specjalna metoda wywoływana **automatycznie w ułamku sekundy, gdy tworzymy obiekt słówkiem `new`**.
   * **Jak go rozpoznać:** Nazywa się **identycznie jak klasa** i **NIE posiada typu zwracanego** (nie ma przed nazwą ani `void`, ani `double`, ani `string`).
   * **Po co istnieje:** Wymusza podanie danych startowych w nawiasie i przypisuje parametry tymczasowe (pisane z małej litery: `adresat`) do stałych właściwości klasy (pisanych z dużej litery: `Adresat`).
3. **Metoda (`Method` / Funkcja)**: Czynność lub obliczenie wykonywane przez klasę. W przeciwieństwie do konstruktora **posiada typ zwracany** (np. `double`, gdy zwraca liczbę, lub `void`, gdy nic nie zwraca) i nazywa się inaczej niż klasa.

### 2.3. Czym różni się Model od Funkcji (Metody)?

| Pojęcie | Definicja | Przykład w projekcie |
| :--- | :--- | :--- |
| **Model** | Cała klasa (pudełko) reprezentująca obiekt z prawdziwego świata i przechowująca jego dane. | Klasa `Przesylka` oraz klasa `PaczkaKurierska`. |
| **Funkcja (Metoda)** | Kawałek kodu *wewnątrz* klasy, który wykonuje operację na danych tego modelu. | Metoda `ObliczCene()` znajdująca się wewnątrz klasy `PaczkaKurierska`. |

### 2.4. Dziedziczenie, Klasy Abstrakcyjne i Polimorfizm
* **Klasa bazowa (Rodzic):** Ogólna klasa nadrzędna (`Przesylka`), która zawiera wspólne cechy dla wszystkich rodzajów przesyłek (`Adresat`, `WagaKg`).
* **Klasa pochodna / dziedzicząca (Dziecko):** Klasa szczegółowa (`PaczkaKurierska : Przesylka`), która przejmuje wszystkie cechy rodzica i dodaje własne (np. `CzyEkspres`).
* **Klasa abstrakcyjna (`abstract class`):** Klasa, która służy wyłącznie jako baza do dziedziczenia. **Nie wolno stworzyć z niej bezpośredniego obiektu** (instrukcja `new Przesylka(...)` wywoła błąd kompilacji).
* **Dlaczego metoda `ObliczCene()` jest abstrakcyjna w klasie bazowej, a definiowana w klasie dziedziczącej?**
  1. Klasa bazowa `Przesylka` nie ma dostępu do właściwości z klas podrzędnych (nie wie o istnieniu pola `CzyEkspres`, bo dziedziczenie działa tylko w dół).
  2. Każdy rodzaj przesyłki (np. `PaczkaKurierska`, `PrzesylkaPaletowa`, `ListPolecony`) ma własny, odrębny wzór na obliczenie ceny.

### 2.5. Trzy sposoby definiowania funkcji w klasie bazowej

| Rodzaj metody w klasie bazowej | Składnia w klasie bazowej | Zachowanie w klasie dziedziczącej |
| :--- | :--- | :--- |
| **1. Zwykła metoda** | `public double ObliczCene() { ... }` | Działa identycznie w każdej klasie podrzędnej. Klasa dziedzicząca dostaje ją automatycznie. |
| **2. Metoda wirtualna (`virtual`)** | `public virtual double ObliczCene() { ... }` | Posiada domyślny wzór w klasie bazowej, ale klasa podrzędna **może** (nie musi) go zmodyfikować słówkiem `override`. |
| **3. Metoda abstrakcyjna (`abstract`)** | `public abstract double ObliczCene();` | Nie posiada ciała `{ }` (kończy się średnikiem `;`). Klasa podrzędna **MUSI** napisać własny wzór używając słówka `override`. |

---

## 🏗️ 3. Architektura MVVM (Model-View-ViewModel)

### 3.1. Po co dzielimy aplikację na 3 foldery?
Pisanie całego kodu w pliku `MainPage.xaml.cs` (tzw. *code-behind*) miesza wygląd ekranu z obliczeniami. Wzorzec **MVVM** rozdziela aplikację na 3 niezależne warstwy:

```text
📦 MVVM (Główny Projekt)
 ┣ 📂 Model
 ┃ ┗ 📜 Przesylka.cs            <-- Dane, konstruktory, dziedziczenie i matematyka
 ┣ 📂 ViewModel
 ┃ ┗ 📜 PrzesylkaViewModel.cs   <-- Pośrednik: właściwości ekranowe, ICommand, INotifyPropertyChanged
 ┣ 📂 View
 ┃ ┣ 📜 MainPage.xaml           <-- Wygląd interfejsu (XAML) i wiązania {Binding}
 ┃ ┗ 📜 MainPage.xaml.cs        <-- Czysty plik inicjalizujący widok (tylko InitializeComponent)
 ┗ 📜 AppShell.xaml             <-- Konfiguracja nawigacji i ekranu startowego
```

### 3.2. Schemat komunikacji między warstwami

```text
+-----------------------------------------------------------------------+
|                              VIEW (XAML)                              |
|  Użytkownik wpisuje dane w <Entry> i klika <Button>                   |
+-----------------------------------------------------------------------+
                   |                                   ^
   1. {Binding}    |                                   | 4. OnPropertyChanged()
   oraz ICommand   v                                   | (Odświeżenie <Label>)
+-----------------------------------------------------------------------+
|                            VIEWMODEL (C#)                             |
|  Odbiera kliknięcie w funkcji Oblicz(), tworzy obiekt Modelu          |
+-----------------------------------------------------------------------+
                   |                                   ^
   2. Tworzy obiekt|                                   | 3. Zwraca wynik
   new Paczka...() v                                   | z ObliczCene()
+-----------------------------------------------------------------------+
|                              MODEL (C#)                               |
|  Konstruktor zapisuje dane, metoda override ObliczCene() liczy koszt  |
+-----------------------------------------------------------------------+
```

---

## 💻 4. Szczegółowa analiza kodu (Krok po kroku)

### 4.1. Warstwa 1: Folder `Model` (Plik `Przesylka.cs`)

```csharp
namespace MVVM.Model
{
    // KLASA BAZOWA (ABSTRAKCYJNA)
    public abstract class Przesylka
    {
        public string Adresat { get; set; }
        public double WagaKg { get; set; }

        // Konstruktor klasy bazowej
        public Przesylka(string adresat, double wagaKg)
        {
            Adresat = adresat;
            WagaKg = wagaKg;
        }

        // Metoda abstrakcyjna - wymusza implementację w klasach pochodnych
        public abstract double ObliczCene();
    }

    // KLASA DZIEDZICZĄCA (: Przesylka)
    public class PaczkaKurierska : Przesylka
    {
        public bool CzyEkspres { get; set; }

        // Konstruktor klasy pochodnej:
        // Przyjmuje 3 parametry i przekazuje 2 z nich (adresat, wagaKg) do konstruktora bazowego ": base(...)"
        public PaczkaKurierska(string adresat, double wagaKg, bool czyEkspres) 
            : base(adresat, wagaKg)
        {
            CzyEkspres = czyEkspres;
        }

        // Przesłonięcie (override) metody abstrakcyjnej z klasy Przesylka
        public override double ObliczCene()
        {
            double cenaPodstawowa = 15.0 + (WagaKg * 2.50);
            if (CzyEkspres)
            {
                cenaPodstawowa = cenaPodstawowa + 20.0;
            }

            return cenaPodstawowa;
        }
    }
}
```

### 4.2. Warstwa 2: Folder `ViewModel` (Plik `PrzesylkaViewModel.cs`)

```csharp
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using MVVM.Model; // Import przestrzeni nazw Modelu

namespace MVVM.ViewModel
{
    // Implementacja interfejsu INotifyPropertyChanged pozwala odświeżać ekran na żywo
    public class PrzesylkaViewModel : INotifyPropertyChanged
    {
        // 1. WŁAŚCIWOŚCI WEJŚCIOWE (powiązane z kontrolkami Entry i CheckBox)
        public string WpisanyAdresat { get; set; } = "Jan Kowalski";
        public double WpisanaWaga { get; set; } = 5.0;
        public bool WybranyEkspres { get; set; } = false;

        // 2. WŁAŚCIWOŚĆ WYJŚCIOWA (powiązana z kontrolką Label wyświetlającą wynik)
        // Prywatne pole pomocnicze ("tajna kieszeń" przechowująca tekst w pamięci)
        private string _komunikatWyniku = "Wpisz dane i kliknij Oblicz";

        // Publiczna właściwość wystawiona dla Widoku (View)
        public string KomunikatWyniku
        {
            get { return _komunikatWyniku; }
            set
            {
                _komunikatWyniku = value; // Zapisanie nowej wartości do pola prywatnego
                OnPropertyChanged();      // Wysłanie sygnału do Widoku: "Odśwież napis na ekranie!"
            }
        }

        // 3. KOMENDA (Wtyczka pod przycisk Button w XAML)
        public ICommand ObliczCeneCommand { get; set; }

        // 4. KONSTRUKTOR VIEWMODELU (Bezparametrowy - uruchamia się przy starcie ekranu)
        public PrzesylkaViewModel()
        {
            // Powiązanie komendy z metodą Oblicz()
            ObliczCeneCommand = new Command(Oblicz);
        }

        // 5. METODA WYKONYWANA PO KLIKNIĘCIU PRZYCISKU
        private void Oblicz()
        {
            // Utworzenie obiektu Modelu na podstawie danych z ekranu
            PaczkaKurierska nowaPaczka = new PaczkaKurierska(WpisanyAdresat, WpisanaWaga, WybranyEkspres);

            // Wywołanie metody obliczającej cenę z Modelu
            double cena = nowaPaczka.ObliczCene();

            // Zaktualizowanie właściwości wynikowej (uruchamia sekcję 'set' i OnPropertyChanged)
            KomunikatWyniku = $"Paczka dla: {nowaPaczka.Adresat} | Koszt: {cena} zł";
        }

        // 6.IMPLEMENTACJA INTERFEJSU INotifyPropertyChanged (Stała formułka)
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? nazwa = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nazwa));
        }
    }
}
```

### 4.3. Warstwa 3: Folder `View` (Pliki `MainPage.xaml` oraz `MainPage.xaml.cs`)

**Plik `View/MainPage.xaml`:**
```xml
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage Title="Kalkulator Przesyłek" x:Class="MVVM.View.MainPage" xmlns="[http://schemas.microsoft.com/dotnet/2021/maui](http://schemas.microsoft.com/dotnet/2021/maui)" xmlns:vm="clr-namespace:MVVM.ViewModel" xmlns:x="[http://schemas.microsoft.com/winfx/2009/xaml](http://schemas.microsoft.com/winfx/2009/xaml)">

    <!-- PODPIĘCIE VIEWMODELU DO WIDOKU (Tworzy obiekt PrzesylkaViewModel w pamięci) -->
    <ContentPage.BindingContext>
        <vm:PrzesylkaViewModel />
    </ContentPage.BindingContext>

    <VerticalStackLayout Padding="30" Spacing="15">

        <Label FontAttributes="Bold" FontSize="24" Text="Nadaj paczkę kurierską"/>

        <Label Text="Adresat przesylki: "/>
        <Entry Text="{Binding WpisanyAdresat}"/>

        <Label Text="Waga paczki (kg): "/>
        <Entry Keyboard="Numeric" Text="{Binding WpisanaWaga}"/>

        <HorizontalStackLayout Spacing="10">
            <CheckBox IsChecked="{Binding WybranyEkspres}"/>
            <Label Text="Przesylka ekspresowa (+20zl)" VerticalOptions="Center"/>
        </HorizontalStackLayout>

        <Button Command="{Binding ObliczCeneCommand}" Text="Oblicz cene"/>

        <Label FontAttributes="Bold" FontSize="18" Text="{Binding KomunikatWyniku}" TextColor="LightGreen"/>

    </VerticalStackLayout>
</ContentPage>
```

**Plik `View/MainPage.xaml.cs` (Czysty Code-Behind):**
```csharp
namespace MVVM.View
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
    }
}
```

---

## 🔍 5. Słownik mechanizmów C# i .NET MAUI (FAQ)

* **Dlaczego mamy dwie zmienne dla wyniku: `_komunikatWyniku` (`private`) oraz `KomunikatWyniku` (`public`)?**
  * Zwykła właściwość `{ get; set; }` zmienia wartość tylko w pamięci RAM, nie informując ekranu o zmianie. Aby dopisać wywołanie `OnPropertyChanged()` wewnątrz bloku `set`, w C# musimy utworzyć prywatne pole pomocnicze (`_komunikatWyniku` pisane z podłogą `_`), w którym faktycznie przechowywany jest tekst. Słowo kluczowe `value` w bloku `set` oznacza nową wartość, która właśnie wpada do właściwości.
* **Dlaczego konstruktor `PrzesylkaViewModel()` nie ma żadnych parametrów w nawiasie `()`?**
  * Ponieważ obiekt ViewModelu jest tworzony przez plik XAML w momencie uruchamiania aplikacji (`<vm:PrzesylkaViewModel />`), zanim użytkownik zdąży cokolwiek wpisać. Konstruktor ten przygotowuje jedynie formularz i podpina komendy pod przyciski.
* **Czym jest `ICommand`?**
  * W architekturze MVVM nie używamy zdarzeń `Clicked` w pliku `.xaml.cs`. Kontrolka `<Button>` w XAML komunikuje się z ViewModelem poprzez właściwość typu `ICommand`, która działa jak most łączący przycisk z metodą `private void Oblicz()`.
* **Co oznacza znak `$` przed cudzysłowem (`$"..."`) oraz znak `|`?**
  * Znak **`$`** to **interpolacja ciągów znaków (String Interpolation)** – pozwala wstawiać zmienne bezpośrednio wewnątrz tekstu w nawiasach klamrowych `{cena}`, zamiast łączyć napisy znakiem `+`.
  * Znak **`|`** wewnątrz cudzysłowu to zwykły znak tekstowy (wizualny separator oddzielający adresata od kosztu na ekranie).

---

## 🛠️ 6. Najczęstsze błędy i jak je naprawić (Troubleshooting)

1. ❌ **Wielkość liter w konstruktorze (`CzyEkspres` vs `czyEkspres`)**
   * **Przyczyna:** C# rozróżnia wielkość liter (*case-sensitive*). Jeśli parametr w nawiasie konstruktora nazwiesz z wielkiej litery, kompilator nie rozróżni go od właściwości klasy.
   * **Rozwiązanie:** Właściwości klasy pisz zawsze **Wielką Literą** (`CzyEkspres`), a parametry konstruktora **małą literą** (`bool czyEkspres`).
2. ❌ **Podawanie typów danych w wywołaniu `: base(adresat, wagaKg)`**
   * **Przyczyna:** Wpisanie `: base(string adresat, double wagaKg)` powoduje błąd kompilacji.
   * **Rozwiązanie:** Typy (`string`, `double`) podajemy tylko raz – w deklaracji konstruktora klasy pochodnej. Do `: base(adresat, wagaKg)` przekazujemy już same nazwy zmiennych.
3. ❌ **Błąd `PropertyChangingEventHandler` zamiast `PropertyChangedEventHandler`**
   * **Przyczyna:** Autouzupełnianie w Visual Studio często podpowiada złą końcówkę (`-ing` zamiast `-ed`).
   * **Rozwiązanie:** Interfejs `INotifyPropertyChanged` wymaga zdarzenia `public event PropertyChangedEventHandler? PropertyChanged;`.
4. ❌ **Brakujące biblioteki (`using`) w ViewModelu**
   * Upewnij się, że na górze pliku ViewModel znajdują się te 3 linijki (i usuń przypadkowo dodane biblioteki, np. `using Kotlin.Properties;`):
     ```csharp
     using System.ComponentModel;               // dla INotifyPropertyChanged
     using System.Runtime.CompilerServices;     // dla [CallerMemberName]
     using System.Windows.Input;                // dla ICommand
     ```
5. ❌ **Kropka zamiast dwukropka w XAML (`<vm.PrzesylkaViewModel />`)**
   * **Przyczyna:** W XAML odwołania do zaimportowanych przestrzeni nazw (`xmlns:vm`) zapisuje się z dwukropkiem.
   * **Rozwiązanie:** Zawsze używaj zapisu `<vm:PrzesylkaViewModel />`.
6. ❌ **Błąd `Nazwa „InitializeComponent” nie istnieje w bieżącym kontekście`**
   * **Przyczyna 1:** W pliku `MainPage.xaml` znajduje się błąd składniowy (np. podwójnie zamknięty nawias `>`), który blokuje generator kodu XAML.
   * **Przyczyna 2:** Po przeniesieniu `MainPage.xaml` do folderu `View`, atrybut `x:Class` w pliku `.xaml` nie zgadza się z `namespace` w pliku `.xaml.cs`.
   * **Rozwiązanie:** Upewnij się, że w obu plikach widnieje ten sam adres (`MVVM.View.MainPage`), zapisz wszystkie pliki (**Ctrl + Shift + S**) i wybierz z górnego menu **Build -> Rebuild Solution**.