using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermove : MonoBehaviour
{
    public bool getcontroll = false;
    public float playerspeed = 5f;
    public float hitdamage = 20;
    private GameObject boss;
    public GameObject healboss;
    private float random;
    public GameObject player2bullet;
    public float attackspeed = 2.0f;
    private float attackspeedtimer;
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.tag == "player2")
        {
            attackspeedtimer = attackspeed;
        }
    }
    private void Awake()
    {
        boss = GameObject.Find("Boss");
    }
    // Update is called once per frame
    void Update()
    {
       
            attackspeedtimer -= Time.deltaTime;
        

        if (getcontroll == false &&gameObject.tag != "Player2")
        {
            transform.position = Vector3.MoveTowards(transform.position, boss.transform.position, playerspeed*Time.deltaTime);
        }
        if (gameObject.tag == "Player2" && getcontroll !=true)
        {
           
            if (attackspeedtimer <= 0)
            {
                Instantiate(player2bullet, transform.position , transform.rotation);
                attackspeedtimer = attackspeed;
            }
            
        }
        if (getcontroll == true)
        {
            if (Input.GetKey("w"))
            {
                transform.Translate(0, playerspeed * Time.deltaTime, 0);
            }
            if (Input.GetKey("s"))
            {
                transform.Translate(0, -1*playerspeed * Time.deltaTime, 0);
            }
            if (Input.GetKey("a"))
            {
                transform.Translate( -1 * playerspeed * Time.deltaTime, 0,0);
            }
            if (Input.GetKey("d"))
            {
                transform.Translate( playerspeed * Time.deltaTime, 0, 0);
            }
            if (gameObject.tag == "Player2")
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    if (attackspeedtimer <= 0)
                    {
                        Instantiate(player2bullet, transform.position, transform.rotation * Quaternion.AngleAxis(10, Vector3.forward));
                        Instantiate(player2bullet, transform.position, transform.rotation * Quaternion.AngleAxis(-10, Vector3.forward));
                        Instantiate(player2bullet, transform.position, transform.rotation);
                        attackspeedtimer = attackspeed;
                    }
                }
            }

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if ((gameObject.tag == "Player1")|| (gameObject.tag == "Player2"))
        {
            if (other.gameObject.tag == "Boss")
            {
                other.GetComponent<BossBehavior>().Health -= hitdamage;
                
                Destroy(gameObject);
            }

        }
        if (other.gameObject.tag == "bullet")
        {
            random = Random.Range(0, 100);
            if (boss.GetComponent<BossBehavior>().Health > 100)
            {
                if (random >= 90)
                {
                    Instantiate(healboss, transform.position+new Vector3(0f,-5f,0f), transform.rotation);
                }
            }
            if (boss.GetComponent<BossBehavior>().Health <= 100)
            {
                if (random >= 80)
                {
                    Instantiate(healboss, transform.position + new Vector3(0f, -5f, 0f), transform.rotation);
                }
            }
            Destroy(other);
            Destroy(gameObject);
            BossBehavior.score += 1;
        }
    }
    private void OnMouseDown()
    {
        getcontroll = true;
    }
}
