using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using KBSVertebrate.Models;

namespace KBSVertebrate.ViewModels
{
    public partial class KBSResult : ContentPage
    {
        public List<ResultModel> ResultList { get; set; }

        public KBSResult()
        {
            Shell.SetNavBarIsVisible(this,false);
            ResultList = new List<ResultModel>();
            BindingContext = this;
            InitializeComponent();
        }

        public KBSResult(List<ResultModel> resultlist)
        {
            Shell.SetNavBarIsVisible(this, false);
            ResultList = resultlist;
            BindingContext = this;
            InitializeComponent();
        }

    }
}