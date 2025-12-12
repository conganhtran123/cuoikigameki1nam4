using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private Vector3 moveDirection;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (moveDirection == Vector3.zero) return;
        transform.position += moveDirection * Time.deltaTime;

    }
    public void SetMoveDirection(Vector3 dir)
    {
        moveDirection = dir;
    }
}
