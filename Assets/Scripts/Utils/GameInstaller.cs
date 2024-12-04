using UnityEngine;
using Substances;

public class GameInstaller : MonoBehaviour{
    [SerializeField] private SubstancesConfiguration substancesConfig;

    private void Start() {
        // Instantiate used to call awake
        SubstancesFactory substancesFactory = new SubstancesFactory(Instantiate(substancesConfig));
        // TODO: include substance spawner creation
    }
}