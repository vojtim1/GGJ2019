using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }

    void RestartGame()
    {

    }
}
