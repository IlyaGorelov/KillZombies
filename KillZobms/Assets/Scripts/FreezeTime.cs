using UnityEngine;

public class FreezeTime : MonoBehaviour
{
    [SerializeField] GameObject[] UI;
    int count = 0;

    private void Update()
    {
        count = 0;
        foreach (GameObject go in UI)
        {
            if(go.activeSelf)count++;
        }
        if (count > 0)
        {
            Time.timeScale = 0;
        }
        else Time.timeScale = 1;
    }
}
