using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication.Applications
{
    public abstract class Page : MVVM.ViewModel, MVVM.Messaging.INavigable
    {
        public bool IsBusy
        {
            get { return m_IsBusy; }
            set
            {
                m_IsBusy = value;
                base.OnPropertyChanged(() => IsBusy);
            }
        } bool m_IsBusy = default(bool);
        public string BusyComment
        {
            get { return m_BusyComment; }
            set
            {
                m_BusyComment = value;
                base.OnPropertyChanged(() => BusyComment);
            }
        } string m_BusyComment = default(string);

        public override void Close()
        {
            if (Nav.Service.CurrentItem == this)
                Nav.Service.NavigateBack();
            else throw new NotSupportedException("Cannot close page while it is not the current page.");
        }

        public virtual void OnNavigateTo()
        {
        }

        public virtual bool PreNavigate()
        {
            return true;
        }

        public virtual void OnNavigateAway()
        {
        }
    }
}
