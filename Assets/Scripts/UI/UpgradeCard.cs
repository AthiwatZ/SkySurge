using UnityEngine;

public enum Rarity { Common, Rare, Epic }

[CreateAssetMenu(menuName = "SkySurge/UpgradeCard")]
public class UpgradeCard : ScriptableObject
{
    public string id;
    public Rarity rarity;
    public UpgradeEffect effect;
}

[System.Serializable]
public class UpgradeEffect
{
    public int addHP;
    public int addDamage;
    public float addMoveSpeed;
    public float addFireRateInverse; // ค่านี้ >0 ทำให้ยิงถี่ขึ้น (ลด fireRate)
}
