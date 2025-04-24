using UnityEngine;

public class CameraFollower : MonoBehaviour {
    public Transform player;

    void LateUpdate () {
        if (player != null) {
            float moveInput = Input.GetAxis ("Horizontal");
            Vector3 pos = transform.position;
            pos.x = Mathf.Max (pos.x, player.position.x);
            transform.position = pos;
        }
    }
}