using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pregunta1 : MonoBehaviour
{
    float posX;
    float posY;
    float velX;
    float velY;
    void Start()
    {
        posX = transform.position.x;
        posY = transform.position.y;
    }

    void Update()
    {
        transform.position = new Vector3 ( posX,posY,0);
        Debug.Log(transform.position);
        if(transform.position.y >0)
            {
                float gravedad = 20;
                velY -= gravedad;
            }
        posX += velX * Time.deltaTime;
        posY  = Mathf.Max(posY+ velY *Time.deltaTime, 0);
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Disparar();
            Debug.Log(velX);
            Debug.Log(velY);
        }
        
        
        
    }

    void Disparar()
    {
        velX += 15 * Mathf.Cos(Mathf.Deg2Rad * 60);
        velY += 15 * Mathf.Sin(Mathf.Deg2Rad * 60);
    }
}
