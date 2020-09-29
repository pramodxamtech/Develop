using DatarynxApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DatarynxApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ToDoList : ContentPage
    {
        public ToDoList()
        {
            InitializeComponent();
            DatarynxRecordViewModel datarynxRecordViewModel = new DatarynxRecordViewModel();
            BindingContext = datarynxRecordViewModel;
        }
    }
}