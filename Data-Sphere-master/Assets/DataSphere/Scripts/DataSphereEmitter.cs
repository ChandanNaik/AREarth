using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class DataSphereEmitter : MonoBehaviour
{

    public ParticleSystem system;


    //public void DataReceived(DataPointViewModel dataPoint)
    //{
    //    CreateDataPoint(dataPoint.rightAscension, dataPoint.declination, dataPoint.color);
    //}

    //private void CreateDataPoint(float rightAscension, float declination, Color color)
    //{
    //    var dataPosition = new Vector3(Mathf.Sin(rightAscension * Mathf.PI * 2) * Mathf.Cos(declination * Mathf.PI), Mathf.Sin(declination * Mathf.PI), Mathf.Cos(rightAscension * Mathf.PI * 2) * Mathf.Cos(declination * Mathf.PI));
    //    system.Emit(new ParticleSystem.EmitParams() { position = dataPosition, startColor = color }, 1);
    //}

    void Start()
    {

    }

    void Update()
    {
        CreateDataPoint(Random.value, Random.Range(-1f, 1f));
    }

    public void CreateDataPoint(float x, float y)
    {
        var dataPosition = new Vector3(Mathf.Sin(x * Mathf.PI) * Mathf.Cos(y * Mathf.PI), Mathf.Sin(y * Mathf.PI), Mathf.Cos(x * Mathf.PI) * Mathf.Cos(y * Mathf.PI));
        system.Emit(new ParticleSystem.EmitParams() { position = dataPosition, startColor = new Color((1 + dataPosition.x) * 0.5f, (1 + dataPosition.y) * 0.5f, (1 + dataPosition.z) * 0.5f) }, 1);
    }

}
