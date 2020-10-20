using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour {
    public Transform followTransform;

    void FixedUpdate() {
        var position = followTransform.position;
        this.transform.position = new Vector3(
            position.x, position.y+4, -1);
    }
}