﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoDBXamarin.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PhotoDBXamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PhotoPage : ContentPage
    {
        ProjectModel model;
        public static string title;
        public PhotoPage(ProjectModel model)
        {
            this.model = model;
            title = model.Name;
            InitializeComponent();
            Gay.Source = ImageSource.FromFile(model.Imagepath);
            //var pinchGesture = new PinchGestureRecognizer();
            //pinchGesture.PinchUpdated += (s, e) => {
            //    // Handle the pinch
            //};
            //Gay.GestureRecognizers.Add(pinchGesture);
        }
        //void OnPinchUpdated(object sender, PinchGestureUpdatedEventArgs e)
        //{
        //    // Handle the pinch
        //}

    }
}