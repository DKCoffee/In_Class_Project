using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int lifesPlayer = 3;
    private int lifesEnemy = 5;

    [SerializeField]
    private Text textLifes;

    private const string TEXT_LIFES = "Lifes : ";

	// Use this for initialization
	void Start ()
    {
		textLifes.text = TEXT_LIFES + lifesPlayer;
	}

    // Update is called once per frame
 
        
	void Update () {
		
	}

    public void PlayerDie()
    {
        lifesPlayer--;
        if(lifesPlayer <= 0)
        {
            SceneManager.LoadScene("DeadScene");
        }
        
    }

    public void EnemyDie()
    {
        lifesEnemy--;
        if(lifesEnemy <= 0)
        {
            SceneManager.LoadScene("WinScene");
        }
       
    }

    public void Life()
    {
        lifesPlayer++;
        textLifes.text = TEXT_LIFES + lifesPlayer;
    }
}
