using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burtov_11._10._2023.Components
{
    public partial class Product
    {
                    public string AVGdiscount
                {
                get
                {
                    
                    int count = 0;
                    double avgfeed = 0;
                    foreach (var p in App.db.Feedback.ToList())
                    {
                        if (p.ProductId == Id)
                        {
                            count++;
                            avgfeed += p.Evaluation;

                        }

                    }
                    return $"{Math.Round(avgfeed / count, 1)}";
                }
            }
            public string DisCount
            {
                get
                {
                    int count = 0;
                    foreach (var p in App.db.Feedback.ToList())
                    {
                        if (p.ProductId == Id)
                        {
                        count++;
                        }

                    }
                    return $"Количество отзывов: {count}";
                }
            }
        }
    }

