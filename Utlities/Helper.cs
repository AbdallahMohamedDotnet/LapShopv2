﻿namespace LapShopv2.Utlities
{
    public static class Helper
    {
        public static async Task<string> UploadImage(List<IFormFile> Files,string folderName)
        {
            foreach (var file in Files)
            {
                if (file.Length > 0)
                {
                    string ImageName = Guid.NewGuid().ToString() + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + ".jpg";
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Uploads", folderName, ImageName);
                    using (var stream = System.IO.File.Create(filePath))
                    {
                        await file.CopyToAsync(stream);
                        return ImageName;
                    }
                }
            }
            return string.Empty;
        }
    }
}
