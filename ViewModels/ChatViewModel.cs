

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
using System.Web;

namespace MauiChatAppdeux.ViewModels
{
    public class ChatViewModel : ViewModelBase
    {
        public ObservableCollection<Message> messageCollection = new ObservableCollection<Message>();
        //private List<Message> messageCollection = new List<Message>();
        
        public string AreaName { get; set; }
        private string chatsend;
        private int count;
        public string ChatSend { 
            get => chatsend; 
            set => SetProperty(ref chatsend, value); 
        }

        public Command SendChatCommand { get; }
        public Command BackCommand { get; }

        public ChatViewModel(int id)
        {
            Shell.Current.Navigation.PopAsync();
            App.ChosenArea.id = id;
            count= 0;
            // AppShell.Current.DisplayAlert("Chat", App.ChosenArea.id.ToString(), "OK");

            LoadData(id);

            SendChatCommand =  new Command(async () => await SendChatTappedAsync());
            BackCommand = new Command(async () => await BackTappedAsync());
        }

        public int Count { get { return count; } set { count = value; OnPropertyChanged(); } }

        private async Task BackTappedAsync()
        {
            // Get current page
            //var page = Application.Current.MainPage.Navigation.NavigationStack.LastOrDefault();

            // Load new page
            //await Shell.Current.GoToAsync(nameof(Chat1Page), false);

            // Remove old page
            //Application.Current.MainPage.Navigation.RemovePage(page);
            await Shell.Current.GoToAsync("//middle/chatarea");
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
                    Count += 1;
                    //await Shell.Current.GoToAsync($"//inside/chat");
                   

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
        public ObservableCollection<Message> MessagesCollection
        {
            get { return messageCollection; }
            set { messageCollection = value; }
        }

        public void LoadData(int id)
        {

            var response = new ObservableCollection<Message>(ChatServices.GetLastFittyChats(id));
            foreach (Message message in response.ToArray())
            {
                message.image = "https://mauichat.elthoro.dk/" + message.image;
                MessagesCollection.Add(message);
                AreaName = message.area;
            }
             
        }

        
    }
}
