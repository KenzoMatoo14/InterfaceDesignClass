using UnityEngine;
using UnityEngine.UI;

public class PlanetsUI : MonoBehaviour
{
    public GameObject[] Planets;

    public Transform[] Positions;

    public Button ButtonPrev;
    public Button ButtonNext;
    void Start()
    {
        if (ButtonPrev != null)
            ButtonPrev.onClick.AddListener(Prev);
        if (ButtonNext != null)
            ButtonNext.onClick.AddListener(Next);
    }

    private void Prev()
    {
        GameObject temp = Planets[2];

        Planets[2] = Planets[1];
        Planets[1] = Planets[0];
        Planets[0] = temp;

        for (int i = 0; i < Planets.Length; i++)
        {
            Planets[i].transform.position = Positions[i].position;
        }
    }
    private void Next()
    {
        GameObject temp = Planets[0];

        Planets[0] = Planets[1];
        Planets[1] = Planets[2];
        Planets[2] = temp;

        for (int i = 0; i < Planets.Length; i++)
        {
            Planets[i].transform.position = Positions[i].position;
        }
    }
}
