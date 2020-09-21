using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticControls : MonoBehaviour
{

    public static float yVelocity = 15f;
    public static int extraAmmo = 0;
    public static int balance = 0;
    // Start is called before the first frame update
    public static int velocityPrice = 10;
    public static int ammoPrice = 100;
    public void UpgradeVelocity()
    {

        if (balance > velocityPrice)
        {
            yVelocity = yVelocity + 1f;
            Debug.Log(yVelocity);
            balance = balance - velocityPrice;
            velocityPrice = velocityPrice + velocityPrice;
        }
        else
        {
            Debug.Log("not enough balance" + balance + velocityPrice);
        }

    }

    public void BuyMoreAmmo()
    {
        if (balance > ammoPrice)
        {
            extraAmmo++;

            balance = balance - ammoPrice;
            ammoPrice = ammoPrice + ammoPrice;
        }
        else
        {
            Debug.Log("not enough balance" + balance + ammoPrice);
        }
    }



    // Update is called once per frame
    void Update()
    {

    }
}
