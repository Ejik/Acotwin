//----------------------------------------------------------------------------------------
// patterns & practices - Smart Client Software Factory - Guidance Package
//
// The IActionCatalogService defines the ability to conditionally execute code based upon 
// aspects of a program that can change at run time 
//
// For more information see: 
// ms-help://MS.VSCC.v80/MS.VSIPCC.v80/ms.scsf.2006jun/SCSF/html/03-490-Using%20the%20Action%20Catalog.htm
//
// Latest version of this Guidance Package: http://go.microsoft.com/fwlink/?LinkId=62182
//----------------------------------------------------------------------------------------

using Microsoft.Practices.CompositeUI;

namespace ACOT.Infrastructure.Interface.Services
{
    public delegate void ActionDelegate(object caller, object target);

    public interface IActionCatalogService
    {
        bool CanExecute(string action, WorkItem context, object caller, object target);
        bool CanExecute(string action);
        void Execute(string action, WorkItem context, object caller, object target);

        void RegisterSpecificCondition(string action, IActionCondition actionCondition);
        void RegisterGeneralCondition(IActionCondition actionCondition);
        void RemoveSpecificCondition(string action, IActionCondition actionCondition);
        void RemoveGeneralCondition(IActionCondition actionCondition);

        void RemoveActionImplementation(string action);
        void RegisterActionImplementation(string action, ActionDelegate actionDelegate);
    }
}
