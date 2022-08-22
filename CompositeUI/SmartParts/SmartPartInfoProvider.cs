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

namespace Cnt.CompositeUI.SmartParts
{
    /// <summary>
    /// Default implementation of a <see cref="ISmartPartInfoProvider"/> that 
    /// can be used to aggregate the behavior on smart parts that use 
    /// a designer to drag and drop the <see cref="ISmartPartInfo"/> components.
    /// </summary>
    [DesignTimeVisible(false)]
    public class SmartPartInfoProvider : Component, ISmartPartInfoProvider
    {
        private List<ISmartPartInfo> items = new List<ISmartPartInfo>();

        /// <summary>
        /// The list of <see cref="ISmartPartInfo"/> items the provider exposes.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public ICollection<ISmartPartInfo> Items
        {
            get { return items; }
        }

        #region ISmartPartInfoProvider Members

        /// <summary>
        /// Retrieves a smart part information object of the given type from the 
        /// registered <see cref="Items"/>.
        /// </summary>
        /// <seealso cref="ISmartPartInfoProvider.GetSmartPartInfo"/>
        public ISmartPartInfo GetSmartPartInfo(Type smartPartInfoType)
        {
            return items.Find(delegate (ISmartPartInfo info)
            {
                return info != null && info.GetType() == smartPartInfoType;
            });
        }

        #endregion
    }
}