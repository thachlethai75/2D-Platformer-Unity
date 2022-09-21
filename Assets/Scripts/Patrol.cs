using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float distance;
    [SerializeField] private Transform groundDetection;
    private bool isMovingRight = true;

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        if(groundInfo.collider == false)
        {
            if(isMovingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                isMovingRight = false;
            }else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                isMovingRight = true;
            }
        }
    }
}
