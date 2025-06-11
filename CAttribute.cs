namespace SemanticNetworks
{
    public class CAttribute
    {
        public string Name { get; }
        public Type AttributeType { get; }

        private Func<object, object> _getAttributeValue;

        public CAttribute(string name, Type attributeType, Func<object, object> getAttributeValue)
        {
            Name = name;
            AttributeType = attributeType;
            _getAttributeValue = getAttributeValue;
        }

        public object GetValue(object obj)
        {
            return _getAttributeValue(obj);
        }
    }
}
