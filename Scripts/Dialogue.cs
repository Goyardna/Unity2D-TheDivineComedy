using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public Text dialogueText; // 对话文本
    public string npcText; // NPC的内容

    private bool playerNpc; // 标记玩家是否与NPC交互

    void Start()
    {
        // 初始化时，确保对话文本为空
        if (dialogueText != null)
        {
            dialogueText.text = "";
        }
    }

    void Update()
    {
        // 如果玩家与NPC交互，显示对话文本
        if (playerNpc && dialogueText != null)
        {
            dialogueText.text = npcText;
        }
        else if (dialogueText != null)
        {
            // 如果玩家没有与NPC交互，清空对话文本
            dialogueText.text = "";
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 当玩家进入触发器区域时
        if (collision.gameObject.CompareTag("Player"))
        {
            dialogueText.text = npcText; // 显示对话文本
            playerNpc = true; // 设置标记
            Debug.Log("1");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // 当玩家离开触发器区域时
        if (collision.gameObject.CompareTag("Player"))
        {
            playerNpc = false; // 重置标记
            Debug.Log("2");
        }
    }
}