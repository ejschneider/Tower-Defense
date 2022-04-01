using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    BuildManager buildManager;
    public Color hoverColor;
    private Color startColor;
    public Color notEnoughMoneyColor;

    public Vector3 turretPositionOffset;
    [Header("Optional")]
    public GameObject turret;
    private Renderer rend;

    void Start()
    {
        buildManager = BuildManager.instance;
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    void OnMouseEnter()
    {
        
        if (!buildManager.CanBuild) return;
        if (turret != null) return;

        if (buildManager.HasMoney)
            rend.material.color = hoverColor;
        else rend.material.color = notEnoughMoneyColor;
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;
        
        if (turret != null)
        {
            buildManager.SelectNode(this);
            return;
        }
        if (!buildManager.CanBuild) return;
        buildManager.BuildTurretOn(this);
    }
    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
    public Vector3 GetBuildPosition()
    {
        return transform.position + turretPositionOffset;
    }
}
