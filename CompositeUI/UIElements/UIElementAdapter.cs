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

using Cnt.CompositeUI.Utility;
using System.Globalization;

namespace Cnt.CompositeUI.UIElements
{
    /// <summary>
    /// Support class to simplify creation of <see cref="IUIElementAdapter"/>-derived classes.
    /// </summary>
    public abstract class UIElementAdapter<TUIElement> : IUIElementAdapter
    {
        /// <summary>
        /// Adds a UI Element.
        /// </summary>
        /// <param name="uiElement"></param>
        /// <returns></returns>
        protected abstract TUIElement Add(TUIElement uiElement);

        /// <summary>
        /// Removes a UI Element.
        /// </summary>
        /// <param name="uiElement">The UI Element to remove.</param>
        protected abstract void Remove(TUIElement uiElement);

        /// <summary>
        /// Adds a UI Element.
        /// </summary>
        /// <param name="uiElement">The UI Element to add.</param>
        /// <returns>The UI Element that was actually added.</returns>
        public object Add(object uiElement)
        {
            Guard.ArgumentNotNull(uiElement, "uiElement");

            TUIElement element = GetTypedElement(uiElement);

            return Add(element); ;
        }

        /// <summary>
        /// Removes a UI Element.
        /// </summary>
        /// <param name="uiElement">The UI Element to remove.</param>
        public void Remove(object uiElement)
        {
            Guard.ArgumentNotNull(uiElement, "uiElement");

            TUIElement element = GetTypedElement(uiElement);
            Remove(element);
        }

        private TUIElement GetTypedElement(object uiElement)
        {
            if (!(uiElement is TUIElement))
            {
                throw new ArgumentException(
                    string.Format(
                        CultureInfo.CurrentCulture,
                        Properties.Resources.UIElementNotCorrectType,
                        typeof(TUIElement).ToString()));
            }

            return (TUIElement)uiElement;
        }

    }
}