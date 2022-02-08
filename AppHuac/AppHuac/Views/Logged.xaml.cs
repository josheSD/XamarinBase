﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppHuac.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Logged : ContentPage
    {
        public Logged()
        {
            InitializeComponent();
            ValidateSesion();
        }

        private async void ValidateSesion()
        {
            bool userFound = await App.Database.GetUserByCode((string)Enums.Enums.TypeLocalStorage.USER);

            if (userFound)
            {
                Application.Current.MainPage = new NavigationPage(new Dashboard());
            }
            else
            {
                Application.Current.MainPage = new Login();
            }
        }
    }
}