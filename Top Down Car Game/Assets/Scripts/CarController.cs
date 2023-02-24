using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _boostAmount = 20f;
    [SerializeField] private float _sideMoveSpeed = 5f;
    [SerializeField] private float _xRange = 4f;
    [SerializeField] private bool _crossedFinishLine = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(LevelManager.Instance.StartGame())
        {
            CarMovement();
        }
    }

    private void CarMovement()
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

    public bool CrossedFinishLine()
    {
        return _crossedFinishLine;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Obstacle"))    
        {
            LevelManager.Instance.GameOver();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Start Line"))
        {
            LevelManager.Instance.StartGasMeter();
        }

        if(other.gameObject.CompareTag("Finish Line"))
        {
            _crossedFinishLine = true;
            LevelManager.Instance.YouWon();
        }
        if(other.gameObject.CompareTag("Boost"))
        {
            StartCoroutine(SetBoost());
        }
    }

    IEnumerator SetBoost()
    {
        float currentSpeed = _moveSpeed;
        _moveSpeed = currentSpeed + _boostAmount;
        yield return new WaitForSeconds(3f);
        _moveSpeed = currentSpeed;
    }
}