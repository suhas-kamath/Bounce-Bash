using UnityEngine;

public class Coin : MonoBehaviour {
    public int coinValue = 1;

    private void OnTriggerEnter2D (Collider2D other) {
        if (other.CompareTag ("PlayerTag")) {
            UiManager.Instance.AddCoins (coinValue);
            Destroy (gameObject);
        } else if (other.CompareTag ("ColliderLeft")) {
            Destroy (gameObject);
        }
    }

}