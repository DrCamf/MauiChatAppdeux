
using MauiChatAppdeux.Models;
using MauiChatAppdeux.Services;
using MauiChatAppdeux.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MauiChatAppdeux.ViewModels
{
    public class ChatViewModel : ViewModelBase, IQueryAttributable
    {
        ObservableCollection<Message> _message;
        private List<Message> messageCollection = new List<Message>();
        private int idfromarea;
        public string AreaName { get; set; }
        public ChatViewModel()
        {
            int id = idfromarea;
            var response = new List<Message>(ChatServices.Instance.GetLastFittyChats(id));
            foreach (Message message in response.ToArray())
            {
                message.image = "https://mauichat.elthoro.dk/" + message.image;
                messageCollection.Add(message);
                AreaName = message.Area;
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

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            string id = HttpUtility.UrlDecode(query["ID"].ToString());
            idfromarea = int.Parse(id);
        }
    }
}
