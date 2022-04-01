using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager instance;
    private TurretBlueprint turretToBuild;
    private Node selectedNode;
    public GameObject buildEffect;

    //in order to make this method accesible to any object in the game, we're using a singleton
    //this instance variable can be accessed from anywhere
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager instance in scene");
            return;
        }
        instance = this;
    }

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Gold >= turretToBuild.cost; } }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
        selectedNode = null;
    }

    public void SelectNode(Node node)
    {
        selectedNode = node;
        turretToBuild = null;
    }

    public void BuildTurretOn(Node node)
    {
        if (PlayerStats.Gold < turretToBuild.cost)
        {
            Debug.Log("Not enough Gold");
            return;
        }
        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;
        GameObject effect = (GameObject)Instantiate(buildEffect, node.GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        PlayerStats.Gold -= turretToBuild.cost;
        Debug.Log(turret + " built! Gold left = " + PlayerStats.Gold);
    }


}
