using UnityEngine;
using System.Collections;

public class WaveManager : MonoBehaviour
{
    public int WaveIndex { get; private set; } = 0;
    public WavePreset[] presets;
    public Transform[] spawnPoints;
    public ItemSpawner itemSpawner;

    bool spawning = false;

    public void StartNextWave()
    {
        if (spawning) return;
        WaveIndex++;
        GameManager.I.ui.UpdateHUD(GameManager.I.player.hp, GameManager.I.player.lv, GameManager.I.player.exp, WaveIndex, GameManager.I.score);
        StartCoroutine(SpawnWaveRoutine(GetRandomPreset()));
    }

    public void StopWave() { StopAllCoroutines(); spawning = false; }

    WavePreset GetRandomPreset()
    {
        return presets[Random.Range(0, presets.Length)];
    }

    IEnumerator SpawnWaveRoutine(WavePreset preset)
    {
        spawning = true;
        foreach (var entry in preset.composition)
        {
            for (int i = 0; i < entry.count; i++)
            {
                var pt = spawnPoints[Random.Range(0, spawnPoints.Length)];
                var go = Instantiate(entry.enemyPrefab, pt.position, Quaternion.identity);
                var e = go.GetComponent<Enemy>();
                e.spawner = itemSpawner;
                e.InitFromScale(GameManager.I.player.lv, WaveIndex);
                yield return new WaitForSeconds(entry.interval);
            }
        }
        spawning = false;

        // หน่วงเล็กน้อยแล้วเริ่มเวฟใหม่อัตโนมัติ
        yield return new WaitForSeconds(2f);
        StartNextWave();
    }
}

