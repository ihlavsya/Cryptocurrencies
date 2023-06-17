using Cryptocurrencies.ViewModels;
using Cryptocurrencies.Views;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
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

namespace Cryptocurrencies.Components
{
    /// <summary>
    /// Interaction logic for GridCryptocurrencyInfo.xaml
    /// </summary>
    public partial class GridCryptocurrencyInfo : UserControl
    {
        public GridCryptocurrencyInfo()
        {
            InitializeComponent();
        }

        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            var a = e.GetPosition(this);
            var b = 3;
        }

        private void DataGrid_CellClicked(object sender, RoutedEventArgs e)
        {
            // Starts the Edit on the row;
            DataGrid grd = (DataGrid)sender;
            var rowView = grd.SelectedItem as RowCryptocurrencyInfoViewModel;
            if (rowView != null)
            {
                CryptocurrencyPage cryptocurrencyPage = new CryptocurrencyPage(rowView)
                {
                    DataContext = rowView
                };
                NavigationService ns = NavigationService.GetNavigationService(this);
                ns.Navigate(cryptocurrencyPage); 
            }
        }
    }
}
