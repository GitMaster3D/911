using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        PlayerControllerBase.Instance.OnDie += GoToMenue;
    }

    public void GoToMenue()
    {
        SceneManager.LoadScene("MainMenue");
    }
}
