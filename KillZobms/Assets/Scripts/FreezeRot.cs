using UnityEngine;

public class FreezeRot : MonoBehaviour
{
    
    void Update()
    {
        transform.rotation = Quaternion.identity;
        float lastH = transform.position.y;
        transform.position = new Vector3(transform.position.x,lastH,transform.position.z);
    }
}
