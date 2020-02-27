using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin2 : MonoBehaviour
{
    public float spinSpeed = 100f;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.Rotate(0f, 0f, Time.deltaTime * this.spinSpeed);

    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("coin col");

        if (other.tag == "Player")
        {
            other.GetComponent<PlayerControllerThatLevelsUp>().GainXP(10);
            Destroy(this.gameObject);
        }

    }
}
