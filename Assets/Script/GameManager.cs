using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject LoseUI;
    public GameObject InGameUI;
    public GameObject WinUI;
    public GameObject GrowUI;
    public GameObject playUI;
    public Image slider;
    //private float targetProgress = 0;
    public float fillSpeed = 0.5f;
    public Text progress;
    public bool play = false;
    // Start is called before the first frame update
    private void Awake()
	{
        instance = this;
	}
	void Start()
    {
        playUI.SetActive(true);
    }
    public void Play()
	{
        play = true;
        playUI.SetActive(false);
        LoseUI.SetActive(false);
        WinUI.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowLoseUI()
    {
        LoseUI.SetActive(true);

    }
    public void ShowInGame()
	{
        LoseUI.SetActive(false);

    }
    public void ShowWinUI()
    {
        WinUI.SetActive(true);

    }
    public void ShowGrowUI()
    {
        GrowUI.SetActive(true);
        StartCoroutine(waiter());
        



    }
    public void HideGrowUI()
    {
        GrowUI.SetActive(false);

    }
    public void SetProgress(float newProgress)
    {
        slider.fillAmount = newProgress;
        progress.text = (slider.fillAmount * 100).ToString("00") + "%";

    }
   /* public void DecrementProgress(float newProgress)
    {
        slider.fillAmount -= newProgress;
        progress.text = (slider.fillAmount * 100).ToString("00") + "%";

    }*/

    internal void SetProgress()
	{
		throw new NotImplementedException();
	}
    IEnumerator waiter()
    {
       
        yield return new WaitForSecondsRealtime(0.5f);
        transform.DOMove(new Vector3(2, 3, 4), 1);
        GrowUI.SetActive(false);



       
    }
}
