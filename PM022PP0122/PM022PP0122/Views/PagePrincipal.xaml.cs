using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PM022PP0122.Models;


namespace PM022PP0122.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PagePrincipal : ContentPage
    {
        public PagePrincipal()
        {
            InitializeComponent();
        }

        private async void toolmenu1_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EmplePage());
        }

        private async void ListaEmpleados_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var Emple = (Empleado)e.Item;
            EmplePage page = new EmplePage();
            page.BindingContext = Emple;
            await Navigation.PushAsync(page);
            //await DisplayAlert("Alerta", " Empleado seleccionado " + Emple.nombre, "OK");
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            
            ListaEmpleados.ItemsSource = await App.DBase.ObtenerListaEmple();
        }
    }
}