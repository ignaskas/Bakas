using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolTip : MonoBehaviour
{
    [SerializeField]
    private Camera uiCamera;
    
    private bool _toolTipToggle;
    private ItemButtons ItemButtonsObj { set; get; }
    private GameObject ClickedButton;
    public GameObject ToolTipTextArea;
    
    public GameObject key;
    public GameObject sword;
    public GameObject staff;
    public GameObject blaster;
    public GameObject flaskEmpty;
    public GameObject flaskFull;
    public GameObject coinPurse;
    public GameObject armor;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D rayHit = Physics2D.Raycast(ray, Vector2.zero);
            
            // RaycastHit rayCastHit;
            // Ray rayCast = Camera.main.ScreenPointToRay(Input.mousePosition);
            // Physics.Raycast(rayCast, out rayCastHit)
            if (rayHit)
            {
                Debug.Log(GameObject.FindWithTag("KeyButton"));
                if (rayHit.collider.CompareTag("ArmorButton"))
                {
                    ClickedButton = GameObject.FindWithTag("ArmorButton");
                    ItemButtonsObj = new ItemButtons(armor, "this is a armor");
                    ToolTipToggle(ItemButtonsObj, ClickedButton, _toolTipToggle);
                }
                else if (rayHit.collider.CompareTag("KeyButton"))
                {
                    Debug.Log("we got a press!");
                    ClickedButton = GameObject.FindWithTag("KeyButton");
                    ItemButtonsObj = new ItemButtons(key, "this is a Key");
                    _toolTipToggle = !_toolTipToggle;
                    ToolTipToggle(ItemButtonsObj, ClickedButton, _toolTipToggle);
                }
            }
        }
    }

    public class ItemButtons
    {
        public GameObject _itemButtons;
        public string _toolTipText;

        public ItemButtons(GameObject itemButtons, string toolTipText)
        {
            this._itemButtons = itemButtons;
            this._toolTipText = toolTipText;
        }
    }
    
    private void ToolTipToggle(ItemButtons currentItemToolTip, GameObject currentItemButton, bool toggle)
    {
        gameObject.SetActive(toggle);
    }
}
