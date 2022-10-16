using System.Collections;
using System.Collections.Generic;
using Character;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities.Editor;
using UnityEditor;
using UnityEngine;

public class MovementDetailsEditor : OdinMenuEditorWindow
{
    private CreateNewMovementDetails _createNewMovementDetails;
    
    [MenuItem("Tools/Movement Details")]
    private static void OpenWindow()
    {
        GetWindow<MovementDetailsEditor>().Show();
    }

    protected override OdinMenuTree BuildMenuTree()
    {
        var tree = new OdinMenuTree();

        _createNewMovementDetails = new CreateNewMovementDetails();

        tree.Add("Create New", _createNewMovementDetails);
        
        tree.AddAllAssetsAtPath("Movement Details", "Assets/ScriptableObjects/Characters/Movement",
            typeof(MovementDetails));
        
        return tree;
    }

    protected override void OnBeginDrawEditors()
    {
        var selected = MenuTree.Selection;

        SirenixEditorGUI.BeginHorizontalToolbar();
        {
            GUILayout.FlexibleSpace();

            if (SirenixEditorGUI.ToolbarButton("Delete Current"))
            {
                var asset = selected.SelectedValue as MovementDetails;
                var path = AssetDatabase.GetAssetPath(asset);
                AssetDatabase.DeleteAsset(path);
                AssetDatabase.SaveAssets();
            }
        }
        SirenixEditorGUI.EndHorizontalToolbar();
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        if (_createNewMovementDetails != null)
            DestroyImmediate(_createNewMovementDetails.MovementDetails);
    }

    public class CreateNewMovementDetails
    {
        [InlineEditor(ObjectFieldMode = InlineEditorObjectFieldModes.Hidden)]
        public MovementDetails MovementDetails;

        public CreateNewMovementDetails()
        {
            MovementDetails = ScriptableObject.CreateInstance<MovementDetails>();
            MovementDetails.Name = "New Movement Details";
        }

        [Button("Add New Movement Details")]
        private void CreateNewDetails()
        {
            AssetDatabase.CreateAsset(MovementDetails, $"Assets/ScriptableObjects/Characters/Movement/MovementDetails_{MovementDetails.Name}.asset");
            AssetDatabase.SaveAssets();
            
            MovementDetails = ScriptableObject.CreateInstance<MovementDetails>();
            MovementDetails.Name = "New Movement Details";
        }
    }
}
