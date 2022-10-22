using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class motiongraph : MonoBehaviour
{
    private List<GameObject> newPoints = new List<GameObject>();

    [SerializeField] int m_totalPoints = 20;
    [SerializeField] float m_separation = 1f;
    [SerializeField] float m_amplitude = 0.7f;
    [SerializeField] private GameObject m_Prefab;

    private void Start()
    {
        for (int i = 0; i < m_totalPoints; i++)
        {
            var newPoint = Instantiate(m_Prefab, transform);
            newPoints.Add(newPoint);
        }
    }
    private void Update()
    {
        for (int i = 0; i < m_totalPoints; i++)
        {
            var newPoint = newPoints[i];
            float x = i * m_separation;
            float y = m_amplitude * Mathf.Sin(i + Time.time);
            newPoint.transform.localPosition = new Vector3(x, y);
        }
    }
}