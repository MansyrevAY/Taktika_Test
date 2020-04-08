using UnityEngine;

[SelectionBase]
public class EnemyBehaviour : MonoBehaviour{

    public delegate void ReachBase();
    public event ReachBase ReachedPlayerBase;

    public EnemyStatsSO stats;

    public void OnBaseReached()
    {
        ReachedPlayerBase?.Invoke();
        Destroy(gameObject);
    }
}
