﻿
namespace JOIN.Helpers;

public static class ServiceHelper
{
    public static TService GetService<TService>() => 
        Current.GetService<TService>();

    public static IServiceProvider Current =>
#if WINDOWS10_0_17763_0_OR_GREATER
            MauiWinUIApplication.Current.Services;
#elif ANDROID
            MauiApplication.Current.Services;
#elif IOS
            MauiUIApplicationDelegate.Current.Services;
#elif MACCATALYST
            MauiUIApplicationDelegate.Current.Services;
#else
            null;
#endif

}
