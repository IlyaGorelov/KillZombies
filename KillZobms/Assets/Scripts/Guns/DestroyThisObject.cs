using System.Collections;
using UnityEngine;

public class DestroyThisObject : MonoBehaviour
{

    private void OnEnable()
    {
       
            StartCoroutine(DestroyAfter(5));
        
    }


    private IEnumerator DestroyAfter(int sec)
    {
        yield return new WaitForSeconds(sec);

        Destroy(gameObject);
    }
}
