using UnityEngine;

public class Singletone : MonoBehaviour
{
    public static Singletone instance;

    private void Start()
    {
        if (instance == null)
            instance = this;
        else if (instance = this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }
}
