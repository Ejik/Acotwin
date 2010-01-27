using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.ObjectBuilder;
using ACOT.Infrastructure.Interface;

namespace ACOT.Infrastructure.HomeModule
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

            //_rootWorkItem.WorkItems.AddNew<ControlledWorkItem<ModuleController>>();
            ControlledWorkItem<ModuleController> workItem = _rootWorkItem.WorkItems.AddNew<ControlledWorkItem<ModuleController>>();
            workItem.Controller.Run();
        }
    }
}
