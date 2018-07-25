using System;
namespace GiaoHangGiaRe.Models
{
    public class ImageForm
    {
        public string base64 { set; get; }
        public ImageForm()
        {
        }
        public ImageForm(string base64)
        {
            this.base64 = base64;
        }
    }
}
