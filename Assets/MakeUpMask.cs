using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MakeUpMask : MonoBehaviour
{

	[SerializeField] ImageType[] PicturesToCompare;

	[SerializeField] bool[] campares = new bool[4];

	[SerializeField] GameObject MiniGameCanvas;


	private void Awake()
	{
		GlobalVars.i.OnCanPassHuntersMiniGame += StartMiniGame;
	}

	private void StartMiniGame()
	{
		MiniGameCanvas.SetActive(true);
	}

	public void MovePartPicture(RectTransform rectTransform)
	{
		rectTransform.position = Input.mousePosition;
	}

	

	public void ComparePicturesParts(ImageType movableImage)
	{
		foreach(ImageType imageItem in PicturesToCompare)
		{
			float xPos = Mathf.Abs(imageItem.gameObject.GetComponent<RectTransform>().position.x - movableImage.gameObject.GetComponent<RectTransform>().position.x);
			float yPos = Mathf.Abs(imageItem.gameObject.GetComponent<RectTransform>().position.y - movableImage.gameObject.GetComponent<RectTransform>().position.y);
			print(xPos);
			print(yPos);
			if (imageItem.ID == movableImage.ID)
			{
				print("compare");
				if (xPos < 100 && yPos < 100)
				{
					campares[imageItem.ID] = true;
					movableImage.gameObject.gameObject.GetComponent<RectTransform>().position = imageItem.gameObject.gameObject.GetComponent<RectTransform>().position;
					if(campares[0] && campares[1] && campares[2] && campares[3])
					{
						GamePassed();
					}
				}
			}
			else print("dont");
			
		}
	}

	void GamePassed()
	{
		GlobalVars.i.OnHuntersQuestDone();
		MiniGameCanvas.SetActive(false);
	}

}
