using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float turnSpeed = 100f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, turnSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            //destroy the coin when it collides with an obstacle
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            //destroy the coin when it collides with a player
            Destroy(gameObject);
            //add score to the game manager
            GameManager.MyInstance.score += 1;
        }
    }
}
