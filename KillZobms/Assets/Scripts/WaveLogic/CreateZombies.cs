using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreateZombies : MonoBehaviour
{
    [SerializeField] GameObject[] zombies;
    [SerializeField] float timeBtw = 1;


    private bool canSpawn = true;

    private void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex==1)
            SpawnInVillage();
        if (SceneManager.GetActiveScene().buildIndex == 3)
            SpawnInCastle();
        if (SceneManager.GetActiveScene().buildIndex == 5)
            SpawnInDump();


    }

    private void SpawnInVillage()
    {
        if (WaveState.waveCount == 1)
        {
            if (!WaveState.isRest && canSpawn)
            {
                canSpawn = false;
                StartCoroutine(Spawn(5, 0, 0, 0));
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
                StartCoroutine(Spawn(5, 5, 0, 0));
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
                StartCoroutine(Spawn(5, 6, 5, 0));
            }
            else if (WaveState.isRest)
            {
                canSpawn = true;
            }

        }



        if (WaveState.waveCount == 4)
        {
            if (!WaveState.isRest && canSpawn)
            {
                canSpawn = false;
                StartCoroutine(Spawn(2, 2, 11, 1));
            }
            else if (WaveState.isRest)
            {
                canSpawn = true;
            }
        }

        if (WaveState.waveCount == 5)
        {
            if (!WaveState.isRest && canSpawn)
            {
                canSpawn = false;
                StartCoroutine(Spawn(0, 0, 5, 5));
            }
            else if (WaveState.isRest)
            {
                canSpawn = true;
            }
        }
    }

    private void SpawnInCastle()
    {
        if (WaveState.waveCount == 1)
        {
            if (!WaveState.isRest && canSpawn)
            {
                canSpawn = false;
                StartCoroutine(Spawn(10, 0, 0, 0));
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
                StartCoroutine(Spawn(5, 5, 0, 0));
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
                StartCoroutine(Spawn(5, 6, 5, 0));
            }
            else if (WaveState.isRest)
            {
                canSpawn = true;
            }

        }



        if (WaveState.waveCount == 4)
        {
            if (!WaveState.isRest && canSpawn)
            {
                canSpawn = false;
                StartCoroutine(Spawn(2, 2, 11, 1));
            }
            else if (WaveState.isRest)
            {
                canSpawn = true;
            }
        }

        if (WaveState.waveCount == 5)
        {
            if (!WaveState.isRest && canSpawn)
            {
                canSpawn = false;
                StartCoroutine(Spawn(0, 0, 10, 5));
            }
            else if (WaveState.isRest)
            {
                canSpawn = true;
            }
        }
    }

    private void SpawnInDump()
    {
        if (WaveState.waveCount == 1)
        {
            if (!WaveState.isRest && canSpawn)
            {
                canSpawn = false;
                StartCoroutine(Spawn(10, 0, 0, 0));
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
                StartCoroutine(Spawn(5, 5, 0, 0));
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
                StartCoroutine(Spawn(3, 6, 8, 0));
            }
            else if (WaveState.isRest)
            {
                canSpawn = true;
            }

        }



        if (WaveState.waveCount == 4)
        {
            if (!WaveState.isRest && canSpawn)
            {
                canSpawn = false;
                StartCoroutine(Spawn(2, 2, 11, 1));
            }
            else if (WaveState.isRest)
            {
                canSpawn = true;
            }
        }

        if (WaveState.waveCount == 5)
        {
            if (!WaveState.isRest && canSpawn)
            {
                canSpawn = false;
                StartCoroutine(Spawn(0, 0, 5, 6));
            }
            else if (WaveState.isRest)
            {
                canSpawn = true;
            }
        }
    }

    IEnumerator Spawn(int a, int b ,int c,int d)
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

        for (int i = 0; i < d; i++)
        {
            Instantiate(zombies[3], transform.position, Quaternion.identity);
            WaveState.zombiesCount++;
            yield return new WaitForSeconds(timeBtw);
        }
    }
}
