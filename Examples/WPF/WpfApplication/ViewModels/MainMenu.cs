using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MVVM;
using MVVM.Messaging;
using WpfApplication.Applications;

namespace WpfApplication.ViewModels
{

    public class MainMenu : ViewModel
    {

        #region properties

        private SynchronizationContext m_context = null;


        //Add/edit items to add/remove from menu

        public RelayCommand MenuItem1
        {
            get { return m_MenuItem1; }
            set
            {
                m_MenuItem1 = value;
                base.OnPropertyChanged(() => MenuItem1);
            }
        } RelayCommand m_MenuItem1 = default(RelayCommand);

        public RelayCommand MenuItem2
        {
            get { return m_MenuItem2; }
            set
            {
                m_MenuItem2 = value;
                base.OnPropertyChanged(() => MenuItem2);
            }
        } RelayCommand m_MenuItem2 = default(RelayCommand);

        public RelayCommand MenuItem3
        {
            get { return m_MenuItem3; }
            set
            {
                m_MenuItem3 = value;
                base.OnPropertyChanged(() => MenuItem3);
            }
        } RelayCommand m_MenuItem3 = default(RelayCommand);

        public RelayCommand MenuItem4
        {
            get { return m_MenuItem4; }
            set
            {
                m_MenuItem4 = value;
                base.OnPropertyChanged(() => MenuItem4);
            }
        } RelayCommand m_MenuItem4 = default(RelayCommand);

        public RelayCommand MenuItem5
        {
            get { return m_MenuItem5; }
            set
            {
                m_MenuItem5 = value;
                base.OnPropertyChanged(() => MenuItem5);
            }
        }
        RelayCommand m_MenuItem5 = default(RelayCommand);

        public RelayCommand MenuItem6
        {
            get { return m_MenuItem6; }
            set
            {
                m_MenuItem6 = value;
                base.OnPropertyChanged(() => MenuItem6);
            }
        }
        RelayCommand m_MenuItem6 = default(RelayCommand);

        public RelayCommand MenuItem7
        {
            get { return m_MenuItem7; }
            set
            {
                m_MenuItem7 = value;
                base.OnPropertyChanged(() => MenuItem7);
            }
        }
        RelayCommand m_MenuItem7 = default(RelayCommand);
        public RelayCommand MenuItem8
        {
            get { return m_MenuItem8; }
            set
            {
                m_MenuItem8 = value;
                base.OnPropertyChanged(() => MenuItem8);
            }
        }
        RelayCommand m_MenuItem8 = default(RelayCommand);

        public RelayCommand MenuItem9
        {
            get { return m_MenuItem9; }
            set
            {
                m_MenuItem9 = value;
                base.OnPropertyChanged(() => MenuItem9);
            }
        }
        RelayCommand m_MenuItem9 = default(RelayCommand);

        public RelayCommand MenuItem10
        {
            get { return m_MenuItem10; }
            set
            {
                m_MenuItem10 = value;
                base.OnPropertyChanged(() => MenuItem10);
            }
        }
        RelayCommand m_MenuItem10 = default(RelayCommand);

        public bool ButtonsEnabled
        {
            get
            {
                return m_ButtonsEnabled;
            }
            set
            {
                m_ButtonsEnabled = value;
                base.OnPropertyChanged(() => ButtonsEnabled);
            }
        } bool m_ButtonsEnabled = default(bool);

        #endregion

        #region Constructor

        public MainMenu(SynchronizationContext context)
        {
            //Create each item as a relay command(navigate) loads a new view into the shell
            m_context = context;
            MenuItem1 = new RelayCommand(p => Nav.Service.NavigateTo(new PageOneViewModel()));
            MenuItem2 = new RelayCommand(p => Nav.Service.NavigateTo(new PageTwoViewModel()));
            MenuItem3 = new RelayCommand(p => Nav.Service.NavigateTo(new PageThreeViewModel()));
            MenuItem4 = new RelayCommand(p => Nav.Service.NavigateTo(new PageFourViewModel()));
            MenuItem5 = new RelayCommand(p => Nav.Service.NavigateTo(new PageFiveViewModel()));
            MenuItem6 = new RelayCommand(p => Nav.Service.NavigateTo(new PageSixViewModel()));
            MenuItem7 = new RelayCommand(p => Nav.Service.NavigateTo(new PageSevenViewModel()));
            MenuItem8 = new RelayCommand(p => Nav.Service.NavigateTo(new PageEightViewModel()));
            MenuItem9 = new RelayCommand(p => Nav.Service.NavigateTo(new PageNineViewModel()));
            MenuItem10 = new RelayCommand(p => Nav.Service.NavigateTo(new PageTenViewModel()));

            ButtonsEnabled = true;
        }

        #endregion

     
    }
}
