using UnityEngine;
using System.Collections.Generic;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject platformPrefab;
    public int numberOfPlatforms = 5;

    public float xMin = 40f;    //Lake Start
    public float xMax = 60f;    //Lake end
    public float zMin = 65f;    //Zone of interest boundary
    public float zMax = 80f;    //Zone of interest boundary


    public float maxJumpDistance = 5f;
    public float platformY = 0.25f;

    private List<Vector3> platforms = new List<Vector3>();

    //void Start()
    //{
    //    GeneratePlatforms();
    //}

    public void GeneratePlatforms()
    {


        // Place the first platform near the edge of the lake

        float ZCoord = Random.Range(zMin, zMax);
        Vector3 firstPlatform = new Vector3(Random.Range(xMin + 1, xMin + 5), platformY, ZCoord);
        platforms.Add(firstPlatform);

        for (int i = 1; i < numberOfPlatforms; i++)
        {
            Vector3 previousPlatform = platforms[i - 1];
            Vector3 newPlatform = Vector3.zero;
            

            float Xoffset = Random.Range(2.5f, 4f); //insure the offset is within jump boundary 

            //Calculate the remaining distance the player can jump

            float Zoffset = CalculateSideB(Xoffset, 5f);

            // Randomly decide whether remDistance should be positive or negative
            Zoffset *= Random.value > 0.5f ? 1 : -1;

            newPlatform.x = previousPlatform.x + Xoffset;
            newPlatform.y = platformY;
            newPlatform.z = previousPlatform.z + Zoffset;



            platforms.Add(newPlatform);
        }


        // Instantiate platforms in Unity
        foreach (Vector3 position in platforms)
        {
            Instantiate(platformPrefab, position, Quaternion.identity);
        }
    }

    public static float CalculateSideB(float a, float c)
    {
        // Ensure c is greater than a to avoid invalid square root operation
        if (c <= a)
        {
            Debug.LogError("Hypotenuse must be greater than the other side.");
            return float.NaN; // Not a Number to indicate an error
        }

        // Calculate b using Pythagorean theorem
        float b = Mathf.Sqrt(c * c - a * a);
        return b;
    }
}
