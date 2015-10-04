using UnityEngine;
using System.Collections;
using System.Linq;

public class Bird : MonoBehaviour
{
    private static TextMesh GameoverText, ScoreText;
    Rigidbody rb;
    private static int passedPipes = 0;
    public static int PassedPipes
    {
        get
        {
            return passedPipes;
        }
        set
        {
            passedPipes = value;
            ScoreText.text = passedPipes.ToString();
        }
    }
    static bool gameover = false;
    private RigidbodyConstraints constraints;
    // Use this for initialization
    void Start()
    {
        if (GameoverText == null) GameoverText = GameObject.Find("GAMEOVER").GetComponent<TextMesh>();
        if (ScoreText == null) ScoreText = GameObject.Find("score").GetComponent<TextMesh>();
        GameoverText.text = "";
        rb = GetComponent<Rigidbody>();
        constraints = rb.constraints;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameover)
            transform.LookAt(transform.position + new Vector3(-5, 5.0f * rb.velocity.y, 0));
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("derp");
            rb.velocity = new Vector3(rb.velocity.x, 5.0f, rb.velocity.z);
        }

        if (gameover && Input.anyKeyDown && !Input.GetKeyDown(KeyCode.Space))
        {
            RESTART();
        }
    }

    public static void GAMEOVER()
    {
        GameoverText.gameObject.SetActive(true);
        GameoverText.text = "GAME OVER\nPASSED " + PassedPipes + " PIPES";
        ScoreText.gameObject.SetActive(false);
       // rb.constraints = RigidbodyConstraints.FreezeAll;
        foreach (var p in FindObjectsOfType<Pipe>())
        {
            p.Speed = 0;
        }
        foreach (var p in FindObjectsOfType<bonuspoints>())
        {
            p.Speed = 0;
        }
        FindObjectOfType<PipeFactory>().Stopped = true;
        gameover = true;
        Debug.Log("HIT!");
    }

    public static void RESTART()
    {
        //rb.constraints = constraints;
        FindObjectOfType<PipeFactory>().Stopped = false;
        FindObjectsOfType<Pipe>().ToList().ForEach(pipe => Destroy(pipe.gameObject));
        FindObjectsOfType<bonuspoints>().ToList().ForEach(bonus => Destroy(bonus.gameObject));
        PassedPipes = 0;
        GameoverText.gameObject.SetActive(false);
        gameover = false;
        ScoreText.gameObject.SetActive(true);
        //transform.position = new Vector3(0, 5, 0);
        PassedPipes = 0;
    }

    void OnCollisionEnter(Collision collision)
    {
       
        GAMEOVER();
        
    }
}
