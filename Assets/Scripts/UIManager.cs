using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text _tapText;
    [SerializeField]private Text _KillsCount;
    [SerializeField] private GameObject LightColor;
    public string TapWhite;
    public string TapBlack;
    public int _kills = 0;

    private void Start()
    {
    }

    // Start is called before the first frame update
    public void ExitGame()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        _KillsCount.text = _kills.ToString();
        if (LightColor.transform.rotation.y>0)
        {
            _tapText.text = TapWhite;
            _tapText.color= Color.black;
        }
        if(LightColor.transform.rotation.y<0)
        {
            _tapText.text = TapBlack;
            _tapText.color= Color.white;

        }
    }
}
