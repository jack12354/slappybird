using UnityEngine;
using System.Collections;

public class Pipe : MonoBehaviour
{

    public float Speed;
    private float lifetime, age;
    private Bird bird, bird2;
    private bool passed, passed2;

    // Use this for initialization
    void Start()
    {
        lifetime = 20;
        Speed /= 100.0f;
        age = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + new Vector3(Speed, 0.0f, 0.0f);
        age += Speed;
        

        if (!passed && bird != null && transform.position.x > bird.transform.position.x)
        {
            Bird.PassedPipes++;
            passed = true;
        }
        if (!passed2 && bird2 != null && transform.position.x > bird2.transform.position.x)
        {
            Bird.PassedPipes++;
            passed2 = true;
        }
        if (age > lifetime)
            GameObject.Destroy(gameObject);
    }

    public void SetBird(Bird b, Bird b2)
    {
        bird = b;
        bird2 = b2;
    }
}
