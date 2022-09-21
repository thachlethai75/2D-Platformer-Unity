using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float folowSpeed = 2f;
    [SerializeField] private float yOffset = 1f;
    [SerializeField] private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3(player.position.x, player.position.y + yOffset, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, folowSpeed * Time.deltaTime);
    }
}
