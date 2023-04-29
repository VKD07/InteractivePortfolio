using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CreateText : MonoBehaviour
{
    [SerializeField] string text;
    [SerializeField] GameObject letter;
    [SerializeField] float textSpacing = 1f;
    [SerializeField] float textSize;
    TextMeshPro textMeshPro;
    Vector3 letterPos;
    float z;
    private void Awake()
    {
        textMeshPro = GetComponent<TextMeshPro>();

        for (int i = 0; i < text.Length; i++)
        {
            z += 0.6f;
            letterPos = new Vector3(transform.position.x + z + textSpacing, transform.position.y, transform.position.z);
            if (text[i].ToString() != " ")
            {
                GameObject letterObj = Instantiate(letter, letterPos, Quaternion.identity);
                letterObj.GetComponent<TextMeshPro>().SetText(text[i].ToString());
                letterObj.transform.localScale = new Vector3(textSize, textSize, textSize);
                letterObj.transform.SetParent(transform);
            }
        }
    }
}
