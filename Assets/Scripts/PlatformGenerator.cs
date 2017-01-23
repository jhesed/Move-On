using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject[] platforms;
    public float minSpawnTime = 0.5f;
    public float maxSpawnTime = 1.5f;
    public float startTime = 1f;

    private float timer = 0.0f;
    private float nextTime;
    private float fastestGenerateTime = 0.3f;
    private float platformFallSpeedAdder = 1f;

    int _randomRockIndex = 0;
    int _currentMaxRandom = 1;
    int _generatorCounter = 0;
    int _maxGenerateRetries = 3;
    int _currentGenerateTries = 0;

    // Allows platforms to be shown after this count
    int __displayPlatform1AfterCount = 0;
    int __displayPlatform2AfterCount = 3;
    int __displayPlatform3AfterCount = 6;
    int __displayPlatform4AfterCount = 9;
    int __displayPlatform5AfterCount = 12;
   
    // Use this for initialization
    void Start()
    {
        //{
        //InvokeRepeating("GeneratePlatform", startTime, 2f);
        //yield return WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));
        //     Invoke("GeneratePlatform", startTime);
        //}

        StartCoroutine(GeneratePlatform());
        
    }

    IEnumerator GeneratePlatform()
    {

        while (true) {

            //startTime -= 0.4f;
            _generatorCounter++;
            //Debug.Log(_generatorCounter);

            //if (startTime <= fastestGenerateTime) {
                // The fastest
            //    startTime = fastestGenerateTime;
            //}
            yield return new WaitForSeconds(startTime);



            // Determines upto what platform type will be generated in random
            if (_generatorCounter > __displayPlatform5AfterCount) {
                _currentMaxRandom = 5;
            }
            else if (_generatorCounter > __displayPlatform4AfterCount)
            {
                _currentMaxRandom = 4;
            }
            else if (_generatorCounter > __displayPlatform3AfterCount)
            {
                _currentMaxRandom = 3;
            }
            else if (_generatorCounter > __displayPlatform2AfterCount)
            {
                _currentMaxRandom = 2;
            }
            else {
                _currentMaxRandom = 1;
            }


            InstantiatePlatforms();

            //timer = 0.0f;
            //nextTime = Random.Range(minSpawnTime, maxSpawnTime);
            //Invoke("GeneratePlatform", startTime-0.1f);
        }
    }


    void InstantiatePlatforms() {
        // generate randoms

        List<int> randoms = GenerateRandoms();
        Debug.Log("randoms: " + randoms);
        for (int i = 0; i < randoms.Count; i++)
        {
            Vector3 pos = new Vector3(Random.value, 1, 1);

            Debug.Log("Position " + pos + "  | rock Index: " + _randomRockIndex + "  | _currentMaxRandom: " + _currentMaxRandom + "  | startTime: " + startTime);
            pos = Camera.main.ViewportToWorldPoint(pos);

            GameObject newPlatform = Instantiate(platforms[randoms[i]], pos, Quaternion.identity) as GameObject;
            newPlatform.GetComponent<FallingObject>().fallSpeed += platformFallSpeedAdder;

        }
        _currentGenerateTries = 0;

    }

    List<int> GenerateRandoms() {
        List<int> randoms = new List<int>();

        int howManyRandoms = Random.Range(1, 3);
        randoms.Add(_GenerateRandom(randoms));
        for (int i = 1; i < howManyRandoms; i++) {
            Debug.Log("i:" + i);
            randoms.Add(_GenerateRandom(randoms));
        }
        return randoms;
    }

    int _GenerateRandom(List<int> previousRandoms)
    {
        Debug.Log("previous Randoms: " + previousRandoms);
        int randomNum = Random.Range(1, _currentMaxRandom);
        if (previousRandoms.Contains(randomNum) && _currentGenerateTries < _maxGenerateRetries)
        {
            _currentGenerateTries += 1;
            _GenerateRandom(previousRandoms);
        }
        return randomNum;
    }
}