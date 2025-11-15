using UnityEngine;
using System.Collections.Generic;

public class UpgradeSystem : MonoBehaviour
{
    [SerializeField] List<UpgradeCard> pool = new();
    List<UpgradeCard> currentChoices = new();

    public List<UpgradeCard> RollChoices(int playerLv, int waveIdx)
    {
        currentChoices.Clear();
        // ดึงมา 3 ใบแบบสุ่มง่าย ๆ
        for (int i = 0; i < 3; i++)
            currentChoices.Add(pool[Random.Range(0, pool.Count)]);
        return currentChoices;
    }

    public void ApplyUpgrade(Player player, UpgradeCard card)
    {
        player.maxHp += card.effect.addHP;
        player.hp = Mathf.Min(player.hp + card.effect.addHP, player.maxHp);
        player.moveSpeed += card.effect.addMoveSpeed;

        if (player.weapon)
        {
            player.weapon.damageBonus += card.effect.addDamage;
            if (card.effect.addFireRateInverse > 0f)
                player.weapon.fireRate = Mathf.Max(0.05f, player.weapon.fireRate - card.effect.addFireRateInverse);
        }
        GameManager.I.ui.UpdateHUD(player.hp, player.lv, player.exp, GameManager.I.waveMgr.WaveIndex, GameManager.I.score);
    }
}

