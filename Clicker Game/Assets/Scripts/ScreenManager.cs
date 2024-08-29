using UnityEngine;

public class ScreenManager : MonoBehaviour
{
	// 원하는 해상도 (가로x세로 비율을 맞춰 설정)
	public int targetWidth = 1080;
	public int targetHeight = 1920;

	void Start()
	{
		// 해상도를 설정하고 창 모드를 설정 (윈도우 빌드에서 창 모드로 실행)
		Screen.SetResolution(targetWidth, targetHeight, false);

		// 화면 비율을 강제 설정
		SetAspectRatio();
	}

	void SetAspectRatio()
	{
		// 현재 화면 비율 계산
		float targetAspect = (float)targetWidth / (float)targetHeight;
		float windowAspect = (float)Screen.width / (float)Screen.height;
		float scaleHeight = windowAspect / targetAspect;

		Camera camera = Camera.main;

		if (scaleHeight < 1.0f)
		{
			Rect rect = camera.rect;

			rect.width = 1.0f;
			rect.height = scaleHeight;
			rect.x = 0;
			rect.y = (1.0f - scaleHeight) / 2.0f;

			camera.rect = rect;
		}
		else
		{
			float scaleWidth = 1.0f / scaleHeight;

			Rect rect = camera.rect;

			rect.width = scaleWidth;
			rect.height = 1.0f;
			rect.x = (1.0f - scaleWidth) / 2.0f;
			rect.y = 0;

			camera.rect = rect;
		}
	}
}