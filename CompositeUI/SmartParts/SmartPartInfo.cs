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
using System.ComponentModel;

namespace Cnt.CompositeUI.SmartParts
{
    /// <summary>
    /// Provides information about a specific smartpart.
    /// </summary>
    public partial class SmartPartInfo : ISmartPartInfo
    {
        #region Fields

        private string description = string.Empty;
        private string title = string.Empty;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SmartPartInfo"/> class.
        /// </summary>
        public SmartPartInfo()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SmartPartInfo"/> class 
        /// with the title and description values.
        /// </summary>
        public SmartPartInfo(string title, string description)
        {
            this.title = title;
            this.description = description;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Description to associate with the related smart part.
        /// </summary>
        [Category("Layout")]
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        /// <summary>
        /// Title to associate with the related smart part.
        /// </summary>
        [Category("Layout")]
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates a new instance of the TSmartPartInfo 
        /// and copies over the information in the source smart part.
        /// </summary>
        public static TSmartPartInfo ConvertTo<TSmartPartInfo>(ISmartPartInfo source)
            where TSmartPartInfo : ISmartPartInfo, new()
        {
            Guard.ArgumentNotNull(source, "source");

            TSmartPartInfo info = new TSmartPartInfo();

            info.Description = source.Description;
            info.Title = source.Title;

            return info;
        }

        #endregion
    }
}