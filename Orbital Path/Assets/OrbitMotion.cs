using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class OrbitMotion : MonoBehaviour
{
    public Transform orbitingObject;
    public Ellipse orbitPath;

    //Segments for the ellipse
    [Range(3, 100)]
    public int segments = 60;

    [Range(0f, 1f)]
    public float orbitProgress = 0f;
    public float orbitPeriod = 3f;
    public bool orbitActive = true;

    //For showing the orbit
    LineRenderer lr;

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (orbitingObject == null)
        {
            orbitActive = false;
            return;
        }
        SetOrbitingObjectPosition();
        StartCoroutine(AnimateOrbit());
    }

    void SetOrbitingObjectPosition()
    {
        //For rotating the object/sphere
        Vector2 orbitPos = orbitPath.Evaluate(orbitProgress);
        orbitingObject.localPosition = new Vector3(orbitPos.x, 0, orbitPos.y);

        //For showing the orbits
        //CalculateEllipse();
    }

    IEnumerator AnimateOrbit()
    {
        if (orbitPeriod < 0.1f)
        {
            orbitPeriod = 0.1f;
        }
        float orbitSpeed = 1f / orbitPeriod;

        while(orbitActive)
        {
            orbitProgress += Time.deltaTime * orbitSpeed;
            orbitProgress %= 1f;
            SetOrbitingObjectPosition();
            yield return null;
        }

    }

    void CalculateEllipse()
    {
        Vector3[] points = new Vector3[segments + 1];

        for (int i = 0; i < segments; i++)
        {
            Vector2 position2D = orbitPath.Evaluate(orbitProgress);
            points[i] = new Vector3(position2D.x, position2D.y, 0f);
        }

        points[segments] = points[0];
        lr.positionCount = segments + 1;
        lr.SetPositions(points);
    }

}
