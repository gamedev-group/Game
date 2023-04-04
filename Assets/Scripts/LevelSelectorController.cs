using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectorController : MonoBehaviour
{
    public int level;
    public TextMeshProUGUI levelText;

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
        GameManager.instance.currentLevel = level; 
        GameManager.instance.currentLevel = level; // comment out when testing specific levels
        //open the corresponding level scene 
        SceneManager.LoadScene("Level " + level.ToString());
        print(level.ToString());
        SceneManager.LoadScene("Level" + level.ToString());
    }
}
