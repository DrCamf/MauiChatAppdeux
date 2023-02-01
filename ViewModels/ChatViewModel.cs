

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiChatAppdeux.Models;
using MauiChatAppdeux.Services;
using MauiChatAppdeux.ViewModels.Base;
using MauiChatAppdeux.Views.Templates;
using Microsoft.Maui.Networking;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Input;

namespace MauiChatAppdeux.ViewModels
{
    public partial class ChatViewModel : ViewModelBase
    {
        public ObservableCollection<Message> MessagesCollection { get; } = new();
        //private List<Message> messageCollection = new List<Message>();
        private string areaname;
        public string AreaName { get { return areaname; }
            set
            {
                areaname = value;
                OnPropertyChanged();
            }
        }
        private string chatsend;
        private int count;
        public string ChatSend { 
            get => chatsend; 
            set => SetProperty(ref chatsend, value); 
        }
        private readonly Task initTask;
        public RefreshView refreshView { get; set; }

        [ObservableProperty]
        bool isRefreshing;

        public Command LoadCommand { get; }
        public Command RefreshCommand { get; }
        public Command SendChatCommand { get; }
        public Command BackCommand { get; }
       
        ChatServices chatServices;
       
        public ChatViewModel( ChatServices chatServices)
        {
            Shell.Current.Navigation.PopAsync();
            
            count= 0;
            // AppShell.Current.DisplayAlert("Chat", App.ChosenArea.id.ToString(), "OK");
           
            this.chatServices = chatServices;

            SendChatCommand =  new Command(async () => await SendChatTappedAsync());
            BackCommand = new Command(async () => await BackTappedAsync());
            LoadCommand = new Command(async () => await LoadData());
            refreshView = new RefreshView();

            this.initTask = InitAsync();


            RefreshCommand = new Command(async () => await RefreshChat());
          
            refreshView.Command = RefreshCommand;
            AreaName = App.ChosenArea.name;
            ScrollView scrollView = new ScrollView();
            //FlexLayout flexLayout = new FlexLayout { ... };
            //scrollView.Content = ChatTemplate;
            //refreshView.Content = scrollView;


        }

        public ChatViewModel()
        {
        }

        private async Task InitAsync()
        {
            await LoadData();
        }

        private async Task RefreshChat()
        {
            {
                if (refreshView.IsRefreshing)
                {
                    await LoadData();
                    await AppShell.Current.DisplayAlert("Chat", "Ikke uploaded", "OK");
                }
                refreshView.IsRefreshing = false;

            }
        }

        

        public int Count { get { return count; } set { count = value; OnPropertyChanged(); } }

        private async Task BackTappedAsync()
        {
            //await LoadData();
            // Get current page
            
            var page = Shell.Current.CurrentPage;

            // Load new page
            await Shell.Current.GoToAsync("//middle/chatarea", false);
            MessagesCollection.Clear();
            AreaName = "";
            // Remove old page
            Application.Current.MainPage.Navigation.RemovePage(page);
            //await Shell.Current.GoToAsync("//middle/chatarea");
        }

        private async Task SendChatTappedAsync()
        {

            if(!string.IsNullOrWhiteSpace(ChatSend))
            {
                DateTime tid = DateTime.Now;
                string tidStr = tid.ToString("u");
                SendMessage message = new SendMessage();

                message.chattext = ChatSend;
                message.user_id = App.UserDetails.id;
                message.chatarea_id = App.ChosenArea.id;
                message.time = tidStr.Remove(tidStr.Length - 1, 1);


                bool response = await ChatServices.Instance.InsertMessage(message);
                if (response)
                {
                    ChatSend = "";
                   
                    //await Shell.Current.GoToAsync($"//inside/chat");
                    await LoadData();

                    //await AppShell.Current.DisplayAlert("Chat", "tekst: " + message.chattext + " time: " +  message.time + " Uid: " + message.user_id + " areaId: " + message.chatarea_id, "OK");
                }
                else
                {
                    await AppShell.Current.DisplayAlert("Chat", "Ikke uploaded", "OK");
                }
            } else
            {
                await AppShell.Current.DisplayAlert("Chat", "Ingen besked", "OK");
            }
           
            
        }

        /*public ObservableCollection<Message> Messages
        {
            get { return _message; }
            set
            {
                _message = value;
               // OnPropertyChanged();
            }
        }*/
       
        [RelayCommand]
        async Task LoadData()
        {
            //await AppShell.Current.DisplayAlert("Chat", "ID: " + App.ChosenArea.id.ToString(), "OK");
            AreaName = App.ChosenArea.name;
            if (IsBusy)
            {
                return;
            }

            try
            {
                /*if (connectivity.NetworkAccess != NetworkAccess.Internet)
                {
                    await Shell.Current.DisplayAlert("No connectivity!",
                                        $"Please check internet and try again.", "OK");
                    return;
                }*/

                IsBusy = true;
                var response = await chatServices.GetLastFittyChats(App.ChosenArea.id);
                if(MessagesCollection.Count != 0)
                {
                    MessagesCollection.Clear();
                }
                foreach (Message message in response.ToArray())
                {
                    message.image = "https://mauichat.elthoro.dk/" + message.image;
                    MessagesCollection.Add(message);
                    AreaName = message.area;
                }


            } catch (Exception ex) 
            {
                //Debug.WriteLine($"Unable to get Message: {ex.Message}");
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }



        }

      
    }

    
}
