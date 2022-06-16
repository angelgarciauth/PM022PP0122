using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PM022PP0122.Models;
using PM022PP0122.Controller;
using Plugin.Media;
using System.IO;

namespace PM022PP0122.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmplePage : ContentPage
    {
        Plugin.Media.Abstractions.MediaFile FileFoto = null;
        public EmplePage()
        {
            InitializeComponent();
        }

        private Byte[] ConvertImageToByteArray()
        {
            if(FileFoto != null)
            {
                using (MemoryStream memory = new MemoryStream())
                {
                    Stream stream = FileFoto.GetStream();
                    stream.CopyTo(memory);
                    return memory.ToArray();

                }
            }
            return null;
        }
 

        private async void btnSave_Clicked(object sender, EventArgs e)
        {
            if (FileFoto == null)
            {
                await DisplayAlert("Error", "No se ha tomado una fotografia", "OK");
                return;
            }

            var emple = new Empleado
            {
                id = 0,
                nombre = txtNombre.Text,
                edad = txtEdad.Text,
                genero = genero.SelectedItem.ToString(),
                fechaIngreso = fecha.Date,
                foto = ConvertImageToByteArray()

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

        private async void btnDelete_Clicked(object sender, EventArgs e)
        {
            var emple = new Empleado
            {
                id = Convert.ToInt32(txtId.Text),
                nombre = txtNombre.Text,
                edad = txtEdad.Text,
                genero = genero.SelectedItem.ToString(),
                fechaIngreso = fecha.Date
            };
            var result = await App.DBase.EmpleDelete(emple);
        }

        private void clear()
        {
            txtNombre.Text = "";
            txtEdad.Text = "";
            txtNombre.Text = "";

        }

        private async void btnActualizar_Clicked(object sender, EventArgs e)
        {
            var emple = new Empleado
            {
                id = 0,
                nombre = txtNombre.Text,
                edad = txtEdad.Text,
                genero = genero.SelectedItem.ToString(),
                fechaIngreso = fecha.Date
            };
            var result = await App.DBase.EmpleDelete(emple);
        }

        private async void btnTomarFoto_Clicked(object sender, EventArgs e)
        {
            FileFoto = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "MisFotos",
                Name = "test.jpg",
                SaveToAlbum = true


            });

            await DisplayAlert("path directorio", FileFoto.Path, "OK");

            if (FileFoto != null)
            {
                Foto.Source = ImageSource.FromStream(() =>
                {
                    return FileFoto.GetStream();
                });
            }
        }
    }
}