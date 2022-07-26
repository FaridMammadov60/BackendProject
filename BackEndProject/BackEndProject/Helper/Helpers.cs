namespace BackEndProject.Helper
{
    public class Helpers
    {
        public static void DeleteImage(string path)
        {
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
        }

    }
}
