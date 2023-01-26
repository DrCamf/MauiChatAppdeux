
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
        ObservableCollection<Message> _message;
        private List<Message> messageCollection = new List<Message>();
        
        public string AreaName { get; set; }
        private string chatsend;
       
        public string ChatSend { 
            get => chatsend; 
            set => SetProperty(ref chatsend, value); 
        }

        public Command SendChatCommand { get; }
        public Command BackCommand { get; }

        public ChatViewModel()
        {
            
            int id = App.ChosenArea.id;

            AppShell.Current.DisplayAlert("Chat", App.ChosenArea.id.ToString(), "OK");

            var response = new List<Message>(ChatServices.Instance.GetLastFittyChats(id));
            foreach (Message message in response.ToArray())
            {
                message.image = "https://mauichat.elthoro.dk/" + message.image;
                messageCollection.Add(message);
                AreaName = message.area;
            }

            SendChatCommand =  new Command(async () => await SendChatTappedAsync());
            BackCommand = new Command(async () => await BackTappedAsync());
        }

        private async Task BackTappedAsync()
        {
            await AppShell.Current.DisplayAlert("Chat", App.ChosenArea.id.ToString(), "OK");

            await Shell.Current.GoToAsync("//profile/chatarea");
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
                message.date = tidStr.Remove(tidStr.Length - 1, 1);


                bool response = ChatServices.Instance.InsertMessage(message);
                if (response)
                { 

                    await AppShell.Current.DisplayAlert("Chat", message.date, "OK");
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

        public ObservableCollection<Message> Messages
        {
            get { return _message; }
            set
            {
                _message = value;
               // OnPropertyChanged();
            }
        }
        public List<Message> MessagesCollection
        {
            get { return messageCollection; }
            set { messageCollection = value; }
        }

        
    }
}
