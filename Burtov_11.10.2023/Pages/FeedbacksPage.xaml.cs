using Burtov_11._10._2023.Components;
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
    /// Логика взаимодействия для FeedbacksPage.xaml
    /// </summary>
    public partial class FeedbacksPage : Page
    {
        Product product {get; set;}
        public FeedbacksPage(Product _product)
        {
            InitializeComponent();
            product = _product;
            Refresh();
        }
        public void Refresh()
        {
            
            IEnumerable<Feedback> flist1 = App.db.Feedback.ToList();
            var feedbacks = flist1.Join(App.db.Product.ToList(),
                x => x.ProductId,
                y => y.Id,
                (x, y) =>  new {y.Title, x.Evaluation, x.Pros, x.Cons  }
                );
            if(product.Id != 0)
            {
                feedbacks = feedbacks.Where(x => x.Title == product.Title);
            }

            if (SortCb != null)
            {
                if (SortCb.SelectedIndex == 1)
                    feedbacks = feedbacks.Where(x => x.Evaluation == 1);
                if (SortCb.SelectedIndex == 2)
                    feedbacks = feedbacks.Where(x => x.Evaluation == 2);
                if (SortCb.SelectedIndex == 3)
                    feedbacks = feedbacks.Where(x => x.Evaluation == 3);
                if (SortCb.SelectedIndex == 4)
                    feedbacks = feedbacks.Where(x => x.Evaluation == 4);
                if (SortCb.SelectedIndex == 5)
                    feedbacks = feedbacks.Where(x => x.Evaluation == 5);
            }
            if(OrderCb != null)
            {
                if(OrderCb.SelectedIndex == 1)
                {
                    feedbacks = feedbacks.OrderBy(x => x.Evaluation).ToList();
                }
                 if (OrderCb.SelectedIndex == 2)
                {
                    feedbacks = feedbacks.OrderByDescending(x => x.Evaluation).ToList();
                }
            }
            FeedsDG.ItemsSource = feedbacks;
            
        }
        private void SortCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
