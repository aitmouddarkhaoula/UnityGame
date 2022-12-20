using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
	[SerializeField] int _number;
	[SerializeField] TextMesh _textMesh;

	public int number => _number;

	public void SetNumber(int num)
	{
		_number = num;
		_textMesh.text = num + "";
	}
}
