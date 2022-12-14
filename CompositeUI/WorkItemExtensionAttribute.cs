//===============================================================================
// Microsoft patterns & practices
// Smart Client Software Factory 2010
//===============================================================================
// Copyright © Microsoft Corporation.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===============================================================================
// The example companies, organizations, products, domain names,
// e-mail addresses, logos, people, places, and events depicted
// herein are fictitious.  No association with any real company,
// organization, product, domain name, email address, logo, person,
// places, or events is intended or should be inferred.
//===============================================================================
//===============================================================================
// Microsoft patterns & practices
// CompositeUI Application Block
//===============================================================================
// Copyright © Microsoft Corporation.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===============================================================================
// Copyright © cntsoftware.com

using Cnt.CompositeUI.Utility;

namespace Cnt.CompositeUI
{
	/// <summary>
	/// Indicates that a class extends <see cref="WorkItem"/> classes. The class
	/// must implement <see cref="IWorkItemExtension"/>.
	/// </summary>
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
	public class WorkItemExtensionAttribute : Attribute
	{
		private Type workItemType;

		/// <summary>
		/// Initializes the attribute with the type of the work item to extend.
		/// </summary>
		public WorkItemExtensionAttribute(Type workItemType)
		{
			Guard.ArgumentNotNull(workItemType, "workItemType");

			this.workItemType = workItemType;
		}

		/// <summary>
		/// The type of the <see cref="WorkItem"/> to extend.
		/// </summary>
		public Type WorkItemType
		{
			get { return workItemType; }
		}
	}
}