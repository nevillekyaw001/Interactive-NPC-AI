using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] GameObject firstFrame;
    [SerializeField] GameObject secondFrame;
    [SerializeField] GameObject thirdFrame;
    [SerializeField] GameObject[] backgrounds;

    int index;

    // Start is called before the first frame update
    void Start()
    {
        index = Random.Range(0,3);
        backgrounds[index].SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Back();
        }
    }

    public void SetRandomBackgroundActive(int index)
    {
        if (index >= 0) // check if the index is within the array bounds
        {
            backgrounds[index].SetActive(true); // activate the game object at the specified index
        }
    }
    public void Talk(int index)
    {
        GameManager.instance.charIndex = index;
        SceneManager.LoadScene(1);
    }

    public void TouchToContinue()
    {
        firstFrame.SetActive(false);
        secondFrame.SetActive(true);  
    }
    public void Back()
    {
        firstFrame.SetActive(true);
        secondFrame.SetActive(false);
    }

    public void InfoButton()
    {
        secondFrame.SetActive(false);
        thirdFrame.SetActive(true);
    }
    public void InfoBackButton()
    {
        secondFrame.SetActive(true);
        thirdFrame.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
