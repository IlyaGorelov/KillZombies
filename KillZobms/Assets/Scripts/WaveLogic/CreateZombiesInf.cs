using UnityEngine;
using System.Collections;

public class CreateZombiesInf : MonoBehaviour
{
    [SerializeField] GameObject[] zombies;
    [SerializeField] float delay = 1;
    private float timeBtw;


    private void Update()
    {
        if (timeBtw <= 0 && InfWaveState.zombiesCount<60)
        {
            InfWaveState.zombiesCount++;
            int rand = Random.Range(0, zombies.Length);
            Instantiate(zombies[rand], transform.position, Quaternion.identity);
            timeBtw = delay;
        }
        else
            timeBtw -= Time.deltaTime;
        

    }
}
