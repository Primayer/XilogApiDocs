using WpfApplication.Applications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IShellView
    {

        Shell m_Shell = null;
        public System.Threading.SynchronizationContext Context
        {
            get
            {
                return m_Context ?? (m_Context = new System.Windows.Threading.DispatcherSynchronizationContext(this.Dispatcher));
            }
        }
        System.Threading.SynchronizationContext m_Context = default(System.Threading.SynchronizationContext);

        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = m_Shell = new Shell(this as IShellView);

            m_Shell.Start();
        }
    }
}
