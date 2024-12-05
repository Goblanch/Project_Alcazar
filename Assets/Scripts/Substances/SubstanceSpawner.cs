using Substances;
using UnityEngine;

public class SubstanceSpawner : ClickableBase
{
    [SerializeField] private SubstanceTypes _substanceToSpawn;
    private SubstancesFactory _substanceFactory;
    [SerializeField]private SubstancesConfiguration _substanceConfig;

    private void Awake() {
        _substanceFactory = new SubstancesFactory(Instantiate(_substanceConfig));
    }

    protected override void OnClicked()
    {
        base.OnClicked();
        Substance substance = _substanceFactory.Create(_substanceToSpawn);
        substance.gameObject.transform.position = transform.position;
    }
}
