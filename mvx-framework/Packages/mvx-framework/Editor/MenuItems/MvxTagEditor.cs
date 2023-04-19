using MvxFramework.UnityEngine.Views;
using UnityEditor;

namespace MvxFramework.Editor.MenuItems
{
    public static class MvxTagEditor
    {
        [MenuItem("MvxFramework/RefreshSortingLayers")]
        public static void MvxRefreshSortingLayers()
        {
            var layerType = typeof(MvxUIDefine.LAYER);

            var tagManager =
                new SerializedObject(AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/TagManager.asset")[0]);
            var layersProp = tagManager.FindProperty("m_SortingLayers");
            layersProp.ClearArray();

            var index = 0;
            foreach (var field in layerType.GetFields())
            {
                layersProp.InsertArrayElementAtIndex(index);
                layersProp.GetArrayElementAtIndex(index).FindPropertyRelative("name").stringValue =
                    field.GetValue(layerType).ToString();
                index++;
            }

            tagManager.ApplyModifiedProperties();
            AssetDatabase.SaveAssets();
        }
    }
}