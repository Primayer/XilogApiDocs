using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication.Applications
{
    public interface IShellView
    {
        System.Threading.SynchronizationContext Context { get; }
        void Close();
    }
}
