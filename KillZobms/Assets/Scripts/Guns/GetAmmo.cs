using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GetAmmo : MonoBehaviour
{
    [SerializeField] int id;
    [SerializeField] int count = 30;
    [SerializeField] GameObject spawnPoint;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out ChangeGuns cg))
        {



            if (cg.gunId != 3)
            {
                if (cg.gunId == id)
                {
                    int scene = SceneManager.GetActiveScene().buildIndex;
                    try
                    {
                        if (scene != 0)
                        {
                            var a = Instantiate(spawnPoint, transform.position, Quaternion.identity);
                            a.GetComponent<SpawnGood>().goodIndex = id;
                        }
                    }
                    catch { }
                    cg.PlaySound();
                    Weapon weapon = collision.gameObject.GetComponentInChildren<Weapon>();
                    weapon.allAmmo += count;
                    Destroy(gameObject);
                }
            }
            else if (cg.gunId == id && cg.gunId == 3)
            {
                int scene = SceneManager.GetActiveScene().buildIndex;
                try
                {
                    if (scene != 0)
                    {
                        var a = Instantiate(spawnPoint, transform.position, Quaternion.identity);
                        a.GetComponent<SpawnGood>().goodIndex = id;
                    }
                }
                catch { }
                cg.PlaySound();
                Shotgun weapon = collision.gameObject.GetComponentInChildren<Shotgun>();
                weapon.allAmmo += count;
                Destroy(gameObject);
            }

        }
    }
}
