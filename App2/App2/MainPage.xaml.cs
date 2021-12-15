using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App2
{
    public partial class MainPage : ContentPage
    {
        int currentState = 1;
        string mathOperator;
        string allPressedNumbers;
        string pressed;
        double firstNumber, secondNumber, result;
        public MainPage()
        {
            InitializeComponent();
        }

        // Funktion för att välja nummer och skriva ut värdet
        void SelectNumber(object sender, EventArgs e){
            Button button = (Button)sender;

                if (currentState < 0)
                {
                    currentState *= -1;
                }
                
                double number;

                // Om värdet konverteras till en siffra
                if (double.TryParse(this.resultText.Text, out number))
                {
                    // kollar viken state programmet är i, om 1 så lagras den valdra siffran i variabel och skrivs ut
                    if (currentState == 1)
                    {
                        //Skriver ut värdet av knappen som trycks
                        pressed += button.Text;
                        this.resultText.Text = pressed;
                        // Konverterar strängen till nummer
                        double.TryParse(pressed, out firstNumber);
                        allPressedNumbers += button.Text;
                        this.currentNumber.Text = allPressedNumbers;
                }
                    // Om första siffran är vald ändras även state och därför körs denna del som läser in andra siffran
                    else
                    {
                        //Skriver ut värdet av knappen som trycks
                        pressed += button.Text;
                        this.resultText.Text = pressed;
                        // Konverterar strängen till nummer
                        double.TryParse(pressed, out secondNumber);
                        allPressedNumbers += button.Text;
                        this.currentNumber.Text = allPressedNumbers;
                }
            }  

        }
        // Funktion som indikerar på att användaren valt en operatör och skall gå vidare till nästa nummer
        void SelectOperator(object sender, EventArgs e)
        {
            currentState = -2;
            Button button = (Button)sender;
            string Operatorpressed = button.Text;
            mathOperator = Operatorpressed;
            // Värden läggs till i variabel för att skriva ut alla siffror användaren tryckt på
            allPressedNumbers += " " + mathOperator + " ";
            this.currentNumber.Text = allPressedNumbers;
            pressed = "";
        }
        // Funktion för att återställa skrivfältet och alla värden
        void Clear(object sender, EventArgs e)
        {
            firstNumber = 0;
            secondNumber = 0;
            currentState = 1;
            this.resultText.Text = "0";
            this.currentNumber.Text = "";
            allPressedNumbers = "";
            pressed = "";
        }
        // Funktion för att göra matematisk uträkning beroende på operatör
        void Calculate(object sender, EventArgs e)
        {
            if (currentState == 2)
            {
                // Switch som körs beroende på vilken operatör man valt
                switch (mathOperator)
                {
                    case "÷":
                        result = firstNumber / secondNumber;
                        break;
                    case "×":
                        result = firstNumber * secondNumber;
                        break;
                    case "+":
                        result = firstNumber + secondNumber;
                        break;
                    case "−":
                        result = firstNumber - secondNumber;
                        break;
                }
                    // Skriver ut resultatet
                    this.resultText.Text = result.ToString();
                   
                    // Återställer alla variabler
                    currentState = -1;
                    allPressedNumbers = "";

                    firstNumber = 0;
                    secondNumber = 0;
                   
                    allPressedNumbers = "";
                    pressed = "";

            }
        }
    }
}
