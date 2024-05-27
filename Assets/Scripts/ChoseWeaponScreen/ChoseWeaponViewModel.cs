using UniRx;

public interface IChoseWeaponViewModel {
    public void Init(IChoseWeaponModel model);

    public ReactiveProperty<int> ChosenWeapon { get; }

    public void SelectWeapon(int id);

    public WeaponsStaticData GetWeaponsStaticData();
}

public class ChoseWeaponViewModel : IChoseWeaponViewModel {
    private IChoseWeaponModel _model;
    
    public ReactiveProperty<int> ChosenWeapon { get; } = new();

    public void Init(IChoseWeaponModel model) {
        _model = model;
        _model.BindUpdater(UpdateViewModel);
        UpdateViewModel();
    }

    public void SelectWeapon(int id) {
        _model.ChoseWeapon(id);
    }

    public WeaponsStaticData GetWeaponsStaticData() => _model.GetWeaponsStaticData();

    private void UpdateViewModel() => ChosenWeapon.SetValueAndForceNotify(_model.ChosenWeaponId);
}
