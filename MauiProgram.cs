using JOIN.Models;
using Microsoft.Maui.LifecycleEvents;
using MonkeyCache.FileStore;

namespace JOIN;


public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder(); //configurazione dei font inseriti nell'applicazione
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("Roboto-Regular.ttf", "RobotoRegular");
				fonts.AddFont("Roboto-Semibold.ttf", "RobotoSemiBold");
				fonts.AddFont("materialdesignicons-webdont.ttf", "IconFont");
			}).ConfigureLifecycleEvents(events =>
			{
			#if ANDROID //evento per i dispositivi Android. Se si è su android, rende la barra di stato del telefono trasparente.

				events.AddAndroid(android => android.OnCreate((activity, bundle) => MakeStatusBarTranslucent(activity)));

				static void MakeStatusBarTranslucent(Android.App.Activity activity)
				{
					activity.Window.SetFlags(Android.Views.WindowManagerFlags.LayoutNoLimits, Android.Views.WindowManagerFlags.LayoutNoLimits);
					activity.Window.ClearFlags(Android.Views.WindowManagerFlags.TranslucentStatus);
					activity.Window.SetStatusBarColor(Android.Graphics.Color.Transparent);
				}
			#endif
			});

		//Register Services
		RegisterAppServices(builder.Services);

		return builder.Build();
	}

	private static void RegisterAppServices(IServiceCollection services)
	{
		//Add Platform specific Dependencies
		services.AddSingleton<IConnectivity>(Connectivity.Current);

		//Register Cache Barrel
		Barrel.ApplicationId = Constants.ApplicationId;
		services.AddSingleton<IBarrel>(Barrel.Current);

		//Register API Services
		//da implementare con la classe API


		services.AddSingleton<StartPageViewModel>();
		
	}

}
