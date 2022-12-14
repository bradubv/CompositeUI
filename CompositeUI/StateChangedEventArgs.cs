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

using System.ComponentModel;

namespace Cnt.CompositeUI
{
	/// <summary>
	/// Provides data for a StateChanged event.
	/// </summary>
	public class StateChangedEventArgs : EventArgs
	{
		private object newValue;
		private object oldValue;
		private string key;

		/// <summary>
		/// Initializes a new instance of the <see cref="StateChangedEventArgs"/> class using the
		/// provided key and new value.
		/// </summary>
		public StateChangedEventArgs(string key, object newValue)
		{
			this.key = key;
			this.newValue = newValue;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="StateChangedEventArgs"/> class using the
		/// provided key, new value, and old value.
		/// </summary>
		public StateChangedEventArgs(string key, object newValue, object oldValue)
		{
			this.key = key;
			this.newValue = newValue;
			this.oldValue = oldValue;
		}

		/// <summary>
		/// Gets and sets the changed <see cref="State"/> item key.
		/// </summary>
		public string Key
		{
			get { return key; }
			set { key = value; }
		}

		/// <summary>
		/// Gets and sets the <see cref="State"/> item's new value.
		/// </summary>
		[DefaultValue(null)]
		public object NewValue
		{
			get { return newValue; }
			set { this.newValue = value; }
		}

		/// <summary>
		/// Gets and sets the <see cref="State"/> item's old value.
		/// </summary>
		[DefaultValue(null)]
		public object OldValue
		{
			get { return oldValue; }
			set { oldValue = value; }
		}
	}
}
