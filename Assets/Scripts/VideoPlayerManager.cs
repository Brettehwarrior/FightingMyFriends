using System;
using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerManager : MonoBehaviour
{
    private VideoPlayer videoPlayer;
    
    private Vector3 originalScale;
    
    private void Awake()
    {
        videoPlayer = GetComponent<VideoPlayer>();
    }

    private void Start()
    {
        videoPlayer.Prepare();
        originalScale = transform.localScale;
    }

    public void SwitchVideo(VideoClip newVideo)
    {
        videoPlayer.clip = newVideo;
        videoPlayer.frame = 0;
    }

    public void SetDirection(float direction)
    {
        // Set scale of video to be in direction of movement
        if (direction == 0)
            return;
        
        direction = -Math.Sign(direction);
        transform.localScale = new Vector3(direction * originalScale.x, originalScale.y, originalScale.z);
    }
}