using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventController : MonoBehaviour
{

    public GameObject WinMenu;
    // Start is called before the first frame update
    void Start()
    {
        if (this.gameObject.name == "triggerDoor")
        {
            WinMenu = GameObject.Find("WinMenu");
            WinMenu.SetActive(false);   
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            WinMenu.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
        }   
    }
}
