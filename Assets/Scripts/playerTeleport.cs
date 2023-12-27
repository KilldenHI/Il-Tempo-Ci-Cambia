using UnityEngine;

public class playerTeleport : MonoBehaviour
{
     private Transform player;
    private Rigidbody _rb;
    [SerializeField] private Transform _camera;
    [SerializeField] private int teleport;
    [SerializeField] private float telepotrCooldown = 0.3f;
    private bool teleportCheck = true;

    private void Start()
    {
        player = GetComponent<Transform>();
        _rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        teleportVoid();

    }

    private void teleportVoid()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            if (teleportCheck)
            {
                teleportCheck = false;
                if (player.position.z < -50)
                {
                    TeleportToPast();
                }
                else if (player.position.z > -50)
                {
                    TeleportToPresent();
                }
                Invoke(nameof(ResertTeleport), telepotrCooldown);
            }

        }
    }


    void TeleportToPresent()
    {
        Vector3 newPosition = player.position;
        newPosition.z -= teleport;
        _rb.MovePosition(newPosition);
        //player.position = newPosition;
        Vector3 newPositionC = _camera.transform.position;
        newPositionC.z -= teleport;
        _camera.transform.position = newPositionC;
    }
    void TeleportToPast()
    {
        Vector3 newPosition = player.position;
        newPosition.z += teleport;
        _rb.MovePosition(newPosition);
        //player.position = newPosition;
        Vector3 newPositionC = _camera.transform.position;
        newPositionC.z += teleport;
        _camera.transform.position = newPositionC;
    }
    private void ResertTeleport()
    {
        teleportCheck = true;
    }
}
