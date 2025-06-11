using System;

namespace SemanticNetworks
{
    public class Relation
    {
        public Concept EaterConcept { get; }
        public Concept EatenConcept { get; }

        public Relation(Concept eaterConcept, Concept eatenConcept)
        {
            EaterConcept = eaterConcept;
            EatenConcept = eatenConcept;
        }

        public bool AppliesTo(object eater, object eaten, Dictionary<Type, Concept> mapping)
        {
            return ConceptHelper.IsInstanceOf(eater, EaterConcept, mapping) &&
                   ConceptHelper.IsInstanceOf(eaten, EatenConcept, mapping);
        }
    }

    public static class EatingRelationsManager
    {
        private static readonly List<Relation> AllowedRelations = new List<Relation>();

        public static void AddRelation(Concept eater, Concept eaten)
        {
            AllowedRelations.Add(new Relation(eater, eaten));
        }

        public static bool CanEat(object eater, object eaten, Dictionary<Type, Concept> mapping)
        {
            foreach (var rel in AllowedRelations)
            {
                if (rel.AppliesTo(eater, eaten, mapping))
                    return true;
            }
            return false;
        }
    }
}
