using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initialization : MonoBehaviour
{
    int index;

    [SerializeField] GameObject[] aiCharacters;

    // Start is called before the first frame update
    void Awake()
    {
        index = GameManager.instance.charIndex;
        aiCharacters[index-1].SetActive(true);
    }



}
