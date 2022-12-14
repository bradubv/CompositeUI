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

using Cnt.ObjectBuilder;

namespace Cnt.CompositeUI.BuilderStrategies
{
	/// <summary>
	/// 
	/// </summary>
	public class ObjectBuiltNotificationPolicy : IBuilderPolicy
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="item"></param>
		public delegate void ItemNotification(object item);

		/// <summary>
		/// 
		/// </summary>
		public Dictionary<WorkItem, ItemNotification> AddedDelegates = new Dictionary<WorkItem, ItemNotification>();

		/// <summary>
		/// 
		/// </summary>
		public Dictionary<WorkItem, ItemNotification> RemovedDelegates = new Dictionary<WorkItem, ItemNotification>();
	}
}
