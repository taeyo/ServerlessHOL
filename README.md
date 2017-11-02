## 제목 : Azure Serveless 핸즈온랩 워크샵

클라우드는 IaaS를 넘어, PaaS로 그리고 PaaS를 넘어 마이크로 PaaS인 서버리스로 그 관심이 옮겨가고 있습니다. 서버의 인프라를 직접 관리하거나, 운영할 필요가 없는 서버리스 기술은 이미 많은 기업의 개발자들이 주목하고 있는 핫한 기술입니다. 

이번 HOL에서는 Azure에서 제공하는 서버리스 기술인 Functions와 Logic App을 직접 코딩하고 개발하면서 그 뛰어난 유연성과 효율성을 직접 느껴보도록 합니다.

지구 상에 유일한 합법적 마약이자 치매 예방에 좋은 Coding을 가열차게 하면서 서버리스를 배워보고 싶다 하시는 분들은 이번 실습 HOL을 놓치지 마세요!

### **대상** : 기업에서 근무하는 초, 중급 개발자

#### **강사** : 한국 마이크로소프트 김태영 부장 (feat. Taeyo)

#### 실습시간(예상) : 5 시간 

## HOL(Hands-on Lab) 진행 순서

### 기술 세션 : Azure의 Serverless 컴퓨팅

- 실습 1 : 온라인으로 Azure Functions 개발 실습
    - Azure Portal을 통한 Node.js 코딩
	- 브라우저 및 PostMan을 사용하여 테스트
	- 모니터링 및 관리 테스트

- 실습 2 : Azure CLI를 이용한 Function 개발 실습
	- Command Line Interface를 통해서 개발
	- Function pack을 이용한 배포

- 실습 3 : Visual Studio를 이용한 서버리스 개발
    - Blob 트리거와 이미지 프로세싱 실습 
    - 기존 개발되어 있는 소스를 사용하여 변형 실습
    - 시나리오
        - 인물 사진을 Blob 저장소에 저장하면
        - 해당 이미지를 AI : Vision API로 분석하여
        - 행복치수에 따라 이미지 배경을 변경 및 이름과 직급을 프린트
        - Output용 Blob 저장소에 변형된 이미지를 저장

### 미니 세션 : 서버리스 핵페스트 프로그램 소개

- 실습 4 : Logic 앱을 사용한 워크플로우 실습
	- Facebook과 Blob Storage(Dropbox) 연계 실습
    - 시나리오
        - 자신의 페이스북 담벼락에 글을 남기면
        - 그 텍스트를 음성으로 변환하고
        - 지정된 Blob 저장소에 파일로 생성함
        - (option) 생성된 음성 파일을 DropBox에도 생성

- 실습 5 : Azure Function + Logic App 종합 실습
    - 메일로 요청을 받아서 프로세싱된 이미지를 회신해주는 시나리오 실습
    - 실습 3에서 만든 Function과 연계하여 워크플로우를 구성
    - 이 실습은 사정에 따라 다른 시나리오로 변경될 수 있음
    
### 모든 참가자는 다음의 사항들을 반드시 본인의 노트북에 설치하고 오셔야 합니다. 

MacBook 유저의 경우에는 가상화를 통해서 Windows OS를 준비하시거나 별도의 Windows 노트북을 지참하시는 것을 권장합니다. 이는 MacBook에는 Visual Studio (Windows)를 설치할 수 없기에 전체 실습과정 중 50%만 실습하실 수 있습니다

### 참가자 준비물 (필수)
> 1. 노트북 (Windows OS)
> 2. Azure 계정(무료 계정이든, MSDN 계정이든, 회사 계정이든)  
> 3. 테더링 가능한 스마트폰(네트워크 사정이 안 좋을 경우 테더링을 강추합니다)  


> **준비물 미 준비 시에는 실습을 제대로 따라하실 수 없으며, 그 부분은 본인의 책임입니다**

### 강좌 참여 시 사전 준비 및 설치 사항(필수)
> - Visual Studio 2017 설치 (Community 버전 무관)  
>   (빨간 박스로 표시한 Azure 개발, ASP.NET 개발은 필수이며, 그 밖에 필요한 것 설치)
>   ![이미지](./images/install.png)
> 
> - Visual Studio Code 설치 : https://code.visualstudio.com/  
> - Azure CLI 설치
> - Node 8.5.0 설치
> - Azure Functions Core Tools 설치
> - Postman 설치
