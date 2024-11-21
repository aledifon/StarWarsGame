using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject panelGameObject;
    [SerializeField]
    private EnemyManager enemyManager;

    //This method is the one we'll call when we press the retry button
    public void LoadSceneLevel()
    {
        SceneManager.LoadScene("Level01");
    }

    public void GameOver()
    {
        panelGameObject.SetActive(true);
        enemyManager.enabled = false;                   // Disable the EnemyManager Component
        Cursor.lockState = CursorLockMode.Confined;     // Unlock the cursor
    }
}
