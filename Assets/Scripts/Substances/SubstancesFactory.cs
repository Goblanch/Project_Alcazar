using Substances;
using UnityEngine;

namespace Substances{
    public class SubstancesFactory{
        private readonly SubstancesConfiguration substancesConfig;

        public SubstancesFactory(SubstancesConfiguration substanceConfig){
            this.substancesConfig = substanceConfig;
        }

        public Substance Create(SubstanceTypes substanceId){
            Substance prefab = substancesConfig.GetSubstancePrefabById(substanceId);

            return Object.Instantiate(prefab);
        }
    }
}