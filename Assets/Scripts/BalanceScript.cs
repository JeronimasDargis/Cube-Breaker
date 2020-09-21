using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BalanceScript : MonoBehaviour

{

    [SerializeField] TextMeshProUGUI balancetext;
    [SerializeField] TextMeshProUGUI velocityPrice;
    [SerializeField] TextMeshProUGUI velocityLevel;
    [SerializeField] TextMeshProUGUI ammunitionPrice;
    [SerializeField] TextMeshProUGUI ammunitionAmount;
    // Start is called before the first frame update
    void Start()
    {
        balancetext.text = "BALANCE:" + StaticControls.balance.ToString();
        velocityPrice.text = "PRICE: " + StaticControls.velocityPrice.ToString();
        ammunitionPrice.text = "PRICE: " + StaticControls.ammoPrice.ToString();
        ammunitionAmount.text = (StaticControls.extraAmmo + 3).ToString();
        velocityLevel.text = (StaticControls.yVelocity - 15f).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        velocityPrice.text = "PRICE: " + StaticControls.velocityPrice.ToString();
        ammunitionPrice.text = "PRICE: " + StaticControls.ammoPrice.ToString();
        balancetext.text = "BALANCE:" + StaticControls.balance.ToString();
        ammunitionAmount.text = (StaticControls.extraAmmo + 3).ToString();
        velocityLevel.text = (StaticControls.yVelocity - 15f).ToString();

    }
}