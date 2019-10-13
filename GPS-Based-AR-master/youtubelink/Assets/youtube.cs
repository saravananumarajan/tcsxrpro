using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Video;
using System.Linq;
using System;
using UnityEngine.Events;

[System.Serializable]
public class VideoInfo
{
    public string quality;
    public string url;
    public string itag;
    public string type;
}

[System.Serializable]
public class VideoInfoCollection
{
    public VideoInfo[] videoInfoCollection;
}

[RequireComponent(typeof(VideoPlayer))]
public class youtube : MonoBehaviour
{
    const string API_ENDPOINT = "http://matthewhallberg.com/jarvis/youtubelink.php/?url=";

    public string YouTubeURL= "https://www.youtube.com/watch?v=IKzqNpWC9WI";

    VideoPlayer videoPlayer;

    // Start is called before the first frame update
    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        LoadVideo(YouTubeURL);
    }

    public void LoadVideo(string url)
    {
        Debug.Log(url);
        StartCoroutine(GetYouTubeLinkRoutine(url));
    }

    IEnumerator GetYouTubeLinkRoutine(string url)
    {
        UnityWebRequest www = UnityWebRequest.Get(API_ENDPOINT + url);
        yield return www.SendWebRequest();
        //read json response into object
        Debug.Log(www);
        VideoInfo[] videoArray = JsonUtility.FromJson<VideoInfoCollection>(
        "{\"videoInfoCollection\":" + www.downloadHandler.text + "}").videoInfoCollection;
        //find video link with desired quality
        VideoInfo videoInfo = videoArray.Where(
        item => item.quality == "medium" && item.type.Contains("mp4")).FirstOrDefault();
        try
        {
            videoPlayer.url = videoInfo.url;
            videoPlayer.Prepare();
            Debug.Log("Video Loaded");
        }
        catch (NullReferenceException e)
        {
            Debug.Log("Enter");
        }
        
        //videoPlayer.Play();
    }
}
