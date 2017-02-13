using MVVM;
using MVVM.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication.Applications;

namespace WpfApplication.ViewModels
{
    public class HomePageViewModel : WpfApplication.Applications.Page
    {


        public string Username
        {
            get
            {
                return m_Username;
            }
            set
            {
                m_Username = value;
                base.OnPropertyChanged(() => Username);
            }
        } string m_Username = default(string);

        public string Password
        {
            get
            {
                return m_Password;
            }
            set
            {
                m_Password = value;
                base.OnPropertyChanged(() => Password);
            }
        } string m_Password = default(string);

        public CommandViewModel LoginCommand
        {
            get { return m_LoginCommand; }
            set
            {
                m_LoginCommand = value;
                base.OnPropertyChanged(() => LoginCommand);
            }
        }
        CommandViewModel m_LoginCommand = default(CommandViewModel);

        public HomePageViewModel()
        {
            Username = "";
            Password = "";

            LoginCommand = new CommandViewModel
            {
                DisplayName = "Login",
                Description = "Login",
                Command = new RelayCommand(p => TryLogin())
            };
        }

        private void TryLogin()
        {
            //check credentials and act accordingly
            //display error if invalid
            //navigate to whatever page if valid
          
            //This will enable the menu buttons
            Mediator.PostMessage(MessageKeys.CanNavigate);

            Nav.Service.NavigateTo(new PageOneViewModel());
        }
    }
}
