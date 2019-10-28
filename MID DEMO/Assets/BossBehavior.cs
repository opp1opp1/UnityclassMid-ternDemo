using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BossBehavior : MonoBehaviour
{
    public GameObject bossbullet;
    public float Health = 200f;
    public float bossspeed = 6f;
    public float shoottime = 0.7f;
    private float shoottimer;
    private int random;
    public float player2bulletdamage = 5f;
    public static float score =0f;
    private bool rage = false;
    public GameObject BossDestroyedSound;
    // Start is called before the first frame update
    void Start()
    {
        score = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        shoottimer -= Time.deltaTime;
        if (Health <= 0)
        {
            Instantiate(BossDestroyedSound, transform.position, transform.rotation);
            SceneManager.LoadScene("Start screen");
        }
        if (Health <= 100)
        {
            rage = true;
        }
        if (Health > 100)
        {
            rage = false;
        }
        if (shoottimer <= 0f && rage==false)
        {
            Instantiate(bossbullet, transform.position, transform.rotation);
            Instantiate(bossbullet, transform.position, transform.rotation * Quaternion.AngleAxis(25, Vector3.forward));
            Instantiate(bossbullet, transform.position, transform.rotation * Quaternion.AngleAxis(-25, Vector3.forward));
            shoottimer = shoottime;
        }
        else if (shoottimer <= 0f &&rage == true)
        {
            Instantiate(bossbullet, transform.position, transform.rotation);
            Instantiate(bossbullet, transform.position, transform.rotation * Quaternion.AngleAxis(25, Vector3.forward));
            Instantiate(bossbullet, transform.position, transform.rotation * Quaternion.AngleAxis(-25, Vector3.forward));
            Instantiate(bossbullet, transform.position, transform.rotation * Quaternion.AngleAxis(45, Vector3.forward));
            Instantiate(bossbullet, transform.position, transform.rotation * Quaternion.AngleAxis(-45, Vector3.forward));
            shoottimer = shoottime -0.1f;
        }
        random = Random.Range(-1, 2);

        transform.Translate(random * bossspeed * Time.deltaTime, 0, 0);

    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "player2_bullet")
        {
            Debug.Log(Health);
            Health -= player2bulletdamage;
            Destroy(other.gameObject);
        }
    }
}





