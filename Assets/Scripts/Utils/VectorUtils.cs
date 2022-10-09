using UnityEngine;

namespace Utils
{
    public static class VectorUtils
    {
        // https://docs.unity3d.com/ScriptReference/GameObject.FindGameObjectsWithTag.html
        public static GameObject FindClosestByTag(Vector3 position, string tag)
        {
            GameObject[] gos;
            gos = GameObject.FindGameObjectsWithTag("Enemy");
            GameObject closest = null;
            float distance = Mathf.Infinity;
            foreach (GameObject go in gos)
            {
                Vector3 diff = go.transform.position - position;
                float curDistance = diff.sqrMagnitude;
                if (curDistance < distance)
                {
                    closest = go;
                    distance = curDistance;
                }
            }
            return closest;
        }
    }
}