using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : MonoBehaviour
{
    public bool explosions = false;
    public GameObject explosion;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        explosion.SetActive(false);
        explosions = false;

    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "planet" && !explosions)
        {
            explosion.SetActive(true);
            explosions = true;
            Invoke("restartGame", 7);

        }
    }
    void restartGame ()
    {
        explosions = false;
        explosion.SetActive(false);
        player.transform.position = Vector3.zero;
    }
}
