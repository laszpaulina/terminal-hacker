using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    enum Screen { MainMenu, Password, Win };
    enum Route { Left, Right, Straight };

    Screen currentScreen = Screen.MainMenu;
    Route chosenRoute = Route.Left;

    void Start() {
        ShowIntroduction();
    }

    void ShowIntroduction() {
        currentScreen = Screen.MainMenu;
        Terminal.WriteLine("Choose your mission. Which would you like to break into?");
        Terminal.WriteLine("Go \"Left\" for the local potions shop");
        Terminal.WriteLine("Go \"Right\" to infiltrate the kings vault");
        Terminal.WriteLine("Keep \"Straight\" for the wizard's guild");
        Terminal.WriteLine("Enter your chosen path :");
    }

    void OnUserInput(string input) {
        if (input.ToLower() == "menu") {
            currentScreen = Screen.MainMenu;
            ShowIntroduction();
        }
        else if (currentScreen == Screen.MainMenu) {
            RunMainMenu(input);
        }
    }

    void RunMainMenu(string input) {
        input = input.ToLower();

        if (input == "left" || input == "right" || input == "straight") {
            currentScreen = Screen.Password;
            ExtractGameLevel(input);
            Terminal.ClearScreen();
            Terminal.WriteLine("you have chosen \" " + input + "\" as your path");
        }
        else {
            Terminal.WriteLine("Please choose a valid level");
        }
    }

    void ExtractGameLevel(string input) {
        if (input == "left") {
            chosenRoute = Route.Left;
        }
        else if (input == "right") {
            chosenRoute = Route.Right;
        }
        else {
            chosenRoute = Route.Straight;
        }
    }

    void StartGameLevel(string route) {
        currentScreen = Screen.Password;
        Terminal.WriteLine("Hello, you have chosen level ");
    }

    // Update is called once per frame
    void Update() {

    }
}
