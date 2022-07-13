using System.IO;

namespace WebApp.Adapter.Web.Services
{
    public interface IImageProcess
    {
        void AddWatermark(string text, string filename, Stream imageStream);
    }
}
