using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Anode nodeData;
    public int gridX, gridY;
    bool isGizmoOn = false;
    public Color gizmoColor;
    
    public void Init(int gridX, int gridY)
    {
        this.gridX = gridX;
        this.gridY = gridY;
        nodeData = new Anode(true, gridX, gridY, 1, this);

    }

    public void SetGizmoOn(bool isOn)
    {
        isGizmoOn = isOn;
    }

    public void SetGizmoColor(Color color)
    {
        gizmoColor = color;
    }

    private void OnDrawGizmos()
    {
        if (!isGizmoOn) return;
        Vector3 height = new Vector3(0, 1, 0);
        Gizmos.DrawSphere(this.transform.position + height, 0.5f);
        Gizmos.color = gizmoColor;

    }

}
