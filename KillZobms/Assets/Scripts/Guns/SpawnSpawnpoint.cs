using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnSpawnpoint : MonoBehaviour
{
    [SerializeField] GameObject spawnPoint;
    [SerializeField] int index;

    private void OnDisable()
    {
        int scene = SceneManager.GetActiveScene().buildIndex;
        try
        {
            if (scene!=0)
            {
                var a = Instantiate(spawnPoint, transform.position, Quaternion.identity);
                a.GetComponent<SpawnGood>().goodIndex = index;

            }
        }
        catch { }
    }
}
