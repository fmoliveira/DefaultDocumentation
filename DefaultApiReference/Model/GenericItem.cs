﻿using System.Xml.Linq;

namespace DefaultApiReference.Model
{
    internal sealed class GenericItem : ADocItem
    {
        public GenericItem(ADocItem parent, XElement item)
            : base(parent, item)
        { }
    }
}
