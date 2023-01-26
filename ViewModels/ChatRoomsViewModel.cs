



using MauiChatAppdeux.Models;
using MauiChatAppdeux.Services;
using MauiChatAppdeux.ViewModels.Base;
using Newtonsoft.Json;
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
      
       
        public Area SelectedArea { get; set; }
        ObservableCollection<Area> _area;
        public Command SelectedAreas { get; }
        private int areanbr;
        public int Areanbr { get; set; }
        


        public ChatRoomsViewModel()
        {
           
            if (Preferences.ContainsKey(nameof(App.ChosenArea)))
            {
                Preferences.Clear(nameof(App.ChosenArea));
            }
            App.ChosenArea = new Area();
            SelectedArea = null;
            //LoadData();
            //this._navigation = navigation;
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
            // await this._navigation.PushAsync(new ChatPage(SelectedArea.Id));
            //var response = ChatAreaServices.Instance.GetArea(SelectedArea.id);

            await AppShell.Current.DisplayAlert("AHHA", SelectedArea.id.ToString(), "OK");
            App.ChosenArea = SelectedArea;

            await AppShell.Current.DisplayAlert("AHHA", App.ChosenArea.id.ToString(), "OK");





            //await AppShell.Current.DisplayAlert("Area", App.ChosenArea.id.ToString(), "OK");

            await Shell.Current.GoToAsync($"//profile/chat");
        }

        public ObservableCollection<Area> Areas
        {
            get { return _area; }
            set
            {
                _area = value;
               // OnPropertyChanged();
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
