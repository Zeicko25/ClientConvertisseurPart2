using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientConvertisseurV2.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using ClientConvertisseurV2.Services;

namespace ClientConvertisseurV2.ViewModels
{
    public class ConvertisseurEuroViewModel : ObservableObject
    {
        private ObservableCollection<Devise> lesDevises;
        private double montant;
        private double resultat;
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
                OnPropertyChanged();
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
                OnPropertyChanged();
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
                OnPropertyChanged();
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
                OnPropertyChanged();

            }
        }

        private async void GetDataOnLoadAsync()
        {
            WSServices service = new WSServices("https://localhost:7058/api/");
            List<Devise> result = await service.GetDevisesAsync("devises");
            
            LesDevises = new ObservableCollection<Devise>(result);
        }

        public ConvertisseurEuroViewModel()
        {
            GetDataOnLoadAsync();
        }
        
    }
}
