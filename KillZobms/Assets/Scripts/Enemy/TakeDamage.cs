using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    private Zombie zombie;
    [SerializeField] int multiplier = 1;

    private void Start()
    {
        zombie = GetComponentInParent<Zombie>();
    }

    public void GetDamage(int damage)
    {
        zombie.health -= damage*multiplier;
    }
}
