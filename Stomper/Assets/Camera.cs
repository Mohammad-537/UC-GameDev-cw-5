using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private Transform cameraTarget;
    [SerializeField] private Vector2 offset;
    [SerializeField] private float smoothTime = 0.03f;
    private Vector2 cameraVelocity = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {
        cameraTarget = GameObject.FindGameObjectWithTag("Player").transform;
        offset = transform.position - cameraTarget.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void LateUpdate()
    {
        Vector2 targetPosition = cameraTarget.position;

        transform.position = Vector2.SmoothDamp(transform.position, targetPosition, ref cameraVelocity, smoothTime);

    }
}
