using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVM;
using MVVM.Messaging;
using WpfApplication.ViewModels;

namespace WpfApplication.Applications
{
    public class Shell : ViewModel
    {
        const string TAG = "App Shell";

        public RelayCommand NavigateBackCommand
        {
            get { return m_NavigateBackCommand; }
            set
            {
                m_NavigateBackCommand = value;
                base.OnPropertyChanged(() => NavigateBackCommand);
            }
        } RelayCommand m_NavigateBackCommand = default(RelayCommand);
        public IShellView ShellView
        {
            get { return m_ShellView; }
            set
            {
                m_ShellView = value;
                base.OnPropertyChanged(() => ShellView);
            }
        } IShellView m_ShellView = default(IShellView);
        public MainMenu ShellMenu 
        { 
            get { return m_ShellMenu; } 
            set 
            { 
                m_ShellMenu = value; 
                base.OnPropertyChanged(() => ShellMenu); 
            } 
        } MainMenu m_ShellMenu = default(MainMenu);
        public Page CurrentPage
        {
            get { return m_CurrentPage; }
            set
            {
                m_CurrentPage = value;
                base.OnPropertyChanged(() => CurrentPage);
                //base.OnPropertyChanged(() => HasHelp);
            }
        } Page m_CurrentPage = default(Page);
        public Page PreviousPage
        {
            get { return m_PreviousPage; }
            set
            {
                m_PreviousPage = value;
                base.OnPropertyChanged(() => PreviousPage);
            }
        } Page m_PreviousPage = default(Page);
        public ViewModelCollection<Toast> Toasts
        {
            get { return m_Toasts; }
            set
            {
                m_Toasts = value;
                base.OnPropertyChanged(() => Toasts);
            }
        } ViewModelCollection<Toast> m_Toasts = default(ViewModelCollection<Toast>);


        public Shell(IShellView shellview)
        {
            if (shellview == null) throw new ArgumentNullException(base.GetMemberNameFromExpression(() => shellview));
            this.ShellView = shellview;
            Toasts = new ViewModelCollection<Toast>(shellview.Context);
            ShellMenu = new MainMenu(ShellView.Context);
            NavigateBackCommand = new RelayCommand(p => Nav.Service.NavigateBack(), p => Nav.Service.HasHistory);        
        }   

        /// <summary>
        /// Application Start - loads to home
        /// </summary>
        public void Start()
        {           
            CurrentPage = new PageOneViewModel();
        }

        public void Stop()
        {
        
        }

        public IntPtr RegisterWindowsMessagesHandler(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            return IntPtr.Zero;
        }

        #region Messages


        /// <summary>
        /// Log navigation between pages
        /// </summary>
        /// <param name="args"></param>
        [MediatorMessageSink(MessageKeys.Navigate)]
        public void OnNavigate(NavigationArgs<Page> args)
        {
            PreviousPage = CurrentPage;
            CurrentPage = args.Destination;
        }

        /// <summary>
        /// show the provided toast
        /// </summary>
        /// <param name="toast"></param>
        [MediatorMessageSink(MessageKeys.ShowToast)]
        public void OnShowToast(Toast toast)
        {
            m_Toasts.Add(toast);
            toast.Start();
        }

        /// <summary>
        /// Disable navigation disables all menu buttons
        /// </summary>
        [MediatorMessageSink(MessageKeys.CannotNavigate)]
        public void DisableNavigation()
        {
            ShellMenu.ButtonsEnabled = false;
        }

        /// <summary>
        /// Enable all menu buttons
        /// </summary>
        [MediatorMessageSink(MessageKeys.CanNavigate)]
        public void EnableNavigation()
        {
            ShellMenu.ButtonsEnabled = true;
        }

        #endregion
    }
}
