using System.Drawing;
using System.IO;

namespace WebApp.Adapter.Web.Services
{
    public interface IAdvanceImageProcess
    {
        void AddWatermarkImage(Stream stream, string text, string filePath, Color color, Color outlineColor);
    }
}
