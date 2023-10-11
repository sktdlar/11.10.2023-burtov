using Burtov_11._10._2023.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burtov_11._10._2023.Components.PartialClass
{
    public partial class product
    {
                    public string AVGdiscount
            {
                get
                {
                    int id = ProductUserControl.SelectedUserId;
                    int count = 0;
                    double avgfeed = 0;
                    foreach (var p in App.db.Feedback.ToList())
                    {
                        if (p.ProductId == id)
                        {
                            count++;
                            avgfeed += p.Evaluation;

                        }

                    }
                    return (avgfeed / count).ToString();
                }
            }
            public string DisCount
            {
                get
                {
                    int id = ProductUserControl.SelectedUserId;
                    int count = 0;
                    double avgfeed = 0;
                    foreach (var p in App.db.Feedback.ToList())
                    {
                        if (p.ProductId == id)
                        {
                            count++;
                            avgfeed += p.Evaluation;

                        }

                    }
                    return "Количество отзывов: " + count.ToString();
                }
            }
        }
    }

