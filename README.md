# Geuneda Assets Importer

Unity Addressables의 에셋 로딩 기능을 확장하는 패키지입니다.

## 개요

이 패키지는 Unity Addressables의 에셋 로딩 기능을 확장하여 각 Addressable 에셋에 대한 새로운 정보를 생성할 수 있게 해줍니다. 에셋 임포트 파이프라인을 확장하여 게임 내 모든 에셋의 약한 참조(weak link)를 타입별로 분리된 여러 ScriptableObject에 포함할 수 있습니다.

## 주요 기능

- Addressable 에셋 정보 자동 생성
- 타입별 에셋 분류
- 약한 참조(weak link) 지원
- 확장 가능한 임포트 파이프라인

## 요구 사항

- Unity 6000.0 이상
- Unity Addressables 패키지 (`com.unity.addressables`)
- Geuneda GameData 패키지 (`com.geuneda.gamedata`)
- UniTask 패키지 (`com.cysharp.unitask`)

## 설치 방법

### Unity Package Manager를 통한 설치

1. Unity 에디터에서 `Window` > `Package Manager`를 엽니다.
2. 좌측 상단의 `+` 버튼을 클릭하고 `Add package from git URL...`을 선택합니다.
3. 다음 URL을 입력합니다:
   ```
   https://github.com/geuneda/geuneda-assetsimporter.git
   ```
4. `Add` 버튼을 클릭합니다.

### manifest.json을 통한 설치

프로젝트의 `Packages/manifest.json` 파일에 다음을 추가합니다:

```json
{
  "dependencies": {
    "com.geuneda.assetsimporter": "https://github.com/geuneda/geuneda-assetsimporter.git"
  }
}
```

## 사용 방법

### Addressable ID 생성

`Tools` > `Generate AddressableIds`를 클릭하여 에셋 정보를 생성합니다.

## 네임스페이스

```csharp
using Geuneda.AssetsImporter;
```

## 라이선스

MIT License
