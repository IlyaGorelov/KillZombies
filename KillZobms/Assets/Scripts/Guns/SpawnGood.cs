using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class SpawnGood : MonoBehaviour
{
    public int goodIndex;
    [SerializeField] GameObject[] goods;
    [SerializeField] TextMeshProUGUI timeText;
    
    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        for (int i = 60; i > 0; i--)
        {
        yield return new WaitForSeconds(1);
            timeText.text =(Convert.ToInt32(timeText.text)-1).ToString();
        }
        Instantiate(goods[goodIndex],transform.position,Quaternion.identity);
        Destroy(gameObject);
    }
}
