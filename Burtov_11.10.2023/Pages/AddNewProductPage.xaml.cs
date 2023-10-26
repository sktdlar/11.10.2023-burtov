using Burtov_11._10._2023.Components;
using Microsoft.Win32;
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
using System.Windows.Shapes;

namespace Burtov_11._10._2023.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddNewProductPage.xaml
    /// </summary>
    public partial class AddNewProductPage : Page
    {
        public Product product;
        public AddNewProductPage(Product _product)
        {
            InitializeComponent();
            product = _product;
            this.DataContext = product;
            if (product.MainImage != null)
            {
                MemoryStream ms = new MemoryStream(product.MainImage);
                BitmapImage biImg = new BitmapImage();
                biImg.BeginInit();
                biImg.StreamSource = ms;
                biImg.EndInit();
                ProdImg.Source = biImg as ImageSource;
            }
            else
            {
                ProdImg.Source = new BitmapImage(new Uri("/Source/StaticPhoto.png", UriKind.Relative)) as ImageSource;
            }
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (product.Id == 0)
            {
                
                App.db.Product.Add(product);
                App.db.SaveChanges();
                NavigationService.GoBack();

            }
            else
            {
                App.db.SaveChanges();
                NavigationService.GoBack();
            }
        }

        private void AddImage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog()
                {
                    Filter = "ПАЭНГЭ|*.png|ДЖЕПЕГ|*.jpg|ДЖПЕГ|*.jpeg"
                };
                if (openFileDialog.ShowDialog() != null)
                {
                    product.MainImage = File.ReadAllBytes(openFileDialog.FileName);
                    MemoryStream ms = new MemoryStream(product.MainImage);
                    BitmapImage biImg = new BitmapImage();
                    biImg.BeginInit();
                    biImg.StreamSource = ms;
                    biImg.EndInit();
                    ProdImg.Source = biImg as ImageSource;
                }

            }
            catch
            {

            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
