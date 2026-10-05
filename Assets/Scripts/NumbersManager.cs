using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NumbersManager : MonoBehaviour
{
    public Button Button1;
    public Button Button2;
    public Button Button3;
    public Button Button4;
    public Button Button5;
    public Button Button6;
    public Button Button7;
    public Button Button8;
    public Button Button9;

    [SerializeField]
    private TextMeshProUGUI NumberDisplay;
    [SerializeField]
    private TextMeshProUGUI NumberInput;
    [SerializeField]
    private TextMeshProUGUI TimerText;
    public float time = 60.0f;

    public int[] Numbers;
    void Start()
    {
        NumberDisplay.text = string.Format(Numbers[0].ToString());

        Button1.onClick.AddListener(() => Debug.Log("CLICK 1"));
        Button2.onClick.AddListener(() => Debug.Log("CLICK 2"));
        Button3.onClick.AddListener(() => Debug.Log("CLICK 3"));
        Button4.onClick.AddListener(() => Debug.Log("CLICK 4"));
        Button5.onClick.AddListener(() => Debug.Log("CLICK 5"));
        Button6.onClick.AddListener(() => Debug.Log("CLICK 6"));
        Button7.onClick.AddListener(() => Debug.Log("CLICK 7"));
        Button8.onClick.AddListener(() => Debug.Log("CLICK 8"));
        Button9.onClick.AddListener(() => Debug.Log("CLICK 9"));

    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        TimerText.text = string.Format("Time: " + time.ToString());
    }

    private void NumberFunction(int number)
    {
        Debug.Log(number);
        NumberInput.text += number.ToString();
    }

}
