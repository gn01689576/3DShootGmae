using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public bool dead = false;
    public GameObject REM;
    bool pause;
    [SerializeField] GameObject replayButton;
    [SerializeField] REMcontroller remcontroller;
    
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (dead == true)
        {
            REMcontroller.monsterScore = 0;
            GameObject.Find("REM").GetComponent<REMcontroller>().SvaeData();
            REM.transform.rotation = Quaternion.LookRotation(Vector3.down);            
            replayButton.SetActive(true);
            Time.timeScale = 0;

           /*f (Input.GetKey(KeyCode.Return))
            {
                Application.LoadLevel(Application.loadedLevel);
                Time.timeScale = 1;
                return;
            }*/
        }
        if (dead == false)
        {
            if (Input.GetKey(KeyCode.P))
            {
                Time.timeScale = 0;
                pause = true;
            }
            if (pause == true)
            {
                if (Input.GetKey(KeyCode.P))
                {
                    Time.timeScale = 1;
                    pause = false;
                }
            }
            return;
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
                
        
        
    }
    public void replay()
    {
        SceneManager.LoadScene("shoot");
        //Time.timeScale = 1;
        
    }

    
}
