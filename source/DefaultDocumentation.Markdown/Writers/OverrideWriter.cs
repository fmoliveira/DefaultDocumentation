﻿using System.Collections.Generic;
using DefaultDocumentation.Model;
using DefaultDocumentation.Writers;

namespace DefaultDocumentation.Markdown.Writers
{
    public sealed class OverrideWriter : IWriter
    {
        private readonly IWriter _writer;
        private readonly Dictionary<string, object> _data;

        public OverrideWriter(IWriter writer)
        {
            _writer = writer;
            _data = new Dictionary<string, object>();
        }

        #region IWriter

        public DocumentationContext Context => _writer.Context;

        public DocItem DocItem => _writer.DocItem;

        public int Length
        {
            get => _writer.Length;
            set => _writer.Length = value;
        }

        public object this[string key]
        {
            get => (_data.TryGetValue(key, out object value) ? value : null) ?? _writer[key];
            set => _data[key] = value;
        }

        public IWriter Append(string value)
        {
            _writer.Append(value);

            return this;
        }

        public IWriter AppendLine()
        {
            _writer.AppendLine();

            return this;
        }

        public bool EndsWith(string value) => _writer.EndsWith(value);

        #endregion
    }
}