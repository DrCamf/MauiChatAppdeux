

using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MauiChatAppdeux.ViewModels.Base
{
    
    public partial class ViewModelBase : ObservableObject
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotBusy))]
        bool isBusy;

        [ObservableProperty]
        string title;

        public bool IsNotBusy => !IsBusy;

    }
}
