using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.ObjectBuilder;
using ACOT.Infrastructure.Interface.Constants;
using ACOT.Infrastructure.Library.UI;
using ACOT.Infrastructure.Interface;
using ACOT.Infrastructure.Layout.Views;

namespace ACOT.Infrastructure.Layout
{
    public class Module : ModuleInit
    {
        private WorkItem _rootWorkItem;

        [InjectionConstructor]
        public Module([ServiceDependency] WorkItem rootWorkItem)
        {
            _rootWorkItem = rootWorkItem;
        }

        public override void Load()
        {
            base.Load();             
    
        }
    }
}
