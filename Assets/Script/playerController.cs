using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float horizontalSpeed = 5f;
    private Rigidbody2D rb;
    private float moveInput;

    void Start () {
        rb = GetComponent<Rigidbody2D> ();
    }

    void Update () {
        moveInput = Input.GetAxis ("Horizontal");
        Vector2 velocity = rb.velocity;
        velocity.x = moveInput * horizontalSpeed;
        rb.velocity = velocity;
    }

}