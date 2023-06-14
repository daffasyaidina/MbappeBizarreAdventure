using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Score : MonoBehaviour
{
    public TextMeshProUGUI kiwi;
    public TextMeshProUGUI KiwiText;
    private string finalTime;
    // Start is called before the first frame update
    private void Start()
    {
    }
    private void Update()
    {
        kiwi.text = KiwiText.text;
    }


}
