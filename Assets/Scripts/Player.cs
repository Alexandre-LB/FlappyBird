using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool start = false;
    private Rigidbody2D rb2D;
    private float thrust = 7.0f;

    private void Start()
    {
        rb2D = gameObject.AddComponent<Rigidbody2D>();
        rb2D.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
    }

    private void Update()
    {
        GameManager.Instance.ChangeState(GameManager.GameState.Menu);

        if (GameManager.Instance.Alive && start)
        {
            GameManager.Instance.ChangeState(GameManager.GameState.Game);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            start = true;
            rb2D.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

            if (GameManager.Instance.Alive)
            {
                rb2D.velocity = new Vector2(0.0f, thrust);
            }
        }        
    }
}
