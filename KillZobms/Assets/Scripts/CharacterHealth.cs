using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    [SerializeField] int health;

    private void Update()
    {
        if (health <= 0) Time.timeScale = 0;
    }

    public void GetDamage(int dam)
    {
        health -= dam;
    }
}
