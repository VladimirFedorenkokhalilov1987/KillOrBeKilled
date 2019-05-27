using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectController : MonoBehaviour
{
  
       public string url = "https://www.google.com.ua";

       public GameObject Connection;
       public GameObject ConnectionGood;
       public GameObject ConnectionBad;
       public GameObject MainMenu;

       private bool connected = false;
       private bool connectedGood = false;
       private bool connectedBad = false;



       private void Start()
       {
           StartCoroutine(ConnectToServer());
       }

       private void FixedUpdate()
       {
           if (connectedBad)
           {
               Debug.Log("0");
               ConnectionBad.SetActive(true);
           }
           if (connectedGood)
           {
               Debug.Log("1");
               StopCoroutine(ConnectToServer());
               StartCoroutine(WaitAnimation());
           }
       }

       IEnumerator ConnectToServer()
       {
           using (WWW www = new WWW(url))
           {
               yield return www;
               if (www.error == null)
               {
                   connectedGood = true;
                   connected = true;
               } 
                   connectedBad = true;
                   connected = false;
               
           }

       }

       IEnumerator WaitAnimation()
       {
           
           if (!connected)
           {
               connectedBad = true;
               connectedGood = false;
           }
           else if (connected)
           {
               connectedBad = false;
               connectedGood = true;
           }
           yield return  new WaitForSeconds(3);
               connectedBad = false;
               
               Connection.SetActive(false);
               ConnectionBad.SetActive(false);
               ConnectionGood.SetActive(true);

               yield return  new WaitForSeconds(3);
               ConnectionGood.SetActive(false);
               MainMenu.SetActive(true);
               this.GetComponent<ConnectController>().enabled = false;
       }



}
