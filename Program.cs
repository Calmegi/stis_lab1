using System;
using System.Collections.Generic;
using SemanticNetworks;
using SubjectDomain;

namespace SemanticNetworksSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Concept animalConcept = new CBuilder(typeof(Animal))
                                        .SetName("Animal")
                                        .SetFilter(obj => true)
                                        .Build();
            Concept mammalConcept = new CBuilder(typeof(Mammal))
                                        .SetName("Mammal")
                                        .SetFilter(obj => true)
                                        .Build();
            Concept birdConcept = new CBuilder(typeof(Bird))
                                        .SetName("Bird")
                                        .SetFilter(obj => true)
                                        .Build();
            Concept humanConcept = new CBuilder(typeof(Human))
                                        .SetName("Human")
                                        .SetFilter(obj => true)
                                        .Build();
            Concept greekConcept = new CBuilder(typeof(Greek))
                                        .SetName("Greek")
                                        .SetFilter(obj => true)
                                        .Build();
            Concept pigConcept = new CBuilder(typeof(Pig))
                                        .SetName("Pig")
                                        .SetFilter(obj => true)
                                        .Build();


            mammalConcept.AddParent(animalConcept);
            birdConcept.AddParent(animalConcept);
            humanConcept.AddParent(mammalConcept);
            greekConcept.AddParent(humanConcept);
            pigConcept.AddParent(mammalConcept);

        
            var conceptMapping = new Dictionary<Type, Concept>
            {
                { typeof(Animal), animalConcept },
                { typeof(Mammal), mammalConcept },
                { typeof(Bird), birdConcept },
                { typeof(Human), humanConcept },
                { typeof(Greek), greekConcept },
                { typeof(Pig), pigConcept },
            };

        
            var aristotle = new Greek();
            var ivan = new Human();
            var khryusha = new Pig();
            var gosha = new Bird();

            
            Console.WriteLine($"Аристотель - грек? {ConceptHelper.IsInstanceOf(aristotle, greekConcept, conceptMapping)}");
            Console.WriteLine($"Аристотель - млекопитающее? {ConceptHelper.IsInstanceOf(aristotle, mammalConcept, conceptMapping)}");
            Console.WriteLine($"Иван - грек? {ConceptHelper.IsInstanceOf(ivan, greekConcept, conceptMapping)}");
            Console.WriteLine($"Хрюша - птица? {ConceptHelper.IsInstanceOf(khryusha, birdConcept, conceptMapping)}");
            Console.WriteLine($"Птица является животным? {ConceptHelper.IsInstanceOf(gosha, animalConcept, conceptMapping)}");

        
            EatingRelationsManager.AddRelation(humanConcept, pigConcept);
            EatingRelationsManager.AddRelation(humanConcept, birdConcept);

            Console.WriteLine($"Аристотель может съесть Ивана? {EatingRelationsManager.CanEat(aristotle, ivan, conceptMapping)}");
            Console.WriteLine($"Иван может съесть Гошу? {EatingRelationsManager.CanEat(ivan, gosha, conceptMapping)}");

            Console.ReadLine();
        }
    }
}
