namespace Athr.Domain.BuildingBlocks
{
    public static class Constants
    {
        public const string UserRolePermissions = "UserRolePermissions";

        public const string RoleAdminAlias = "Admin";
        public const string GENDER_MALE = "MALE";
        public const string GENDER_FEMALE = "FEMALE";

        public static string[] AllowedImageMimeTypes = ["image/jpeg", "image/png", "image/webp"];

        public static string[] AllowedMediaTypes = [
            "video/mp4",
            "audio/mpeg", // .mp3
            "application/pdf",
            "application/vnd.openxmlformats-officedocument.wordprocessingml.document" // .docx
        ];
        public static int MaxImageBytes = 2_000_000;
        public static long MaxMediaBytes = 2L * 1024 * 1024 * 1024; //2GB

        public static int HashDepth = 2;

        public static string RootPath = "app";
        public static string PublicPath = "documents";
        public static string UploadPath = string.Join(Path.DirectorySeparatorChar, RootPath, PublicPath);

        public static string DefaultImage = "default-image.png";
        public static string DefaultImagePath = string.Join(Path.DirectorySeparatorChar, PublicPath, DefaultImage);
        public static string ProfileImagePath = "profile_images";
        public static string LibraryPath = "library";


    }
}
