using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public Transform followTransform;

    void FixedUpdate() {
        var position = followTransform.position;
        this.transform.position = new Vector3(
            position.x, position.y, -1);
    }
}