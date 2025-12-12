using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : Enemy
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float speedDanThuong = 20f;
    [SerializeField] private float speedDanVongTron = 20f;
    [SerializeField] private GameObject miniEnemy;
    [SerializeField] private float skillCooldown = 2f;
    private float nextSkillTime = 0f;

    [SerializeField] private GameObject checkPoint;
    protected override void Update()
    {
        base.Update();
        if(Time.time >= nextSkillTime)
        {
            UseSkill();
        }
    }

    protected override void Die()
    {
        if (checkPoint != null)
        {
            Instantiate(checkPoint, transform.position, Quaternion.identity);
        }
        base.Die();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (player != null)
            {
                player.takeDamage(enterDamage);
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (player != null)
            {
                player.takeDamage(stayDamage);
            }
        }
    }

    private void banDanThuong()
    {
        if(player != null)
        { 
            
            Vector3 dir = (player.transform.position - firePoint.position);
            dir.Normalize();
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            EnemyBullet enemyBullet = bullet.AddComponent<EnemyBullet>();
            enemyBullet.SetMoveDirection(dir * speedDanThuong);
        }
    }

    private void banDanVongTron()
    {
        const int bulletCount = 20;
        float angleStep = 360f / bulletCount;
        for (int i=0; i < bulletCount;  i++)
        {
            float angle = i * angleStep;
            float dirX = Mathf.Cos(angle * Mathf.Deg2Rad);
            float dirY = Mathf.Sin(angle * Mathf.Deg2Rad);
            Vector3 dir = new Vector3(dirX, dirY, 0);
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            EnemyBullet enemyBullet = bullet.AddComponent<EnemyBullet>();
            enemyBullet.SetMoveDirection(dir * speedDanVongTron);
        }
        {
            
        }
    }


    private void sinhEnemy()
    {
        Instantiate(miniEnemy, transform.position, Quaternion.identity);
    }

    private void RandomSKill()
    {
        int rand = Random.Range(0, 3);
        switch (rand)
        {
            case 0:
                banDanThuong();
                break;
            case 1:
                banDanVongTron();
                break;
            case 2:
                sinhEnemy();
                break;
        }
    }
    private void UseSkill()
    {
        nextSkillTime = Time.time + skillCooldown;
        RandomSKill();
    }
}
