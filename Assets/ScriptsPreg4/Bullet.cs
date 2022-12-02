using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D mRb;
    
    private void Awake() 
    {
        mRb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        mRb.velocity = Vector2.right*2;
        StartCoroutine(DestroyBullet());
    }
    IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(3f);
        this.gameObject.SetActive(false);
    }
}
