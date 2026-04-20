namespace Backend.Application.Common.Helpers
{
    public static class FileExtensionHelper
    {
        public static readonly Dictionary<FileType, HashSet<string>> AllowedExtensions = new()
        {
            { FileType.Image, new HashSet<string> { ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".tiff" } },
            { FileType.Document, new HashSet<string> { ".pdf", ".doc", ".docx", ".xls", ".xlsx", ".ppt", ".pptx", ".txt" } }
        };
    }
}