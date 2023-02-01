



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
       
        public int Areanbr { get; set; }
        
        


        public ChatRoomsViewModel()
        {
            /*var myExistingPageList = Shell.Current.Navigation.NavigationStack.ToList();
            foreach (var item in myExistingPageList)
            {
                _pages.Add(item);
            }
            Shell.Current.Navigation.PopAsync();
            
           
            if (Preferences.ContainsKey(nameof(App.ChosenArea)))
            {
                Preferences.Clear(nameof(App.ChosenArea));
            }*/
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

            // await AppShell.Current.DisplayAlert("AHHA", SelectedArea.id.ToString(), "OK");
            var myExistingPageList = Shell.Current.Navigation.NavigationStack.ToList();
            await AppShell.Current.DisplayAlert("Area", "antal " + myExistingPageList.Count.ToString(), "OK");

            // await AppShell.Current.DisplayAlert("AHHA", App.ChosenArea.id.ToString(), "OK");
            
            switch (SelectedArea.id)
            {
                case 1:
                    App.ChosenArea.id= 1;
                    App.ChosenArea.name = "World war 1";
                    await Shell.Current.GoToAsync($"//inside/chat1");
                    break;
                case 2:
                    App.ChosenArea.id = 2;
                    App.ChosenArea.name = "World war 2";
                    await Shell.Current.GoToAsync($"//inside/chat1");
                    break; 
                case 3:
                    App.ChosenArea.id = 3;
                    App.ChosenArea.name = "Franco-Prussian War";
                    await Shell.Current.GoToAsync($"//inside/chat1");
                    break;
                case 4:
                    App.ChosenArea.id = 4;
                    App.ChosenArea.name = "Vietnam War";
                    await Shell.Current.GoToAsync($"//inside/chat1");
                    break;
                case 5:
                    App.ChosenArea.id = 5;
                    App.ChosenArea.name = "Korean War";
                    await Shell.Current.GoToAsync($"//inside/Dash");
                    break;
            }



            //await AppShell.Current.DisplayAlert("Area", App.ChosenArea.id.ToString(), "OK");

            //await Shell.Current.GoToAsync($"//inside/chat");
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
