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

using System.Globalization;
using Cnt.CompositeUI.Utility;

namespace Cnt.CompositeUI.UIElements
{
	/// <summary>
	/// Catalog that keeps track of each <see cref="IUIElementAdapterFactory"/> that is available.
	/// </summary>
	public class UIElementAdapterFactoryCatalog : IUIElementAdapterFactoryCatalog
	{
		private List<IUIElementAdapterFactory> factories = new List<IUIElementAdapterFactory>();

		/// <summary>
		/// Gets the list that includes each registered <see cref="IUIElementAdapterFactory"/> in the catalog.
		/// </summary>
		public IList<IUIElementAdapterFactory> Factories
		{
			get { return factories.AsReadOnly(); }
		}

		/// <summary>
		/// Adds a <see cref="IUIElementAdapterFactory"/> to the catalog.
		/// </summary>
		/// <param name="adapterFactory">The factory to add.</param>
		public void RegisterFactory(IUIElementAdapterFactory adapterFactory)
		{
			Guard.ArgumentNotNull(adapterFactory, "adapterFactory"); //TODO: Make sure this is using the right Guard

			factories.Add(adapterFactory);
		}

		/// <summary>
		/// Retrieves a <see cref="IUIElementAdapterFactory"/> for the given UI Element.
		/// </summary>
		/// <param name="element">The UI Element a factory is to be retrieved for.</param>
		/// <returns>The factory for the UI Element.</returns>
		public IUIElementAdapterFactory GetFactory(object element)
		{
			foreach (IUIElementAdapterFactory factory in factories)
			{
				if (factory.Supports(element))
					return factory;
			}

			throw new ArgumentException(String.Format(CultureInfo.CurrentCulture,
									Properties.Resources.NoRegisteredUIElementFactory,
									element.GetType().ToString()));
		}
	}
}