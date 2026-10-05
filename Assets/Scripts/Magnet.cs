using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    public string PivotTag;
    public float MinDistance = 0.5f;
    private GameObject[] _Pivots;
    public static string MagnetTag = "Magnet";
    public int InputNumber;

    public NumbersManagerDrag NDManager; 
    public static void CheckMagnet(Transform piece)
    {
        GameObject magnetGO = GameObject.FindWithTag(MagnetTag);
        if (magnetGO != null)
        {
            Magnet magnet = magnetGO.GetComponent<Magnet>();
            if (magnet != null)
            {
                magnet.CheckMagnetWithPivots(piece);
            }
        }
    }

    public void CheckMagnetWithPivots(Transform piece)
    {
        float minDistance = MinDistance * 2.0f;
        Transform minDistanceTransform = null;

        foreach (GameObject pivot in _Pivots)
        {
            float distance = Vector3.Distance(pivot.transform.position, piece.position);
            if (distance <= MinDistance && distance < minDistance)
            {
                minDistance = distance;
                minDistanceTransform = pivot.transform;
            }
        }

        if (minDistance != MinDistance * 2.0f)
        {
            piece.position = minDistanceTransform.position;

            UnityEngine.Debug.Log("La pieza con Tag [" + piece.tag + "] fue colocada en el cuadro: " + minDistanceTransform.name);

            if (minDistanceTransform.name == "Pivot")
            {
                if (piece.CompareTag("Tile1")){
                    UnityEngine.Debug.Log("First Digit: 1");
                    InputNumber += 1000;
                }
                else if (piece.CompareTag("Tile2"))
                {
                    UnityEngine.Debug.Log("First Digit: 2");
                    InputNumber += 2000;
                }
            }
            if (minDistanceTransform.name == "Pivot (1)")
            {
                if (piece.CompareTag("Tile1"))
                {
                    UnityEngine.Debug.Log("Second Digit: 1");
                    InputNumber += 100;
                }
                else if (piece.CompareTag("Tile2"))
                {
                    UnityEngine.Debug.Log("Second Digit: 2");
                    InputNumber += 200;
                }
            }
            if (minDistanceTransform.name == "Pivot (2)")
            {
                if (piece.CompareTag("Tile1"))
                {
                    UnityEngine.Debug.Log("Third Digit: 1");
                    InputNumber += 10;
                }
                else if (piece.CompareTag("Tile2"))
                {
                    UnityEngine.Debug.Log("Third Digit: 2");
                    InputNumber += 20;
                }
            }
            if (minDistanceTransform.name == "Pivot (3)")
            {
                if (piece.CompareTag("Tile1"))
                {
                    UnityEngine.Debug.Log("Forth Digit: 1");
                    InputNumber += 1;
                }
                else if (piece.CompareTag("Tile2"))
                {
                    UnityEngine.Debug.Log("Forth Digit: 2");
                    InputNumber += 2;
                }
            }

            UnityEngine.Debug.Log("InputNumber: " + InputNumber);

            DetectarNumero(InputNumber, NDManager.Number);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _Pivots = GameObject.FindGameObjectsWithTag(PivotTag);
    }

    public void DetectarNumero(int InputNumber, int DesiredNumber)
    {
        if (InputNumber == DesiredNumber)
        {
            UnityEngine.Debug.Log("Número correcto");
        }
        else
        {
            UnityEngine.Debug.Log("Número incorrecto");
        }
    }
}

