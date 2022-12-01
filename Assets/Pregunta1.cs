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

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3 ( posX,posY,0);
        Debug.Log(transform.position);
        if(transform.position.y >0)
            {
                float gravedad = 1;
                velY -= gravedad;
            }
        posX += velX * Time.deltaTime;
        posY  = Mathf.Max(posY+ velY *Time.deltaTime, 0);
        if(Input.GetKeyDown("space"))
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
