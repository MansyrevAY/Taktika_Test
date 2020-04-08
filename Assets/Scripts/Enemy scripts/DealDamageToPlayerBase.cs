using UnityEngine;

[RequireComponent(typeof(EnemyBehaviour))]
public class DealDamageToPlayerBase : MonoBehaviour
{
    private int damage;

    // Start is called before the first frame update
    void Start() => damage = GetComponent<EnemyBehaviour>().stats.ThisWaveDamage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag.Equals("Base"))
        {
            collision.gameObject.GetComponent<PlayerBaseBehaviuor>().TakeDamage(damage);
        }
    }
}
