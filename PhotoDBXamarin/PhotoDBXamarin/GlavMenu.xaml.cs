using PhotoDBXamarin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PhotoDBXamarin
{
    public partial class MainPage : ContentPage
    {
        string path;
        string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        public MainPage()
        {
            InitializeComponent();
            ImageList.RefreshCommand = new Command(() =>
            {
                ImageList.IsRefreshing = false;
            });
        }

        async void GetPhotoAsync(object sender, EventArgs e)
        {
            try
            {
                // выбираем фото
                var photo = await MediaPicker.PickPhotoAsync();
                path = photo.FullPath;
                // загружаем в ImageView
                //img.Source = ImageSource.FromFile(photo.FullPath);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Сообщение об ошибке", ex.Message, "OK");
            }
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            UpdateList();
        }


        async void TakePhotoAsync(object sender, EventArgs e)
        {
            try
            {
                var photo = await MediaPicker.CapturePhotoAsync(new MediaPickerOptions
                {
                    Title = $"xamarin.{DateTime.Now.ToString("dd.MM.yyyy_hh.mm.ss")}.png"
                });

                // для примера сохраняем файл в локальном хранилище
                var newFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), photo.FileName);
                using (var stream = await photo.OpenReadAsync())
                using (var newStream = File.OpenWrite(newFile))
                    await stream.CopyToAsync(newStream);

                Debug.WriteLine($"Путь фото {photo.FullPath}");
                path = photo.FullPath;
                // загружаем в ImageView
                //img.Source = ImageSource.FromFile(photo.FullPath);
                UpdateList();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Сообщение об ошибке", ex.Message, "OK");
            }
        }
        void UpdateList()
        {
            ImageList.ItemsSource = null;
            ImageList.ItemsSource = App.Db.GetProjects();
        }

        private void imgList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //img.Source =  e.SelectedItem;
        }

        private void BtnADD_Clicked(object sender, EventArgs e)
        {
            try
            {
                App.Db.SaveItem(new Models.ProjectModel(Namelabel.Text, path));
                UpdateList();
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", ex.Message, "OK");  
            }
        }

        private async void ImageList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            await Navigation.PushAsync(new PhotoPage((ProjectModel)e.Item));
        }
    }
}
