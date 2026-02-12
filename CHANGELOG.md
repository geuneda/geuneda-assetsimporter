# Changelog
이 패키지의 모든 주요 변경사항은 이 파일에 기록됩니다.

이 형식은 [Keep a Changelog](http://keepachangelog.com/en/1.0.0/)를 기반으로 하며,
이 프로젝트는 [Semantic Versioning](http://semver.org/spec/v2.0.0.html)을 따릅니다.

## [0.5.2] - 2026-01-14

**Changed**:
- 의존성 `com.geuneda.dataextensions` 및 `com.geuneda.configsprovider`를 `com.geuneda.gamedata`로 통합
- 어셈블리 정의에서 `Geuneda.GameData` 참조로 업데이트

## [0.5.1] - 2024-11-19

**Changed**:
- 올바르게 동작하지 않는 불필요한 *UniTaskExtension*을 제거
- 모든 로드 및 언로드 메서드가 비동기로 실행되므로 *AssetResolverService*의 해당 메서드 이름에 async 접두사를 추가

**Fixed**:
- 콜백과 함께 호출 시 크래시가 발생하던 *AssetResolverService.UnloadScene* 메서드를 수정

## [0.5.0] - 2024-11-13

**New**:
- 보다 복잡한 프로젝트에서 필요한 에셋 설정 임포트를 커스터마이징할 수 있는 새로운 *AssetsConfigsImporterBase*를 추가
- 설정 임포트 시 *TId* enum과 *TScriptableObject*의 코드 생성을 가능하게 하는 새로운 *AssetsConfigsGeneratorImporter* 및 *IAssetConfigsGeneratorImporter*를 추가. 이를 통해 에셋 설정 개발 흐름을 단순화
- Cysharp *UniTask* 패키지를 프로젝트에 추가
- Addressable 에셋을 Id와 에셋 타입으로 관리할 수 있도록 돕는 *AssetResolverService* 및 *IAssetResolverService*를 패키지에 추가. *ScriptableObject* 설정에서 에셋을 추가하는 기능도 지원

**Changed**:
- *IScriptableObjectImporter*를 제거. 이제 *IAssetConfigsImporter*가 필요한 모든 에셋 설정 임포트를 위한 완전한 인터페이스로 사용
- *AssetsConfigsImporter*의 *TId* 제약 조건을 항상 Enum으로 변경
- 에셋 임포터의 성능 및 인스펙터 비주얼을 개선
- WebGL 빌드에서 코드를 실행할 수 있도록 *AddressableAssetLoader*, *IAssetLoader*, *ISceneLoader*의 모든 에셋 로딩을 *UniTask*로 변경

**Fixed**:
- 이 패키지가 WebGL 빌드에서 사용되지 못하던 문제를 수정

## [0.4.0] - 2024-11-08

**New**:
- "Tools/Addressables/" 메뉴 항목에 새로운 "Toggle Auto Import" 버튼을 추가하여 코드 재컴파일 시 모든 에셋 임포터 처리를 일시정지할 수 있도록 지원. 스크립트 변경 시 에디터 리로딩 속도를 향상

**Changed**:
- *IAssetLoader*가 작업 완료 시 콜백을 실행하도록 변경. 이를 통해 비 Task 작업이 자체 스코프에서 로직을 실행 가능

**Fixed**:
- 에셋 타입 처리에 실패했을 때 *AddressableId*가 생성되는 것을 방지. 이를 통해 로드 실패한 에셋 타입을 올바르게 보고하면서 향후 컴파일 오류를 방지

## [0.3.0] - 2024-04-27

**New**:
- 생성되는 설정 일부를 제어하기 위한 새로운 AddressableId Generator Settings 스크립터블 오브젝트를 추가

**Changed**:
- Unity 에디터 명령을 Tools/AddressableId Generator 경로로 이동

## [0.2.1] - 2023-09-04

**Changed**:
- AddressableConfig를 구조체에서 클래스로 변경. 이 변경으로 코드베이스에서 메모리 사용의 유연성과 효율성이 향상되며, AddressableConfig 인스턴스를 공유하거나 null로 설정하여 잠재적 중복을 줄일 수 있음. 값 타입에서 참조 타입으로의 전환으로 인해 일부 컨텍스트에서 AddressableConfig 사용 방식이 변경될 수 있음

## [0.2.0] - 2023-08-27

**New**:
- Unity 에디터의 Tools 메뉴에서 접근 가능한 에셋 데이터 임포트를 위한 AssetsImporter 도구를 도입
- 씬 에셋 유효성 검사를 위한 AssetReferenceScene 클래스를 추가

**Changed**:
- 새로운 네임스페이스, enum, 조회 메서드를 포함하도록 AddressableIdsGenerator를 업데이트. 라벨 기반 에셋 필터링을 개선
- AddressablesAssetLoader의 LoadAssetAsync 및 InstantiateAsync 메서드의 파라미터 타입을 string에서 object로 변경
- 여러 파일에서 네임스페이스를 "GameLovers.AddressablesExtensions"에서 "GameLovers.AssetsImporter"로 이름 변경

**Fixed**:
- AddressablesAssetLoader의 UnloadAsset 메서드에서 GameObject가 파괴되는 것을 방지

## [0.1.1] - 2020-08-31

**Fixed**:
- *AddressablesIdGenerator*에서 생성된 파일의 네임스페이스 설정을 수정

## [0.1.0] - 2020-08-31

- 패키지 배포를 위한 최초 제출
