using UnityEngine;

public class GetFirstAid : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.TryGetComponent(out CharacterHealth ch))
        {
            if (ch.health < 100)
            {
                ch.GetAid(100);
                Destroy(gameObject);
            }
        }
    }
}
