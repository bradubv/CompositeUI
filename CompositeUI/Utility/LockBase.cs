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

namespace Cnt.CompositeUI.Utility
{
	internal delegate void AcquireIntTimeoutMethod(int millisecondsTimeout);
	internal delegate void AcquireTimeSpanTimeoutMethod(TimeSpan timeout);
	internal delegate void ReleaseMethod();

	/// <summary>
	/// Base class for <see cref="ReaderWriterLock"/> helper classes 
	/// <see cref="ReaderLock"/> and <see cref="WriterLock"/>.
	/// </summary>
	/// <seealso cref="ReaderLock"/>
	/// <seealso cref="WriterLock"/>
	public abstract class LockBase : IDisposable
	{
		ReleaseMethod release;
		bool timedOut = false;

		internal LockBase(AcquireIntTimeoutMethod acquire, ReleaseMethod release, int timeout)
		{
			this.release = release;

			try
			{
				acquire(timeout);
			}
			catch (ApplicationException)
			{
				timedOut = true;
			}
		}

		internal LockBase(AcquireTimeSpanTimeoutMethod acquire, ReleaseMethod release, TimeSpan timeout)
		{
			this.release = release;

			try
			{
				acquire(timeout);

			}
			catch (ApplicationException)
			{
				timedOut = true;
			}
		}

		/// <summary>
		/// If a timeout was specified in the constructor, it returns whether the operation 
		/// succeeded or timed out.
		/// </summary>
		public bool TimedOut
		{
			get { return timedOut; }
		}

		/// <summary>
		/// Releases the lock acquired at construction time.
		/// </summary>
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		/// <summary>
		/// Called to free resources.
		/// </summary>
		/// <param name="disposing">Should be true when calling from Dispose().</param>
		protected virtual void Dispose(bool disposing)
		{
			if (disposing && !timedOut)
			{
				release();
			}
		}
	}
}
