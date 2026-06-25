namespace AutoBattleCoop.Assets.Scripts.Damage {
    public interface IDamageResolver {

        int ResolveDamage(int baseDamage, EDamageType damageType, AbstractUnit unit);

    }
}
