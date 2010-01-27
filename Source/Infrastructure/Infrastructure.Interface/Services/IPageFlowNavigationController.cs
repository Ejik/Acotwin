namespace ACOT.Infrastructure.Interface.Services
{
    /// <summary>
    /// Интерфейс для сервиса получения списка файлов. 
    /// </summary>
    public interface IPageFlowNavigationController
    {
        System.Collections.Generic.List<string> ViewOrder { get; }
        
        object CurrentWorkItem();

        void AddView(string id, object view);

        void SetVisibility(string vievID);

        void RemoveView(string viewID);
    }
}
