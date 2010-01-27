using System;
using System.Collections.Generic;
using System.Text;

namespace ACOT.Infrastructure.Controls.Threading
{
	public enum WorkItemStatus 
	{ 
		Completed, 
		Queued, 
		Executing, 
		Aborted 
	}
}
