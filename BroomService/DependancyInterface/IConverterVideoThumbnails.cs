using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BroomService.DependancyInterface
{
    public interface IConverterVideoThumbnails
    {
        byte[] Getthumbnails(string videoPath);
    }
}
