using UnityEditor;
using UnityEngine;

// ReSharper disable once CheckNamespace

namespace GeunedaEditor.AssetsImporter
{
	/// <summary>
	/// Addressables Id 생성기 설정을 담는 ScriptableObject
	/// </summary>
	[CreateAssetMenu(fileName = "AddressablesIdGenerator Settings", menuName = "ScriptableObjects/Editor/AddressablesIdGenerator")]
	public class AddressablesIdGeneratorSettings : ScriptableObject
	{
		public string ScriptFilename = "AddressableId";
		public string Namespace = "Game.Ids";
		public string AddressableLabel = "GenerateIds";

		[MenuItem("Tools/AddressableIds Generator/Select Settings.asset")]
		public static AddressablesIdGeneratorSettings SelectSheetImporter()
		{
			var settings = AssetDatabase.FindAssets($"t:{nameof(AddressablesIdGeneratorSettings)}");
			var scriptableObject = settings.Length > 0 ?
									   AssetDatabase.LoadAssetAtPath<AddressablesIdGeneratorSettings>(AssetDatabase.GUIDToAssetPath(settings[0])) :
									   CreateInstance<AddressablesIdGeneratorSettings>();

			if (settings.Length == 0)
			{
				AssetDatabase.CreateAsset(scriptableObject, $"Assets/{nameof(AddressablesIdGeneratorSettings)}.asset");
				AssetDatabase.SaveAssets();
				AssetDatabase.Refresh();
			}

			Selection.activeObject = scriptableObject;

			return scriptableObject;
		}
	}
}