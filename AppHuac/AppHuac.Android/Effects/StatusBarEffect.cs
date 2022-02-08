using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AppHuac.Droid.Effects;
using Plugin.CurrentActivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ResolutionGroupName("Xamarin")]
[assembly: ExportEffect(typeof(StatusBarEffect), "StatusBarEffect")]
namespace AppHuac.Droid.Effects
{
    public class StatusBarEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            var statusBarEffect = (AppHuac.Effects.StatusBarEffect)Element.Effects.FirstOrDefault(e => e is AppHuac.Effects.StatusBarEffect);

            if (statusBarEffect != null)
            {
                var backgroundColor = statusBarEffect.BackgroundColor.ToAndroid();
                var isLight = statusBarEffect.isLight;
                Window currentWindow = GetCurrentWindow();
                currentWindow.SetStatusBarColor(backgroundColor);
                currentWindow.DecorView.SystemUiVisibility = isLight ? (StatusBarVisibility)(SystemUiFlags.LightStatusBar) : 0;
            }
        }

        protected override void OnDetached()
        {

        }

        Window GetCurrentWindow()
        {
            var window = CrossCurrentActivity.Current.Activity.Window;

            window.ClearFlags(WindowManagerFlags.TranslucentStatus);
            window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);
            return window;
        }

    }
}