using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.LocalNotifications;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Hydratus
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : TabbedPage
    {
        //inicializačné premenné
        double vypiteLitre = 0;
        double cielLitre = 3;
        int pohlavie;


        public MainPage()
        {
            InitializeComponent();
            vypite.Text = string.Format("{0:F1}", vypiteLitre);

            //načítanie údajov
            vaha.Text = Hydratus.Nastavenie.PosledneNastavenieVahy;
            vyska.Text = Hydratus.Nastavenie.PosledneNastavenieVysky;
            picker.SelectedItem = Hydratus.Nastavenie.PosledneNastaveniePohlavia;

        }


        private void ManipulaciaPoctu(object sender, ValueChangedEventArgs e)
        {
            vypiteLitre = Dvojdecak.Value + Trojdecak.Value + Pollitrak.Value;

            vypite.Text = string.Format("{0:F1}", vypiteLitre);
            
			var odporucanyCas = DateTime.UtcNow.AddHours(2);

            progres.Progress = vypiteLitre / cielLitre;

			if (vypiteLitre >= cielLitre)
				casovac.Text = "- LIMIT DOSIAHNUTÝ -";
			else
				casovac.Text = odporucanyCas.ToString("t");
        }

        private void NahrataVaha(object sender, EventArgs e)
        {
			System.Diagnostics.Debug.WriteLine("Vaha...OK!");


        }

        private void NahrataVyska(object sender, EventArgs e)
        {
			System.Diagnostics.Debug.WriteLine("Vyska...OK!");
          
        }

        void ZmenaIndexuPohlavia(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                
                pohlavie = picker.SelectedIndex;

            }
        }

        private void PotvrdBMI_Clicked(object sender, EventArgs e)
        {
            //BMI výpočet
            double vahaVypocet, vyskaVypocet, BMIvypocet = 0;
            Double.TryParse(vaha.Text, out vahaVypocet);
            Double.TryParse(vyska.Text, out vyskaVypocet);
            BMIvypocet = vahaVypocet / (vyskaVypocet * vyskaVypocet) * 10000;

            //BMI výstup
            infoBMI.Text = string.Format("Váš BMI index: {0:F2}", BMIvypocet);

            //prísun vody výpočet
            cielLitre = vahaVypocet / 30;

            ciel.Text = string.Format("{0:F1}", cielLitre);

            //uloženie údajov
            Hydratus.Nastavenie.PosledneNastavenieVahy = vaha.Text;
            Hydratus.Nastavenie.PosledneNastavenieVysky = vyska.Text;
            Hydratus.Nastavenie.PosledneNastaveniePohlavia = picker.Items[pohlavie];

            
        }
        

    }
}
