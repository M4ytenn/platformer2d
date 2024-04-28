using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private float _attackRange = 1;
    [SerializeField] private float _damage = 1;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(_attackPoint.position, _attackRange);

            foreach (Collider2D collider in colliders)
            {
                if (collider.TryGetComponent(out Health health))
                {
                    health.ApplyDamage(_damage);
                }
            }
        }
    }
}
