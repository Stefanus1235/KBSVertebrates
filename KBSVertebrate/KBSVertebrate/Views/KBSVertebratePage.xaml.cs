using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using KBSVertebrate.Models;
using System.IO;
using System.Reflection;
using CsvHelper;
using System.Globalization;

using KBSVertebrate.ViewModels;

namespace KBSVertebrate.Views
{
    public partial class KBSVertebratePage : ContentPage
    {
        public KBSViewModel vm;
        public KBSViewModel VM
        {
            get { return vm; }
            set { vm = value; }
        }

        public string answer;


        public KBSVertebratePage()
        {
            Shell.SetNavBarIsVisible(this,false);
            vm = new KBSViewModel();
            vm.QuestionBuilder();
            BindingContext = vm;
            InitializeComponent();
            Console.Write("Count :");
            Console.WriteLine(vm.CurrentQuestion.Count);

        }

        public KBSVertebratePage(KBSViewModel vm)
        {
            this.vm = vm;
            vm.QuestionBuilder();
            InitializeComponent();
        }

        private async void NextQuestionClicked(object sender, EventArgs e)
        {
            if (answer != null) 
            { 
                vm.PruneQnA(answer);
                vm.TraitPruning();
                List<ResultModel> result = vm.QuestionBuilder();
                if (result != null)
                {
                    KBSResult resultpage = new KBSResult(result);
                    await Navigation.PushAsync(resultpage);
                }
            }


        }

        void OnRadioButtonCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            answer = $"{rb.Content}";
        }

    }
}