using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectorController : MonoBehaviour
{
    public int level;
    public Text levelText;

    // Start is called before the first frame update
    void Start()
    {
        levelText.text = level.ToString();
    }

    //funciton: OpenScene
    //purpose: load the corresponding level based on the button being pressed 
    public void OpenScene()
    {
        //set the current level to the level selected 
        GameManager.instance.currentLevel = level; // comment out when testing specific levels
        //open the corresponding level scene 
        print(level.ToString());
        
        //start the time 
        GameManager.instance.levelStartTime = Time.time; 

        SceneManager.LoadScene("Level" + level.ToString());
    }
}
