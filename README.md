#  AR Interactive Storybook

**Unity + ARCore + C#** 기반의 안드로이드용 증강현실 앱입니다.

---

# Project Overview
- **개발 기간**:  2024.11.06 ~ 2024.11.28
- **플랫폼**: Android (Unity AR Foundation / ARCore)

동화책 페이지 이미지를 인식하여 AR 캐릭터와 인터랙션 콘텐츠를 실행하는 증강현실 기반 스토리 콘텐츠입니다.
---

##  핵심 기능

| 기능 | 설명 |
|------|------|
| **Image Tracking** | 책 페이지 이미지를 인식하여 AR 콘텐츠 실행 |
| **AR Character Animation** | 아기돼지 삼형제와 늑대 캐릭터 애니메이션 구현 |
| **Voice Interaction (STT)** | 음성 인식을 통한 캐릭터 상호작용 |
| **Touch Interaction** | 터치 기반 캐릭터 반응 및 인터랙션 |
| **UI System** | 홈 화면, 설명 화면, 설정 UI 구현 |
| **Scene Testing** | 페이지별 AR 인식 및 콘텐츠 동작 테스트 |

---

# Tech Stack

**Engine**

- Unity 2021 
- AR Foundation
- ARCore

**Language**

- C#

**AR System**

- ARTrackedImageManager

**Voice Recognition**

- Google STT (Speech-to-Text)

---

# Role

**Team Leader / PM**

- Team Leader / PM
- 프로젝트 일정 관리 및 역할 분담
- ARCore 이미지 인식 테스트 및 최적화
- UI 및 사용자 인터랙션 흐름 설계
- Unity 기반 콘텐츠 통합 및 기능 테스트

---


##  시연 영상

- [YouTube 시연 영상 보기](https://youtu.be/fCQ7DFrzGPM)

---

# AR Image Tracking Optimization

동화책 이미지를 AR 트래킹 대상으로 사용하면서 인식률 문제를 해결하기 위해 다양한 테스트를 진행했습니다.

- 배경 색상 및 조명 환경 변화 실험
- 이미지 명암 대비 조정
- 색지 활용을 통한 트래킹 안정성 개선
- **ARCore 이미지 분석 툴(arcoreimg)** 을 활용한 인식률 비교 테스트
- 실제 동화책 크기 기준 환경 테스트 반복

AR 콘텐츠의 프리팹 실행, 상호작용, 내레이션 동작이 모두 이미지 인식에 의존하기 때문에  
이미지 인식 안정성을 프로젝트의 핵심 요소로 두고 개선 작업을 진행했습니다.

---

# Self Development

- AR Image Tracking 시스템 이해 및 구현 경험
- AR 콘텐츠 인터랙션 설계 및 UI 흐름 구성 경험
- Unity 기반 모바일 AR 콘텐츠 개발 경험
- 팀 프로젝트 관리 및 협업 경험
