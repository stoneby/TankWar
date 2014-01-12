using UnityEngine;

public class Menu : MonoBehaviour
{
    private const int ButtonNum = 4;
    private const float RowWidthRatio = 0.25f;

    private float buttonGridWidth;
    private float buttonGridHeight;
    private float buttonLeft;
    private float buttonTop;
    private float buttonWidth;
    private float buttonHeight;

    private Vector2 scrollPosition;
    private float scrollViewLeft;
    private float scrollViewTop;
    private float scrollViewWidth;
    private float scrollViewHeight;
    private float scrollViewRealWidth;
    private float scrollViewRealHeight;

    private float serverGridHeight = 50;
    private int serverNum = 15;
    private float serverLeft;
    private float serverTop;
    private float serverWidth;
    private float serverHeight;

    void OnGUI()
    {
        DrawMainGUI();
    }

    private void DrawMainGUI()
    {
        buttonGridWidth = Screen.width * RowWidthRatio;
        buttonGridHeight = Screen.height * 1f / ButtonNum;
        buttonLeft = buttonGridWidth / 8;
        buttonTop = buttonGridHeight / 8;
        buttonWidth = buttonGridWidth * 6 / 8;
        buttonHeight = buttonGridHeight * 6 / 8;

        scrollViewLeft = buttonGridWidth;
        scrollViewTop = buttonTop;
        scrollViewWidth = Screen.width - buttonGridWidth;
        scrollViewHeight = Screen.height;
        scrollViewRealWidth = scrollViewWidth * 6 / 8;
        scrollViewRealHeight = serverGridHeight * serverNum;

        GUI.BeginGroup(new Rect(0, 0, Screen.width, Screen.height), "", "Box");

        if (GUI.Button(new Rect(buttonLeft, buttonTop, buttonWidth, buttonHeight), "Create"))
        {
            DrawCreateServer();
        }
        else if (GUI.Button(new Rect(buttonLeft, buttonTop + buttonGridHeight, buttonWidth, buttonHeight), "Join"))
        {
            DrawJoinServer();
        }
        else if (GUI.Button(new Rect(buttonLeft, buttonTop + buttonGridHeight * 2, buttonWidth, buttonHeight),
                            "Refresh"))
        {
            RefreshServer();
        }
        else if (GUI.Button(new Rect(buttonLeft, buttonTop + buttonGridHeight * 3, buttonWidth, buttonHeight),
                            "Settings"))
        {
            DrawSettings();
        }

        DrawServers();

        GUI.EndGroup();
    }

    private void DrawCreateServer()
    {
        Application.LoadLevel("Bang");
    }

    private void DrawJoinServer()
    {
    }

    private void RefreshServer()
    {
    }

    private void DrawSettings()
    {
    }

    private void DrawServers()
    {
        scrollPosition = GUI.BeginScrollView(
            new Rect(scrollViewLeft, scrollViewTop, scrollViewWidth, scrollViewHeight), scrollPosition,
            new Rect(scrollViewLeft, scrollViewTop, scrollViewRealWidth, scrollViewRealHeight));

        for (var i = 0; i < serverNum; ++i)
        {
            DrawServer(i);
        }

        GUI.EndScrollView();
    }

    private void DrawServer(int index)
    {
        serverLeft = scrollViewLeft + scrollViewWidth / 12;
        serverTop = scrollViewTop + serverGridHeight / 12 + index * serverGridHeight;
        serverWidth = scrollViewWidth * 10 / 12;
        serverHeight = serverGridHeight * 10 / 12;

        if (GUI.Button(new Rect(serverLeft, serverTop, serverWidth, serverHeight), "Server Created: No." + index))
        {
            Application.LoadLevel("Bang");
        }
    }
}
