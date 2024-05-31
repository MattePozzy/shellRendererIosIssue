using Android.App;
using Android.Content.PM;
using Android.Graphics;
using Android.Views;
using Android.Widget;
using Microsoft.Maui.Platform;

namespace MauiApp12
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        public static AndroidX.AppCompat.Widget.Toolbar Toolbar;

        public static void ChageToolbar(string icona, Microsoft.Maui.Graphics.Color color)
        {
            //var dark = Microsoft.Maui.Graphics.Color.FromArgb("#ac99ea");
            //var light = Microsoft.Maui.Graphics.Color.FromArgb("#512BD4");

            //Microsoft.Maui.Graphics.Color col = Application.Current.RequestedTheme == AppTheme.Dark ? dark : light;

            //var backgroundDrawable = new GradientDrawable();
            //backgroundDrawable.SetShape(ShapeType.Rectangle);
            //backgroundDrawable.SetCornerRadius(0);
            //backgroundDrawable.SetColor(col.ToPlatform());

            TextView tv = new(Platform.CurrentActivity)
            {
                Text = icona,
                //Background = backgroundDrawable,
            };

            tv.SetTextColor(color.ToPlatform());
            tv.SetTextSize(Android.Util.ComplexUnitType.Pt, 20);
            tv.Gravity = GravityFlags.Center | GravityFlags.Right;

            Typeface plain = Typeface.CreateFromAsset(Platform.CurrentActivity.Assets, "materialdesignicons-webfont.ttf");
            tv.SetTypeface(plain, TypefaceStyle.Normal);

            Toolbar.NavigationIcon = new ViewDrawable(tv);
        }
    }
}
