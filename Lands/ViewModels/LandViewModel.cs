﻿
namespace Lands.ViewModels
{
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using Models;

    public class LandViewModel: BaseViewModel
    {

        #region properties
        public Land Land
        {
            get;
            set;
        }


        public ObservableCollection<Border> Borders
        {
            get { return this.borders; }
            set { this.SetValue(ref this.borders, value); }
        }

        public ObservableCollection<Currency> Currencies
        {
            get { return this.currencies; }
            set { this.SetValue(ref this.currencies, value); }
        }

        public ObservableCollection<Language> Languages
        {
            get { return this.languages; }
            set { this.SetValue(ref this.languages, value); }
        }

        #endregion


        #region Attributes
        private ObservableCollection<Border> borders;
        private ObservableCollection<Currency> currencies;
        private ObservableCollection<Language> languages;
        #endregion



        #region constructor
        public LandViewModel(Land land)
        {
            this.Land = land;
            this.LoadBorders();
            this.Currencies = new ObservableCollection<Currency>(this.Land.Currencies);
            this.Languages = new ObservableCollection<Language>(this.Land.Languages);
        }


        #endregion

        #region Methods
        private void LoadBorders()
        {
            this.Borders = new ObservableCollection<Border>();
            foreach (var item in this.Land.Borders)
            {
                var land = MainViewModel.ObtenerInstancia().LandsList.Where(l => l.Alpha3Code == item).FirstOrDefault();

                if (land != null)
                {
                    this.Borders.Add(new Border { Code = land.Alpha3Code, Name = land.Name });
                }
            }

        }
        #endregion
    }
}
