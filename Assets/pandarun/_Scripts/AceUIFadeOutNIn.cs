using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public enum FadeType 
{
	FadeIn,FadeOut,Fade0To1to0
}
 
public class AceUIFadeOutNIn : MonoBehaviour
{
	public FadeType fadeType;
	// Use this for initialization
	[Range(1,4)]
	public float TimeDuration  = 4;
	[Range(1,4)]
	public float TimeStayAt1  = 4;
    int enabledCount = 0;

    void OnEnable()
    {
        if (enabledCount != 0)
            Start();

        enabledCount++;
    }
    void Start()
    {
       

		switch (fadeType) {
		case FadeType.FadeOut:
			changeImageNText(0, TimeDuration);
			break;
		case FadeType.FadeIn:
			changeImageNText(0, 0);
			changeImageNText(1, TimeDuration);
			break;
		case FadeType.Fade0To1to0:
			changeImageNText(0, 0);
			changeImageNText(1, TimeDuration);
			StartCoroutine(	AceHelper.waitThenCallback(TimeStayAt1,()=>{
				changeImageNText(0, TimeDuration);
			}
			));
			break;
		}

    }
	 
	void changeImageNText(float alpha,float TimeDuration)
	{
		foreach (Image img in transform.GetComponentsInChildren<Image>())
		{
			
			img.CrossFadeAlpha(alpha, TimeDuration, true);
			Debug.Log(img.name);
		}
		//first set all to zero
		foreach (Text txt in transform.GetComponentsInChildren<Text>())
		{
			txt.CrossFadeAlpha(alpha, TimeDuration, true);
			Debug.Log(txt.name);
		}
	}
	
	 
}
