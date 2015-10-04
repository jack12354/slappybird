using UnityEngine;
using System.Collections;

public class restartgame : MonoBehaviour {

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
            Bird.RESTART();
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
            Bird.RESTART();
            Debug.Log("Yay! A hand collided!");
        }
    }
}
