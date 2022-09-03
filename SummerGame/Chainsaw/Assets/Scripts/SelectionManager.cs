using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] private Material highlightMaterial;
    [SerializeField] private string selectableTag = "Selectable";
    [SerializeField] private string readableTag = "Readable";
    [SerializeField] private Material defoultMaterial;
    public float rayDistance = 1f;
    
    public GameObject[] passSymbols = new GameObject[5];
    private int symbolNamber = 0;
    private bool power = false;
    private bool saw = false;
    
    public GameObject passNote;
    public GameObject tom1;
    public GameObject tom2;
    public GameObject tom3;
    public GameObject tom4;

    private string enteredPassword = "";
    public string password = "1234";
        
    private Transform _selection;

    public GameObject circularSaw;
    private Animator circularSawAnimator;

    public GameObject boxDoor;
    private Animator boxDoorAnimator;

    public GameObject paint;
    private Animator paintAnimator;        
    
    private ArrayList inventory = new ArrayList();

    public GameObject woodAndKey;
    public GameObject sawAndStick;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        circularSawAnimator = circularSaw.GetComponent<Animator>();
        paintAnimator = paint.GetComponent<Animator>();
        boxDoorAnimator = boxDoor.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (power == true && saw == true)
        {
            circularSawAnimator.Play("saw");            
        }
        if (_selection != null)
        {
            var selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.material = defoultMaterial;
            _selection = null;
        }
        
        var ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0.0f));
        RaycastHit hit;
       
        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            var selection = hit.transform;

            if (selection.CompareTag(readableTag))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
  
                if (selectionRenderer != null)
                {
                    defoultMaterial = selectionRenderer.material;
                    selectionRenderer.material = highlightMaterial;
                }

                if (Input.GetKeyDown(KeyCode.E))
                {
                    GameObject go = selection.transform.gameObject;
                    string name = go.name;

                    if (name.Equals("boxDoor"))
                    {
                        boxDoorAnimator.Play("boxDoor");
                    }

                    if (name.Equals("pen"))
                    {
                        for (int i = 0; i < inventory.Count; i++)
                        {
                            GameObject inGo = (GameObject) inventory[i];
                            string inName = inGo.name;
                            if (inName.Equals("Key"))//Конец игры
                            {                              
                                Application.Quit();
                                Debug.Log("Quest completed");
                            }
                        }
                    }

                    if (name.Equals("table"))
                    {
                        for (int i = 0; i < inventory.Count; i++)
                        {
                            GameObject inGo = (GameObject) inventory[i];
                            string inName = inGo.name;
                            if (inName.Equals("FullWood") && power == true && saw == true)
                            {
                                woodAndKey.SetActive(true); // Распил
                            }

                            if (inName.Equals("SawDisck"))
                            {                              
                                sawAndStick.SetActive(true);
                                saw = true;
                                
                            }
                        }
                    }
                    
                    if (name.Equals("Tom1"))
                    {
                        tom1.SetActive(true);
                        Debug.Log("read");
                    }
                    if (name.Equals("Tom2"))
                    {
                        tom2.SetActive(true);
                        Debug.Log("read");
                    }
                    if (name.Equals("Tom3"))
                    {
                        tom3.SetActive(true);
                        Debug.Log("read");
                    }
                    if (name.Equals("Tom4"))
                    {
                        tom4.SetActive(true);
                        Debug.Log("read");
                    }

                    if (name.Equals("PassNote")) // Записка
                    {
                        passNote.SetActive(true);
                        Debug.Log("read");
                    }
                    
                }
     
                _selection = selection;
            }
            
            
            if (selection.CompareTag(selectableTag))
            {
                
                var selectionRenderer = selection.GetComponent<Renderer>();
  
                if (selectionRenderer != null)
                {
                    defoultMaterial = selectionRenderer.material;
                    selectionRenderer.material = highlightMaterial;
                }

                if (Input.GetKeyDown(KeyCode.E))
                {
                    
                    GameObject go = selection.transform.gameObject;
                    string name = go.name;
                    char[] charName = name.ToCharArray();

                    if (name.Equals("Button"))// Кномпка на картине
                    {
                        paintAnimator.Play("paint");
                    }
                    
                    if (charName.Length == 1)
                    {
                        enteredPassword += name;
                        passSymbols[symbolNamber].SetActive(true);
                        symbolNamber++;
                        for (int i = 0; i < charName.Length; i++)
                        {
                            Debug.Log(charName[i].ToString());
                        }
                    }
                    else 
                    { // Добавление в инвентарь
                        inventory.Add(go);
                        Debug.Log(name + " added");
                        go.transform.position = new Vector3(1f, 10f, 1f);
//                        Destroy(go);
                    }

                    if (enteredPassword.Length == 4) // Проверка пароля на терминале
                    {
                        if (password.Equals(enteredPassword))
                        {
                            Debug.Log("Power"); //Питание на станок
                            power = true;
                            passSymbols[4].SetActive(true);
                            enteredPassword = "";
                            symbolNamber = 0;
                            for (int i = 0; i < 4; i++)
                            {
                                passSymbols[i].SetActive(false);
                            }       
                        }
                        else
                        {
                            enteredPassword = "";
                            symbolNamber = 0;
                            for (int i = 0; i < 4; i++)
                            {
                                passSymbols[i].SetActive(false);
                            }
                        }
                    }
                }

                _selection = selection;
            }

        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            passNote.SetActive(false);
            tom1.SetActive(false);
            tom2.SetActive(false);
            tom3.SetActive(false);
            tom4.SetActive(false);
        }
    }
}
