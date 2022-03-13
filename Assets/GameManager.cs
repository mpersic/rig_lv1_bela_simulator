using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text MainText;
    public State GameState;

    public enum State
    {
        start, next, nextYourTeammate, chooseContract, fourJacks, victory, cheatingDefeat, contractDefeat, defeat
    };

    // Start is called before the first frame update
    void Start()
    {
        GameState = State.start;
        //SoundManagerScript.PlaySound();
    }

    // Update is called once per frame
    void Update()
    {
        switch (GameState)
        {
            case State.start:
                StartGame();
                break;

            case State.next:
                Next();
                break;

            case State.nextYourTeammate:
                NextYourTeammate();
                break;

            case State.chooseContract:
                ChooseContract();
                break;

            case State.fourJacks:
                FourJacks();
                break;

            case State.victory:
                Victory();
                break;

            case State.cheatingDefeat:
                CheatingDefeat();
                break;

            case State.defeat:
                Defeat();
                break;

            case State.contractDefeat:
                ContractDefeat();
                break;

            default:
                StartGame();
                break;

        }
    }

    void StartGame()
    {
        MainText.text = "The score is 830-900 for them, you are dealing cards. The enemy team is already " +
            "won in their heads, but it is not over yet. " +
            "\nPress S to continue.";
        if (Input.GetKeyDown(KeyCode.S))
        {
            GameState = State.next;
        }
    }

    void Next()
    {
        MainText.text = "Enemy team is giggling, which probably indicates they have good cards and will force you to choose a contract." +
            "\nPress A to signalize to your teammate that this won't finish well. He needs to choose hearts as a contract!" +
            "\nPress S to keep calm";
        if (Input.GetKeyDown(KeyCode.A))
        {
            GameState = State.cheatingDefeat;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            GameState = State.nextYourTeammate;
        }
    }

    void NextYourTeammate()
    {
        MainText.text = "Your teammate doesnt look too enthusiastic. He lets the enemy choose contract" +
            "\nYou need to choose a contract!" +
            "\nPress S to think";
        if (Input.GetKeyDown(KeyCode.S))
        {
            GameState = State.chooseContract;
        }
    }

    void ChooseContract()
    {
        MainText.text = "You have 3 jacks and are strong in hearts. The only jack missing is the hearts?" +
            "\nPress S to call hearts!" +
            "\nPress A to choose bells!";
        if (Input.GetKeyDown(KeyCode.S))
        {
            GameState = State.contractDefeat;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            GameState = State.fourJacks;
        }
    }

    void FourJacks()
    {
        MainText.text = "You got the fourth jack!"
            + "\nPress A to kick their lower back connecting with legs!";
        if (Input.GetKeyDown(KeyCode.A))
        {
            GameState = State.victory;
        }
    }

    void ContractDefeat()
    {
        MainText.text = "You didnt get the jack of hearts! Enemies have 150 declaration points!"
                    + "\nPress A to play the game";
        if (Input.GetKeyDown(KeyCode.A))
        {
            GameState = State.defeat;
        }
    }

    void Victory()
    {
        MainText.text = "You won! Congratulations!" +
                   "\nPress S for a new game!";
        if (Input.GetKeyDown(KeyCode.S))
        {
            GameState = State.start;
        }
    }

    void Defeat()
    {
        MainText.text = "You lost!" +
                   "\nPress S to try again!";
        if (Input.GetKeyDown(KeyCode.S))
        {
            GameState = State.start;
        }
    }

    void CheatingDefeat()
    {
        MainText.text = "You cant cheat!" +
                    "\nPress S to continue";
        if (Input.GetKeyDown(KeyCode.S))
        {
            GameState = State.defeat;
        }
    }

}
