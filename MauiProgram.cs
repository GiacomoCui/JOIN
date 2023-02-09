using JOIN.Models;
using JOIN.Views.ProfiloUtente;
using JOIN_App.ViewControls.Utenti;
using JOIN_App.ViewModels.ProfiloUtente;
using JOIN_App.Views.ProfiloUtente;
using Microsoft.Maui.LifecycleEvents;
using MonkeyCache.FileStore;

namespace JOIN;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("Roboto-Regular.ttf", "RobotoRegular");
				fonts.AddFont("Roboto-Semibold.ttf", "RobotoSemiBold");
				fonts.AddFont("materialdesignicons-webdont.ttf", "IconFont");
			}).ConfigureLifecycleEvents(events =>
			{
			#if ANDROID

				events.AddAndroid(android => android.OnCreate((activity, bundle) => MakeStatusBarTranslucent(activity)));

				static void MakeStatusBarTranslucent(Android.App.Activity activity)
				{
					activity.Window.SetFlags(Android.Views.WindowManagerFlags.LayoutNoLimits, Android.Views.WindowManagerFlags.LayoutNoLimits);
					activity.Window.ClearFlags(Android.Views.WindowManagerFlags.TranslucentStatus);
					activity.Window.SetStatusBarColor(Android.Graphics.Color.Transparent);
				}
			#endif
			});

        //Transient Page & ViewModel
        builder.Services.AddTransient<PaginaProfiloUtente>();
        builder.Services.AddTransient<ProfiloUtenteViewModel>();
        builder.Services.AddTransient<PaginaProfiloModificabile>();
        builder.Services.AddTransient<PaginaProfiloModificabileViewModel>();
        builder.Services.AddTransient<Utente>();
		

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


		services.AddSingleton<StartPageViewModel>();
		
	}

}
