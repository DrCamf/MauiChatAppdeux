

namespace MauiChatAppdeux.ViewModels.Base
{
    public partial class ViewModelBase : BindableObject
    {
        

        public virtual Task InitializeAsync(object navigationData)
        {
            return Task.FromResult(false);
        }
    }
}
