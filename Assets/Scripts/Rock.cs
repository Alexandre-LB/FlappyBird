using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public bool alive = true;
    public float Speed = 3f;

    void Update()
    {
        if (GameManager.Instance.Alive == false)
        {
            Speed = 0f;
        }

        transform.Translate(Vector2.left * Speed * Time.deltaTime);
        if (transform.position.magnitude > 12.0f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.Instance.ChangeState(GameManager.GameState.Death);
    }
}