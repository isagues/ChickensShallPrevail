using UnityEngine;

namespace Utils
{
    public static class VectorUtils
    {
        // https://docs.unity3d.com/ScriptReference/GameObject.FindGameObjectsWithTag.html
        public static GameObject FindClosestByTag(Vector3 position, string tag)
        {
            var gos = GameObject.FindGameObjectsWithTag(tag);
            GameObject closest = null;
            var distance = Mathf.Infinity;
            foreach (var go in gos)
            {
                var curDistance = Distance(go.transform.position, position);
                if (!(curDistance < distance)) continue;
                
                closest = go;
                distance = curDistance;
            }
            return closest;
        }

        public static float Distance(Vector3 v1, Vector3 v2)
        {
            return (v1 - v2).sqrMagnitude;
        }
    }
}