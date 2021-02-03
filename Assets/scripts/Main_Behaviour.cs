﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
// using Newtonsoft.Json;
// using UnityEditor.Experimental.GraphView;
// using UnityEditorInternal;
// using StatePattern;
using UnityEngine;
using UnityEngine.Serialization;
 using UnityEngine.SocialPlatforms;
 using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;
using Random = System.Random;

public class Main_Behaviour : MonoBehaviour
{
    public Button[] menuCards;
    public GameObject storyPlate;
    public menuBehaviur menuBehaviurRef;
    public Inventory inventoryRef;

    public Transform playerPosition;
    public int playerSpeed = 2;

    public GameState PlayerPoint { get; set; }
    public GameState CoinUpdate { get; set; }
    public GameState FlaskUpdate { get; set; }

    public class GameState
    {
        public string name;
        public Cards storyCardName;
        public Position position;
        public GameState[] possibleOutcomes;
        public Vector3[] steps;
        public CenterCard StoryCards;
        public AttributeCheck StatCheck;
        
        public GameState(string name, Cards storyCardName, Position position, GameState[] possibleOutcomes, Vector3[] steps, CenterCard storyCards, AttributeCheck statReturn)
        {
            this.name = name;
            this.storyCardName = storyCardName;
            this.position = position;
            this.possibleOutcomes = possibleOutcomes;
            this.steps = steps;
            this.StoryCards = storyCards;
            this.StatCheck = statReturn;
        }
    }

    public class AttributeCheck
    {
        public bool AttributeReturn { set; get; }

        public AttributeCheck(bool attributeReturn)
        {
            AttributeReturn = attributeReturn;
        }
    }
    
    public class Cards
    {
        public Sprite CardImage;

        public Cards(Sprite cardImage)
        {
            CardImage = cardImage;
        }
    }

    public class Position
    {
        private float _locationX, _locationY;

        public Position(float locX, float locY)
        {
            _locationX = locX;
            _locationY = locY;
        }
    }

    public class CenterCard
    {
        public Sprite StoryBlock;

        public CenterCard(Sprite centerField)
        {
            StoryBlock = centerField;
        }
    }

    //GameStates
    public void CreateObjects()
    {
        //this is death
        GameState port = new GameState(
            "portEnding",
            new Cards(Resources.Load<Sprite>("cards_faces/Port_PH")), 
            new Position(3.73f, 8.814f),
            new GameState[] {},
            new []
            {
                new Vector3(0.232f, 7.24f, -1f),
                new Vector3(0.631f, 9.541f, -1f),
                new Vector3(1.633f, 9.643f, -1f),
                new Vector3(3.73f, 8.814f, -1f),
            },
            new CenterCard(Resources.Load<Sprite>("Story_Board/Story_Template")),
            new AttributeCheck(true)
        );
        //this is death
        GameState miningCampSteal = new GameState(
            "miningCampStealEnding",
            new Cards(Resources.Load<Sprite>("cards_faces/MiningCamp_PH")),
            new Position(-4.05f, 13.9f),
            new GameState[] {},
            new []
            {
                new Vector3(0.6f, 13.13f, -1f),
                new Vector3(-0.67f, 13.77f, -1f),
                new Vector3(-4.05f, 13.9f, -1f),
            },
            new CenterCard(Resources.Load<Sprite>("Story_Board/Story_Template")),
            new AttributeCheck(true)
        );
        //this is death
        GameState failToWin = new GameState(
            "failToWinEnding",
            new Cards(Resources.Load<Sprite>("cards_faces/dragon_steal_card")),
            new Position(1.81f, -9.61f),
            new GameState[] {},
            new []
            {
                new Vector3(1.14f, -6.68f, -1f),
                new Vector3(1.81f, -9.61f, -1f),
            },
            new CenterCard(Resources.Load<Sprite>("Story_Board/Story_Template")),
            new AttributeCheck(true)
        );
        
        //This is the end BITCOIN ending
        GameState mineBitCoins = new GameState(
            "mineBitCoinEnding",
            new Cards(Resources.Load<Sprite>("cards_faces/MiningCamp_PH")),
            new Position(-4.05f, 13.9f),
            new GameState[] {},
            new []
            {
                new Vector3(0.6f, 13.13f, -1f),
                new Vector3(-0.67f, 13.77f, -1f),
                new Vector3(-4.05f, 13.9f, -1f),
            },
            new CenterCard(Resources.Load<Sprite>("Story_Board/Story_Template")),
            new AttributeCheck(true)
        );
        
        //Dragon ending do an if check for items
        GameState toDragon = new GameState(
            "goToDragonEnding",
            new Cards(Resources.Load<Sprite>("cards_faces/dragon_attack_fail_card")),
            new Position(18.64f, -1.22f),
            new GameState[] {},
            new []
            {
                new Vector3(4.95f, -5.46f, -1f),
                new Vector3(13.04f, -2.31f, -1f),
                new Vector3(14.19f, -2.31f, -1f),
                new Vector3(15.73f, -2.89f, -1f),
                new Vector3(17.63f, -3.13f, -1f),
                new Vector3(18.64f, -1.22f, -1f),
            },
            new CenterCard(Resources.Load<Sprite>("Story_Board/Story_Template")),
            new AttributeCheck(true)
        );
        //outskirts ending do roll on outcome
        GameState outskirts = new GameState(
            "outskirtsEnding",
            new Cards(Resources.Load<Sprite>("cards_faces/Outskirts_PH")),
            new Position(7.16f, 1.34f),
            new GameState[] {},
            new []
            {
                new Vector3(3.42f, -0.25f, -1f),
                new Vector3(5.43f, 0.12f, -1f),
                new Vector3(7.16f, 1.34f, -1f),
            },
            new CenterCard(Resources.Load<Sprite>("Story_Board/Story_Template")),
            new AttributeCheck(true)
        );
        //this is death
        GameState goToCityAfterJungle = new GameState(
            "goToCityAfterJungleEnding",
            new Cards(Resources.Load<Sprite>("cards_faces/merchant_keep_card")),
            new Position(4.21f, -2.45f),
            new GameState[] {},
            new []
            {
                new Vector3(1.52f, -6.73f, -1f),
                new Vector3(4.99f, -5.4f, -1f),
                new Vector3(4.21f, -2.45f, -1f),
            },
            new CenterCard(Resources.Load<Sprite>("Story_Board/Story_Template")),
            new AttributeCheck(true)
        );
        
        //this is death
        GameState forrestDrink = new GameState(
            "forrestEnding",
            new Cards(Resources.Load<Sprite>("cards_faces/forest_drink_card")),
            new Position(-16.39f, 2.11f),
            new GameState[] {},
            new []
            {
                new Vector3(-16.39f, 2.11f, -1f),
            },
            new CenterCard(Resources.Load<Sprite>("Story_Board/Story_Template")),
            new AttributeCheck(true)
        );
        
        //this is death do a roll for outcome
        GameState flee = new GameState(
            "FleeEnding",
            new Cards(Resources.Load<Sprite>("cards_faces/dragon_run_card")),
            new Position(18.191f, 6.756f),
            new GameState[] {},
            new []
            {
                new Vector3(16.508f, 8.654f, -1f),
                new Vector3(16.947f, 7.682f, -1f),
                new Vector3(16.947f, 7.682f, -1f),
                new Vector3(17.536f, 7.588f, -1f),
                new Vector3(18.191f, 6.756f, -1f),
            },
            new CenterCard(Resources.Load<Sprite>("Story_Board/Story_Template")),
            new AttributeCheck(true)
        );
        //do a roll for ending
        GameState toMountains = new GameState(
            "mountainsEnding",
            new Cards(Resources.Load<Sprite>("cards_faces/mountains_PH")),
            new Position(18.95f, 13.99f),
            new GameState[] {},
            new []
            {
                new Vector3(15.41f, 4.91f, -1f),
                new Vector3(16.23f, 7.07f, -1f),
                new Vector3(17.17f, 8.91f, -1f),
                new Vector3(17.64f, 9.9f, -1f),
                new Vector3(18f, 12.16f, -1f),
                new Vector3(18.64f, 12.82f, -1f),
                new Vector3(18.46f, 13.36f, -1f),
                new Vector3(18.95f, 13.99f, -1f),
            },
            new CenterCard(Resources.Load<Sprite>("Story_Board/Story_Template")),
            new AttributeCheck(true)
        );
        
        GameState miningCampTalkToTheBoss = new GameState(
            "miningCampTalk",
            new Cards(Resources.Load<Sprite>("cards_faces/MiningCamp_PH")),
            new Position(-4.05f, 13.9f),
            new [] {mineBitCoins},
            new []
            {
                new Vector3(0.6f, 13.13f, -1f),
                new Vector3(-0.67f, 13.77f, -1f),
                new Vector3(-4.05f, 13.9f, -1f),
            },
            new CenterCard(Resources.Load<Sprite>("Story_Board/Story_Template")),
            new AttributeCheck(menuBehaviurRef.strStat >= 5)
        );
        
        GameState miningCamp = new GameState(
            "miningCamp",
            new Cards(Resources.Load<Sprite>("cards_faces/MiningCamp_PH")),
            new Position(1.81f, 13.5f),
            new [] {miningCampTalkToTheBoss, miningCampSteal},
            new []
            {
                new Vector3(0.3f, 7.01f, -1f),
                new Vector3(0.51f, 8.45f, -1f),
                new Vector3(0.92f, 10.85f, -1f),
                new Vector3(0.92f, 13.22f, -1f),
                new Vector3(1.81f, 13.5f, -1f),
            },
            new CenterCard(Resources.Load<Sprite>("Story_Board/Story_Template")),
            new AttributeCheck(true)
        );
        
        GameState buyArmor = new GameState(
            "BuyArmor",
            new Cards(Resources.Load<Sprite>("cards_faces/armor")),
            new Position(3.529f, -2.451f),
            new [] {toDragon},
            new []
            {
                new Vector3(3.529f, -2.451f, -1f),
            },
            new CenterCard(Resources.Load<Sprite>("Story_Board/Story_Template")),
            new AttributeCheck(false)
        );
        
        GameState stealArmor = new GameState(
            "StealArmor",
            new Cards(Resources.Load<Sprite>("cards_faces/armor")),
            new Position(18.64f, -1.22f),
            new [] {toDragon},
            new []
            {
                new Vector3(4.95f, -5.46f, -1f),
                new Vector3(13.04f, -2.31f, -1f),
                new Vector3(14.19f, -2.31f, -1f),
                new Vector3(15.73f, -2.89f, -1f),
                new Vector3(17.63f, -3.13f, -1f),
                new Vector3(18.64f, -1.22f, -1f),
            },
            new CenterCard(Resources.Load<Sprite>("Story_Board/Story_Template")),
            new AttributeCheck(menuBehaviurRef.agyStat >= 5)
        );

        GameState shop = new GameState(
            "Shop",
            new Cards(Resources.Load<Sprite>("cards_faces/armor")),
            new Position(3.529f, -2.451f),
            new [] {toDragon, buyArmor, stealArmor},
            new []
            {
                new Vector3(3.895f, -1.173f, -1f),
                new Vector3(4.778f, -1.948f, -1f),
                new Vector3(3.529f, -2.451f, -1f),
            },
            new CenterCard(Resources.Load<Sprite>("Story_Board/Story_Template")),
            new AttributeCheck(true)
        );
        
        GameState cityAfterQuest = new GameState(
            "cityAfterQuest",
            new Cards(Resources.Load<Sprite>("cards_faces/town_leave_card")),
            new Position(4.2f, -2.56f),
            new [] {shop, outskirts, toDragon},
            new []
            {
                new Vector3(-0.52f, -6.75f, -1f),
                new Vector3(4.94f, -5.64f, -1f),
                new Vector3(4.2f, -2.56f, -1f),
            },
            new CenterCard(Resources.Load<Sprite>("Story_Board/Story_Template")),
            new AttributeCheck(true)
        );
        
        GameState takeLootBack = new GameState(
            "takeLootBack",
            new Cards(Resources.Load<Sprite>("cards_faces/merchant_return_card")),
            new Position(-1f, -5.76f),
            new [] {cityAfterQuest, toDragon},
            new []
            {
                new Vector3(1.45f, -6.63f, -1f),
                new Vector3(-1f, -6.63f, -1f),
                new Vector3(-1f, -5.76f, -1f),
            },
            new CenterCard(Resources.Load<Sprite>("Story_Board/Story_Template")),
            new AttributeCheck(true)
        );
        
        GameState jungle = new GameState(
            "jungle",
            new Cards(Resources.Load<Sprite>("cards_faces/Lizard_Men_PH")),
            new Position(2.116f, -11.071f),
            new [] {takeLootBack, goToCityAfterJungle},
            new []
            {
                new Vector3(4.344f, -11.139f, -1f),
                new Vector3(4.962f, -12.45f, -1f),
                new Vector3(2.116f, -11.071f, -1f),

            },
            new CenterCard(Resources.Load<Sprite>("Story_Board/Story_Template")),
            new AttributeCheck(true)
        );
        
        GameState helpMerchant = new GameState(
            "aggreToHelp",
            new Cards(Resources.Load<Sprite>("cards_faces/follow_lizardmen_card")),
            new Position(2.304f, -10.633f),
            new [] {jungle},//TODO: need 1 more choice to leave and go to city directly
            new []
            {
                new Vector3(1.226f, -6.399f, -1f),
                new Vector3(1.815f, -8.836f, -1f),
                new Vector3(2.304f, -10.633f, -1f),
            },
            new CenterCard(Resources.Load<Sprite>("Story_Board/Story_Template")),
            new AttributeCheck(true)
        );
        
        GameState ignoreMerchant = new GameState(
            "ignoreMerchant",
            new Cards(Resources.Load<Sprite>("cards_faces/ignore_merchant_card")),
            new Position(4.2f, -2.56f),
            new [] {shop, toDragon},
            new []
            {
                new Vector3(-0.52f, -6.75f, -1f),
                new Vector3(4.94f, -5.64f, -1f),
                new Vector3(4.2f, -2.56f, -1f),
            },
            new CenterCard(Resources.Load<Sprite>("Story_Board/Story_Template")),
            new AttributeCheck(true)
        );
        
        GameState quest = new GameState(
            "cityQuest",
            new Cards(Resources.Load<Sprite>("cards_faces/Quest_PH")),
            new Position(-1.25f, -5.89f),
            new [] {helpMerchant, ignoreMerchant},
            new []
            {
                new Vector3(4.72f, -5.56f, -1f),
                new Vector3(-0.59f, -6.76f, -1f),
                new Vector3(-1.25f, -5.89f, -1f),
            },
            new CenterCard(Resources.Load<Sprite>("Story_Board/Story_Template")),
            new AttributeCheck(true)
        );
        
        //city line coming from crossroads
        GameState city = new GameState(
            "city",
            new Cards(Resources.Load<Sprite>("cards_faces/go_to_town_card")),
            new Position(3.61f, -2.24f),
            new [] {quest, outskirts, shop},
            new []
            {
                new Vector3(-0.87f, 4.62f, -1f),
                new Vector3(1.48f, 2.72f, -1f),
                new Vector3(1.89f, 2.09f, -1f),
                new Vector3(3.06f, 1.93f, -1f),
                new Vector3(3.61f, 0.78f, -1f),
                new Vector3(3.61f, -2.24f, -1f),
            },
            new CenterCard(Resources.Load<Sprite>("Story_Board/Story_Template")),
            new AttributeCheck(true)
        );
        
        //forest crossroads merge with road story if heading to city
        GameState crossRoads = new GameState(
            "crossroads",
            new Cards(Resources.Load<Sprite>("cards_faces/CrossRoads_PH")),
            new Position(-0.84f, 6.34f),
            new [] {city, miningCamp, port},//TODO: reuse this for extra dragon
            new []
            {
                new Vector3(-7.15f, 3.23f, -1f),
                new Vector3(-5.19f, 6.34f, -1f),
                new Vector3(-0.84f, 6.34f, -1f),
            },
            new CenterCard(Resources.Load<Sprite>("Story_Board/Story_Template")),
            new AttributeCheck(true)
        );
        
        GameState forrestIntCheck = new GameState(
            "forrestIntCheck",
            new Cards(Resources.Load<Sprite>("cards_faces/forest_flask_card")),
            new Position(-0.84f, 6.34f),
            new [] {city, miningCamp, port},
            new []
            {
                new Vector3(-7.15f, 3.23f, -1f),
                new Vector3(-5.19f, 6.34f, -1f),
                new Vector3(-0.84f, 6.34f, -1f),
            },
            new CenterCard(Resources.Load<Sprite>("Story_Board/Story_Template")),
            new AttributeCheck(menuBehaviurRef.intelStat >= 5)
        );
        
        GameState forrestWalk = new GameState(
            "forrestLeave",
            new Cards(Resources.Load<Sprite>("cards_faces/forest_leave_card")),
            new Position(-0.84f, 6.34f),
            new [] {city, miningCamp, port},
            new []
            {
                new Vector3(-7.15f, 3.23f, -1f),
                new Vector3(-5.19f, 6.34f, -1f),
                new Vector3(-0.84f, 6.34f, -1f),
            },
            new CenterCard(Resources.Load<Sprite>("Story_Board/Story_Template")),
            new AttributeCheck(true)
        );
        
        // forrest line starts here
        GameState forrest = new GameState(
            "forrest",
            new Cards(Resources.Load<Sprite>("cards_faces/forest_card")),
            new Position(-11.19f, 1.43f),
            new [] {forrestDrink, forrestWalk, forrestIntCheck},
            new []
            {
                new Vector3(-14.68f, -3.61f, -1f),
                new Vector3(-17.07f, -2.11f, -1f),
                new Vector3(-11.19f, 1.43f, -1f),
            },
            new CenterCard(Resources.Load<Sprite>("Story_Board/Story_Template")),
            new AttributeCheck(true)
        );
        
        GameState toBattlefield = new GameState(
            "battliefield",
            new Cards(Resources.Load<Sprite>("cards_faces/To_battlefield_PH")),
            new Position(15.18f, 9.28f),
            new [] {flee},
            new []
            {
                new Vector3(15.25f, 6.56f, -1f),
                new Vector3(15.18f, 9.28f, -1f),
            },
            new CenterCard(Resources.Load<Sprite>("Story_Board/Story_Template")),
            new AttributeCheck(true)
        );
        
        GameState portal = new GameState(
            "portal",
            new Cards(Resources.Load<Sprite>("cards_faces/portal_card")),
            new Position(15.13f, 3.81f),
            new [] {toDragon, toBattlefield, toMountains},//TODO: need new object for Dragon Fight
            new []
            {
                new Vector3(-13.33f, -7.63f, -1f),
                new Vector3(-9.36f, -13.29f, -1f),
                new Vector3(15.13f, 3.81f, -1f),
            },
            new CenterCard(Resources.Load<Sprite>("Story_Board/Story_Template")),
            new AttributeCheck(true)
        );
        
        GameState road = new GameState(
            "road",
            new Cards(Resources.Load<Sprite>("cards_faces/road_card")),
            new Position(-0.98f, -5.85f),
            new [] {helpMerchant, ignoreMerchant},
            new []
            {
                new Vector3(-9.64f, -6.37f, -1f),
                new Vector3(-6.71f, -7.02f, -1f),
                new Vector3(-1.18f, -6.77f, -1f),
                new Vector3(-0.98f, -5.85f, -1f),
            },
            new CenterCard(Resources.Load<Sprite>("Story_Board/Story_Template")),
            new AttributeCheck(true)
        );
        //TODO: remove the first extra step of movement it is not needed
        GameState blaster = new GameState(
            "blaster",
            new Cards(Resources.Load<Sprite>("cards_faces/Tech_Chest")),
            new Position(-12.82f, -6.55f), 
            new [] {forrest, road, portal},
            new []
            {
                new Vector3(-16.51f, -5.89f, -1f),
                new Vector3(-12.82f, -6.55f, -1f),
            },
            new CenterCard(Resources.Load<Sprite>("Story_Board/Dwarf_Life")),
            new AttributeCheck(true)
        );
        
        GameState sword = new GameState(
            "sword",
            new Cards(Resources.Load<Sprite>("cards_faces/sturdy_chest_card")),
            new Position(-12.82f, -6.55f), 
            new [] {forrest, road, portal},
            new []
            {
                new Vector3(-16.51f, -5.89f, -1f),
                new Vector3(-12.82f, -6.55f, -1f),
            },
            new CenterCard(Resources.Load<Sprite>("Story_Board/Bastard_Sword")),
            new AttributeCheck(true)
        );
        
        GameState staff = new GameState(
            "staff",
            new Cards(Resources.Load<Sprite>("cards_faces/Magic_chest_card")),
            new Position(-12.82f, -6.55f),
            new [] {forrest, road, portal},
            new []
            {
                new Vector3(-16.51f, -5.89f, -1f), 
                new Vector3(-12.82f, -6.55f, -1f), 
            },
            new CenterCard(Resources.Load<Sprite>("Story_Board/Dragon_Run")),
            new AttributeCheck(true)
        );
        
        GameState home = new GameState(
            "start",
            new Cards(Resources.Load<Sprite>("cards_faces/armor")),
            new Position(-16.42f, -5.76f),
            new [] {staff, sword, blaster},
            new []
            {
                new Vector3(-16.42f, -5.76f, -1f),
            },
            new CenterCard(Resources.Load<Sprite>("Story_Board/Beginning")),
            new AttributeCheck(true)
        );
        
        PlayerPoint = home;
        CoinUpdate = buyArmor;
        FlaskUpdate = forrestIntCheck; //TODO: update this to dragon figth check
    }
//Move player
    private async void MoveMe(GameState stepsToTake)
    {
        foreach (var currentStep in stepsToTake.steps)//check current GameState.Steps that player has picked
        {
            StartCoroutine(MoveOverSeconds(gameObject, currentStep, playerSpeed));
            WhichSideDoIFace(transform.position.x, currentStep.x, transform.position.y, currentStep.y);
            await Task.Delay(playerSpeed * 1000);
        }   
        
    }
//Move over X frames
    public IEnumerator MoveOverSpeed(GameObject objectToMove, Vector3 end, float speed)
    {
        // speed should be 1 unit per second
        while (objectToMove.transform.position != end)
        {
            objectToMove.transform.position =
                Vector3.MoveTowards(objectToMove.transform.position, end, speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }
//move over X seconds
    private IEnumerator MoveOverSeconds(GameObject objectToMove, Vector3 end, float seconds)
    {
        float elapsedTime = 0;
        Vector3 startingPos = objectToMove.transform.position;
        while (elapsedTime < seconds)
        {
            objectToMove.transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        objectToMove.transform.position = end;
    }
//Change the direction the player is facing based on the direction of movement
    private void WhichSideDoIFace (float currentX, float nextStepX, float currentY, float nextStepY) {
        if ((nextStepX >= currentX) && (nextStepY >= currentY)) {  //we are moving NW -- top rigth
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            gameObject.GetComponent<SpriteRenderer>().flipY = false;
        } else if ((nextStepX <= currentX) && (nextStepY <= currentY)) { //we are moving SE -- bottom left
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            gameObject.GetComponent<SpriteRenderer>().flipY = true;
        } else if ((nextStepX <= currentX) && (nextStepY >= currentY)) { //we are moving NE -- top left
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            gameObject.GetComponent<SpriteRenderer>().flipY = false;
        } else if ((nextStepX >= currentX) && (nextStepY <= currentY)) { //we are moving SW -- bottom rigth
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            gameObject.GetComponent<SpriteRenderer>().flipY = true;
        }
    }
//Change the cards based on what GameState the player is currently in
    private void ChangeButtonImg(GameState currentState)
    {
        var i = 0;
        foreach (var buttonImage in currentState.possibleOutcomes)
        {
            //TODO: buttonImage.attriubteCheck is returning false no matter the check
            var currentCard = menuCards[i];
            if (!currentCard.gameObject.activeSelf)//show cards if they are currently hidden
            {
                currentCard.gameObject.SetActive(true);
            }
            if (!buttonImage.StatCheck.AttributeReturn)//only show the card if player has required stats
            {
                currentCard.gameObject.SetActive(false);
            }
            currentCard.GetComponent<Image>().sprite = buttonImage.storyCardName.CardImage;
            i++;
        }

        while (i < 3)//hide cards if they are currently showing
        {
            menuCards[i].gameObject.SetActive(false);
            i++;
        }
    }

    //TODO: add life to map Movement of dragon fire animation water

    //TODO: add a random generator function for random outcome endings
    private void RandomOutcomeGenerator(GameState ending, int chanceToWinMultiplier)
    {
        if (ending.name == "failToWinEnding" | ending.name == "outskirtsEnding" | ending.name == "FleeEnding")
        {
            var chanceToWin = UnityEngine.Random.Range(0, 10);
            
        }
    } 
    //change story based on what GameState the player is currently in
    private async void ChangeStoryPlate(GameState currentState)
    {
        var hideForTime = currentState.steps.Length;
        storyPlate.gameObject.SetActive(false);
        await Task.Delay((hideForTime * playerSpeed) * 1000);
        storyPlate.gameObject.GetComponent<Image>().sprite = currentState.StoryCards.StoryBlock;
        storyPlate.gameObject.SetActive(true);
    }

    // Register Button events
    private void OnEnable()
    {
        menuCards[0].onClick.AddListener(ButtonCallBackCard1);
        menuCards[1].onClick.AddListener(ButtonCallBackCard2);
        menuCards[2].onClick.AddListener(ButtonCallBackCard3);
        DEBUGONLY.onClick.AddListener(()=>buttonCallBackDEBUG());
    }
    
    public Button DEBUGONLY;
    public InputField DEBUGFIELD;

    private void buttonCallBackDEBUG()
    {
        var position = this.transform.position;
        var outputX = position.x.ToString();
        var outputY = position.y.ToString();
        string txtDoucumentName = Application.streamingAssetsPath + "/cords/" + "I AM LAZY" + ".txt";

        if (!File.Exists(txtDoucumentName))
        {
            File.WriteAllText(txtDoucumentName, "MY LOG \n\n");
        }

        if (DEBUGFIELD.text == "")
        {
            File.AppendAllText(txtDoucumentName, "new Vector3(" + outputX + "f, " + outputY + "f," + " " + "-1f)," + "\n");
        }
        else
        {
            File.AppendAllText(txtDoucumentName, DEBUGFIELD.text + ": " + "\n");
        }

        DEBUGFIELD.text = "";
    }

    //Card1 button actions
    private void ButtonCallBackCard1()
    {
        PlayerPoint = PlayerPoint.possibleOutcomes[0];
        inventoryRef.InventoryCheck();
        ChangeStoryPlate(PlayerPoint);
        MoveMe(PlayerPoint);
        ChangeButtonImg(PlayerPoint);
    }

    //Card2 button actions
    private void ButtonCallBackCard2()
    {
        PlayerPoint = PlayerPoint.possibleOutcomes[1];
        inventoryRef.InventoryCheck();
        ChangeStoryPlate(PlayerPoint);
        MoveMe(PlayerPoint);
        ChangeButtonImg(PlayerPoint);
    }

    //Card2 button actions
    private void ButtonCallBackCard3()
    {
        PlayerPoint = PlayerPoint.possibleOutcomes[2];
        inventoryRef.InventoryCheck();
        ChangeStoryPlate(PlayerPoint);
        MoveMe(PlayerPoint);
        ChangeButtonImg(PlayerPoint);
    }
}