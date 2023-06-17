using Cryptocurrencies.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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

namespace Cryptocurrencies.Views
{
    /// <summary>
    /// Interaction logic for CryptocurrencyPage.xaml
    /// </summary>
    public partial class CryptocurrencyPage : Page
    {
        public CryptocurrencyPage(RowCryptocurrencyInfoViewModel rowCryptocurrencyInfoViewModel)
        {
            InitializeComponent();
        }
    }
}
