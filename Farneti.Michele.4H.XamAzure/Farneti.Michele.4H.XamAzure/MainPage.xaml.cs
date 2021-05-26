using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Farneti.Michele._4H.XamAzure.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace Farneti.Michele._4H.XamAzure
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            List<Studente> elenco = new List<Studente>();

            //elenco.Add(new Studente { Nome = "Marco", Cognome="Togni" });
            //elenco.Add(new Studente { Nome = "Marco", Cognome = "Rospi" });
            //elenco.Add(new Studente { Nome = "Mario", Cognome = "Doccia" });

            try
            {
                HttpClient client = new HttpClient();
                string response = await client.GetStringAsync("https://flr.azurewebsites.net/studenti");
                elenco = JsonConvert.DeserializeObject<List<Studente>>(response);
            }
            catch (Exception err)
            {
                await DisplayAlert("Ocio!!", err.Message, "Ok");
            }
           
            lvStudenti.ItemsSource = elenco;
        }
    }
}
