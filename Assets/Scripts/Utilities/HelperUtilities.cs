using System.Collections;
using UnityEngine;

namespace Utilities
{
    public static class HelperUtilities
    {

        #region Validation
        
        public static bool ValidateCheckEmptyString(Object obj, string fieldName, string stringToCheck)
        {
            if (stringToCheck == "")
            {
                Debug.Log($"{fieldName} is empty and must contain a value in object {obj.name}");
                return true;
            }

            return false;
        }

        public static bool ValidateCheckNullValue(Object obj, string fieldName, Object objectToCheck)
        {
            if (objectToCheck != null) return false;
            
            Debug.Log($"{fieldName} is null and must contain a value in object {obj.name}");
            return true;

        }

        public static bool ValidateCheckEnumerableValues(Object obj, string fieldName,
            IEnumerable enumerableObjectToCheck)
        {
            var error = false;
            var count = 0;

            if (enumerableObjectToCheck == null)
            {
                Debug.Log($"{fieldName} is null in object {obj.name}");
                return true;
            }

            foreach (var item in enumerableObjectToCheck)
            {
                if (item == null)
                {
                    Debug.Log($"{fieldName} has null values in object {obj.name}");
                    error = true;
                }
                else
                {
                    count++;
                }
            }

            if (count == 0)
            {
                Debug.Log($"{fieldName} has no values in object {obj.name}");
                error = true;
            }

            return error;
        }

        public static bool ValidateCheckPositiveValue(Object obj, string fieldName, int value, bool isZeroAllowed)
        {
            var isInvalid = false;

            if (isZeroAllowed)
            {
                if (value < 0)
                {
                    Debug.Log($"{fieldName} must contain a positive or zero value in object {obj.name}");
                    isInvalid = true;
                }
            }
            else
            {
                if (value <= 0)
                {
                    Debug.Log($"{fieldName} must contain a positive value in object {obj.name}");
                    isInvalid = true;
                }
            }

            return isInvalid;
        }
        
        public static bool IsGreaterThanZero(int value) => value > 0;

        public static bool IsPositiveValue(float value) => value >= 0;
        
        public static bool ValidateCheckPositiveValue(Object obj, string fieldName, float value, bool isZeroAllowed)
        {
            var isInvalid = false;

            if (isZeroAllowed)
            {
                if (value < 0)
                {
                    Debug.Log($"{fieldName} must contain a positive or zero value in object {obj.name}");
                    isInvalid = true;
                }
            }
            else
            {
                if (value <= 0)
                {
                    Debug.Log($"{fieldName} must contain a positive value in object {obj.name}");
                    isInvalid = true;
                }
            }

            return isInvalid;
        }

        public static bool ValidateCheckPositiveRange(Object obj, string fieldNameMinimum, float minValue,
            string fieldNameMaximum, float maxValue, bool isZeroAllowed)
        {
            var error = false;

            if (minValue > maxValue)
            {
                Debug.Log($"{fieldNameMinimum} must be less than or equal to {fieldNameMaximum} in object {obj.name}");
                error = true;
            }

            if (ValidateCheckPositiveValue(obj, fieldNameMinimum, minValue, isZeroAllowed)) error = true;

            if (ValidateCheckPositiveValue(obj, fieldNameMaximum, maxValue, isZeroAllowed)) error = true;

            return error;
        }
        
        #endregion

        /// <summary>
        /// Get the world pos of the mouse
        /// </summary>
        /// <returns></returns>
        public static Vector3 GetMouseWorldPos()
        {
            var mouseScreenPos = Input.mousePosition;

            mouseScreenPos.x = Mathf.Clamp(mouseScreenPos.x, 0f, Screen.width);
            mouseScreenPos.y = Mathf.Clamp(mouseScreenPos.y, 0f, Screen.height);

            var mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);
            mouseWorldPos.z = 0f;

            return mouseWorldPos;
        }

        public static Vector2 DirectionTo(Vector2 from, Vector2 to)
        {
            var heading = to - from;
            var distance = heading.magnitude;
            return heading / distance;
        }

        public static float GetAngleFromVector(Vector3 v)
        {
            var radians = Mathf.Atan2(v.y, v.x);
            return radians * Mathf.Rad2Deg;
        }

        public static Vector3 GetDirectionVectorFromAngle(float angle)
        {
            return new Vector3()
            {
                x = Mathf.Cos(Mathf.Deg2Rad * angle),
                y = Mathf.Sin(Mathf.Deg2Rad * angle),
                z = 0f
            };
        }

        /// <summary>
        /// returns whether an interval is overlapping
        /// used in overlap checks of dungeon builder
        /// </summary>
        /// <param name="min1"></param>
        /// <param name="max1"></param>
        /// <param name="min2"></param>
        /// <param name="max2"></param>
        /// <returns></returns>
        public static bool IsOverlappingInterval(int min1, int max1, int min2, int max2) =>
            Mathf.Max(min1, min2) <= Mathf.Min(max1, max2);

        /// <summary>
        /// Convert from linear scale to logarithmic dB scale
        /// </summary>
        /// <param name="linear"></param>
        /// <returns></returns>
        public static float LinearToDecibels(int linear)
        {
            var linearScaleRange = 20f;
            return Mathf.Log10(linear / linearScaleRange) * 20f;
        }
    }
}