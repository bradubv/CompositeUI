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

namespace Cnt.CompositeUI
{
	/// <summary>
	/// Indicates that a class should be automatically registered as a service into the
	/// application's root <see cref="WorkItem"/>.
	/// </summary>
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
	public sealed class ServiceAttribute : Attribute
	{
		private Type registerAs;
		private bool addOnDemand;

		/// <summary>
		/// Initializes a new instance of the <see cref="ServiceAttribute"/> class. The
		/// registered type will the concrete type of the service.
		/// </summary>
		public ServiceAttribute()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ServiceAttribute"/> class using
		/// the provided type as the registration type for the service.
		/// </summary>
		/// <param name="registerAs">The registration type for the service.</param>
		public ServiceAttribute(Type registerAs)
		{
			this.registerAs = registerAs;
		}

		/// <summary>
		/// The service type implemented by the attributed class. This is the type 
		/// that will be used to register the service with the <see cref="WorkItem"/>.
		/// </summary>
		public Type RegisterAs
		{
			get { return registerAs; }
		}

		/// <summary>
		/// Specifies that the service instance will be created and added to the container
		/// upon request of that service (delayed creation).
		/// </summary>
		public bool AddOnDemand
		{
			get { return this.addOnDemand; }
			set { this.addOnDemand = value; }
		}
	}
}