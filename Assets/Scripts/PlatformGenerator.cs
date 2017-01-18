using System.Collections;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject[] platforms;
    public float minSpawnTime = 0.5f;
    public float maxSpawnTime = 1.5f;
    public float startTime = 5f;

    private float timer = 0.0f;
    private float nextTime;

    int _randomRockIndex = 0;
    int _currentMaxRandom = 5;
    int _generatorCounter = 0;

    // Allows platforms to be shown after this count
    int __displayPlatform1AfterCount = 0;
    int __displayPlatform2AfterCount = 3;
    int __displayPlatform3AfterCount = 6;
    int __displayPlatform4AfterCount = 9;
    int __displayPlatform5AfterCount = 12;
   
    // Use this for initialization
    void Start()
    {
        while (true) {
            //{
            //InvokeRepeating("GeneratePlatform", startTime, 2f);
            //yield return WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));
            //     Invoke("GeneratePlatform", startTime);
            //}

            GeneratePlatform();
            yield WaitForSeconds(startTime - 0.3f);
        }
    }

    void GeneratePlatform()
    {

        Debug.Log(_generatorCounter);

        _generatorCounter++;
        
        // Determines upto what platform type will be generated in random
        if (_generatorCounter > __displayPlatform5AfterCount) {
            _currentMaxRandom = 5;
        }
        else if (_generatorCounter > __displayPlatform4AfterCount)
        {
            _currentMaxRandom = 4;
        }
        if (_generatorCounter > __displayPlatform3AfterCount)
        {
            _currentMaxRandom = 3;
        }
        if (_generatorCounter > __displayPlatform2AfterCount)
        {
            _currentMaxRandom = 2;
        }
        else{
            _currentMaxRandom = 1;
        }

        _randomRockIndex = Random.Range(0, _currentMaxRandom);
        Vector3 pos = new Vector3(Random.value, 1, 1);
        pos = Camera.main.ViewportToWorldPoint(pos);

        Instantiate(platforms[_randomRockIndex], pos, Quaternion.identity);


        //timer = 0.0f;
        //nextTime = Random.Range(minSpawnTime, maxSpawnTime);
        //Invoke("GeneratePlatform", startTime-0.1f);
    }
}