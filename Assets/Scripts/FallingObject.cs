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

    public GameObject platform; // reference to the platform to move
    public float fallSpeed = 5f; // fall speed of the object
    
    // private variables

    Transform _transform;
  
    // Use this for initialization
    void Start()
    {
        _transform = platform.transform;
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
            Debug.Log("(FallingObject) invisible in screen, destroying");
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
