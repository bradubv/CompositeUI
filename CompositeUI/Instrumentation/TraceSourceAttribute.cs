﻿//===============================================================================
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

using System.Diagnostics;
using Cnt.ObjectBuilder;

namespace Cnt.CompositeUI
{
	/// <summary>
	/// Indicates that a property or parameter will be dependency injected with a
	/// <see cref="TraceSource"/>.
	/// </summary>
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Parameter, AllowMultiple = false, Inherited = true)]
	public class TraceSourceAttribute : ParameterAttribute
	{
		private string sourceName;

		/// <summary>
		/// Name of the <see cref="TraceSource"/> to get.
		/// </summary>
		public string SourceName
		{
			get { return sourceName; }
		}

		/// <summary>
		/// Creates a new instance of the <see cref="TraceSourceAttribute"/> class.
		/// </summary>
		/// <param name="sourceName">Name of the <see cref="TraceSource"/> to get.</param>
		public TraceSourceAttribute(string sourceName)
		{
			this.sourceName = sourceName;
		}

		/// <summary>
		/// See <see cref="ParameterAttribute.CreateParameter"/> for more information.
		/// </summary>
		public override IParameter CreateParameter(Type memberType)
		{
			return new TraceSourceParameter(memberType, sourceName);
		}

		private class TraceSourceParameter : KnownTypeParameter
		{
			private string sourceName;

			public TraceSourceParameter(Type memberType, string sourceName)
				: base(memberType)
			{
				this.sourceName = sourceName;
			}

			public override object GetValue(IBuilderContext context)
			{
				DependencyResolutionLocatorKey key = new DependencyResolutionLocatorKey(typeof(ITraceSourceCatalogService), null);
				ITraceSourceCatalogService svc = (ITraceSourceCatalogService)context.Locator.Get(key);

				return svc != null ? svc.GetTraceSource(sourceName) : null;
			}
		}
	}
}
