using UnityEngine;

public class PlayerScoot : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private bool _smoothMovement;

    private void Update ()
    {
        if(_smoothMovement)
        {
            RunSmoothMovement();
        }
        else
        {
            RunSteppedMovement();
        }
        
    }

    private void RunSmoothMovement ()
    {
        Vector3 direction = Vector3.zero;

        if(Input.GetKey(KeyCode.W))
        {
            direction += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector3.left;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector3.back;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector3.right;
        }

        transform.position += direction * _speed * Time.deltaTime;
    }

    private void RunSteppedMovement ()
    {
        Vector3 direction = Vector3.zero;

        if(Input.GetKeyDown(KeyCode.W))
        {
            direction += Vector3.forward;
        } else if (Input.GetKeyDown(KeyCode.A))
        {
            direction += Vector3.left;
        } else if (Input.GetKeyDown(KeyCode.S))
        {
            direction += Vector3.back;
        } else if (Input.GetKeyDown(KeyCode.D))
        {
            direction += Vector3.right;
        }

        transform.position += direction;
    }
}