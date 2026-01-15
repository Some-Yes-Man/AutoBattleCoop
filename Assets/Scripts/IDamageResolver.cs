namespace AutoBattleCoop {
    public interface IDamageResolver {

        int ResolveDamage(int baseDamage, EDamageType damageType, AbstractUnit unit);

    }
}
