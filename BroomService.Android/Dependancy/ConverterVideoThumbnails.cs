using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Media;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using BroomService.DependancyInterface;
using BroomService.Droid.Dependancy;
using Xamarin.Forms;

[assembly: Dependency(typeof(ConverterVideoThumbnails))]
namespace BroomService.Droid.Dependancy
{
    public class ConverterVideoThumbnails : IConverterVideoThumbnails
    {
        private byte[] bitmapData;

        public byte[] Getthumbnails(string videoPath)
        {
            Bitmap bMap = ThumbnailUtils.CreateVideoThumbnail(videoPath, ThumbnailKind.FullScreenKind);
            MemoryStream memoryStream = new MemoryStream();

            using (var stream = new MemoryStream())
            {
                bMap.Compress(Android.Graphics.Bitmap.CompressFormat.Png, 0, stream);
                bitmapData = stream.ToArray();
            }
            return bitmapData;
        }
    }
}