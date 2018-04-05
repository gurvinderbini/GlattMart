using System;
using System.ComponentModel;
using System.Net.Http;
using System.Threading.Tasks;
using FluentValidation;
using GlattMart.Helper;
using GlattMart.Models;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace GlattMart
{
    public class SignupPageModel: FreshMvvm.FreshBasePageModel,INotifyPropertyChanged
    {
        public SignupValidatorModel UserObj { get; set; }
        ServiceResponse<string> data = new ServiceResponse<String>();

        private string _firstname;
        public string FirstName
        {
            get
            {
                return _firstname;
            }
            set
            {
                _firstname = value;
                OnPropertyChanged("FirstName");
                //this.Set(ref this._username, value, "UserName");
            }
        }

        private string _lastname;
        public string LastName
        {
            get
            {
                return _lastname;
            }
            set
            {
                _lastname = value;
                OnPropertyChanged("LastName");
                //this.Set(ref this._username, value, "UserName");
            }
        }

        private string _email;
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                OnPropertyChanged("Email");
                //this.Set(ref this._username, value, "UserName");
            }
        }

        private string _mobileno;
        public string Mobileno
        {
            get
            {
                return _mobileno;
            }
            set
            {
                _mobileno = value;
                OnPropertyChanged("Mobileno");
                //this.Set(ref this._username, value, "UserName");
            }
        }

        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged("Password");
                //this.Set(ref this._password, value, "Password");
            }
        }


        private readonly IValidator _validator;
        public SignupPageModel()
        {
            _validator = new SignUpValidator();
        }
        private Command signUpCommand;
        public Command SignUpCommand
        {
            get
            {
                return signUpCommand ?? (signUpCommand = new Command(ExecuteSignUpCommand));
            }
        }
        private string _validateMessage;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public string ValidateMessage
        {
            get
            {
                return _validateMessage;
            }
            set
            {
                _validateMessage = value;
                OnPropertyChanged("ValidateMessage");
                //this.Set(ref this._validateMessage, value, "ValidateMessage");
            }
        }
        protected async void ExecuteSignUpCommand()
        {
            UserObj = new SignupValidatorModel
            {
                FirstName = _firstname,
                LastName = _lastname,
                Email=_email,
                Password=_password,
                MobileNo=_mobileno,

            };
            ValidateMessage = "";
            var validationResult = _validator.Validate(UserObj);
            if (validationResult.IsValid)
            {

                await Task.Factory.StartNew(() =>
                {
                    DependencyService.Get<IProgressbar>().Show("");
                    SignupParamModel param = new SignupParamModel();
                    param.token = ConstantData.token;
                    param.firstname = FirstName;
                    param.lastname = LastName;
                    param.email = Email;
                    param.password = Password;
                    param.company = Mobileno;
                    data = ServiceManager.GenericRestCallUsingHttpClient<string, SignupParamModel>("account/createAccount", HttpMethod.Post, param);
                });
                DependencyService.Get<IProgressbar>().Hide();
                if (data != null)
                {
                    if (data.Data != null)
                    {
                        var resultSet = JsonConvert.DeserializeObject<SignupModelResponse>(data.Data);
                        if (resultSet.result == true)
                        {
                            var result = await Application.Current.MainPage.DisplayAlert("Success", "Account created successfully", null, "Continue to Login");
                            if (!result)
                            {
                                await Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
                            }
                            // await Application.Current.MainPage.Navigation.PopToRootAsync();
                        }
                        else
                        {
                            await Application.Current.MainPage.DisplayAlert("Alert", resultSet.msg, "OK");
                        }
                        //LoginResponseModel
                    }
                }
            }
            else
            {
                for (int i = 0; i < validationResult.Errors.Count;i++)
                {
                    ValidateMessage += validationResult.Errors[i] + "\n";
                }
                await Application.Current.MainPage.DisplayAlert("Alert", ValidateMessage, "OK");
            }
        }
    }
}