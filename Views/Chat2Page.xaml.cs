using MauiChatAppdeux.ViewModels;

namespace MauiChatAppdeux;

public partial class Chat2Page : ContentPage
{
	public Chat2Page(ChatViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}