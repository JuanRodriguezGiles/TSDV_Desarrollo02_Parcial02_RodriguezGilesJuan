using TMPro;
using UnityEngine;
public class Wind : MonoBehaviour
{
    AreaEffector2D _wind;
    TMP_Text _text;
    float _time;
    void Start()
    {
        _wind = GetComponent<AreaEffector2D>();
        _text = GetComponent<TMP_Text>();
    }
    void Update()
    {
        _time += Time.deltaTime;
        if (!(_time > 3)) return;
        if (_wind.forceMagnitude == 0)
        {
            _wind.forceMagnitude = 1;
            _text.text = "W";
        }
        else
        {
            _wind.forceMagnitude = 0;
            _text.text = "";
        }
        _time = 0;
    }
}