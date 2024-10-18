using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject score;
    [SerializeField] private GameObject timer;
    [SerializeField] private GameObject bullets;
    [SerializeField] private GameObject play;
    [SerializeField] private GameObject title;
    [SerializeField] private GameObject instruction;
    public static bool playPressed;
    void Awake()
    {
        playPressed = false;
        score.SetActive(false);
        timer.SetActive(false);
        bullets.SetActive(false);
        play.SetActive(true);
        title.SetActive(true);
        instruction.SetActive(true);
    }
    public void Play(){
        playPressed = true;
        score.SetActive(true);
        timer.SetActive(true);
        bullets.SetActive(true);
        play.SetActive(false);
        title.SetActive(false);
        instruction.SetActive(false);
    }
}
