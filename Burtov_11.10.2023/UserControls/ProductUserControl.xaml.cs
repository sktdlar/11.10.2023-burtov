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

namespace Burtov_11._10._2023.UserControls
{
    /// <summary>
    /// Логика взаимодействия для ProductUserControl.xaml
    /// </summary>
    public partial class ProductUserControl : UserControl
    {
        public static int SelectedUserId { get; set; }
        public ProductUserControl(int id, string Title, double? Discount, decimal Cost/*, string AVGdiscount, string DisCount*/)
        {
            InitializeComponent();
            TitleTb.Text = Title;
            SelectedUserId = id;
            if (Discount != 0 )
            {
                DiscountTb.Text = $"-{Discount}%";
            }
            else
            {
                DiscountTb.Visibility = Visibility.Collapsed;
                DiscountRect.Visibility = Visibility.Collapsed;
            }
            CostTb.Text = $"{Math.Round(Cost, 2)}₽";
            //FeedAVG.Text = AVGdiscount;

        }
    }
}
