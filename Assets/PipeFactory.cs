using UnityEngine;
using System.Collections;
using System.Linq;

public class PipeFactory : MonoBehaviour
{
    GameObject Pipe, bonus;
    public float Speed;
    public float last, lastbonus;
    private Bird theword, theword2;
    private bool stopped;
    public bool Stopped
    {
        get
        {
            return stopped;
        }
        set
        {
            stopped = value;
            last = lastbonus = Time.time;
            lastbonus += 3.5f*Speed;
        }
    }

    // Use this for initialization
    void Start()
    {

        Pipe = Resources.Load<GameObject>("Pipebase");
        bonus = Resources.Load<GameObject>("Bonus");
        Speed /= 1000;
        last = lastbonus = Time.time;
        lastbonus += 3.5f*Speed;
    }

    // Update is called once per frame
    void Update()
    {
        var birds = GameObject.FindObjectsOfType<Bird>();
        if(birds.Count() > 0)
            theword = birds[0];
        else
            theword = null;
        if (birds.Count() > 1)
            theword2 = birds[1];//GameObject.Find("palm").GetComponent<Bird>();
        else
            theword2 = null;

        if (last + Speed < Time.time && !Stopped)
        {
            last = Time.time;
            Pipe pipe =((GameObject) Instantiate(Pipe, transform.position + new Vector3(0, Random.Range(-1.0f, 1.0f), 0), transform.rotation)).GetComponent<Pipe>();
            pipe.SetBird(theword, theword2);
        }
        if (lastbonus + (Speed*2.0f) < Time.time && !Stopped)
        {
            lastbonus = Time.time;
            bonuspoints pipe = ((GameObject)Instantiate(bonus, transform.position + new Vector3(0, Random.Range(3.0f, 4.0f) * (Random.Range(0, 100) < 50 ? 1 : -1), 0), transform.rotation)).GetComponent<bonuspoints>();
            pipe.SetBird(theword, theword2);
        }


    }
}
