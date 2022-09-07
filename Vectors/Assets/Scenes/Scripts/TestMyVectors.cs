using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMyVectors : MonoBehaviour
{
    [SerializeField]
    private MyVector myFirstVector, mySecondVector;
    [SerializeField, Range(0, 1)]
    private float factor = 0;

    void Update()
    {
        myFirstVector.Draw(Color.blue);
        mySecondVector.Draw(Color.green);
        MyVector lerp = myFirstVector.Lerp(myFirstVector, mySecondVector, factor);
        lerp.Draw(Color.red);

        MyVector diff = myFirstVector - lerp;
        diff.Draw(lerp, Color.yellow);
    }
}
