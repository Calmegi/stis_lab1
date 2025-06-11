using System;
using System.Collections.Generic;

namespace SemanticNetworks
{
    public class Concept
    {
        public string Name { get; }
        public Type BaseType { get; }
        public List<CAttribute> Attributes { get; }

        private Predicate<object> _filter;
        private List<Concept> _parents = new List<Concept>();

        public Concept(string name, Type baseType, List<CAttribute> attributes, Predicate<object> filter)
        {
            Name = name;
            BaseType = baseType;
            Attributes = attributes;
            _filter = filter;
        }

        public void AddParent(Concept parent)
        {
            _parents.Add(parent);
        }

        public bool IsA(Concept other)
        {
            if (this == other) return true;

            var current = this.GetParent();
            while (current != null && current != other)
            {
                current = current.GetParent();
                if (current == other)
                    return true;
            }
            return false;
        }

        private Concept GetParent()
        {
            if (_parents.Count > 0)
                return _parents[0];
            return null;
        }

        public bool HasInstance(object obj)
        {
            if (obj == null || obj.GetType() != BaseType || !_filter(obj))
                return false;
            return true;
        }

        public CAttribute GetAttribute(string attributeName)
        {
            var attribute = Attributes.Find(a => a.Name == attributeName);
            if (attribute == null)
                throw new Exception($"Атрибут '{attributeName}' не найден в концепте '{Name}'");
            return attribute;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
