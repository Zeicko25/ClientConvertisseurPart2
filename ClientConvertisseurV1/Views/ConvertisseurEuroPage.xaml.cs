// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using ClientConvertisseurV1.Models;
using ClientConvertisseurV1.Services;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ClientConvertisseurV1.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ConvertisseurEuroPage : Page, INotifyPropertyChanged
    {
        public ConvertisseurEuroPage()
        {
            this.InitializeComponent();
            this.DataContext = this;
            GetDataOnLoadAsync();
        }
        private ObservableCollection<Devise> lesDevises;
        private double montant;
        private double resultat;
        public event PropertyChangedEventHandler? PropertyChanged;
        private Devise selectedDevise;
        public ObservableCollection<Devise> LesDevises
        {
            get
            {
                return lesDevises;
            }

            set
            {
                lesDevises = value;
                OnPropertyChanged(nameof(LesDevises));
            }
        }

        public Devise SelectedDevise
        {
            get
            {
                return selectedDevise;
            }

            set
            {
                selectedDevise = value;
                OnPropertyChanged(nameof(SelectedDevise));
            }
        }

        public double Montant
        {
            get
            {
                return montant;
            }

            set
            {
                montant = value;
                OnPropertyChanged(nameof(Montant));
            }
        }

        public double Resultat1
        {
            get
            {
                return resultat;
            }

            set
            {
                resultat = value;
                OnPropertyChanged(nameof(Resultat1));

            }
        }

        private async void GetDataOnLoadAsync()
        {
            WSService service = new WSService("https://localhost:7155/api/");
            List<Devise> result = await service.GetDevisesAsync("devises");
            LesDevises = new ObservableCollection<Devise>(result);
        }
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        private void ConvertMoney(object sender, RoutedEventArgs e)
        {
            Resultat1 = SelectedDevise.Taux * Montant;
        }


    }
}
