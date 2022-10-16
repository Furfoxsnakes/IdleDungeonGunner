using Cinemachine;
using UnityEngine;
using Utilities;

namespace Common
{
    [RequireComponent(typeof(CinemachineTargetGroup))]
    public class CinemachineTarget : MonoBehaviour
    {
        private CinemachineTargetGroup _cinemachineTargetGroup;
        private GameObject _cursor;

        private void Awake()
        {
            _cinemachineTargetGroup = GetComponent<CinemachineTargetGroup>();
            // create an empty object for cinemachine group to follow for cursor
            _cursor = new GameObject("CursorTarget");
        }

        private void Start()
        {
            SetCinemachineTargetGroup();
        }

        private void Update()
        {
            _cursor.transform.position = HelperUtilities.GetMouseWorldPos();
        }

        private void SetCinemachineTargetGroup()
        {
            var cinemachineTargetGroupPlayer = new CinemachineTargetGroup.Target
            {
                weight = 1f,
                radius = 5f,
                target = Engine.E.Player.transform
            };
            
            var cinemachineTargetGroupCursor = new CinemachineTargetGroup.Target
            {
                weight = 1f,
                radius = 1f,
                target = _cursor.transform
            };

            _cinemachineTargetGroup.m_Targets = new CinemachineTargetGroup.Target[] {cinemachineTargetGroupPlayer, cinemachineTargetGroupCursor};
        }
    }
}