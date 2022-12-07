using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class LevelSelector : MonoBehaviour
{
    public static int selectedLevel;
    public int level;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void OpenScene()
    {
        selectedLevel = level;
        SceneManager.LoadScene(selectedLevel);
    }
}
