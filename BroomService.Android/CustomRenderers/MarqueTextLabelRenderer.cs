using System.Reflection;
using Android.Content;
using Android.Graphics;
using Java.Lang;
using Android.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using BroomService.Droid.CustomRenderers;
using BroomService.CustomControls;
using System.ComponentModel;

[assembly: ExportRenderer(typeof(MarqueTextlabel), typeof(MarqueTextLabelRenderer))]
namespace BroomService.Droid.CustomRenderers
{
    public class MarqueTextLabelRenderer : LabelRenderer
    {

        public MarqueTextLabelRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
            try
            {
                if (!string.IsNullOrEmpty(e.NewElement?.FontFamily))
                {
                    var font = Typeface.CreateFromAsset(Android.App.Application.Context.ApplicationContext.Assets, e.NewElement.FontFamily + ".ttf");
                    Control.Typeface = font;
                    Control.SetSingleLine(true);
                    Control.SetHorizontallyScrolling(true);
                    Control.HorizontalScrollBarEnabled = false;
                    Control.VerticalScrollBarEnabled = false;
                    Control.Selected = true;
                    Control.Ellipsize = Android.Text.TextUtils.TruncateAt.Marquee;
                    Control.SetMarqueeRepeatLimit(-1);
                    UpdateFormattedText();
                    //if (e.NewElement?.FontFamily == "Raleway-ExtraBold")
                    //{
                    //    var font = Typeface.CreateFromAsset(Android.App.Application.Context.ApplicationContext.Assets,
                    //        e.NewElement.FontFamily + ".ttf");
                    //    Control.Typeface = font;
                    //}
                    //else
                    //{
                    //    var font = Typeface.CreateFromAsset(Android.App.Application.Context.ApplicationContext.Assets, e.NewElement.FontFamily + ".otf");
                    //    Control.Typeface = font;
                    //}
                }
            }
            catch (System.Exception)
            {
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == Label.FormattedTextProperty.PropertyName ||
                e.PropertyName == Label.TextProperty.PropertyName ||
                e.PropertyName == Label.FontAttributesProperty.PropertyName ||
                e.PropertyName == Label.FontProperty.PropertyName ||
                e.PropertyName == Label.FontSizeProperty.PropertyName ||
                e.PropertyName == Label.FontFamilyProperty.PropertyName ||
                e.PropertyName == Label.TextColorProperty.PropertyName)
            {
                UpdateFormattedText();
            }
        }

        private void UpdateFormattedText()
        {
            if (Element?.FormattedText == null)
                return;

            var extensionType = typeof(FormattedStringExtensions);
            var type = extensionType.GetNestedType("FontSpan", BindingFlags.NonPublic);
            var ss = new SpannableString(Control.TextFormatted);
            var spans = ss.GetSpans(0, ss.ToString().Length, Class.FromType(type));
            foreach (var span in spans)
            {
                var start = ss.GetSpanStart(span);
                var end = ss.GetSpanEnd(span);
                var flags = ss.GetSpanFlags(span);
                var font = (Font)type.GetProperty("Font").GetValue(span, null);
                ss.RemoveSpan(span);
                var newSpan = new CustomTypefaceSpan(Control, Element, font);
                ss.SetSpan(newSpan, start, end, flags);
            }
            Control.TextFormatted = ss;
        }
    }
}