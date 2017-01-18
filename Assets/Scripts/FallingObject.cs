/**
 * Attach to an object to make it fall
 * @Author: Jhesed Tacadena
 * @Date: 2017-01-17
 * 
 * */

using UnityEngine;
using System.Collections;

public class FallingObject : MonoBehaviour
{

    public GameObject mainCamera; // the main camera of the game
    public GameObject platform; // reference to the platform to move
    public float fallSpeed = 5f; // fall speed of the object
    public int maxPlatformWidth = 4;  // How wide the platform can be?

    // private variables

    Transform _transform;
    
    // Use this for initialization
    void Start()
    {
        _transform = platform.transform;

        // Randomize platform width
        _transform.localScale = new Vector3(Random.Range(0, maxPlatformWidth), 1, 1);

        /*
        float height = Camera.main.orthographicSize * 2.0f;
        float width = height * Screen.width / Screen.height;
        //float xCoord = Random.Range(0.0f, width);
        //float xCoord = Random.Range(0.0f, Screen.width)/100;
        float xCoord = Random.Range(0.0f, Camera.main.orthographicSize);
        int isNegative = Random.Range(0, 1);
        if (isNegative == 1) {
            xCoord *= 1;
        }
        _transform.position = Camera.main.ViewportToWorldPoint(new Vector2(xCoord, 1.0f));
        */
        /*
        Debug.Log("random: " + xCoord);
        _transform.position = Camera.main.ViewportToWorldPoint(new Vector2(xCoord, 1));
        */
        // Instantiate to random position
        /*
        _transform.position = new Vector3(
            _transform.position.y - 5 * Random.value)), // Random y position 
            5,  // fall from top 
            _transform.position.z);
        */
        //Camera camera = Camera.main;
        //_transform.position = camera.ViewportToWorldPoint(new Vector3(1, 1, camera.)); // Random y position, 1, camera.nearClipPlane));

        //Vector3 worldPoint = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 5));
        //_transform.position = worldPoint;


    }

    // game loop
    void Update()
    {
        if (IsVisibleToCamera(_transform))
        {
            // Make object fall if it is visible in the screen
            Movement();
        }
        else
        {
            // Destroy object for optimization
            Destroy(platform);
        }
    }

    void Movement()
    {
        platform.transform.position -= platform.transform.up * Time.deltaTime * fallSpeed;
    }

    public static bool IsVisibleToCamera(Transform transform)
    {
        // Taken from https://forum.unity3d.com/threads/how-do-i-use-renderer-isvisible.377388/
        Vector3 visTest = Camera.main.WorldToViewportPoint(transform.position);
        return (visTest.x >= 0 && visTest.y >= 0) && (visTest.x <= 1 && visTest.y <= 1) && visTest.z >= 0;
    }
}
