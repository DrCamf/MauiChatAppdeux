using MauiChatAppdeux.ViewModels;

namespace MauiChatAppdeux;

public partial class ChatDetail : ContentPage
{
	public ChatDetail(ChatDetailViewModel viewModel)
	{
		InitializeComponent();
		BindingContext= viewModel;
	}
}