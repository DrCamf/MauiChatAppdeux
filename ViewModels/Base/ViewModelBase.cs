

using CommunityToolkit.Mvvm.ComponentModel;

namespace MauiChatAppdeux.ViewModels.Base
{
    public partial class ViewModelBase : ObservableObject
    {
        [ObservableProperty]
        private bool _isBusy;

        [ObservableProperty]
        private string _title;

    }
}
