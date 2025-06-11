using System;
using System.Collections.Generic;

namespace SemanticNetworks
{
    public static class ConceptHelper
    {
        public static Concept GetConceptForInstance(object instance, Dictionary<Type, Concept> mapping)
        {
            Type type = instance.GetType();
            while (type != null)
            {
                if (mapping.ContainsKey(type))
                    return mapping[type];
                type = type.BaseType;
            }
            return null;
        }

        public static bool IsInstanceOf(object instance, Concept targetConcept, Dictionary<Type, Concept> mapping)
        {
            var instanceConcept = GetConceptForInstance(instance, mapping);
            if (instanceConcept == null) return false;
            return instanceConcept == targetConcept || instanceConcept.IsA(targetConcept);
        }
    }
}
