### Create Azure Resources for this HOL

> 모든 작업은 Azure Portal에서 수행합니다.   
> 작업에 앞서 Azure Portal의 언어설정은 "English"로 변경합니다.  
> (한글의 경우 명칭이 이상하게 나오는 경우가 있어 혼란예방하기 위함입니다)


1. 리소스 그룹(Resource Group) 만들기
    - Name : **Az-Hol-Serverless** 
    - Location : japan west 
2. App Service Plan 만들기
    - Name : **ServerlessHol-dev** 
    - Location : japan west
    - Resource group : Az-Hol-Serverless
    - OS : Windows
    - Pricing Tier : B1 Basic
3. Emotion API(preview) 만들기
    - Name : **EmotionApi-dev** 
    - Location : West Us
    - Pricing Tier : F0
    - Resource group : Az-Hol-Serverless
4. Text Analytics API (preview) 만들기
    - Name : **TextAnalyApi-Dev** 
    - Location : japan west
    - Pricing Tier : F0
5. Storage account - blob, file, table, queue 만들기
    - Name : **serverlessstor** 
    - Replication : LRS
    - Location : japan west
    - Resource group : Az-Hol-Serverless
    - Rest of all : use default value
6. Function App 만들기
    - Name : **SeverlessFunc-<전번4자리>**
    - Resource group : Az-Hol-Serverless
    - Hosting Plan : App Service Plan
    - App Service Plan/Location : ServerlessHol-dev
    - Storage : __serverlessstor__
7. 저장소 계정 안에 Blob Container 만들기
    - Name : **card-input**, **card-output**, **audio**
    - Public access level : Blob (anonymous read access for blobs only)  

    
### 실습 시작 전에 다음의 항목들을 [메모장]에 복사해 둡니다.

> 시작 전에 복사해 둘 것
>	- Storage Account 연결 문자열 설정
>	- EmotionAPIKey
>       -  Emotion API의 키
>   - Text Analytics 의 키