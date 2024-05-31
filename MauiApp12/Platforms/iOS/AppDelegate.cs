using Foundation;
using Microsoft.Maui.Platform;
using UIKit;

namespace MauiApp12
{
    [Register("AppDelegate")]
    public class AppDelegate : MauiUIApplicationDelegate
    {
        public static UINavigationController NavBarController;

        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            bool iOS15oMaggiore = UIDevice.CurrentDevice.CheckSystemVersion(15, 0);
            if (iOS15oMaggiore)
            {
                // Navbar
                UINavigationBarAppearance navAppearance = new();
                navAppearance.ConfigureWithDefaultBackground();

                UINavigationBar.Appearance.StandardAppearance = navAppearance;
                UINavigationBar.Appearance.ScrollEdgeAppearance = UINavigationBar.Appearance.StandardAppearance;

                // Toolbar
                UIToolbarAppearance toolAppearance = new();
                toolAppearance.ConfigureWithDefaultBackground();

                UIToolbar.Appearance.StandardAppearance = toolAppearance;
                UIToolbar.Appearance.CompactAppearance = UIToolbar.Appearance.StandardAppearance;

                UITabBar.Appearance.BackgroundColor = UIColor.White;
            }

            return base.FinishedLaunching(application, launchOptions);
        }


        public static void ChageToolbar(string icona, Color color)
        {
            if (NavBarController != null && NavBarController.NavigationBar.Items[0].LeftBarButtonItem != null)
            {
                CoreGraphics.CGSize imageSize = new CoreGraphics.CGSize(30, 30);
                NavBarController.NavigationBar.Items[0].LeftBarButtonItem.Image = CustomShellToolbarAppearanceTracker.ImageWithFont("Material Design Icons", 30, imageSize, color, icona);
                NavBarController.TabBarController.TabBar.BarTintColor = color.ToPlatform();
                NavBarController.TabBarController.TabBar.BackgroundColor = color.ToPlatform();
            }
        }
    }
}
