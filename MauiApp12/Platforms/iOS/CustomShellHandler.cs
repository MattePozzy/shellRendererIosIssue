using Foundation;
using Microsoft.Maui.Controls.Handlers.Compatibility;
using Microsoft.Maui.Controls.Platform.Compatibility;
using Microsoft.Maui.Platform;
using System.Drawing;
using UIKit;

namespace MauiApp12
{
    public class CustomShellHandler : ShellRenderer
    {
        //protected override IShellTabBarAppearanceTracker CreateTabBarAppearanceTracker()
        //{
        //    return new CustomShellTabBarAppearanceTracker();
        //}

        protected override IShellNavBarAppearanceTracker CreateNavBarAppearanceTracker()
        {
            return new CustomShellToolbarAppearanceTracker(this, base.CreateNavBarAppearanceTracker());
        }

        protected override IShellSectionRenderer CreateShellSectionRenderer(ShellSection shellSection)
        {
            var renderer = base.CreateShellSectionRenderer(shellSection);
            if (renderer != null)
            {
                var a = (renderer as ShellSectionRenderer);
                (renderer as ShellSectionRenderer).NavigationBar.Translucent = false;
            }
            return renderer;
        }

        protected override IShellItemRenderer CreateShellItemRenderer(ShellItem item)
        {
            var renderer = base.CreateShellItemRenderer(item);
            (renderer as ShellItemRenderer).TabBar.Translucent = false;
            return renderer;
        }
    }

    public class CustomShellToolbarAppearanceTracker : IShellNavBarAppearanceTracker
    {
        private readonly IShellContext shellContext;
        private readonly IShellNavBarAppearanceTracker baseTracker;

        public CustomShellToolbarAppearanceTracker(IShellContext shellContext, IShellNavBarAppearanceTracker baseTracker)
        {
            this.shellContext = shellContext;
            this.baseTracker = baseTracker;
        }

        public void Dispose()
        {
            baseTracker.Dispose();
        }

        public void ResetAppearance(UINavigationController controller)
        {
            baseTracker.ResetAppearance(controller);
        }

        public void SetAppearance(UINavigationController controller, ShellAppearance appearance)
        {
            baseTracker.SetAppearance(controller, appearance);
            if (controller.View is not null && shellContext.Shell.CurrentPage is not null)
            {
                controller.View.BackgroundColor = shellContext.Shell.CurrentPage.BackgroundColor.ToPlatform();
            }
        }

        public void UpdateLayout(UINavigationController controller)
        {
            baseTracker.UpdateLayout(controller);
            if (controller.NavigationBar.Items[0].LeftBarButtonItem != null)
            {

                CoreGraphics.CGSize imageSize = new CoreGraphics.CGSize(30, 30);
                controller.NavigationBar.Items[0].LeftBarButtonItem.Image = ImageWithFont("Material Design Icons", 30, imageSize, Colors.White, MaterialFontIcons.Menu);

                controller.TabBarController.TabBar.BarTintColor = Colors.White.ToPlatform();
                controller.TabBarController.TabBar.BackgroundColor = Colors.White.ToPlatform();
            }

            AppDelegate.NavBarController = controller;
        }

        public void SetHasShadow(UINavigationController controller, bool hasShadow)
        {
            baseTracker.SetHasShadow(controller, hasShadow);
        }

        // https://gist.github.com/blitzvb/7582002
        public static UIImage ImageWithFont(string fontName, float fontSize, CoreGraphics.CGSize imageSize, Microsoft.Maui.Graphics.Color color, string text)
        {
            if (fontName != null && text != null && color != null)
            {
                UIGraphics.BeginImageContextWithOptions(imageSize, false, 0.0f);

                NSAttributedString attrString = new NSAttributedString(text, new UIStringAttributes()
                {
                    Font = UIFont.FromName(fontName, fontSize),
                    ForegroundColor = color.ToPlatform()
                });

                float w = (float)imageSize.Width;
                float h = (float)imageSize.Height;

                NSStringDrawingContext strContext = new NSStringDrawingContext();
                var rectFont = attrString.GetBoundingRect(imageSize, NSStringDrawingOptions.UsesDeviceMetrics, strContext);
                attrString.DrawString(new RectangleF(0, 0, w, h));
                //attrString.DrawString(new RectangleF(w / 2 - (float)rectFont.Width / 2, h / 2 - (float)rectFont.Height / 2, w, h));

                UIImage image = UIGraphics.GetImageFromCurrentImageContext();
                UIGraphics.EndImageContext();

                AppShell.SetTabBarForegroundColor(AppShell.Current, color);

                return image;
            }
            return null;
        }
    }

}
