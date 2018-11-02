﻿

namespace Lands.ViewModels
{
    using System.ComponentModel;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using Xamarin.Forms;

    public class LoginViewModel : INotifyPropertyChanged
    {

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Atributos_a_refrescar_loginviewModel
            private string email;
            private string password;
            private bool isrunning;
            private bool isenabled;
        #endregion

        #region Properties
        public string Email
        {
            get;
            set;
        }

        public string Password
        {
            get { return this.password;  }
            set {
                if (this.password != value)
                {
                    this.password = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Password)));
                }

            }
        }

        public bool IsRunning
        {
            get { return this.isrunning; }
            set
            {
                if (this.isrunning != value)
                {
                    this.isrunning = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.IsRunning)));
                }

            }
        }

        public bool IsRemembered
        {
            get;
            set;
        }
        public bool IsEnabled
        {
            get { return this.isenabled; }
            set
            {
                if (this.isenabled != value)
                {
                    this.isenabled = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.IsEnabled)));
                }

            }
        }

        #endregion

        #region Command

        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(Login);

            }


        }



        private async void Login()
        {
            if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert("Error",
                                                          "You must enter an Email",
                                                          "Accept");
                return;
            }
            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert("Error",
                                                           "You must enter a Password",
                                                           "Accept");
                return;
            }


            IsRunning = true;
            IsEnabled = false;

            if (this.Email != "cf" || this.Password != "123")
            {

                IsRunning = false;
                IsEnabled = true;

                await Application.Current.MainPage.DisplayAlert("Error",
                                                           "Email or Password Incorrect",
                                                           "Accept");

                this.Password = string.Empty;
                // se debe de implementar una interfaz INotifyPropertyChanged por que no se 
                // blanquea la caja de texto password
                // solo se blanquea la variable en el loginviewmodel, pero no esta blanqueado en la loginPage, por tal motivo la interfaz 
                return;
            }



            IsRunning = false;
            IsEnabled = true;

            await Application.Current.MainPage.DisplayAlert("OK",
                                                           "Yeahhh",
                                                           "Accept");

        }


        #endregion


        #region Constructors

        public LoginViewModel()
        {
            this.IsRemembered = true;
            this.IsEnabled = true;
        }

        #endregion
    }
}
