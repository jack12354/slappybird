using UnityEngine;
using System.Collections;

public class cameralerp : MonoBehaviour
{

    private GameObject bird;
    // Use this for initialization
    void Start () {
        bird = GameObject.Find("BirdSphere");
    }
    
    // Update is called once per frame
    void Update ()
    {
        float y = Mathf.Lerp(transform.position.y, bird.transform.position.y + 1, 0.1f);
        Debug.Log(y);
        transform.position = new Vector3(transform.position.x, y, transform.position.z);
    }
}
