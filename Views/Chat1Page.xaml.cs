using AndroidX.Lifecycle;
using MauiChatAppdeux.ViewModels;

namespace MauiChatAppdeux;

public partial class Chat1Page : ContentPage
{
	public Chat1Page(ChatViewModel viewModel )
	{
        
        InitializeComponent();
        BindingContext = viewModel;
       
        


    }



}