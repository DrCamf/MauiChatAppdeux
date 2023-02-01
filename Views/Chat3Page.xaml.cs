using MauiChatAppdeux.ViewModels;

namespace MauiChatAppdeux;

public partial class Chat3Page : ContentPage
{
	public Chat3Page(ChatViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}