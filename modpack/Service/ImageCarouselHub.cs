using Microsoft.AspNetCore.SignalR;
using modpack.Models;

namespace modpack.Service
{
    public class ImageCarouselHub : Hub
    {
        public async Task UpdateImages(string ids)
        {
            try
            {
                var idArray = ids.Split(',').Select(id => int.Parse(id)).ToList();
                var imagePaths = new List<string>();
                foreach (var id in idArray)
                {
                    var imagePath = $"/images/carousel/carousel{id}.jpeg";
                    imagePaths.Add(imagePath);
                }

                // 发送更新到所有客户端
                await Clients.All.SendAsync("ReceiveImagePaths", imagePaths);
            }
            catch (Exception ex)
            {
                // Handle the exception, maybe log it
                Console.WriteLine($"Error updating images: {ex.Message}");
            }
        }
    }
}
