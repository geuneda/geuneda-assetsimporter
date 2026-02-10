using UnityEngine;
using UnityEngine.AddressableAssets;

// ReSharper disable once CheckNamespace

namespace Geuneda.AssetsImporter
{
	/// <summary>
	/// 씬을 위한 <see cref="AssetReference"/> 구현
	/// </summary>
	[System.Serializable]
	public class AssetReferenceScene : AssetReference
	{
		/// <summary>
		/// 새 AssetReference 객체를 생성합니다.
		/// </summary>
		/// <param name="guid">에셋의 GUID입니다.</param>
		public AssetReferenceScene(string guid) : base(guid)
		{
		}
 
		/// <inheritdoc/>
		public override bool ValidateAsset(Object obj)
		{
#if UNITY_EDITOR
			var type = obj.GetType();
			return typeof(UnityEditor.SceneAsset).IsAssignableFrom(type);
#else
			return false;
#endif
		}
 
		/// <inheritdoc/>
		public override bool ValidateAsset(string path)
		{
#if UNITY_EDITOR
			var type = UnityEditor.AssetDatabase.GetMainAssetTypeAtPath(path);
			return typeof(UnityEditor.SceneAsset).IsAssignableFrom(type);
#else
			return false;
#endif
		}
 
#if UNITY_EDITOR
		/// <summary>
		/// 부모 editorAsset의 타입별 오버라이드입니다. 에디터에서 참조된 에셋을 나타내는 데 사용됩니다.
		/// </summary>
		public new UnityEditor.SceneAsset editorAsset => (UnityEditor.SceneAsset)base.editorAsset;
#endif
	}
}