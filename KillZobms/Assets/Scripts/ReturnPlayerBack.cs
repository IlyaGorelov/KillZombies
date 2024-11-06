using UnityEngine;

public class ReturnPlayerBack : MonoBehaviour
{
    Vector3 lastState;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out CharacterController c))
        {
            lastState = other.gameObject.transform.position;
            other.gameObject.transform.position = lastState;
        }
    }
}
