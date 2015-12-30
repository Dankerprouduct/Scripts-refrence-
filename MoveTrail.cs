using UnityEngine;
using System.Collections;

public class MoveTrail : MonoBehaviour {

    public float moveSpeed = 0;

    void Start()
    {
        moveSpeed = -8f;
    }
	void Update () {
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
        Destroy(this.gameObject, 1);
    }
}
