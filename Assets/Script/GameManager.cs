using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject LoseUI;
    // Start is called before the first frame update
    private void Awake()
	{
        instance = this;
	}
	void Start()
    {
        
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
}
