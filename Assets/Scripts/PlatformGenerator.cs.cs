using UnityEngine;

public class Generate : MonoBehaviour
{
    public GameObject[] platforms;

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("GeneratePlatform", 1f, 1.5f);
    }

    void GeneratePlatform()
    {
        Instantiate(platforms[0]);
    }
}