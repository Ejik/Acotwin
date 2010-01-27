﻿//----------------------------------------------------------------------------------------
// patterns & practices - Smart Client Software Factory - Guidance Package
//
// This file was generated by this guidance package as part of the solution template
//
// The ActionStrategy class is an ObjectBuilder builder strategy that will register all methods
// decorated with the ActionAttribute in the IActionCatalogService
// 
// For more information see: 
// ms-help://MS.VSCC.v80/MS.VSIPCC.v80/ms.practices.scsf.2007may/SCSF/html/03-01-140-How_to_Use_the_Action_Catalog.htm
//
// Latest version of this Guidance Package: http://go.microsoft.com/fwlink/?LinkId=62182
//----------------------------------------------------------------------------------------

using System;
using System.Reflection;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.ObjectBuilder;
using ACOT.Infrastructure.Interface.Services;
using ACOT.Infrastructure.Interface;

namespace ACOT.Infrastructure.Library.BuilderStrategies
{
    public class ActionStrategy : BuilderStrategy
    {
        public override object BuildUp(IBuilderContext context, Type typeToBuild, object existing, string idToBuild)
        {
            WorkItem workItem = GetWorkItem(context, existing);

            if (workItem != null)
            {
                IActionCatalogService actionCatalog = workItem.Services.Get<IActionCatalogService>();
                if (actionCatalog != null)
                {
                    Type targetType = existing.GetType();

                    foreach (MethodInfo methodInfo in targetType.GetMethods())
                        RegisterActionImplementation(context, actionCatalog, existing, idToBuild, methodInfo);
                }
            }

            return base.BuildUp(context, typeToBuild, existing, idToBuild);
        }

        public override object TearDown(IBuilderContext context, object item)
        {
            WorkItem workItem = GetWorkItem(context, item);

            if (workItem != null)
            {
                IActionCatalogService actionCatalog = workItem.Services.Get<IActionCatalogService>();
                if (actionCatalog != null)
                {
                    Type targetType = item.GetType();

                    foreach (MethodInfo methodInfo in targetType.GetMethods())
                        RemoveActionImplementation(context, actionCatalog, item, methodInfo);
                }
            }
            return base.TearDown(context, item);
        }

        private void RemoveActionImplementation(IBuilderContext context, IActionCatalogService catalog, object existing, MethodInfo methodInfo)
        {
            foreach (ActionAttribute attr in methodInfo.GetCustomAttributes(typeof(ActionAttribute), true))
            {
                catalog.RemoveActionImplementation(attr.ActionName);

                TraceTearDown(context, existing, "Action implementation removed for action {0}, for the method {1} on the type {2}.", attr.ActionName, methodInfo.Name, existing.GetType().Name);
            }
        }

        private void RegisterActionImplementation(IBuilderContext context, IActionCatalogService catalog, object existing, string idToBuild, MethodInfo methodInfo)
        {
            foreach (ActionAttribute attr in methodInfo.GetCustomAttributes(typeof(ActionAttribute), true))
            {
                ActionDelegate actionDelegate = (ActionDelegate)Delegate.CreateDelegate(typeof(ActionDelegate), existing, methodInfo);
                catalog.RegisterActionImplementation(attr.ActionName, actionDelegate);

                // TODO: Add to resources
                TraceBuildUp(context, existing.GetType(), idToBuild, "Action implementation built for action {0}, for the method {1} on the type {2}.", attr.ActionName, methodInfo.Name, existing.GetType().Name);
            }
        }

        private WorkItem GetWorkItem(IBuilderContext context, object item)
        {
            if (item is WorkItem)
                return item as WorkItem;

            return context.Locator.Get<WorkItem>(new DependencyResolutionLocatorKey(typeof(WorkItem), null));
        }
    }
}
