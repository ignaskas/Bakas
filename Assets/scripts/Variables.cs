﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

    public class Variables : MonoBehaviour
    {
        //States
       public enum StatesFsm
        {
            None,
            Sword,
            Staff,
            Blaster,
            Forest,
            Portal,
            Road,
            ForestDrinkWater,
            ForestWalkAway,
            ForestIntCheck,
            AfterForestGoCity,
            AfterForestGoBitCoin,
            CityGoldCheck,
            CityAgyCheck,
            CityQuest,
            CityLeave,
            BitCoinQuest,
            BitCoinLeave,
            BitCoinDie,
            MerchantHelp,
            MerchantIgnore,
            JungleRun,
            JungleSteal,
            JungleReturn,
            MerchantToCity,
            CityDie,
            PortalDragon,
            DragonAgyCheck,
            DragoonPoison,
            DragonWin,
            DragonDie,
            PortalBattlefield,
            BattlefieldDwarfs,
            BattlefieldOrcs,
            BattlefieldDie,
            DwarfsQuest,
            DwarfsWin,
            DwarfsDie,
            OrcsFlee,
            OrcsDie
        }

    }
        
// public Button DEBUGONLY;
// public InputField DEBUGFIELD;
// DEBUGONLY.onClick.AddListener(()=>buttonCallBackDEBUG());
// private void buttonCallBackDEBUG()
// {
// var position = this.transform.position;
// var outputX = position.x.ToString();
// var outputY = position.y.ToString();
// string txtDoucumentName = Application.streamingAssetsPath + "/cords/" + "I AM LAZY" + ".txt";
//
//     if (!File.Exists(txtDoucumentName))
// {
//     File.WriteAllText(txtDoucumentName, "MY LOG \n\n");
// }
//
// if (DEBUGFIELD.text == "")
// {
//     File.AppendAllText(txtDoucumentName,  "new Position(" + outputX + "f, " + outputY + "f)," + "\n");
// }
// else
// {
//     File.AppendAllText(txtDoucumentName,  DEBUGFIELD.text + ": " + "\n");   
// }
//
// DEBUGFIELD.text = "";
//         
//         
// //TODO: make the objecs in to an txt file 
// var idk = JsonConvert.SerializeObject(cards);
// var sure = JsonConvert.DeserializeObject<List<Sprite>>(idk);

// }

//---------------------------------------------------------------------------------------
    
    
// private void Click(GameState state)
// {
//     var x = position.locationX;
//     var y = position.locationY;
//     
//     foreach(Position aState in steps)
//     {
//         // Debug.Log(steps);
//         MoveMe(x, steps.locX, y, steps.locY);
//         x = PlayerPoint.locationX;
//         y = PlayerPoint.locationY;
//     }
// }


// .GetComponent<Image>().sprite =  cards[buttonImage.name];
// ToList().FirstOrDefault(e => e.name == buttonimage.name.ToString());
// buttonName.GetComponent<Image>().sprite = cards[buttonimage.name];

// menuCards[i].GetComponent<GameObject>().SetActive(false);

// var foo = new List<Sprite>();
// foo.AddRange(cards);
// foo.Where(e => e.name == "");
// foo.FirstOrDefault(e => )

// Directory.CreateDirectory(Application.streamingAssetsPath + "/cords/");


// float interpolationRatio = (float) _elapsedFrames / interpolationFramesCount;
// Vector3.Lerp(currentStep.locationX, currentStep.locationX, interpolationRatio);
// _elapsedFrames = (_elapsedFrames + 1) % (interpolationFramesCount + 1); 



        
//
// foreach (var currentStep in nextStep.steps)
// {
//     whichSideDoIFace(start.position.locationX, nextStep.position.locationX,  start.position.locationY, nextStep.position.locationY);
//     transform.position = new Vector3(currentStep.locationX, currentStep.locationY, 0);
//     await Task.Delay(200);
//     start = nextStep;
// }

// public int interpolationFramesCount = 45; // Number of Frames to complete the animation
// private int _elapsedFrames = 0;