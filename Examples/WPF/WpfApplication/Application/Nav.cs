using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication.Applications
{
    /// <summary>
    /// Singleton exposure of a <see cref="NavigationService"/>
    /// </summary>
    public static class Nav
    {
        static System.Threading.ReaderWriterLockSlim padlock = new System.Threading.ReaderWriterLockSlim();
        static MVVM.Messaging.NavigationService<Page> m_Service;
        public static MVVM.Messaging.NavigationService<Page> Service
        {
            get
            {
                lock (padlock)
                {
                    padlock.EnterUpgradeableReadLock();

                    if (m_Service == null)
                    {
                        try
                        {
                            padlock.EnterWriteLock();
                            m_Service = new MVVM.Messaging.NavigationService<Page>(MessageKeys.Navigate);
                        }
                        finally
                        {
                            padlock.ExitWriteLock();
                        }
                    }

                    padlock.ExitUpgradeableReadLock();

                    return m_Service;
                }
            }
        }
    }
}
