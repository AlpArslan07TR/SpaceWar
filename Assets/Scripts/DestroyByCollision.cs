using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByCollision : MonoBehaviour
{
    public GameObject explosion;
    public GameObject player_explosion;
    private GameController gameController;

    private void Start()
    {
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Boundary")
        {
            return;
        }

        if (other.tag == "Player")
        {
            Instantiate(player_explosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
        }
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(other.gameObject);
        Destroy(gameObject);
        gameController.UpdateScore();

    }
}
