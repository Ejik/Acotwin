
namespace ACOT.Infrastructure.Interface.Services
{
    /// <summary>
    /// Интерфейс для сервиса получения списка файлов. 
    /// </summary>
    public interface IFilesWalker
    {
        System.IO.FileInfo[] GetFilesList(string filter);   
    }
}
