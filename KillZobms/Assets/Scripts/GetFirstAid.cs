using UnityEngine;
using UnityEngine.SceneManagement;

public class GetFirstAid : MonoBehaviour
{
    [SerializeField] GameObject spawnPoint;
    [SerializeField] int index;

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.TryGetComponent(out CharacterHealth ch))
        {
            if (ch.health < 100)
            {
                int scene = SceneManager.GetActiveScene().buildIndex;
                try
                {
                    if (scene != 0)
                    {
                        var a = Instantiate(spawnPoint, transform.position, Quaternion.identity);
                        a.GetComponent<SpawnGood>().goodIndex = index;

                    }
                }
                catch { }
                ch.GetAid(100);
                Destroy(gameObject);
            }
        }
    }
}
