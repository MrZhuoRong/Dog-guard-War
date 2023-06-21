using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerGetHit : MonoBehaviour
{
    private Movement movement;
    private AttackPlayer attacker;
    private GameInput input;
    private Animator animator;
    public CharacterStats PlayercharacterStats;

    public PlayerHealthUI playerHealthUI;

    private float playerAttackTime = 0.5f;
    private float playEnterWaterTime = 1f;//进入水池受伤

    public float setInvincibleTime = 1f;

    private float invincibleTime;//无敌时间

    private bool playerIsDie = false;
    
    // Start is called before the first frame update
    void Awake()
    {
        PlayercharacterStats = GetComponent<CharacterStats>();//获得人物设定的属性
        PlayercharacterStats.CurrentHealth = PlayercharacterStats.MaxHealth;
        invincibleTime = setInvincibleTime;
        movement = GetComponent<Movement>();
        input = GetComponent<GameInput>();
        attacker = GetComponent<AttackPlayer>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        if (!playerIsDie)
        {
            input.moveAction += Move2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerIsDie)
        {
            UpdateTime();
            if (playerAttackTime < 0)
            {
                input.AttackAction += attacker.Attacking;
                playerAttackTime = 0.5f;
            }
        }
        PlayerHealthUI.currenthealth = PlayercharacterStats.CurrentHealth;
        PlayerHealthUI.maxhealth = PlayercharacterStats.MaxHealth;
        FallInHell();
    }

    private void UpdateTime()
    {
        invincibleTime -= Time.deltaTime;
        playEnterWaterTime -= Time.deltaTime;
        playerAttackTime -= Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!playerIsDie)
        {
            if(invincibleTime<=0)
            {
                if (other.tag == "EnemyAttack")
                {
                    Debug.Log(other.tag);
                    PlayercharacterStats.GetDamage(PlayercharacterStats);//扣除对应攻击对象的血量
                    if (PlayercharacterStats.CurrentHealth == 0)
                    {
                        playerIsDie = true;
                        animator.SetBool("IsDie", playerIsDie);
                    }
                    invincibleTime = setInvincibleTime;
                }
                else if (other.tag == "BossAttack")
                {
                    Debug.Log(other.tag);
                    PlayercharacterStats.GetDoubleDamage(PlayercharacterStats);//扣除对应攻击对象的血量
                    if (PlayercharacterStats.CurrentHealth == 0)
                    {
                        playerIsDie = true;
                        animator.SetBool("IsDie", playerIsDie);
                    }
                    invincibleTime = setInvincibleTime;
                }
                else if (other.tag == "SpearD")
                {
                    Debug.Log(other.tag);
                    PlayercharacterStats.GetDoubleDamage(PlayercharacterStats);//扣除对应攻击对象的血量
                    if (PlayercharacterStats.CurrentHealth == 0)
                    {
                        playerIsDie = true;
                        animator.SetBool("IsDie", playerIsDie);
                    }
                    invincibleTime = setInvincibleTime;
                }
            }
        }
    }
    private void OnTriggerStay(Collider other)//陷阱
    {
        if (!playerIsDie) {
            
            if(playEnterWaterTime <= 0)
            {
                if (other.tag == "Water")
                {
                    PlayercharacterStats.GetDamage(PlayercharacterStats);//扣除对应攻击对象的血量
                    if (PlayercharacterStats.CurrentHealth == 0)
                    {
                        playerIsDie = true;
                        animator.SetBool("IsDie", playerIsDie);
                    }
                }
                playEnterWaterTime = 1;
            }
        }
    }

    public void Move2(Vector2 moveInput)
    {
        movement.RightValue = moveInput.x;
        movement.ForwardValue = moveInput.y;
    }

    public void FallInHell()
    {
        if (!playerIsDie)
        {
            if (this.transform.position.y <= -15)
            {
                PlayercharacterStats.CurrentHealth = 0;
                if (PlayercharacterStats.CurrentHealth == 0)
                {
                    playerIsDie = true;
                    animator.SetBool("IsDie", playerIsDie);
                }
            }
        }
    }
}
