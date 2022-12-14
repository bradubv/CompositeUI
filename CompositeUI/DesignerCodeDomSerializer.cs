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

using System.CodeDom;
using System.ComponentModel.Design.Serialization;
using System.ComponentModel.Design;
using System.ComponentModel;

namespace Cnt.CompositeUI
{
    /// <summary>
    /// Helper base class for custom serializers.
    /// </summary>
    internal class DesignerCodeDomSerializer : CodeDomSerializer
    {
        protected static TMember FindMember<TMember>(CodeTypeDeclaration declaration, string memberName)
            where TMember : CodeObject
        {
            foreach (CodeTypeMember member in declaration.Members)
            {
                TMember method = member as TMember;
                if (method != null && member.Name == memberName)
                {
                    return method;
                }
            }

            return null;
        }

        protected static CodeMemberMethod FindInitializeComponent(CodeTypeDeclaration declaration)
        {
            return FindMember<CodeMemberMethod>(declaration, "InitializeComponent");
        }

        protected static void AddStatementToInitializeComponent(CodeTypeDeclaration declaration, CodeStatement statement)
        {
            CodeMemberMethod init = FindInitializeComponent(declaration);
            if (init != null)
            {
                init.Statements.Add(statement);
            }
        }

        protected static List<string> GetComponentsOnDesignerSurface(IDesignerSerializationManager manager, object rootComponent)
        {
            // Through the designer host we can inspect the components on the surface.
            IDesignerHost host = (IDesignerHost)manager.GetService(typeof(IDesignerHost));
            List<string> names = new List<string>(host.Container.Components.Count);
            foreach (IComponent component in host.Container.Components)
            {
                // Beware that the root component also appears on the list.
                if (component != rootComponent)
                {
                    names.Add(component.Site.Name);
                }
            }

            return names;
        }

        protected static void RemoveFromStatements<TCodeObject>(CodeStatementCollection statements, Predicate<TCodeObject> shouldRemove)
            where TCodeObject : CodeObject
        {
            List<CodeStatement> toRemove = new List<CodeStatement>();
            foreach (CodeStatement statement in statements)
            {
                TCodeObject typedStatement = statement as TCodeObject;
                CodeExpressionStatement expression = statement as CodeExpressionStatement;
                if (typedStatement == null && expression != null)
                {
                    typedStatement = expression.Expression as TCodeObject;
                }

                if (typedStatement != null && shouldRemove(typedStatement))
                {
                    toRemove.Add(statement);
                }
            }

            foreach (CodeStatement statement in toRemove)
            {
                statements.Remove(statement);
            }
        }

        protected static void RemoveFromInitializeComponent<TCodeObject>(CodeTypeDeclaration declaration, Predicate<TCodeObject> shouldRemove)
            where TCodeObject : CodeObject
        {
            CodeMemberMethod initialize = FindInitializeComponent(declaration);

            if (initialize != null)
            {
                RemoveFromStatements<TCodeObject>(initialize.Statements, shouldRemove);
            }
        }

        protected static List<TCodeObject> FindCode<TCodeObject>(CodeStatementCollection statements, Predicate<TCodeObject> matchesFilter)
            where TCodeObject : CodeObject
        {
            List<TCodeObject> values = new List<TCodeObject>();
            foreach (CodeStatement statement in statements)
            {
                TCodeObject typedStatement = statement as TCodeObject;
                CodeExpressionStatement expression = statement as CodeExpressionStatement;
                if (typedStatement == null && expression != null)
                {
                    typedStatement = expression.Expression as TCodeObject;
                }

                if (typedStatement != null && matchesFilter(typedStatement))
                {
                    values.Add(typedStatement);
                }
            }

            return values;
        }

        protected static TCodeObject FindFirstCode<TCodeObject>(CodeStatementCollection statements, Predicate<TCodeObject> matchesFilter)
            where TCodeObject : CodeObject
        {
            foreach (CodeStatement statement in statements)
            {
                TCodeObject typedStatement = statement as TCodeObject;
                CodeExpressionStatement expression = statement as CodeExpressionStatement;
                if (typedStatement == null && expression != null)
                {
                    typedStatement = expression.Expression as TCodeObject;
                }

                if (typedStatement != null && matchesFilter(typedStatement))
                {
                    return typedStatement;
                }
            }

            return null;
        }
    }
}