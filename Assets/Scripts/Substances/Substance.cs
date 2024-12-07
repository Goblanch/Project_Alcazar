using UnityEngine;


namespace Substances{

    public enum SubstanceTypes{
        iron, obsidian, fire
    }

    public abstract class Substance : ItemPickable
    {
        [SerializeField] protected SubstanceTypes _substanceId;
        public SubstanceTypes SubstanceID => _substanceId;
    }

}
