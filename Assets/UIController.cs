using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIController : MonoBehaviour
{
    public static UIController instance;
    public Slider healthSlider;
    public TextMeshProUGUI healthText;

    [Space(10)]
    [Header("Variable for pause menus")]
    public GameObject PauseMenu;
    public bool toggle = false;
    // Start is called before the first frame update
    void Start()
    {
         healthSlider = GameObject.Find("HealthBar").GetComponent<Slider>();
        healthText = GameObject.Find("number").GetComponent<TextMeshProUGUI>();

        PauseMenu = GameObject.Find("PauseMenu");
        PauseMenu.SetActive(false);
    }
    public void Awake()
    {
        instance = this;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showPause()
    {
        Cursor.lockState = CursorLockMode.Confined;
        PauseMenu.SetActive(true);
    }
    public void hidePause()
    {
        Cursor.lockState -= CursorLockMode.Locked;
        PauseMenu?.SetActive(false);   
    }
}
