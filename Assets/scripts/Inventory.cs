using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Main_Behaviour mainBehaviourRef;
    public menuBehaviur menuBehaviurRef;
    
    private bool _key = true;
    private bool _sword;
    private bool _staff;
    private bool _blaster;
    private bool _flaskEmpty = true;
    private bool _flaskFull;
    public bool _coinPurse;
    private bool _armor;

    public Main_Behaviour MainBehaviour => mainBehaviourRef;
    //Update GameStates to reflect the choice
    public void InventoryCheck()
    {
        switch (MainBehaviour.PlayerPoint.name)
            {
                case "sword":
                    _sword = !_sword;
                    _key = !_key;
                    UpdateInventory(_sword, menuBehaviurRef.sword);
                    UpdateInventory(_key, menuBehaviurRef.key);
                    break;
                case "staff":
                    _staff = !_staff;
                    _key = !_key;
                    UpdateInventory(_staff, menuBehaviurRef.staff);
                    UpdateInventory(_key, menuBehaviurRef.key);
                    break;
                case "blaster":
                    _blaster = !_blaster;
                    _key = !_key;
                    UpdateInventory(_blaster, menuBehaviurRef.blaster);
                    UpdateInventory(_key, menuBehaviurRef.key);
                    break;
                case "forrestIntCheck":
                    _flaskEmpty = !_flaskEmpty;
                    _flaskFull = !_flaskFull;
                    UpdateInventory(_flaskEmpty, menuBehaviurRef.flaskEmpty);
                    UpdateInventory(_flaskFull, menuBehaviurRef.flaskFull);
                    MainBehaviour.FlaskUpdate.StatCheck.AttributeReturn = _flaskFull;
                    break;
                case "jungle":
                    _coinPurse = !_coinPurse;
                    UpdateInventory(_coinPurse, menuBehaviurRef.coinPurse);
                    MainBehaviour.CoinUpdate.StatCheck.AttributeReturn = _coinPurse;
                    break;
                case "BuyArmor":
                    _coinPurse = !_coinPurse;
                    _armor = !_armor;
                    UpdateInventory(_coinPurse, menuBehaviurRef.coinPurse);
                    UpdateInventory(_armor, menuBehaviurRef.armor);
                    break;
                case "StealArmor":
                    _armor = !_armor;
                    UpdateInventory(_armor, menuBehaviurRef.armor);
                    break;
                default:
                
                    break;
            }
    }
//Show hide items based on Players Choice 
    private void UpdateInventory(bool itemState, GameObject currentItem)
    {
        currentItem.SetActive(itemState);
    }
    
}