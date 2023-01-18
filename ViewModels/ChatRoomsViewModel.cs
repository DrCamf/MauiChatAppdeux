

using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using MauiChatAppdeux.Models;
using MauiChatAppdeux.Services;
using MauiChatAppdeux.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MauiChatAppdeux.ViewModels
{
    public class ChatRoomsViewModel : ViewModelBase
    {
        
        private List<Area> areasCollection = new List<Area>();
        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        ToastDuration duration = ToastDuration.Short;
        private INavigation _navigation;
        public Area SelectedArea { get; set; }
        ObservableCollection<Area> _area;
        public Command SelectedAreas { get; }
        public ChatRoomsViewModel(INavigation navigation)
        {
            //LoadData();
            this._navigation = navigation;
            SelectedAreas = new Command(SelectedAreaTappedAsync);
            var response = new List<Area>(ChatAreaServices.Instance.GetAllAreas());
            foreach (Area area in response.ToArray())
            {
                area.image = "https://mauichat.elthoro.dk/" + area.image;
                areasCollection.Add(area);
            }
            
        }

        private async void SelectedAreaTappedAsync(object sender)
        {
            /*var text = SelectedArea.Id.ToString();
            var toast = Toast.Make(text + " hej", duration);
            await toast.Show(cancellationTokenSource.Token);*/
            await this._navigation.PushAsync(new ChatPage(SelectedArea.Id));
        }

        public ObservableCollection<Area> Areas
        {
            get { return _area; }
            set
            {
                _area = value;
                OnPropertyChanged();
            }
        }

        void LoadData()
        {
            Areas = new ObservableCollection<Area>(ChatAreaServices.Instance.GetAllAreas());
        }
       
        public List<Area> AreasCollection
        {
            get { return areasCollection; }
            set { areasCollection = value; }
        }
    }
}
