#load "image-lib.csx"
 
using System.Net; 
using System.Net.Http;
using System.Net.Http.Headers;  
using Newtonsoft.Json; 
using System.IO; 
using System.Drawing;  
using System.Drawing.Imaging;

private const string EMOTION_API_URI      = "https://westus.api.cognitive.microsoft.com/face/v1.0/detect";
private const string EMOTION_API_KEY_NAME = "EmotionAPIKey";
private const string ASSETS_FOLDER        = "assets";
private static string ASSETS_PATH = "";

public static async Task Run(byte[] image, string name, Stream outputBlob, 
    TraceWriter log,
    ExecutionContext ctx)
{
    ASSETS_PATH = Path.Combine(
        ctx.FunctionDirectory, 
        ASSETS_FOLDER);
    log.Info("ASSETS_PATH : " + ASSETS_PATH);

    string result = await CallEmotionAPI(image, log);
    log.Info(result);    
 
    if (String.IsNullOrEmpty(result)) {
        log.Error("No result from Emotion API");
        return;
    }

    var imageData = JsonConvert.DeserializeObject<Face[]>(result);

    // hardcoded version if not calling the emotion APIs
    // var imageData = new Face[] { 
    //     new Face() {
    //         FaceRectangle = new FaceRectangle(),
    //         FaceAttributes = new FaceAttributes(){
    //            Emotion = new Emotion() { Happiness = 1.0 }
    //         }
    //     }
    // };

    if (imageData.Length == 0) {
        log.Error("No face detected in image");
        return;
    } 

    double score = 0;
    var faceData = imageData[0]; // assume exactly one face 

    var card = GetCardImageAndScores(faceData.FaceAttributes.Emotion, out score, log);
    var personInfo = GetNameAndTitle(name); // extract name and title from filename

    MergeCardImage(card, image, personInfo, score); 

    SaveAsJpeg(card, outputBlob);  
}

public static Tuple<string, string> GetNameAndTitle(string filename)
{
    string[] words = filename.Split('-');
    
    return words.Length > 1 ? Tuple.Create(words[0], words[1]) : Tuple.Create("", "");
}

static Image GetCardImageAndScores(Emotion scores, out double score, TraceWriter log)
{
    NormalizeScores(scores); 

    var cardBack = "neutral.png";
    score = scores.Neutral; 
    const int angerBoost = 2, happyBoost = 4;

    if (scores.Surprise > 10) {
        cardBack = "surprised.png";
        score = scores.Surprise;
    }
    else if (scores.Anger > 10) {
        cardBack = "angry.png";
        score = scores.Anger * angerBoost;
    }
    else if (scores.Happiness > 50) {
        cardBack = "happy.png";
        score = scores.Happiness * happyBoost; 
    }

    log.Info(GetFullImagePath(cardBack)); 

    return Image.FromFile(GetFullImagePath(cardBack));
}

static async Task<string> CallEmotionAPI(byte[] image, TraceWriter log)
{
    var client = new HttpClient();

    var content = new StreamContent(new MemoryStream(image));
    var key = Environment.GetEnvironmentVariable(EMOTION_API_KEY_NAME);

    client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", key);
    content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

    UriBuilder builder = new UriBuilder(EMOTION_API_URI);
    builder.Query = "returnFaceAttributes=emotion";
    string urlforEmotion = builder.Uri.ToString();

    log.Info("Emtion URL : " + urlforEmotion);

    var httpResponse = await client.PostAsync(urlforEmotion, content);

    if (httpResponse.StatusCode == HttpStatusCode.OK) {
        return await httpResponse.Content.ReadAsStringAsync();
    }

    return null;
}

static string GetFullImagePath(string filename)
{
    //var path = Path.Combine(
    //    Environment.GetEnvironmentVariable("ROOT"), 
    //    Environment.GetEnvironmentVariable("SITE_PATH"), 
    //    ASSETS_FOLDER,
    //   filename);

    var path = Path.Combine(
        ASSETS_PATH,
        filename);

    return Path.GetFullPath(path);
}
