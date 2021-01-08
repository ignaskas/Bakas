using System;
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
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;

public class Main_Behaviour : MonoBehaviour
{
    public Button[] menuCards;
    
    public Transform playerPosition;
    public int playerSpeed = 2;

    public GameState PlayerPoint { get; set; }

    //Gamestate class
    public class GameState
    {
        public Cards name;
        public Position position;
        public GameState[] possibleOutcomes;
        public Vector3[] steps;
        public Items items;

        //CONSTRUCTOR
        public GameState(Cards name, Position position, GameState[] possibleOutcomes, Vector3[] steps)
        {
            this.name = name;
            this.position = position;
            this.possibleOutcomes = possibleOutcomes;
            this.steps = steps;
        }
        // only return true if we are not doing an attribute check
        Boolean attributeCheck()
        {
            return true;
        }
      
        void complicatedBehaviour()
        {

        }
        //Generates all posibale outcomes from current GameState
        public void updatePossibilites()
        {
            foreach(GameState aState in possibleOutcomes)
            {
                if (aState.attributeCheck())
                {
                    aState.complicatedBehaviour();
                }
            }
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
    
    public class Items
    {
        private bool _sword, _staff, _blaster, _bagOfCoin, _emptyBagOfCoin, _armor, _flaskEmpty, _flaskFull, _key;
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

    //GameStates
    public void Start()
    {
        //this is death
        GameState port = new GameState(
            new Cards(Resources.Load<Sprite>("cards_faces/Port_PH")), 
            new Position(15.13f, 3.81f),
            new GameState[] {},
            new []
            {
                new Vector3(-13.33f, -7.63f, -1f),
                new Vector3(-9.36f, -13.29f, -1f),
                new Vector3(15.13f, 3.81f, -1f),
            }
        );
        //this is death
        GameState miningCampSteal = new GameState(
            new Cards(Resources.Load<Sprite>("cards_faces/MiningCamp_PH")),
            new Position(-4.05f, 13.9f),
            new GameState[] {},
            new []
            {
                new Vector3(0.6f, 13.13f, -1f),
                new Vector3(-0.67f, 13.77f, -1f),
                new Vector3(-4.05f, 13.9f, -1f),
            }
        );
        //this is death
        GameState failToWin = new GameState(
            new Cards(Resources.Load<Sprite>("cards_faces/dragon_steal_card")),
            new Position(1.81f, -9.61f),
            new GameState[] {},
            new []
            {
                new Vector3(1.14f, -6.68f, -1f),
                new Vector3(1.81f, -9.61f, -1f),
            }
        );
        
        //This is the end BITCOIN ending
        GameState mineBitCoins = new GameState(
            new Cards(Resources.Load<Sprite>("cards_faces/MiningCamp_PH")),
            new Position(-4.05f, 13.9f),
            new GameState[] {},
            new []
            {
                new Vector3(0.6f, 13.13f, -1f),
                new Vector3(-0.67f, 13.77f, -1f),
                new Vector3(-4.05f, 13.9f, -1f),
            }
        );
        
        //Dragon ending do an if check for items
        GameState toDragon = new GameState(
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
            }
        );
        //outskirts ending do roll on outcome
        GameState outskirts = new GameState(
            new Cards(Resources.Load<Sprite>("cards_faces/Outskirts_PH")),
            new Position(7.16f, 1.34f),
            new GameState[] {},
            new []
            {
                new Vector3(3.42f, -0.25f, -1f),
                new Vector3(5.43f, 0.12f, -1f),
                new Vector3(7.16f, 1.34f, -1f),
            }
        );
        //this is death
        GameState goToCityAfterJungle = new GameState(
            new Cards(Resources.Load<Sprite>("cards_faces/merchant_keep_card")),
            new Position(4.21f, -2.45f),
            new GameState[] {},
            new []
            {
                new Vector3(1.52f, -6.73f, -1f),
                new Vector3(4.99f, -5.4f, -1f),
                new Vector3(4.21f, -2.45f, -1f),
            }
        );
        
        //this is death
        GameState forrestDrink = new GameState(
            new Cards(Resources.Load<Sprite>("cards_faces/forest_drink_card")),
            new Position(-16.39f, 2.11f),
            new GameState[] {},
            new []
            {
                new Vector3(-16.39f, 2.11f, -1f),
            }
        );
        
        //this is death do a roll for outcome
        GameState flee = new GameState(
            new Cards(Resources.Load<Sprite>("cards_faces/dragon_run_card")),
            new Position(-16.33f, 2.47f),
            new GameState[] {},
            new []
            {
                new Vector3(-16.33f, 2.47f, -1f)
            }
        );
        //do a roll for ending
        GameState toMountains = new GameState(
            new Cards(Resources.Load<Sprite>("cards_faces/mountains_PH")),
            new Position(18.68f, 13.33f),
            new GameState[] {},
            new []
            {
                new Vector3(18.14f, 12.07f, -1f),
                new Vector3(18.68f, 12.61f, -1f),
                new Vector3(18.52f, 13.12f, -1f),
                new Vector3(18.68f, 13.33f, -1f),
            }
        );
        
        GameState miningCampTalkToTheBoss = new GameState(
            new Cards(Resources.Load<Sprite>("cards_faces/MiningCamp_PH")),
            new Position(-4.05f, 13.9f),
            new [] {mineBitCoins},
            new []
            {
                new Vector3(0.6f, 13.13f, -1f),
                new Vector3(-0.67f, 13.77f, -1f),
                new Vector3(-4.05f, 13.9f, -1f),
            }
        );
        
        GameState miningCamp = new GameState(
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
            }
        );
        
        GameState shop = new GameState(
            new Cards(Resources.Load<Sprite>("cards_faces/armor")),
            new Position(11.37f, 1.67f),
            new [] {toDragon},
            new []
            {
                new Vector3(-13.11f, -4.19f, -1f),
            }
        );
        
        GameState cityAfterQuest = new GameState(
            new Cards(Resources.Load<Sprite>("cards_faces/town_leave_card")),
            new Position(4.2f, -2.56f),
            new [] {shop, outskirts, toDragon},
            new []
            {
                new Vector3(-0.52f, -6.75f, -1f),
                new Vector3(4.94f, -5.64f, -1f),
                new Vector3(4.2f, -2.56f, -1f),
            }
        );
        
        GameState takeLootBack = new GameState(
            new Cards(Resources.Load<Sprite>("cards_faces/merchant_return_card")),
            new Position(-1f, -5.76f),
            new [] {cityAfterQuest, toDragon},
            new []
            {
                new Vector3(1.45f, -6.63f, -1f),
                new Vector3(-1f, -6.63f, -1f),
                new Vector3(-1f, -5.76f, -1f),
            }
        );
        
        GameState jungle = new GameState(
            new Cards(Resources.Load<Sprite>("cards_faces/Lizard_Men_PH")),
            new Position(1.81f, -9.61f),
            new [] {takeLootBack, goToCityAfterJungle, failToWin},
            new []
            {
                new Vector3(1.14f, -6.68f, -1f),
                new Vector3(1.81f, -9.61f, -1f),
            }
        );
        
        GameState helpMerchant = new GameState(
            new Cards(Resources.Load<Sprite>("cards_faces/follow_lizardmen_card")),
            new Position(-1.25f, -5.89f),
            new [] {jungle, toDragon},
            new []
            {
                new Vector3(4.72f, -5.56f, -1f),
                new Vector3(-0.59f, -6.76f, -1f),
                new Vector3(-1.25f, -5.89f, -1f),
            }
        );
        
        GameState ignoreMerchant = new GameState(
            new Cards(Resources.Load<Sprite>("cards_faces/ignore_merchant_card")),
            new Position(4.2f, -2.56f),
            new [] {shop, toDragon},
            new []
            {
                new Vector3(-0.52f, -6.75f, -1f),
                new Vector3(4.94f, -5.64f, -1f),
                new Vector3(4.2f, -2.56f, -1f),
            }
        );
        
        GameState quest = new GameState(
            new Cards(Resources.Load<Sprite>("cards_faces/Quest_PH")),
            new Position(-1.25f, -5.89f),
            new [] {helpMerchant, ignoreMerchant},
            new []
            {
                new Vector3(4.72f, -5.56f, -1f),
                new Vector3(-0.59f, -6.76f, -1f),
                new Vector3(-1.25f, -5.89f, -1f),
            }
        );
        
        //city line coming from crossroads
        GameState city = new GameState(
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
            }
        );
        
        //forest crossroads merge with road story if heading to city
        GameState crossRoads = new GameState(
            new Cards(Resources.Load<Sprite>("cards_faces/CrossRoads_PH")),
            new Position(-0.84f, 6.34f),
            new [] {city, miningCamp, port},
            new []
            {
                new Vector3(-7.15f, 3.23f, -1f),
                new Vector3(-5.19f, 6.34f, -1f),
                new Vector3(-0.84f, 6.34f, -1f),
            }
        );
        
        GameState forrestIntCheck = new GameState(
            new Cards(Resources.Load<Sprite>("cards_faces/forest_flask_card")),
            new Position(-0.84f, 6.34f),
            new [] {crossRoads},
            new []
            {
                new Vector3(-7.15f, 3.23f, -1f),
                new Vector3(-5.19f, 6.34f, -1f),
                new Vector3(-0.84f, 6.34f, -1f),
            }
        );
        
        GameState forrestWalk = new GameState(
            new Cards(Resources.Load<Sprite>("cards_faces/forest_leave_card")),
            new Position(-0.84f, 6.34f),
            new [] {crossRoads},
            new []
            {
                new Vector3(-7.15f, 3.23f, -1f),
                new Vector3(-5.19f, 6.34f, -1f),
                new Vector3(-0.84f, 6.34f, -1f),
            }
        );
        
        // forrest line starts here
        GameState forrest = new GameState(
            new Cards(Resources.Load<Sprite>("cards_faces/forest_card")),
            new Position(-11.19f, 1.43f),
            new [] {forrestDrink, forrestWalk, forrestIntCheck},
            new []
            {
                new Vector3(-14.68f, -3.61f, -1f),
                new Vector3(-17.07f, -2.11f, -1f),
                new Vector3(-11.19f, 1.43f, -1f),
            }
        );
        
        GameState toBattlefield = new GameState(
            new Cards(Resources.Load<Sprite>("cards_faces/To_battlefield_PH")),
            new Position(15.18f, 9.28f),
            new [] {flee},
            new []
            {
                new Vector3(15.25f, 6.56f, -1f),
                new Vector3(15.18f, 9.28f, -1f),
            }
        );
        
        GameState portal = new GameState(
            new Cards(Resources.Load<Sprite>("cards_faces/portal_card")),
            new Position(15.13f, 3.81f),
            new [] {toDragon, toBattlefield, toMountains},
            new []
            {
                new Vector3(-13.33f, -7.63f, -1f),
                new Vector3(-9.36f, -13.29f, -1f),
                new Vector3(15.13f, 3.81f, -1f),
            }
        );
        
        GameState road = new GameState(
            new Cards(Resources.Load<Sprite>("cards_faces/road_card")),
            new Position(-16.33f, 2.47f),
            new [] {helpMerchant, ignoreMerchant},
            new []
            {
                new Vector3(-16.33f, 2.47f, -1f)
            }
        );
        
        GameState blaster = new GameState(
            new Cards(Resources.Load<Sprite>("cards_faces/Tech_Chest")),
            new Position(-12.82f, -6.55f), 
            new [] {forrest, road, portal},
            new []
            {
                new Vector3(-16.51f, -5.89f, -1f),
                new Vector3(-12.82f, -6.55f, -1f),
            }
        );
        
        GameState sword = new GameState(
            new Cards(Resources.Load<Sprite>("cards_faces/sturdy_chest_card")),
            new Position(-12.82f, -6.55f), 
            new [] {forrest, road, portal},
            new []
            {
                new Vector3(-16.51f, -5.89f, -1f),
                new Vector3(-12.82f, -6.55f, -1f),
            }
        );
        
        GameState staff = new GameState(
            new Cards(Resources.Load<Sprite>("cards_faces/Magic_chest_card")),
            new Position(-12.82f, -6.55f),
            new [] {forrest, road, portal},
            new []
            {
                new Vector3(-16.51f, -5.89f, -1f), 
                new Vector3(-12.82f, -6.55f, -1f), 
            }
        );
        
        GameState home = new GameState(
            new Cards(Resources.Load<Sprite>("cards_faces/armor")),
            new Position(-16.42f, -5.76f),
            new [] {staff, sword, blaster},
            new []
            {
                new Vector3(-16.42f, -5.76f, -1f),
            }
        );

        PlayerPoint = home;
    }
    
    private async void MoveMe(GameState stepsToTake)
    {
        foreach (var currentStep in stepsToTake.steps)
        {
            StartCoroutine(MoveOverSeconds(gameObject, currentStep, playerSpeed));
            WhichSideDoIFace(transform.position.x, currentStep.x, transform.position.y, currentStep.y);
            await Task.Delay(playerSpeed * 1000);
        }   
        
    }
    
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

    private void WhichSideDoIFace (float currentX, float nextStepX, float currentY, float nextStepY) {
        if ((nextStepX > currentX) && (nextStepY > currentY)) {  //we are moving NW -- top rigth
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            gameObject.GetComponent<SpriteRenderer>().flipY = false;
        } else if ((nextStepX < currentX) && (nextStepY < currentY)) { //we are moving SE -- bottom left
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            gameObject.GetComponent<SpriteRenderer>().flipY = true;
        } else if ((nextStepX < currentX) && (nextStepY > currentY)) { //we are moving NE -- top left
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            gameObject.GetComponent<SpriteRenderer>().flipY = false;
        } else if ((nextStepX > currentX) && (nextStepY < currentY)) { //we are moving SW -- bottom rigth
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            gameObject.GetComponent<SpriteRenderer>().flipY = true;
        }
    }

    public void ChangeButtonImg(GameState currentState)
    {
        var i = 0;
        foreach (var buttonImage in currentState.possibleOutcomes)
        {
            var currentCard = menuCards[i];
            if (!currentCard.gameObject.activeSelf)
            {
                    currentCard.gameObject.SetActive(true);
            }
            currentCard.GetComponent<Image>().sprite = buttonImage.name.CardImage;
            i++;
        }

        while (i < 3)
        {
            menuCards[i].gameObject.SetActive(false);
            i++;
        }
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
        PlayerPoint.updatePossibilites();
        MoveMe(PlayerPoint);
        ChangeButtonImg(PlayerPoint);
    }

    //Card2 button actions
    private void ButtonCallBackCard2()
    {
        PlayerPoint = PlayerPoint.possibleOutcomes[1];
        PlayerPoint.updatePossibilites();
        MoveMe(PlayerPoint);
        ChangeButtonImg(PlayerPoint);
    }

    //Card2 button actions
    private void ButtonCallBackCard3()
    {
        PlayerPoint = PlayerPoint.possibleOutcomes[2];
        PlayerPoint.updatePossibilites();
        MoveMe(PlayerPoint);
        ChangeButtonImg(PlayerPoint);
    }
}