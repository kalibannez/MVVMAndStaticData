using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

public class EntryPoint : MonoBehaviour {
    
    [SerializeField]
    private ChoseWeaponScreen _choseWeaponScreen;

    [SerializeField]
    private Canvas _canvas;

    [Inject]
    private IChoseWeaponViewModel _weaponViewModel;

    [Inject]
    private ChoseWeaponModel _weaponModel;

    void Start() {
        ChoseWeaponScreenBinder.Bind(_choseWeaponScreen, _weaponViewModel, _weaponModel);
    }
}

static class ChoseWeaponScreenBinder {
    public static void Bind(ChoseWeaponScreen screen, IChoseWeaponViewModel viewModel, ChoseWeaponModel model) {
        screen.Init(viewModel);
        model.Init();
        viewModel.Init(model);
    }
}
