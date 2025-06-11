using System;
using System.Collections.Generic;

namespace SemanticNetworks
{
    public class CBuilder
    {
        private string _conceptName;
        private Type _conceptBaseType;
        private List<CAttribute> _conceptAttributes = new List<CAttribute>();
        private Predicate<object> _conceptFilter;

        public CBuilder(Type conceptBaseType)
        {
            _conceptBaseType = conceptBaseType;
        }

        public CBuilder SetName(string conceptName)
        {
            _conceptName = conceptName;
            return this;
        }

        public CBuilder SetAttribute(string attributeName, Type attributeType, Func<object, object> getAttributeValue)
        {
            var attribute = new CAttribute(attributeName, attributeType, getAttributeValue);
            _conceptAttributes.Add(attribute);
            return this;
        }

        public CBuilder SetFilter(Predicate<object> filter)
        {
            _conceptFilter = filter;
            return this;
        }

        public Concept Build()
        {
            return new Concept(_conceptName, _conceptBaseType, _conceptAttributes, _conceptFilter);
        }
    }
}
