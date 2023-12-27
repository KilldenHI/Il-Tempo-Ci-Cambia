using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.PlayerLoop;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rigidbody))]
public class player : MonoBehaviour
{
    [SerializeField] private float _Speed = 10f;
    [SerializeField] private float JumpForce = 800f;
    [SerializeField] private float _rotationSpeed = 5f;
    [SerializeField] private Transform _playerA;
    private Animator anim;

    private bool isRunning;

    private bool _isGrounded;
    private Rigidbody _rb;
    private Quaternion _Rotate;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        //anim = GetComponentInChildren<Animator>();
    }

    void FixedUpdate()
    {
        MovementLogic();
        JumpLogic();
    }

    void Update()
    {
        if (_isGrounded)
        {
            //anim.SetTrigger("landing");

        }
        else
        {
            //anim.SetBool("fall", true);

        }
    }

    private void MovementLogic()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        float moveVertical = Input.GetAxis("Vertical");

        if (moveHorizontal != 0 || moveVertical !=0)
        {
            if (_isGrounded)
            {
                //anim.SetBool("run", true);
                //anim.SetBool("idle", false);
            }
            Vector3 velocity = new Vector3(moveHorizontal, 0.0f, moveVertical) * _Speed;
            velocity.y = _rb.velocity.y;
            Vector3 worldVelocity = transform.TransformVector(velocity);
            _rb.velocity = worldVelocity;

            if (Vector3.Angle(_playerA.forward, velocity) > 0)
            {
                Vector3 newDirection = Vector3.RotateTowards(_playerA.forward, velocity, _rotationSpeed, 0);
                newDirection.y = 0;
                _playerA.rotation = Quaternion.LookRotation(newDirection);
                _Rotate = _playerA.rotation;

            }
            else _playerA.rotation = _Rotate;
        }
        else
        {
            if (_isGrounded)
            {
               // anim.SetBool("idle", true);
                //anim.SetBool("run", false);
            }

        }


    }

    private void JumpLogic()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_isGrounded)
            {
                _rb.AddForce(Vector3.up * JumpForce);
                //anim.SetTrigger("jump");
                //_isGrounded = false;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == ("Ground"))
        {
            _isGrounded = true;
        }
    }


}
