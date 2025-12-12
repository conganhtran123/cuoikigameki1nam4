using UnityEngine.UI;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected float enemySpeed = 2.0f;
    protected Player player;
    [SerializeField] protected float maxHP = 50f;
    protected float currentHP;
    [SerializeField] private Image hpBar;
    [SerializeField] protected float enterDamage = 10f;
    [SerializeField] protected float stayDamage = 1.0f;
    protected virtual void Start()
    {
        player = GameObject.FindObjectOfType<Player>();
        currentHP = maxHP;
        updateHPBar();
    }
    protected virtual void Update()
    {
        moveToPlayer();
    }

    protected void moveToPlayer()
    {
        if(player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position,player.transform.position, enemySpeed * Time.deltaTime);
            flipEnemy();
        }
    }
    protected void flipEnemy()
    {
        if (player != null)
        {
            transform.localScale = new Vector3(player.transform.position.x > transform.position.x ? -1: 1, 1, 1);
        } 
        
    }

    public virtual void takeDamage(float damage)
    {
        currentHP -= damage;
        currentHP = Mathf.Max(currentHP, 0);
        updateHPBar();
        if (currentHP <= 0)
        {
            Die();
        }
    }
    protected virtual void Die()
    {
        Destroy(gameObject);
    }

    protected void updateHPBar()
    {
        if (hpBar != null)
        {
            hpBar.fillAmount = currentHP / maxHP;
        }
    }
}
