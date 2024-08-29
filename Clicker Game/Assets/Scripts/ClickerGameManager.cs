using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClickerGameManager : MonoBehaviour
{
	public TextMeshProUGUI scoreText;  // 점수를 표시하는 텍스트
	public TextMeshProUGUI upgradeCostText;  // 업그레이드 비용을 표시하는 텍스트
	public TextMeshProUGUI levelText;  // 업그레이드 비용을 표시하는 텍스트
	public Button clickButton;  // 클릭 버튼
	public Button upgradeButton;  // 업그레이드 버튼

	private int score = 0;  // 현재 점수
	private int pointsPerClick = 1;  // 클릭당 획득 점수
	private int upgradeCost = 10;  // 업그레이드 비용
	private int level = 1;  // 현재 레벨


	void Start()
	{
		UpdateUI();
	}

	public void OnClickButtonPressed()
	{
		score += pointsPerClick;
		UpdateUI();
	}

	public void OnUpgradeButtonPressed()
	{
		if (score >= upgradeCost)
		{
			score -= upgradeCost;
			pointsPerClick *= 2;
			upgradeCost *= 2;  // 업그레이드 비용 증가

			LevelUp();
			UpdateUI();
		}
	}

	private void LevelUp()
	{
		level++;
	}

	private void UpdateUI()
	{
		scoreText.text = "Score: " + score.ToString();
		upgradeCostText.text = "Upgrade Cost: " + upgradeCost.ToString();
		levelText.text = "Level: " + level.ToString();
	}
}