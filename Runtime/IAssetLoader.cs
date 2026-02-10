using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

// ReSharper disable CheckNamespace

namespace Geuneda.AssetsImporter
{
	/// <summary>
	/// 이 인터페이스는 에셋 로딩 방식을 객체 참조로 래핑할 수 있게 합니다
	/// </summary>
	public interface IAssetLoader
	{
		/// <summary>
		/// 주어진 <paramref name="key"/>에서 지정된 <typeparamref name="T"/> 타입의 에셋을 로드합니다.
		/// 이 메서드의 실행을 돕기 위해 <seealso cref="AddressableConfig"/>에서 에셋 경로를 요청하는 것을 권장합니다.
		/// 에셋이 로드되면 <paramref name="onCompleteCallback"/>을 호출합니다.
		/// 이 메서드는 비동기 메서드에서 제어할 수 있으며 로드된 에셋을 반환합니다.
		/// </summary>
		UniTask<T> LoadAssetAsync<T>(object key, Action<T> onCompleteCallback = null);

		/// <summary>
		/// 주어진 <paramref name="key"/>의 프리팹을 주어진 <paramref name="parent"/>와
		/// 주어진 <paramref name="instantiateInWorldSpace"/>로 로드 및 인스턴스화합니다.
		/// 월드 공간 기준 또는 부모 기준으로 인스턴스 트랜스폼을 유지합니다.
		/// 이 메서드의 실행을 돕기 위해 <seealso cref="AddressableConfig"/>에서 에셋 경로를 요청하는 것을 권장합니다.
		/// 에셋이 인스턴스화되면 <paramref name="onCompleteCallback"/>을 호출합니다.
		/// 이 메서드는 비동기 메서드에서 제어할 수 있으며 인스턴스화된 프리팹을 반환합니다
		/// </summary>
		UniTask<GameObject> InstantiateAsync(object key, Transform parent, bool instantiateInWorldSpace,
			Action<GameObject> onCompleteCallback = null);

		/// <summary>
		/// 주어진 <paramref name="key"/>의 프리팹을 주어진 <paramref name="position"/>,
		/// 주어진 <paramref name="rotation"/> 및 주어진 <paramref name="parent"/>로 로드 및 인스턴스화합니다.
		/// 이 메서드의 실행을 돕기 위해 <seealso cref="AddressableConfig"/>에서 에셋 경로를 요청하는 것을 권장합니다.
		/// 에셋이 인스턴스화되면 <paramref name="onCompleteCallback"/>을 호출합니다.
		/// 이 메서드는 비동기 메서드에서 제어할 수 있으며 인스턴스화된 프리팹을 반환합니다
		/// </summary>
		UniTask<GameObject> InstantiateAsync(object key, Vector3 position, Quaternion rotation, Transform parent,
			Action<GameObject> onCompleteCallback = null);

		/// <summary>
		/// 주어진 <paramref name="asset"/>을 게임 메모리에서 언로드합니다.
		/// <typeparamref name="T"/>가 <seealso cref="GameObject"/> 타입인 경우 파괴도 수행합니다.
		/// 에셋이 언로드되면 <paramref name="onCompleteCallback"/>을 호출합니다.
		/// </summary>
		UniTask UnloadAssetAsync<T>(T asset, Action onCompleteCallback = null);
	}
}