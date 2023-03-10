using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targets : MonoBehaviour
{
    public ParticleSystem explosion;
    public int scorePoint;
    private Rigidbody target;
    private GameObject gameManager;
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        target = GetComponent<Rigidbody>();
        target.AddForce(RandomForce(), ForceMode.Impulse);
        target.AddTorque(RandomTorque(), ForceMode.Impulse);
        transform.position = RandomPos();

    }

    void Update()
    {
        
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(12, 16);
    }

    Vector3 RandomTorque()
    {
        return new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10));
    }

    Vector3 RandomPos()
    {
       return new Vector3(Random.Range(-4, 4), -4);
    }
    private void OnMouseDown()
    {
        if (gameManager.GetComponent<GameManager>().isGameActive)
        {
            Destroy(gameObject);
            gameManager.GetComponent<GameManager>().UpdateScore(scorePoint);
            Instantiate(explosion,transform.position,explosion.transform.rotation);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!gameObject.CompareTag("Bad"))
        {
            gameManager.GetComponent<GameManager>().Gameover();
        }
        Destroy(gameObject);
    }
}
