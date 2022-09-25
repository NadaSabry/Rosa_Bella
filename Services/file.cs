namespace Rosa_Bella.Services
{
    public class file
    {
        public static bool IsValidImage(IFormFile image)
        {
            if(image==null) return false; 
            string imageType = Path.GetExtension(image.FileName).ToLower();
            string[] validTypes = new string[] { "png", "jpg", "jpeg", "gif" };
            foreach (var type in validTypes)
            {
                if (imageType.Contains(type)) return true;
            }
            return false;
        }
        public static void SaveFile(IFormFile userImage, IWebHostEnvironment Ih)
        {
            string fullPath = string.Empty;

            // path of file Images in folder wwwroot
            // compine = connect جمعهم سوا
            string path = Path.Combine(Ih.WebRootPath, "Images");
            fullPath = Path.Combine(path, userImage.FileName);
            userImage.CopyTo(new FileStream(fullPath, FileMode.Create));

        }
    }
}
