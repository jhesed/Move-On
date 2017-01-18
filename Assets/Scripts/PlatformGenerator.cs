using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject[] platforms;

    int _randomRockIndex = 0;
    int _currentMaxRandom = 5;
    int _generatorCounter = 0;


    // Allows platforms to be shown after this count
    int __displayPlatform1AfterCount = 0;
    int __displayPlatform2AfterCount = 5;
    int __displayPlatform3AfterCount = 10;
    int __displayPlatform4AfterCount = 15;
    int __displayPlatform5AfterCount = 20;
   
    // Use this for initialization
    void Start()
    {
        InvokeRepeating("GeneratePlatform", 5f, 1.5f);
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
        Instantiate(platforms[_randomRockIndex]);
    }
}