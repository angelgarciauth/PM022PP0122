using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PM022PP0122.Models;
using PM022PP0122.Controller;

namespace PM022PP0122.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmplePage : ContentPage
    {
        public EmplePage()
        {
            InitializeComponent();
        }

 

        private async void btnSave_Clicked(object sender, EventArgs e)
        {
            var emple = new Empleado
            {
                id = 0,
                nombre = txtNombre.Text,
                edad = txtEdad.Text,
                genero = genero.SelectedItem.ToString(),
                fechaIngreso = fecha.Date
            };
            
            var result = await App.DBase.EmpleSave(emple);
            if (result > 0)
            {
                await DisplayAlert("Alert", "Guardado Correctamente", "OK");
            }
            else
            {
                await DisplayAlert("Alert", "Ha ocurrido un error", "OK");
            }
            
            clear();

        }

        private void btnDelete_Clicked(object sender, EventArgs e)
        {

        }

        private void clear()
        {
            txtNombre.Text = "";
            txtEdad.Text = "";
            txtNombre.Text = "";

        }
    }
}