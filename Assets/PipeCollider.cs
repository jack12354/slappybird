using UnityEngine;
using System.Collections;

public class PipeCollider : MonoBehaviour {

    // Use this for initialization
    void Start () {
    
    }
    
    // Update is called once per frame
    void Update () {
    
    }


    void OnCollisionEnter(Collision collision)
    {
         //       if (IsHand(collision.collider))
        {
            Debug.Log("Yay! A hand collided!");
            Bird.GAMEOVER();
        }
    }

    private bool IsHand(Collider other)
    {
        if (other.transform.parent && other.transform.parent.parent && other.transform.parent.parent.GetComponent<HandModel>())
            return true;
        else
            return false;
    }

    void OnTriggerEnter(Collider other)
    {
        //      if (IsHand(other))
        {
            Bird.GAMEOVER();
            Debug.Log("Yay! A hand collided!");
        }
    }
}
