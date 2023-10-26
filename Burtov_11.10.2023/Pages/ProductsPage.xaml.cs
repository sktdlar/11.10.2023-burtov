using Burtov_11._10._2023.Components;
using Burtov_11._10._2023.UserControls;
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

namespace Burtov_11._10._2023.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProductsPage.xaml
    /// </summary>
    public partial class ProductsPage : Page
    {
        public ProductsPage()
        {

            InitializeComponent();
            Refresh();
        }
        private void Refresh()
        {
            IEnumerable<Product> products = App.db.Product.ToList();
            if (DiscoCb.SelectedIndex != 0)
            {
                if (DiscoCb.SelectedIndex == 1)
                {
                    products = products.Where(x => x.Discount <= 15);
                }
                if (DiscoCb.SelectedIndex == 2)
                {
                    products = products.Where(x => x.Discount <= 30 & x.Discount >= 16);
                }
                if (DiscoCb.SelectedIndex == 3)
                {
                    products = products.Where(x => x.Discount <= 31 & x.Discount >= 75);
                }
                if (DiscoCb.SelectedIndex == 4)
                {
                    products = products.Where(x => x.Discount <= 75 & x.Discount >= 100);
                }
            }
            if (CostCb.SelectedIndex != 0)
            {
                if (CostCb.SelectedIndex == 1)
                {
                    products = products.OrderBy(x => x.Title).ToList();
                }
                if (CostCb.SelectedIndex == 2)
                {
                    products = products.OrderByDescending(x => x.Title).ToList();
                }
            }
         
            if (SearchTB.Text != "")
            {
                products = products.Where(x => x.Title.Contains(SearchTB.Text) || x.Title.ToLower().Contains(SearchTB.Text) || x.Title.ToUpper().Contains(SearchTB.Text));
            }
            ProductsWrapPanel.Children.Clear();
            foreach (var item in products)
            {
                ProductsWrapPanel.Children.Add(new ProductUserControl(item));
            }
        }

        private void DiscoCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void Cost_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }

        private void AddNewProduct_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GetNavigationService(this).Navigate(new Pages.AddNewProductPage(new Product()));
        }

        private void GoBackBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                NavigationService.GetNavigationService(this).GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
        }
    }
}

