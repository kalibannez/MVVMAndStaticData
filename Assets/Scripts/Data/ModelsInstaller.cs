using Zenject;

public class ModelsInstaller : MonoInstaller {

    public override void InstallBindings() {
        Container.Bind<IChoseWeaponViewModel>().To<ChoseWeaponViewModel>().AsSingle().NonLazy();
        Container.Bind<ChoseWeaponModel>().AsSingle().NonLazy();
    }

}
