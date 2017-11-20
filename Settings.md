### Create Azure Resources for this HOL
	
1. Create Resource Group
    - Name : **Az-Hol-Serverless** 
    - Location : southeast asia 
2. Create App Service Plan 
    - Name : **ServerlessHol-dev** 
    - Location : southeast asia
    - Resource group : Az-Hol-Serverless
    - OS : Windows
    - Pricing Tier : B1 Basic
3. Create Emotion API(preview)
    - Name : **EmotionApi-dev** 
    - Location : West Us
    - Pricing Tier : F0
    - Resource group : Az-Hol-Serverless
4. Create Text Analytics API (preview)
    - Name : **TextAnalyApi-Dev** 
    - Location : Southeast Asia
    - Pricing Tier : F0
5. Create Storage account - blob, file, table, queue
    - Name : **serverlessstor** 
    - Replication : LRS
    - Location : southeast asia
    - Resource group : Az-Hol-Serverless
    - Rest of all : use default value
6. Create Function App
    - Name : **SeverlessFunc-<전번4자리>**
    - Resource group : Az-Hol-Serverless
    - Hosting Plan : App Service Plan
    - App Service Plan/Location : ServerlessHol-dev
    - Storage : serverlessstor
7. Create Blob Container in Storage Account
    - Name : **card-input**, **card-output** 
    - Public access level : Blob (anonymous read access for blobs only)  