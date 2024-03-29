using System;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class 文本管理器 : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    public static new Camera camera;
    public static bool Active = true;

    protected TextMeshProUGUI tmp;

    protected TMP_MeshInfo[] cachedMeshInfoVertexData;

    protected bool isHoveringObject;
    protected int selectedWord = -1;

    public bool IsDebug;
    public bool IsOnce;

    protected virtual void Awake()
    {
        tmp = gameObject.GetComponent<TextMeshProUGUI>();

    }

    void OnEnable()
    {
        // Subscribe to event fired when text object has been regenerated.
        TMPro_EventManager.TEXT_CHANGED_EVENT.Add(ON_TEXT_CHANGED);
    }
    void OnDisable()
    {
        // UnSubscribe to event fired when text object has been regenerated.
        TMPro_EventManager.TEXT_CHANGED_EVENT.Remove(ON_TEXT_CHANGED);
    }
    void ON_TEXT_CHANGED(UnityEngine.Object obj)
    {
        if (obj == tmp)
        {
            // Update cached vertex data.
            cachedMeshInfoVertexData = tmp.textInfo.CopyMeshInfoVertexData();
        }
    }

    protected virtual void LateUpdate()
    {
        try
        {
            if (isHoveringObject && Active)
            {
                int wordIndex = TMP_TextUtilities.FindIntersectingWord(tmp, Input.mousePosition, camera);
                if (IsDebug)
                {
                    print("wordIndex  " + wordIndex);
                    print("selectedWord  " + selectedWord);
                }

                int linkIndex = TMP_TextUtilities.FindIntersectingLink(tmp, Input.mousePosition, camera);
                if (selectedWord != -1 && (wordIndex == -1 || wordIndex != selectedWord))
                {
                    TMP_WordInfo wInfo = tmp.textInfo.wordInfo[selectedWord];
                    // Iterate through each of the characters of the word.
                    for (int i = 0; i < wInfo.characterCount; i++)
                    {
                        int characterIndex = wInfo.firstCharacterIndex + i;

                        // Get the index of the material / sub text object used by this character.
                        int meshIndex = tmp.textInfo.characterInfo[characterIndex].materialReferenceIndex;

                        // Get the index of the first vertex of this character.
                        int vertexIndex = tmp.textInfo.characterInfo[characterIndex].vertexIndex;

                        // Get a reference to the vertex color
                        Color32[] vertexColors = tmp.textInfo.meshInfo[meshIndex].colors32;
                        if (IsDebug)
                        {
                            print("characterIndex" + characterIndex);
                            print("vertexColors.Length  " + vertexColors.Length);
                            print("vertexIndex  " + vertexIndex);
                        }
                        Color32 c = vertexColors[vertexIndex].Tint(1.33333f);

                        vertexColors[vertexIndex] = c;
                        vertexColors[vertexIndex + 1] = c;
                        vertexColors[vertexIndex + 2] = c;
                        vertexColors[vertexIndex + 3] = c;
                    }

                    // Update Geometry
                    tmp.UpdateVertexData(TMP_VertexDataUpdateFlags.All);

                    selectedWord = -1;
                }
                if (wordIndex != -1 && wordIndex != selectedWord && linkIndex != -1)
                {
                    selectedWord = wordIndex;
                    TMP_WordInfo wInfo = tmp.textInfo.wordInfo[wordIndex];
                    for (int i = 0; i < wInfo.characterCount; i++)
                    {
                        int characterIndex = wInfo.firstCharacterIndex + i;

                        // Get the index of the material / sub text object used by this character.
                        int meshIndex = tmp.textInfo.characterInfo[characterIndex].materialReferenceIndex;

                        int vertexIndex = tmp.textInfo.characterInfo[characterIndex].vertexIndex;

                        // Get a reference to the vertex color
                        Color32[] vertexColors = tmp.textInfo.meshInfo[meshIndex].colors32;

                        Color32 c = vertexColors[vertexIndex + 0].Tint(0.75f);

                        vertexColors[vertexIndex + 0] = c;
                        vertexColors[vertexIndex + 1] = c;
                        vertexColors[vertexIndex + 2] = c;
                        vertexColors[vertexIndex + 3] = c;
                    }
                    tmp.UpdateVertexData(TMP_VertexDataUpdateFlags.All);
                }
            }
        }
        catch (IndexOutOfRangeException)
        {
        }

    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        isHoveringObject = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        LateUpdate();
        isHoveringObject = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {

    }

    public virtual void OnPointerDown(PointerEventData eventData)
    {

    }

    public virtual void OnPointerUp(PointerEventData eventData)
    {
        if (Active)
        {
            int linkIndex = TMP_TextUtilities.FindIntersectingLink(tmp, Input.mousePosition, camera);
            if (linkIndex != -1)
            {
                TMP_LinkInfo linkInfo = tmp.textInfo.linkInfo[linkIndex];
                // Debug.Log("Link ID: \"" + linkInfo.GetLinkID() + "\"   Link Text: \"" + linkInfo.GetLinkText() + "\""); // Example of how to retrieve the Link ID and Link Text.
                Vector3 worldPointInRectangle;

                RectTransformUtility.ScreenPointToWorldPointInRectangle(tmp.rectTransform, Input.mousePosition, camera, out worldPointInRectangle);

                游戏管理器.实例.处理按钮事件(linkInfo.GetLinkID());

            }

        }
    }
}
