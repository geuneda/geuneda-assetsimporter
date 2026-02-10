using Geuneda.GameData;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using UnityEngine.AddressableAssets;

// ReSharper disable once CheckNamespace

namespace Geuneda.AssetsImporter
{
	/// <summary>
	/// 에셋 설정 ScriptableObject의 추상 기본 클래스입니다.
	/// 약한 참조 에셋을 사용하는 에셋 설정의 기본 계약을 제공합니다.
	/// </summary>
	public abstract class AssetConfigsScriptableObject : ScriptableObject
	{
		[SerializeField] private string _assetsFolderPath;

		/// <summary>
		/// 이 ScriptableObject가 설정된 에셋의 타입을 가져옵니다.
		/// </summary>
		public abstract Type AssetType { get; }

		/// <summary>
		/// 이 컨테이너에서 참조할 에셋의 폴더 경로를 반환합니다.
		/// </summary>
		public string AssetsFolderPath
		{
			get => _assetsFolderPath;
			set => _assetsFolderPath = value;
		}
	}
	/// <summary>
	/// 에셋 설정 ScriptableObject의 추상 기본 클래스입니다.
	/// 약한 참조 에셋을 사용하는 에셋 설정의 기본 계약을 제공합니다.
	/// </summary>
	/// <typeparam name="TId">식별자의 타입으로, 구조체여야 합니다.</typeparam>
	/// <typeparam name="TAsset">에셋의 타입입니다.</typeparam>
	public abstract class AssetConfigsScriptableObjectBase<TId, TAsset> :
		AssetConfigsScriptableObject, IPairConfigsContainer<TId, TAsset>, ISerializationCallbackReceiver
	{
		[SerializeField] private List<Pair<TId, TAsset>> _configs = new();

		/// <inheritdoc />
		public List<Pair<TId, TAsset>> Configs
		{
			get => _configs;
			set => _configs = value;
		}

		/// <summary>
		/// 에셋 설정을 읽기 전용 딕셔너리로 요청합니다
		/// </summary>
		public IReadOnlyDictionary<TId, TAsset> ConfigsDictionary { get; private set; }

		/// <inheritdoc />
		public void OnBeforeSerialize()
		{
			// 아무것도 하지 않음
		}

		/// <inheritdoc />
		public virtual void OnAfterDeserialize()
		{
			var dictionary = new Dictionary<TId, TAsset>();

			foreach (var config in Configs)
			{
				dictionary.Add(config.Key, config.Value);
			}

			ConfigsDictionary = new ReadOnlyDictionary<TId, TAsset>(dictionary);
		}
	}

	/// <inheritdoc />
	public abstract class AssetConfigsScriptableObject<TId, TAsset> :
		AssetConfigsScriptableObjectBase<TId, AssetReference>
	{
		/// <inheritdoc />
		public override Type AssetType => typeof(TAsset);
	}
}