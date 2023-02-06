using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _sideMoveSpeed = 5f;
    [SerializeField] private float _xRange = 4.4f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        transform.Translate(Vector3.up * _moveSpeed * Time.deltaTime);
        transform.Translate(Vector3.right * _sideMoveSpeed * horizontalInput * Time.deltaTime);

        if(transform.position.x > _xRange)
        {
            transform.position = new Vector3(_xRange, transform.position.y, transform.position.z);
        }

         if(transform.position.x < -_xRange)
        {
            transform.position = new Vector3(-_xRange, transform.position.y, transform.position.z);
        }
        
    }
}
