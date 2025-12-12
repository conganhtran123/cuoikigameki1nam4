using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private float maxHP = 100f;
    private float currentHP;
    [SerializeField] private Image hpBar;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    private bool isShielded = false;

    [SerializeField] private Color colorShield;
    [SerializeField] private Color colorNormal;

    [SerializeField] private GameObject gameOver;
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        gameOver.SetActive(false);
        
        currentHP = maxHP;
        updateHPBar();
    }

    // Update is called once per frame
    void Update()
    {
        
        movePlayer();
        
    }
    public void movePlayer()
    {
        Vector2 playerInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector2 moveVelocity = playerInput.normalized * moveSpeed;
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
        
        if (playerInput != Vector2.zero)
        {
            animator.SetBool("isRun", true);
        }
        else
        {
            animator.SetBool("isRun", false);
        }
        if(playerInput.x > 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (playerInput.x < 0)
        {
            spriteRenderer.flipX = false;
        }
    }
    public void takeDamage(float damage)
    {
        if(isShielded == false)
        {
            isShielded = true;
            currentHP -= damage;
            currentHP = Mathf.Max(currentHP, 0);
            updateHPBar();
            if (currentHP <= 0)
            {
                Die();
            }
            StartCoroutine(Shield());
        }    
        
        
    }

    public void Heal(float healAmount)
    {
        if(currentHP < maxHP)
        {
            currentHP += healAmount;
            currentHP = Mathf.Min(currentHP, maxHP);
            updateHPBar();
        }
        
    }

    public IEnumerator Shield()
    {
        spriteRenderer.color = colorShield;
        yield return new WaitForSeconds(3);
        isShielded = false;
        spriteRenderer.color = colorNormal;
    }
    private void Die()
    {
        Destroy(gameObject);
        gameOver.SetActive(true);
    }

    private void updateHPBar()
    {
       if (hpBar != null)
        {
            hpBar.fillAmount = currentHP / maxHP;
        }
    }

}
