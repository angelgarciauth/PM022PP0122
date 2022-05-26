using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PM022PP0122
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        public MainPage(DateTime date)
        {
            InitializeComponent();
        }

        private async void btnMostrar_Clicked(object sender, EventArgs e)
        {
            
           await DisplayAlert("Aviso", String.Format("Nombre: {0} Edad: {1}", txtNombre.Text, txtEdad.Text),"OK");

        }
       

        private async void btnSegundaPag_Clicked(object sender, EventArgs e)
        {
            var emple = new Models.Empleado
            {
                nombre = txtNombre.Text,
                edad = txtEdad.Text
            };
            var segunda = new SecondPage();
            segunda.BindingContext = emple;
            await Navigation.PushAsync(segunda);
        }
    }
}
