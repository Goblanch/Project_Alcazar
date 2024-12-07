using UnityEngine;
using Substances;

public class GameInstaller : MonoBehaviour{
    [SerializeField] private SubstancesConfiguration substancesConfig;
    [SerializeField] private UIMediator ui;

    private void Awake() {
        ServiceLocator.Instance.RegisterService<UIMediator>(ui);
    }

    private void Start() {
        // Instantiate used to call awake
        SubstancesFactory substancesFactory = new SubstancesFactory(Instantiate(substancesConfig));
    }
}