

namespace Lands.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using Models;
    using Services;
    using Xamarin.Forms;

    public class LandsViewModel : BaseViewModel
    {




        #region services
        private ApiService apiService;


        #endregion

        #region Attributes

        //private List<Land> lands;
        // no debe ser una lista sencilla debe ser una lista que se va a pintar  y refrescar, por eso debe ser una observable collections

        private ObservableCollection<LandItemViewModel> lands;
        private bool isRefreshing;
        private string filtro;
        private List<Land> landsList;

        #endregion

        #region Properties
        public ObservableCollection<LandItemViewModel> Lands
        {
            get { return this.lands; }
            set { SetValue(ref this.lands, value); }
        }

        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { SetValue(ref this.isRefreshing, value); }
        }

        public string Filtro
        {
            get { return this.filtro; }
            set 
            { 
                SetValue(ref this.filtro, value);
                this.Buscador();
            }
        }


        #endregion

        #region constructors

        public LandsViewModel()
        {

            this.apiService = new ApiService();
            this.LoadLands();
        }



        #endregion


        #region Methods
        private async void LoadLands()
        {


            this.IsRefreshing = true;

            var conexion = await this.apiService.CheckConnection();
            if (!conexion.IsSuccess)
            {

                this.IsRefreshing = false;

                await Application.Current.MainPage.DisplayAlert("Error", conexion.Message, "Accept");

                await Application.Current.MainPage.Navigation.PopAsync();
                return;
            }


            var response = await this.apiService.GetList<Land>("http://restcountries.eu",
                                                                "/rest",
                                                                "/v2/all");

            if (!response.IsSuccess)
            {

                this.IsRefreshing = false;

                await Application.Current.MainPage.DisplayAlert("Error", response.Message, "Accept");
                return;

            }

            this.landsList = (List<Land>)response.Result;
            this.Lands = new ObservableCollection<LandItemViewModel>(this.ToLandItemViewModel()); // transformar a una lista observable para pintarla en la pantalla 

            this.IsRefreshing = false;
        }





        #endregion


        #region Methods
        private IEnumerable<LandItemViewModel> ToLandItemViewModel()
        {
            return this.landsList.Select(l => new LandItemViewModel
            {
                Alpha2Code = l.Alpha2Code,
                Alpha3Code = l.Alpha3Code,
                AltSpellings = l.AltSpellings,
                Area = l.Area,
                Borders = l.Borders,
                CallingCodes = l.CallingCodes,
                Capital = l.Capital,
                Cioc = l.Cioc,
                Currencies = l.Currencies,
                Demonym = l.Demonym,
                Flag = l.Flag,
                Gini = l.Gini,
                Languages = l.Languages,
                Latlng = l.Latlng,
                Name = l.Name,
                NativeName = l.NativeName,
                NumericCode = l.NumericCode,
                Population = l.Population,
                Region = l.Region,
                RegionalBlocs = l.RegionalBlocs,
                Subregion = l.Subregion,
                Timezones = l.Timezones,
                TopLevelDomain = l.TopLevelDomain,
                Translations = l.Translations,
            });

        }

        #endregion


        #region command

        public ICommand RefreshCommand
        {
            get { return new RelayCommand(LoadLands); }
            
        }

        public ICommand BuscadorCommand
        {
            get { return new RelayCommand(Buscador); }
        }

        private void Buscador()
        {
            if (string.IsNullOrEmpty(Filtro))
            {
                this.Lands = new ObservableCollection<LandItemViewModel>(this.ToLandItemViewModel());
            }
            else
            {
                this.Lands = new ObservableCollection<LandItemViewModel>(this.ToLandItemViewModel().Where(l => l.Name.ToLower().Contains(this.Filtro.ToLower()) ||
                                                                                l.Capital.ToLower().Contains(this.Filtro.ToLower())));
            }
        }

        #endregion
    }
}
