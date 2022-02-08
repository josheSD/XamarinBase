using AppHuac.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppHuac.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DashboardFlyout : ContentPage
    {
        public ListView ListView;

        public DashboardFlyout()
        {
            InitializeComponent();

            BindingContext = new DashboardFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        class DashboardFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<Models.Menu> MenuItems { get; set; }

            public DashboardFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<Models.Menu>(new[]
                {
                    new Models.Menu { Id = 0, Title = "Home" },
                    new Models.Menu { Id = 1, Title = "Profile" },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}