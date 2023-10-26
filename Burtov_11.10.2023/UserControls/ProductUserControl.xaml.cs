using Burtov_11._10._2023.Components;
using Burtov_11._10._2023.Pages;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Burtov_11._10._2023.UserControls
{
    /// <summary>
    /// Логика взаимодействия для ProductUserControl.xaml
    /// </summary>
    public partial class ProductUserControl : UserControl
    {
        public static int SelectedUserId { get; set; }
        public Product Product;
        public ProductUserControl(Product _product)
        {
/*            int id, string Title, double? Discount, decimal Cost, string AVGdiscount, string DisCount
*/            InitializeComponent();
            Product = _product;
            TitleTb.Text = Product.Title;
            SelectedUserId = Product.Id;
            if(Product.MainImage != null)
            {
            BitmapImage BiImg = new BitmapImage();
            MemoryStream ms = new MemoryStream(Product.MainImage);
            BiImg.BeginInit();
            BiImg.StreamSource = ms;
            BiImg.EndInit();
            ProductImg.Source = BiImg as ImageSource;

            }
            if (Product.Discount != 0 )
            {
                DiscountTb.Text = $"-{Product.Discount}%";
            }
            else
            {
                DiscountTb.Visibility = Visibility.Collapsed;
                DiscountRect.Visibility = Visibility.Collapsed;
            }
            if(Product.Discount != 0)
            {
                DiscountCostTb.Visibility = Visibility.Visible;
                DiscountCostTb.Text = Math.Round(Product.Cost, 2).ToString();
            }
            CostTb.Text = $"{Math.Round(Product.Cost - (Product.Cost * (decimal)Product.Discount / 100), 2)}₽";
            FeedAVG.Text = $"★ {Product.AVGdiscount}";
            CountOfFeedbackTb.Text = Product.DisCount;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
             NavigationService.GetNavigationService(this).Navigate(new Pages.AddNewProductPage(Product));
            
        }
    }
}
