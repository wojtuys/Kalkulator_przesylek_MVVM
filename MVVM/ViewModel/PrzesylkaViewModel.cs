using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using MVVM.Model;

namespace MVVM.ViewModel
{
    public class PrzesylkaViewModel : INotifyPropertyChanged
    {
        public string WpisanyAdresat { get; set; } = "Jan Kowalski";
        public double WpisanaWaga { get; set; } = 5.0;
        public bool WybranyzEkspres{ get; set; } = false;

        private string _komunikatWyniku = "Wpisz dane i kliknij Oblicz"; 
        public string KomunikatWyniku 
        {
            get { return _komunikatWyniku; }
            set
            {
                _komunikatWyniku = value;
                OnPropertyChanged();
            }
        }

        public ICommand ObliczCeneCommand { get; set; }

        public PrzesylkaViewModel()
        {
            ObliczCeneCommand = new Command(Oblicz);
        }

        private void Oblicz()
        {
            PaczkaKurierska nowaPaczka = new PaczkaKurierska(WpisanyAdresat, WpisanaWaga, WybranyzEkspres);

            double cena = nowaPaczka.ObliczCene();

            KomunikatWyniku = $"Paczka dla: {nowaPaczka.Adresat} | Koszt: {cena} zł"; 
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? nazwa = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nazwa));
        }

    }
    
    
}
