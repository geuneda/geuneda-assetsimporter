using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

// ReSharper disable once CheckNamespace

namespace Geuneda.AssetsImporter
{
	/// <summary>
	/// 모든 중요 데이터를 포함하는 Addressable의 설정을 나타냅니다.
	/// Id는 AddressableIdsGenerator 코드 생성기가 생성한 AddressableId의 정수 표현입니다
	/// </summary>
	[Serializable]
	public class AddressableConfig
	{
		public int Id;
		public string Address;
		public string Path;
		public string AssetFileType;
		public Type AssetType;
		public ReadOnlyCollection<string> Labels;

		public AddressableConfig(int id, string address, string path, Type assetType, string[] labels)
		{
			Id = id;
			Address = address;
			Path = path;
			AssetFileType = path.Substring(path.LastIndexOf('.') + 1);
			AssetType = assetType;
			Labels = new ReadOnlyCollection<string>(labels);
		}

		/// <summary>
		/// 이 <see cref="AddressableConfig"/>가 씬의 설정인 경우 씬 이름을 반환합니다.
		/// </summary>
		/// <exception cref="InvalidOperationException">
		/// 이 <see cref="AddressableConfig"/>가 씬의 설정이 아닌 경우 발생합니다
		/// </exception>
		public string GetSceneName()
		{
			if (AssetType != typeof(UnityEngine.SceneManagement.Scene))
			{
				throw new InvalidOperationException($"This {nameof(AddressableConfig)} is not of a " +
													$"{typeof(UnityEngine.SceneManagement.Scene)} config type. It's of {AssetType.Name} type.");
			}

			var index = Address.LastIndexOf("/", StringComparison.Ordinal);
			var typeIndex = Address.LastIndexOf(".", StringComparison.Ordinal);

			index = index < 0 ? 0 : index + 1;
			typeIndex = typeIndex < index ? Address.Length : typeIndex;

			return Address.Substring(index, typeIndex - index);
		}
	}

	/// <summary>
	/// Dictionary에서 박싱을 방지합니다
	/// </summary>
	public class AddressableConfigComparer : IEqualityComparer<AddressableConfig>
	{
		/// <inheritdoc />
		public bool Equals(AddressableConfig x, AddressableConfig y)
		{
			return x.Id == y.Id;
		}

		/// <inheritdoc />
		public int GetHashCode(AddressableConfig config)
		{
			return config.Id;
		}
	}
}