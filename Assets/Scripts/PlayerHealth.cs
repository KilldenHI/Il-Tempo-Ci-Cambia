using UnityEngine.UI;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 3;
    [SerializeField] private int currentHealth;
    [SerializeField] private GameObject diePanel;
    [SerializeField] float delayBeforeShowingMenu = 3f;
    [SerializeField] private Image healrhbar;

    private movePlayer _player;
    private Collider _collider;
    private Rigidbody _rb;
    private Animator anim;
    private bool _die = true;

    private float bar = 1;

    void Start()
    {
        currentHealth = maxHealth;
        anim = GetComponentInChildren<Animator>();
        _player = GetComponent<movePlayer>();
        _rb = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        bar = bar - 0.25f;
        healrhbar.fillAmount = bar;
        Debug.Log(bar);
        if (currentHealth <= 0 & _die)
        {
            Die(); 
        }
    }

    void Die()
    {
        anim.SetTrigger("die");
        Debug.Log("Player died");
        _player.enabled = false;
        _rb.useGravity = false;
        _collider.enabled = false;
        Invoke("ShowDeathMenu", delayBeforeShowingMenu);
        _die = false;
    }
    void ShowDeathMenu()
    {
        diePanel.SetActive(true);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(1);
        }
    }

}
