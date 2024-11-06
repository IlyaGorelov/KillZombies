using System.Collections;
using UnityEngine;

public class CreateZombies : MonoBehaviour
{
    [SerializeField] GameObject[] zombies;
    [SerializeField] float timeBtw = 1;


    private bool canSpawn = true;

    private void Update()
    {
        if (WaveState.waveCount == 1)
        {
            if (!WaveState.isRest && canSpawn)
            {
                canSpawn = false;
                StartCoroutine(Spawn(5,0,0));
            }
            else if (WaveState.isRest)
            {
                canSpawn = true;
            }
        }

        if (WaveState.waveCount == 2)
        {
            if (!WaveState.isRest && canSpawn)
            {
                canSpawn = false;
                StartCoroutine(Spawn(5,5,0));
            }
            else if (WaveState.isRest)
            {
                canSpawn = true;
            }
        }

        if (WaveState.waveCount == 3)
        {
            if (!WaveState.isRest && canSpawn)
            {
                canSpawn = false;
                StartCoroutine(Spawn(5, 6, 5));
            }
            else if (WaveState.isRest)
            {
                canSpawn = true;
            }
            
        }


    }

    IEnumerator Spawn(int a, int b ,int c)
    {
        for (int i = 0; i < a; i++)
        {
            Instantiate(zombies[0],transform.position,Quaternion.identity);
            WaveState.zombiesCount++;
            yield return new WaitForSeconds(timeBtw);
        }
        for (int i = 0; i < b; i++)
        {
            Instantiate(zombies[1], transform.position, Quaternion.identity);
            WaveState.zombiesCount++;
            yield return new WaitForSeconds(timeBtw);
        }
        for (int i = 0; i < c; i++)
        {
            Instantiate(zombies[2], transform.position, Quaternion.identity);
            WaveState.zombiesCount++;
            yield return new WaitForSeconds(timeBtw);
        }
    }
}
