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

    private void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Obstacle"))
    {
        Destroy(gameObject);
    }

    if (other.CompareTag("Player"))
    {
        Destroy(gameObject);
        GameManager.MyInstance.score += 1;
    }
}

}
