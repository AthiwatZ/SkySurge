using UnityEngine;

public enum PickupType { Exp, Heal }

public class Pickup : MonoBehaviour
{
    public PickupType type;
    public int value = 1;

    void Awake()
    {
        var rb = gameObject.AddComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.linearVelocity = Vector2.zero;
        var c = gameObject.AddComponent<CircleCollider2D>();
        c.isTrigger = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        var p = other.GetComponent<Player>();
        if (!p) return;

        if (type == PickupType.Exp) p.exp += value;
        else if (type == PickupType.Heal) p.Heal(value);

        Destroy(gameObject);
        GameManager.I.ui.UpdateHUD(p.hp, p.lv, p.exp, GameManager.I.waveMgr.WaveIndex, GameManager.I.score);
    }
}

