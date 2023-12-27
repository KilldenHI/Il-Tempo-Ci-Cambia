using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using UnityEngine.AI;

public class movePlayer : MonoBehaviour
{
    [SerializeField] private float _Speed = 10f;
    [SerializeField] private float playerHeight;
    [SerializeField] private LayerMask _graundMask;
    [SerializeField] private float graundDrag;
    [SerializeField] private float jampForce;
    [SerializeField] private float jumpCooldown;
    [SerializeField] private float airMultiplier;



    private float hInput;
    private float vInput;
    private Vector3 moveDirection;
    private Rigidbody _rb;
    private bool _isGrounded = false;
    private bool _isAvalibleToJump;

    private Animator anim;

    [SerializeField] private Transform _playerA;
    [SerializeField] private float _rotationSpeed = 5f;

    private Quaternion _Rotate;


    void Start()
    {
        _isAvalibleToJump = true;
        _rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
        _rb.freezeRotation = true;
    }
    private void InputFromDevice()
    {
        hInput = Input.GetAxisRaw("Horizontal");
        vInput = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded && _isAvalibleToJump)
        {
            anim.SetTrigger("jump");
            _isAvalibleToJump = false;
            Jump();
            Invoke(nameof(ReserJump), jumpCooldown);
        }
    }
    private void Update()
    {
        _isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, _graundMask);
        //Debug.Log(_isGrounded);
        InputFromDevice();
        ControlSpeed();
        if (_isGrounded)
        {
            _rb.drag = graundDrag;
            anim.SetBool("fall", false);
            anim.SetTrigger("landing");
        }
        else
        {
            _rb.drag = 0;
            
        }
    }
    void FixedUpdate()
    {
        MovementLogic();
    }

    private void MovementLogic()
    {
        moveDirection = new Vector3(hInput, 0.0f, vInput);       
        if (_isGrounded)
        {
            _rb.AddForce(moveDirection * _Speed, ForceMode.Force);
            if(moveDirection != Vector3.zero)
            {
                anim.SetBool("idle", false);
                anim.SetBool("run", true);
            }
            else
            {
                anim.SetBool("run", false);
                anim.SetBool("idle", true);
            }

        } else if (!_isGrounded)
        {
            _rb.AddForce(moveDirection * _Speed * airMultiplier, ForceMode.Force);
            anim.SetBool("fall", true);
        }


        if (Vector3.Angle(_playerA.forward, moveDirection) > 0)
        {
            Vector3 newDirection = Vector3.RotateTowards(_playerA.forward, moveDirection, _rotationSpeed, 0);
            newDirection.y = 0;
            _playerA.rotation = Quaternion.LookRotation(newDirection);
            _Rotate = _playerA.rotation;


        }
    }

    private void ControlSpeed()
    {
        Vector3 clampVelocity = new Vector3(_rb.velocity.x, 0f, _rb.velocity.z);
        if (!(clampVelocity.magnitude > _Speed))
        {
            return;
        }
        Vector3 velocityLimited = clampVelocity.normalized * _Speed;
        _rb.velocity = new Vector3(velocityLimited.x, _rb.velocity.y, velocityLimited.z);
    }

    private void Jump()
    {
        _rb.velocity = new Vector3(_rb.velocity.x, 0f, _rb.velocity.z);
        _rb.AddForce(transform.up * jampForce, ForceMode.Impulse);
        

    }

    private void ReserJump()
    {
        _isAvalibleToJump = true;
    }

}
