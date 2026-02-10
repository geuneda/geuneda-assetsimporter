using UnityEditor;
using UnityEngine;

// ReSharper disable once CheckNamespace

namespace GeunedaEditor.AssetsImporter
{
	/// <summary>
	/// 모든 또는 특정 에셋 데이터를 임포트하는 ScriptableObject 도구
	/// </summary>
	[CreateAssetMenu(fileName = "AssetsImporter", menuName = "ScriptableObjects/Editor/AssetsImporter")]
	public class AssetsImporter : ScriptableObject
	{
		public static bool AutoUpdateOnRefresh;
		
		[MenuItem("Tools/Assets Importer/Select AssetsImporter.asset")]
		private static void SelectAssetsImporter()
		{
			var assets = AssetDatabase.FindAssets($"t:{nameof(AssetsImporter)}");
			var scriptableObject = assets.Length > 0 ? 
				                       AssetDatabase.LoadAssetAtPath<AssetsImporter>(AssetDatabase.GUIDToAssetPath(assets[0])) :
				                       CreateInstance<AssetsImporter>();

			if (assets.Length == 0)
			{
				AssetDatabase.CreateAsset(scriptableObject, $"Assets/{nameof(AssetsImporter)}.asset");
				AssetDatabase.SaveAssets();
				AssetDatabase.Refresh();
			}

			Selection.activeObject = scriptableObject;
		}
	}
}