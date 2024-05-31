using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Views;
using Android.Widget;
using Microsoft.Maui.Controls.Handlers.Compatibility;
using Microsoft.Maui.Controls.Platform.Compatibility;
using Microsoft.Maui.Platform;

namespace MauiApp12
{
    public class CustomShellHandler : ShellRenderer
    {
        //protected override IShellBottomNavViewAppearanceTracker CreateBottomNavViewAppearanceTracker(ShellItem shellItem)
        //{
        //    return new CustomShellBottomNavViewAppearanceTracker(this, shellItem.CurrentItem);
        //}

        protected override IShellToolbarAppearanceTracker CreateToolbarAppearanceTracker()
        {
            return new CustomShellToolbarAppearanceTracker(this);
        }
    }

    //class CustomShellBottomNavViewAppearanceTracker : ShellBottomNavViewAppearanceTracker
    //{
    //    private readonly IShellContext shellContext;

    //    public CustomShellBottomNavViewAppearanceTracker(IShellContext shellContext, ShellItem shellItem) : base(shellContext, shellItem)
    //    {
    //        this.shellContext = shellContext;
    //    }

    //    public override void SetAppearance(BottomNavigationView bottomView, IShellAppearanceElement appearance)
    //    {
    //        base.SetAppearance(bottomView, appearance);
    //        var backgroundDrawable = new GradientDrawable();
    //        backgroundDrawable.SetShape(ShapeType.Rectangle);
    //        backgroundDrawable.SetCornerRadius(30);
    //        backgroundDrawable.SetColor(appearance.EffectiveTabBarBackgroundColor.ToPlatform());
    //        bottomView.Background = backgroundDrawable;

    //        var layoutParams = bottomView.LayoutParameters;
    //        if (layoutParams is ViewGroup.MarginLayoutParams marginLayoutParams)
    //        {
    //            var margin = 30;
    //            marginLayoutParams.BottomMargin = margin;
    //            marginLayoutParams.LeftMargin = margin;
    //            marginLayoutParams.RightMargin = margin;
    //            bottomView.LayoutParameters = layoutParams;
    //        }
    //    }

    //    protected override void SetBackgroundColor(BottomNavigationView bottomView, Color color)
    //    {
    //        base.SetBackgroundColor(bottomView, color);
    //        bottomView.RootView?.SetBackgroundColor(shellContext.Shell.CurrentPage.BackgroundColor.ToPlatform());
    //    }
    //}

    public class TextDrawable : Drawable
    {
        private string text;
        private Android.Graphics.Paint paint;

        public TextDrawable(string text)
        {
            this.text = text;

            this.paint = new Android.Graphics.Paint();
            paint.Color = Colors.Orange.ToPlatform();
            paint.TextSize = 22f;
            paint.AntiAlias = true;
            paint.FakeBoldText = true;
            paint.SetShadowLayer(6f, 0, 0, Colors.Pink.ToPlatform());
            paint.SetStyle(Android.Graphics.Paint.Style.Fill);
            paint.TextAlign = Android.Graphics.Paint.Align.Left;

            //Paint p = new Paint();
            ////Set font
            //Typeface plain = Typeface.createFromAsset(context.getAssets(), "custom_font.ttf");
            //p.setTypeface(plain);
        }

        public override int Opacity => -1; // PixelFormat.TRANSLUCENT;

        public override void Draw(Canvas canvas)
        {
            canvas.DrawText(text, 0, 0, paint);
        }

        public override void SetAlpha(int alpha)
        {
            paint.Alpha = alpha;
        }

        public override void SetColorFilter(ColorFilter? colorFilter)
        {
            paint.SetColorFilter(colorFilter);
        }
    }

    public class ViewDrawable : Drawable
    {
        Android.Views.View mView;

        public ViewDrawable(Android.Content.Context context, int layoutId)
        {
            new ViewDrawable(LayoutInflater.From(context).Inflate(layoutId, null));
        }

        public ViewDrawable(Android.Views.View view)
        {
            mView = view;
        }

        public Android.Views.View getView()
        {
            return mView;
        }

        public override void SetBounds(int left, int top, int right, int bottom)
        {
            base.SetBounds(left, top, right, bottom);
            int widthMeasureSpec = Android.Views.View.MeasureSpec.MakeMeasureSpec(right - left, MeasureSpecMode.Exactly);
            int heightMeasureSpec = Android.Views.View.MeasureSpec.MakeMeasureSpec(bottom - top, MeasureSpecMode.Exactly);
            mView.Measure(widthMeasureSpec, heightMeasureSpec);
            mView.Layout(left, top, right, bottom);
        }

        public override int Opacity => -2;

        public override void Draw(Canvas canvas)
        {
            mView.Draw(canvas);
        }

        public override void SetAlpha(int alpha)
        {
            mView.Alpha = alpha / 255f;
        }

        public override void SetColorFilter(ColorFilter? colorFilter)
        {
        }
    }

    //public class TextDrawable : Drawable
    //{
    //    public TextDrawable(string text, Color color, int size)
    //    {

    //    }

    //    public override int Opacity => throw new NotImplementedException();

    //    public override void Draw(Android.Graphics.Canvas canvas)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public override void SetAlpha(int alpha)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public override void SetColorFilter(Android.Graphics.ColorFilter? colorFilter)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}


    //    class TextDrawable(text: String, color: Int, size: Float) : Drawable()
    //    {
    //    private val paint = TextPaint().also {
    //        it.color = color
    //        it.textSize = size
    //        it.isAntiAlias = true
    //        it.isFakeBoldText = true
    //        it.setShadowLayer(6f, 0f, 0f, Color.BLACK)
    //        it.style = Paint.Style.FILL
    //        it.textAlign = Paint.Align.LEFT
    //    }

    //private val textWidth = Rect().let {
    //    paint.getTextBounds(text, 0, when(text.contains("\n")) {
    //        true->text.indexOf("\n")
    //            false->text.length
    //        }, it)

    //        it.right
    //    }

    //private var staticLayout = when {
    //    Build.VERSION.SDK_INT < Build.VERSION_CODES.M-> {
    //        StaticLayout(text, 0, text.length, paint, textWidth,
    //            Layout.Alignment.ALIGN_NORMAL, StaticLayout.DEFAULT_LINESPACING_MULTIPLIER, StaticLayout.DEFAULT_LINESPACING_ADDITION,
    //            true
    //        )
    //        }
    //        else -> {
    //        StaticLayout.Builder
    //        .obtain(text, 0, text.length, paint, textWidth)
    //        .build()
    //        }
    //}

    //override fun draw(canvas: Canvas)
    //{
    //    canvas.save()
    //        canvas.translate(bounds.left.toFloat(), bounds.top.toFloat())
    //        staticLayout.draw(canvas)
    //        canvas.restore()
    //    }

    //override fun getIntrinsicWidth(): Int {
    //        return staticLayout.width
    //    }

    //    override fun getIntrinsicHeight(): Int {
    //        return staticLayout.height
    //    }

    //    override fun setAlpha(alpha: Int)
    //{
    //    paint.alpha = alpha
    //    }

    //override fun setColorFilter(cf: ColorFilter?)
    //{
    //    paint.setColorFilter(cf)
    //    }

    //@Deprecated("Deprecated in Java",
    //    ReplaceWith("PixelFormat.TRANSLUCENT", "android.graphics.PixelFormat")
    //)
    //    override fun getOpacity(): Int {
    //        return PixelFormat.TRANSLUCENT
    //    }
    //}


    class CustomShellToolbarAppearanceTracker : ShellToolbarAppearanceTracker
    {
        public CustomShellToolbarAppearanceTracker(IShellContext shellContext) : base(shellContext)
        {
        }

        public override void SetAppearance(AndroidX.AppCompat.Widget.Toolbar toolbar, IShellToolbarTracker toolbarTracker, ShellAppearance appearance)
        {
            base.SetAppearance(toolbar, toolbarTracker, appearance);

            if (toolbarTracker.CanNavigateBack == false)
            {
                var dark = Microsoft.Maui.Graphics.Color.FromArgb("#ac99ea");
                var light = Microsoft.Maui.Graphics.Color.FromArgb("#512BD4");

                Microsoft.Maui.Graphics.Color col = Application.Current.RequestedTheme == AppTheme.Dark ? dark : light;

                var backgroundDrawable = new GradientDrawable();
                backgroundDrawable.SetShape(ShapeType.Rectangle);
                backgroundDrawable.SetCornerRadius(0);
                backgroundDrawable.SetColor(col.ToPlatform());

                TextView tv = new(Platform.CurrentActivity)
                {
                    Text = MaterialFontIcons.Menu,
                    Background = backgroundDrawable,
                };

                tv.SetTextColor(Colors.White.ToPlatform());
                tv.SetTextSize(Android.Util.ComplexUnitType.Pt, 20);
                tv.Gravity = GravityFlags.Center | GravityFlags.Right;

                Typeface plain = Typeface.CreateFromAsset(Platform.CurrentActivity.Assets, "materialdesignicons-webfont.ttf");
                tv.SetTypeface(plain, TypefaceStyle.Normal);

                toolbar.NavigationIcon = new ViewDrawable(tv);

                MainActivity.Toolbar = toolbar;
            }
        }
    }
}
