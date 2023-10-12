﻿using Burtov_11._10._2023.Components;
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

namespace Burtov_11._10._2023
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var products = App.db.Product.ToList();
            foreach (var product in products)
            {
                ProductsWrapPanel.Children.Add(new UserControls.ProductUserControl(product.Id, product.Title, product.Discount, product.Cost, product.AVGdiscount, product.DisCount));
            }
        }
    }
}
