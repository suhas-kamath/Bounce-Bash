using UnityEngine;

public class Danger : MonoBehaviour {
    public float rotationSpeed = 90f;

    void Update () {
        transform.Rotate (0, 0, rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D (Collider2D other) {
        if (other.CompareTag ("PlayerTag")) {
            GameManager.Instance.GameOver ();
            Destroy (gameObject);
        } else if (other.CompareTag ("ColliderLeft")) {
            Destroy (gameObject);
        }
    }

}