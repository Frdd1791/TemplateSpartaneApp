﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TemplateSpartaneApp.Views.ProductosNutricionales
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductosNutricionalesPage : ContentPage
    {
        public ProductosNutricionalesPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}