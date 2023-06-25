using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AttackPlayer : MonoBehaviour
{
    private GameInput input;

    public GameObject attackRange;

    public GameObject attackEffect1;
    public GameObject attackEffect2;//攻击特效

    private Animator animator;
    private int Attack01AniID;
    private int Attack02AniID;

    private float playerAttackTime = 0.1f;

    static public int KillNumber;
    // Start is called before the first frame update
    void Start()
    {
        KillNumber = 0;
        animator = GetComponent<Animator>();
        Attack01AniID = Animator.StringToHash("Attack01");
        Attack02AniID = Animator.StringToHash("Attack02");

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        
    }

    public void Attacking(bool bFiring)
    {
        int attacknum = -1;
        playerAttackTime -= Time.deltaTime;
        if (playerAttackTime < 0)
        {
            attacknum=Random.Range(0, 2);
        }
        switch (attacknum)
        {
            case -1:
                break;
            case 0:
                animator.SetTrigger(Attack01AniID);
                playerAttackTime = 0.1f;
                break;
            case 1:
                animator.SetTrigger(Attack02AniID);
                playerAttackTime = 0.1f;
                break;
        }
 
    }

    //Animation Event
    public void SetAttacktrue()
    {
        attackRange.SetActive(true);
        
    }
    public void SetAttackfalse()
    {
        attackRange.SetActive(false);
    }
    public void SetAttackEffect1()
    {
        //characterStats.TakeDamage(characterStats);//扣除对应攻击对象的血量
        //GameObject.Instantiate(attackEffect1).transform.position = attackRange.transform.position;

    }
    public void SetAttackEffect2()
    {
        
        //characterStats.TakeDoubleDamage(characterStats);//扣除对应攻击对象的血量
        //GameObject.Instantiate(attackEffect2).transform.position = attackRange.transform.position;

    }

    public void EnterGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
    
}
