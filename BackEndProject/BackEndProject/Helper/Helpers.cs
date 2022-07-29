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

    public enum UserRoles
    {
        Member = 1,
        Manager = 2,
        Admin = 4,
        SuperAdmin = 8,
    }


}
