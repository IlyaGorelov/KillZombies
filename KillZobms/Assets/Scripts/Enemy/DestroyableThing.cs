using UnityEngine;

public class DestroyableThing : MonoBehaviour
{
    [SerializeField] int health;


    // Update is called once per frame
    void Update()
    {
        if(health<=0) Destroy(gameObject);
    }

    public void GetDamage(int damage) => health -= damage;
}
