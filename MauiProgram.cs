#if IOS
using Plugin.Firebase.iOS;
#else


#endif
using CommunityToolkit.Maui;
namespace MauiChatAppdeux;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseMauiCommunityToolkit()
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

       

        return builder.Build();
	}

    

    
}
