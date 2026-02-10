using Cysharp.Threading.Tasks;
using System;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

// ReSharper disable CheckNamespace

namespace Geuneda.AssetsImporter
{
	/// <summary>
	/// 이 인터페이스는 씬 로딩 방식을 객체 참조로 래핑할 수 있게 합니다
	/// </summary>
	public interface ISceneLoader
	{
		/// <summary>
		/// 주어진 <paramref name="path"/>에서 지정된 매개변수 설정으로 씬을 로드합니다.
		/// 이 메서드의 실행을 돕기 위해 <seealso cref="AddressableConfig"/>에서 씬 경로를 요청하는 것을 권장합니다.
		/// 씬이 로드되면 <paramref name="onCompleteCallback"/>을 호출합니다.
		/// 이 메서드는 비동기 메서드에서 제어할 수 있으며 로드된 에셋을 반환합니다
		/// </summary>
		UniTask<Scene> LoadSceneAsync(string path, LoadSceneMode loadMode = LoadSceneMode.Single, 
			bool activateOnLoad = true, Action<Scene> onCompleteCallback = null);

		/// <summary>
		/// 주어진 <paramref name="scene"/>을 게임 메모리에서 언로드합니다.
		/// 씬이 언로드되면 <paramref name="onCompleteCallback"/>을 호출합니다.
		/// 이 메서드는 비동기 메서드에서 제어할 수 있습니다
		/// </summary>
		UniTask UnloadSceneAsync(Scene scene, Action onCompleteCallback = null);
	}
}