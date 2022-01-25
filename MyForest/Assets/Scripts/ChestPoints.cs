using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class ChestPoints : MonoBehaviour
{
    public GameObject medkitChest;
    public GameObject ammoChest;
    public GameObject keyChest;

    public int medkitChestCount;
    public int ammoChestCount;
    public int keyChestCount;
    
    private ArrayList allChestPoints;
    private Transform chestPoint;
    
    // Start is called before the first frame update
    void Start()
    {
        allChestPoints = new ArrayList();
        
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            allChestPoints.Add(gameObject.transform.GetChild(i));
        }

        GameObject enviroment = GameObject.Find("Enviroment");

        for (int i = 5; i <= 8; i++)
        {
            Transform objectsListTransform = enviroment.transform.GetChild(i);

            for (int j = 0; j < objectsListTransform.childCount; j++)
            {
                Transform gameObjectTransform = objectsListTransform.GetChild(j);
                
                Transform chestPoints = gameObjectTransform.GetChild(gameObjectTransform.childCount - 1);

                for (int z = 0; z < chestPoints.childCount; z++)
                {
                    allChestPoints.Add(chestPoints.GetChild(z));
                }
            }
        }
        
        SpawnChest(medkitChest, medkitChestCount);
        SpawnChest(ammoChest, ammoChestCount);
        SpawnChest(keyChest, keyChestCount);

    }

    private void SpawnChest(GameObject chest, int count)
    {
        for (int i = 0; i < count; i++)
        {
            if (allChestPoints.Capacity>0)
            {
                int randomIndex = Random.Range(0, (allChestPoints.Count - 1));
                chestPoint = (Transform) allChestPoints[randomIndex];

                Quaternion quaternion = new Quaternion(); // 0,0,0
                
                GameObject createdChest = Instantiate(chest, chestPoint.transform.position, quaternion);
                createdChest.transform.SetParent(chestPoint);
                createdChest.transform.rotation = quaternion; //Reset Rotation (Rotation was changed in SetParent)
            
                Debug.Log(chestPoint.transform.position.x + " " + chestPoint.transform.position.y + " " + chestPoint.transform.position.z);
                
                allChestPoints.Remove(chestPoint);
            }
        }
    }
}
