using LazZiya.ImageResize;
using System.Drawing;
using System.IO;

namespace WebApp.Adapter.Web.Services
{
    public class AdvanceImageProcess : IAdvanceImageProcess
    {
        public void AddWatermarkImage(Stream stream, string text, string filePath, Color color, Color outlineColor)
        {
            using (var img = Image.FromFile(@"wwwroot\images\image-file.jpg"))
            {
                var tOps = new TextWatermarkOptions
                {
                    // Change text color and opacity
                    // Text opacity range depends on Color's alpha channel (0 - 255)
                    TextColor = color,

                    // Add text outline
                    // Outline color opacity range depends on Color's alpha channel (0 - 255)
                    OutlineColor = outlineColor
                };

                img.AddTextWatermark(text, tOps)
                   .SaveAs(filePath);
            }
        }
    }
}
