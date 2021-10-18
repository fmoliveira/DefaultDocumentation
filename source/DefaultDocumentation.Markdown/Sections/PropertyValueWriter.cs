﻿using System.Xml.Linq;
using DefaultDocumentation.Model.Member;
using DefaultDocumentation.Writer;

namespace DefaultDocumentation.Markdown.Sections
{
    public sealed class PropertyValueWriter : SectionWriter
    {
        public PropertyValueWriter()
            : base("propertyvalue")
        { }

        public override void Write(PageWriter writer)
        {
            if (writer.CurrentItem is PropertyDocItem propertyItem)
            {
                writer
                    .EnsureLineStart()
                    .AppendLine("#### Property Value")
                    .AppendLink(propertyItem, propertyItem.Property.ReturnType)
                    .AppendLine();

                XElement value = propertyItem.Documentation.GetValue();

                if (value != null)
                {
                    writer
                        .Append(value)
                        .AppendLine();
                }
            }
        }
    }
}