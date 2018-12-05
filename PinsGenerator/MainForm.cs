using PinsGenerator.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PinsGenerator
{
    public partial class MainForm : Form
    {
        private readonly PinsRepository _pinRepo;

        public MainForm(PinsRepository pinRepo)
        {
            this._pinRepo = pinRepo;
            InitializeComponent();
        }

        private void generatePin_Click(object sender, EventArgs e)
        {
            var isOutputLabelVisible = this.outputLabel.Visible;
            var isPinOutputVisible = this.pinOutput.Visible;


            if (isOutputLabelVisible && isPinOutputVisible)
            {
                this.outputLabel.Visible = false;
                this.pinOutput.Visible = false;
            }

            string strRandomPin = this.generatePinString();

            while (this._pinRepo.findPin(strRandomPin))
            {
                strRandomPin = this.generatePinString();
            }

            if (!this._pinRepo.findPin(strRandomPin))
            {
                this._pinRepo.insertPin(strRandomPin);
                this.pinOutput.Text = strRandomPin;
                this.outputLabel.Visible = true;
                this.pinOutput.Visible = true;
            }

            // if we run out of all possible combinations all user to restart the program.
            // 10 x 10 x 10 x 10 = 10 000 and minus obvious numbers such as 1111, 2222 and so on,
            // thus 9990 possible combinations.
            // If we want to increase the complexity of the pin we can change the condition in the
            // validateAndReturnNumbers() to (duplicates > 1), that would prevent numbers like 1112, 2221 and so on..
            // then we need to change 9990 to 9830
            ReadOnlyCollection<string> allPins = this._pinRepo.GetAllPins();
            if (allPins.Count == 9990)
            {
                this.pinOutput.Text = string.Format("We run out of possible combinations.\n Number of pins:{0}.\n Click restart program.", allPins.Count.ToString());
                this.restartProgram.Visible = true;
                this.generatePinBtn.Visible = false;
            }
        }

        private string generatePinString()
        {
            var randomNumbers = this.validateAndReturnNumbers();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < randomNumbers.Length; i++)
            {
                sb.Append(randomNumbers[i].ToString());
            }

            return sb.ToString();
        }

        private int[] validateAndReturnNumbers()
        {
            int[] generatedNumbers = this.generateRandomNumbers();
            int duplicates = checkForDuplicates(generatedNumbers);

            while (duplicates == 3)
            {
                generatedNumbers = this.generateRandomNumbers();

                duplicates = checkForDuplicates(generatedNumbers);
            }

            return generatedNumbers;
        }

        private int[] generateRandomNumbers()
        {
            Random random = new Random();

            int randomOne = random.Next(9);
            int randomTwo = random.Next(9);
            int randomThree = random.Next(9);
            int randomFour = random.Next(9);

            int[] numbersArr = new int[4] { randomOne, randomTwo, randomThree, randomFour };

            return numbersArr;
        }

        private int checkForDuplicates(int[] generatedNumbers)
        {
            int duplicates = 0;

            for (int i = 0; i < generatedNumbers.Length; i++)
            {     
                for (int j = i + 1; j < generatedNumbers.Length; j++)
                {

                    if (generatedNumbers[i] == generatedNumbers[j])
                    {
                        duplicates++;
                        break;
                    }
                }
            }

            return duplicates;
        }

        private void restartBtn_Clicked(object sender, EventArgs e)
        {
            this._pinRepo.dropTable();
            this.restartProgram.Visible = false;
            this.outputLabel.Visible = false;
            this.pinOutput.Visible = false;
            this.generatePinBtn.Visible = true;
            this._pinRepo.createTable();
        }
    }
}
