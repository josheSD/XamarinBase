using AppHuac.iOS.Effects;
using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ResolutionGroupName("Xamarin")]
[assembly: ExportEffect(typeof(StatusBarEffect), "StatusBarEffect")]
namespace AppHuac.iOS.Effects
{
    public class StatusBarEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            var statusBarEffect = (AppHuac.Effects.StatusBarEffect)Element.Effects.FirstOrDefault(e => e is AppHuac.Effects.StatusBarEffect);

            if (statusBarEffect != null)
            {
                UIView statusBar = UIApplication.SharedApplication.ValueForKey(new NSString("statusBar")) as UIView;

                // var isLight = statusBarEffect.isLight;   -- FALTA BUSCAR PARA IOS COMO FUNCIONA

                if (statusBar.RespondsToSelector(new ObjCRuntime.Selector("setBackgroundColor:")))
                {
                    statusBar.BackgroundColor = statusBarEffect.BackgroundColor.ToUIColor();
                }
            }
        }

        protected override void OnDetached()
        {

        }
    }
}