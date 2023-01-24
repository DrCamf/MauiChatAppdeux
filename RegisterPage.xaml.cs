using MauiChatAppdeux.ViewModels;

namespace MauiChatAppdeux;

public partial class RegisterPage : ContentPage
{
	public RegisterPage()
	{
		InitializeComponent();
		BindingContext = new RegistrationViewModel(Navigation);

    }
}