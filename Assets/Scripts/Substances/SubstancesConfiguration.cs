using UnityEngine;
using System.Collections.Generic;
using System;

namespace Substances{

    [CreateAssetMenu(fileName = "SubstancesConfiguration", menuName = "Substances/SubstancesConfiguration")]
    public class SubstancesConfiguration : ScriptableObject
    {
        [SerializeField] private Substance[] substances;
        private Dictionary<SubstanceTypes, Substance> idToSubstance;

        private void Awake() {
            idToSubstance = new Dictionary<SubstanceTypes, Substance>(substances.Length);
            foreach(Substance substance in substances){
                idToSubstance.Add(substance.SubstanceID, substance);
            }
        }

        public Substance GetSubstancePrefabById(SubstanceTypes substanceID){
            if(!idToSubstance.TryGetValue(substanceID, out var substance)){
                throw new Exception($"Substance with id {substanceID} does not exist");
            }

            return substance;
        }
    }
}


