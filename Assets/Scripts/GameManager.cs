using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float MenueDelay;
    
    void Start()
    {
        PlayerControllerBase.Instance.OnDie += GoToMenue;
    }

    public void GoToMenue()
    {
        StartCoroutine(SceneChange());
    }

    private IEnumerator SceneChange()
    {
        yield return new WaitForSeconds(MenueDelay);
        SceneManager.LoadScene("MainMenue");
    }
}
