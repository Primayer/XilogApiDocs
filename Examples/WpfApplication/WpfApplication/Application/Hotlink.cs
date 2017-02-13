using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication.Applications
{
    public class Hotlink : MVVM.CommandViewModel
    {
        public bool ClosableByUser
        {
            get { return m_ClosableByUser; }
            set
            {
                m_ClosableByUser = value;
                base.OnPropertyChanged(() => ClosableByUser);
            }
        } bool m_ClosableByUser = default(bool);
        /// <summary>
        /// Conent for this hotlink
        /// </summary>
        public object Content
        {
            get
            {
                return m_Content ?? DisplayName;
            }
            set
            {
                m_Content = value;
                base.OnPropertyChanged(() => Content);
            }
        } object m_Content = default(object);
        /// <summary>
        /// Gets or sets the category into which this hotlink should be sorted. Ideally, this string is user friendly.
        /// </summary>
        public string Category
        {
            get { return m_Category; }
            set
            {
                m_Category = value;
                base.OnPropertyChanged(() => Category);
            }
        } string m_Category = default(string);
    }
}
