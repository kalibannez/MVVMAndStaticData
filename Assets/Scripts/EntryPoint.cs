using UnityEngine;
using Zenject;

public class EntryPoint : MonoBehaviour {
    
    [SerializeField]
    private GameObject _choseWeaponScreen;

    [Inject]
    private IChoseWeaponViewModel _weaponViewModel;

    [Inject]
    private ChoseWeaponModel _weaponModel;

    void Start() {
        ChoseWeaponScreenBinder.Bind(_choseWeaponScreen.GetComponent<IChoseWeaponScreen>(), _weaponViewModel, _weaponModel);
    }
}

static class ChoseWeaponScreenBinder {
    public static void Bind(IChoseWeaponScreen screen, IChoseWeaponViewModel viewModel, ChoseWeaponModel model) {
        screen.Init(viewModel);
        model.Init();
        viewModel.Init(model);
    }
}
