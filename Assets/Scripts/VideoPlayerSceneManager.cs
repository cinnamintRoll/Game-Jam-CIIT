using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;


public class VideoPlayerSceneManager : MonoBehaviour
{
    private VideoPlayer videoPlayer;
    public string menu;

    private void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.loopPointReached += EndReached;
    }

    void EndReached(VideoPlayer videoPlayer)
    {
        SceneManager.LoadScene(menu);
    }
}
