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
	/// A <see cref="BuilderStrategy"/> which is used to help the application startup sequence properly 
	/// initialize the root <see cref="WorkItem"/> when it is created.
	/// </summary>
	internal class RootWorkItemInitializationStrategy : BuilderStrategy
	{
		/// <summary>
		/// The delegate which is called just as the <see cref="WorkItem"/> is finishing initialization.
		/// </summary>
		public delegate void RootWorkItemInitializationCallback();

		RootWorkItemInitializationCallback callback;

		/// <summary>
		/// Creates a new instance of the RootWorkItemInitializationStrategy class using the given
		/// callback method.
		/// </summary>
		/// <param name="callback">The <see cref="RootWorkItemInitializationCallback"/> callback method
		/// to call when the <see cref="WorkItem"/> is finishing its initialization.</param>
		public RootWorkItemInitializationStrategy(RootWorkItemInitializationCallback callback)
		{
			this.callback = callback;
		}

		/// <summary>
		/// See <see cref="BuilderStrategy.BuildUp"/> for more information.
		/// </summary>
		public override object BuildUp(IBuilderContext context, Type typeToBuild, object existing, string idToBuild)
		{
			WorkItem wi = existing as WorkItem;

			if (wi != null && wi.Parent == null)
				callback();

			return base.BuildUp(context, typeToBuild, existing, idToBuild);
		}
	}
}