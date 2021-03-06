using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMo : MonoBehaviour
{
    public bool SlowMoActive;
    public float SlowMoTime;
    public GameObject Number1;
    public GameObject Number2;
    public GameObject Number3;
    public GameObject Number4;
    public GameObject Number5;
    public GameObject Slow;
    public GameObject Fast;
    //public bool IsPlayer = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SlowMoStart()
    {

        Slow.active = true;
            FindObjectOfType<PlayerMove>().SlowBoi();
            Invoke("SlowMoEnd", SlowMoTime);
            Debug.Log("Recieved request time frozen");
        Text1();
        //FindObjectOfType<PlayerMove>().SlowMoNo();


    }

    public void SlowMoEnd()
    {

        Slow.active = false;
            FindObjectOfType<PlayerMove>().NormSpeedBoi();
            SlowMoActive = false;
            Debug.Log("Time returned to normal");
        
    }

    public void SPEEEEEDStart()
    {
        Fast.active = true;
        Text1();
        FindObjectOfType<PlayerMove>().FastBoi();
        Invoke("SPEEEEEDEnd", SlowMoTime);
        Invoke("SlowMoStart", SlowMoTime);
    }

    public void SPEEEEEDEnd()
    {
        Fast.active = false;
        FindObjectOfType<PlayerMove>().NormSpeedBoi();
    }

    public void Text1()
    {
        Number1.active = true;
        Invoke("Text2", 1);
    }

    public void Text2()
    {
        Number2.active = true;
        Number1.active = false;
        Invoke("Text3", 1);
    }

    public void Text3()
    {
        Number3.active = true;
        Number2.active = false;
        Invoke("Text4", 1);
    }

    public void Text4()
    {
        Number4.active = true;
        Number3.active = false;
        Invoke("Text5", 1);
    }

    public void Text5()
    {
        Number5.active = true;
        Number4.active = false;
        Invoke("ClearText5", 1);
    }

    public void ClearText5()
    {
        Number5.active = false;
    }
}
