using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

// ReSharper disable CheckNamespace

namespace Geuneda.AssetsImporter
{
	/// <summary>
	/// 로딩 메서드를 위한 유틸리티 개선을 제공하는 헬퍼 클래스
	/// </summary>
	public static class AssetLoaderUtils
	{
		/// <summary>
		/// 주어진 <paramref name="tasks"/> 목록을 순회하는 헬퍼 메서드입니다.
		/// 먼저 완료된 태스크를 반환하고 모든 태스크가 완료될 때까지 다음으로 이동합니다.
		/// </summary>
		/// <remarks>
		/// .Net 엔지니어의 구현을 기반으로 합니다 <seealso cref="https://devblogs.microsoft.com/pfxteam/processing-tasks-as-they-complete/"/>
		/// </remarks>
		public static Task<Task<T>>[] Interleaved<T>(IEnumerable<Task<T>> tasks)
		{
			var inputTasks = tasks.ToList();
			var buckets = new TaskCompletionSource<Task<T>>[inputTasks.Count];
			var results = new Task<Task<T>>[buckets.Length];
			var nextTaskIndex = -1;

			for (var i = 0; i < buckets.Length; i++)
			{
				buckets[i] = new TaskCompletionSource<Task<T>>();
				results[i] = buckets[i].Task;
			}

			foreach (var inputTask in inputTasks)
			{
				inputTask.ContinueWith(Continuation, CancellationToken.None, TaskContinuationOptions.ExecuteSynchronously, TaskScheduler.Default);
			}

			return results;

			// 로컬 함수
			void Continuation(Task<T> completed)
			{
				buckets[Interlocked.Increment(ref nextTaskIndex)].TrySetResult(completed);
			}
		}
	}
}