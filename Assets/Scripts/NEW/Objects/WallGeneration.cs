
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class WallGeneration : MonoBehaviour
{
    [SerializeField] private GameObject brickPrefab;
    [SerializeField] private int rows = 20;
    [SerializeField] private int columns = 5;
    [SerializeField] private float brickBreadth = 0.5f;
    [SerializeField] private float brickHeight = 0.2f;

    private float alternateHalfBrickDistance;
    private Vector3 currentPosition;

    public void GenerateWall()
    {
        currentPosition = transform.position;

        for (int i = 0; i < rows; i++)
        {
            alternateHalfBrickDistance = (i % 2 == 0)? 0f: brickBreadth / 2f;

            for (int j = 0; j < columns; j++)
            {
                Vector3 brickPosition = currentPosition +
                    new Vector3(
                        j * brickBreadth + alternateHalfBrickDistance,
                        i * brickHeight,
                        0f
                    );

                #if UNITY_EDITOR
                GameObject brick = (GameObject)
                    PrefabUtility.InstantiatePrefab(brickPrefab, transform);

                Undo.RegisterCreatedObjectUndo(brick, "Generate Wall");

                brick.transform.position = brickPosition;
                brick.transform.rotation = transform.rotation;
                #else
                Instantiate(brickPrefab, brickPosition, transform.rotation, transform);
                #endif
            }
        }
    }

    public void ClearWall()
    {
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            GameObject brick = transform.GetChild(i).gameObject;

            #if UNITY_EDITOR
            Undo.DestroyObjectImmediate(brick);
            #else
            Destroy(brick);
            #endif
        }
    }
}
