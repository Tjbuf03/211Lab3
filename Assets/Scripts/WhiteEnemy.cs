using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteEnemy : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            Destroy(this.gameObject);
        }
    }

}
