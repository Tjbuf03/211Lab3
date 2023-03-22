using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float playerSpeed;
    private Rigidbody2D rb;
    private Vector2 playerDirection;

    public ProjectileBehaviour RegularBulletPrefab;
    public ProjectileBehaviour RedBulletPrefab;
    public ProjectileBehaviour BlueBulletPrefab;
    public Transform LaunchOffset;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float directionX = Input.GetAxisRaw("Horizontal");
        float directionY = Input.GetAxisRaw("Vertical");

        playerDirection = new Vector2(directionX, directionY).normalized;

        if (Input.GetKeyDown(KeyCode.F))
        {
            Instantiate(RegularBulletPrefab, LaunchOffset.position, transform.rotation);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Instantiate(RedBulletPrefab, LaunchOffset.position, transform.rotation);
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            Instantiate(BlueBulletPrefab, LaunchOffset.position, transform.rotation);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(playerDirection.x * playerSpeed, playerDirection.y * playerSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "End")
        {
            SceneManager.LoadScene("End");
        }
    }
}

