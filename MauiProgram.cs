#if IOS
using Plugin.Firebase.iOS;
#else


#endif

using MauiChatAppdeux.Services;
using MauiChatAppdeux.ViewModels;


namespace MauiChatAppdeux;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("Metropolis-Black.otf", "Metropolis Black");
                fonts.AddFont("Metropolis-Light.otf", "Metropolis Light");
                fonts.AddFont("Metropolis-Medium.otf", "Metropolis Medium");
                fonts.AddFont("Metropolis-Regular.otf", "Metropolis Regular");
                fonts.AddFont("Metropolis-Regular.otf", "Metropolis Regular");
                fonts.AddFont("MaterialIcons-Regular.ttf", "Material Icons");
            });


        builder.Services.AddSingleton<ChatAreaServices>();
        builder.Services.AddSingleton<ChatServices>();
        builder.Services.AddSingleton<RegisterService>();
        builder.Services.AddSingleton<ILoginService, LoginService>();

        //views
        builder.Services.AddTransient<ChatPage>();
        builder.Services.AddTransient<ChatRooms>();
        builder.Services.AddTransient<RegisterPage>();
        builder.Services.AddSingleton<HomeView>();


        //viewmodel
        builder.Services.AddTransient<ChatRoomsViewModel>();
        builder.Services.AddTransient<ChatViewModel>();
        builder.Services.AddSingleton<LoginViewModel>();
        builder.Services.AddTransient<RegistrationViewModel>();


        return builder.Build();
	}

    

    
}
