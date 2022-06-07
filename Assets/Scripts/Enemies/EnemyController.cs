using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private int lifePoints = 100;
    [SerializeField] private int damage = 20;

    PlayerController mainCharacter;

    Animator _animator; 

    void Start()
    {
        mainCharacter = GameObject.Find("MainCharacter").GetComponent<PlayerController>();
        _animator = GetComponent<Animator>(); 
    }

    public void attack()
    {
        if (!_animator.GetBool("isDead"))
        {
            mainCharacter.takeDamage(damage);
        }
    }

    public void takeDamage(int damage)
    {
        lifePoints -= damage;
        if (lifePoints <= 0)
        {
            die(); 
        }
    }

    private void die()
    {
        if (!_animator.GetBool("isDead"))
        {
            _animator.SetBool("isDead", true); 
            //Destroy(this.gameObject); 
        }
       
    }
}
