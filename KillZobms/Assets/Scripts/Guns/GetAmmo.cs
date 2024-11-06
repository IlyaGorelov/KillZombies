using UnityEngine;

public class GetAmmo : MonoBehaviour
{
    [SerializeField] int id;
    [SerializeField] int count = 30;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out ChangeGuns cg))
        {
            if (cg.gunId != 3)
            {
            if(cg.gunId == id)
            {
                cg.PlaySound();
                Weapon weapon = collision.gameObject.GetComponentInChildren<Weapon>();
                weapon.allAmmo += count;
                Destroy(gameObject);
            }
            }
            else
            {
                cg.PlaySound();
                Shotgun weapon = collision.gameObject.GetComponentInChildren<Shotgun>();
                weapon.allAmmo += count;
                Destroy(gameObject);
            }

        }
    }
}
