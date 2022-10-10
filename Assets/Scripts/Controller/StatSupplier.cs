using System;
using UnityEngine;

namespace Controller
{
    public class StatSupplier : MonoBehaviour
    {
        [SerializeField] private ScriptableObject stat;

        public T GetStat<T>()
        {
            try
            {
                return (T) (object) stat; // Feo
            }
            catch (InvalidCastException)
            {
                throw new InvalidStatTypeException();
            }
            
        }
    }

    public class InvalidStatTypeException : Exception
    {
    }
}