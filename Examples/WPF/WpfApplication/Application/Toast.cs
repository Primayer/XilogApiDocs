using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVM;

namespace WpfApplication.Applications
{
    public class Toast : ViewModel
    {
        public static readonly TimeSpan SHORT = new TimeSpan(0, 0, 3);
        public static readonly TimeSpan LONG = new TimeSpan(0, 0, 6);

        System.Threading.Timer m_Timer = null;
        TimeSpan m_Duration;
        /// <summary>
        /// Gets or sets the action to perform when the toast is activated (clicked)
        /// </summary>
        public RelayCommand ActivateCommand
        {
            get { return m_ActivateCommand; }
            set
            {
                m_ActivateCommand = value;
                base.OnPropertyChanged(() => ActivateCommand);
            }
        } RelayCommand m_ActivateCommand = default(RelayCommand);

        /// <summary>
        /// Gets or sets the content of this toast. If null, returns display name.
        /// </summary>
        public object Content
        {
            get { return m_Content ?? this.DisplayName; }
            set
            {
                m_Content = value;
                base.OnPropertyChanged(() => Content);
            }
        } object m_Content = default(object);

        public Toast()
            : this(SHORT)
        {

        }
        public Toast(TimeSpan displayDuration)
        {
            m_Duration = displayDuration;
            ActivateCommand = CloseCommand;
        }
        public void Start()
        {
            if (m_Timer != null)
                m_Timer.Change(System.Threading.Timeout.Infinite, System.Threading.Timeout.Infinite);
            m_Timer = new System.Threading.Timer(p => TimeExpired(), null, Convert.ToInt32(m_Duration.TotalMilliseconds), System.Threading.Timeout.Infinite);
        }

        void TimeExpired()
        {
            this.Close();
        }
    }
}
