using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonopolyV1
{
    public partial class Monopoly : Form                // Add trading -- IF the current player does not own a property they clicked on (and it is not owned by -1), do trade
    {
        int currentPlayer = 0;
        int diceTotal;
        int currentProperty;
        bool rollDouble = false;
        bool chanceChestBool = false; // Global Variables used 
        bool chanceChestSecondBool = false; //          for Chance and Chest mechanics
        int doubleCount = 0;
        int houseBuy;
        string winner;
        bool gameFinished = false;
        Color p0 = Color.FromArgb(0, 162, 192);
        Color p1 = Color.FromArgb(255, 128, 0);
        Color p2 = Color.FromArgb(192, 0, 192);
        Color p3 = Color.FromArgb(210, 60, 60);
        
        PictureBox[] ownedColours = new PictureBox[28];
        Property[] property = new Property[28];
        BoardSpace[] boardspace = new BoardSpace[41];
        Player[] player = new Player[4];
        Image[] propertyInfo = new Image[28];

        public void turnCheck()
        {
            
            if (currentPlayer > 3)
            {
               currentPlayer = 0;
            }
            if (player[currentPlayer].Bankrupt == true)
            {
                currentPlayer++;             
            }   
            if (player[currentPlayer].Bankrupt == true)
            {
                currentPlayer++;
            }

            if (currentPlayer > 3)
            {
                currentPlayer = 0;
            }

        } // Checks if the current player is over 3(player 4), if it is over 3, it gets set to 0 (player 1)
        public void winnerCheck()
        {

            if (player[0].Bankrupt == true & player[1].Bankrupt == true & player[2].Bankrupt == true)
            {
                gameFinished = true;
                winner = player[3].Name;
                labelWinner.Text = winner + " wins!";
                labelWinner.BackColor = p3;
                labelWinner.Visible = true;
                buttonEndTurn.Visible = false;
                buttonRollDice.Visible = false;
                diceText.Visible = false;
                diceTextNum.Visible = false;
                labelPlayerTurnName.Visible = false;
                labelPlayerTurnText.Visible = false;
                imageDice1.Visible = false;
                imageDice2.Visible = false;
                buttonJailFree.Visible = false;
                buttonJailFee.Visible = false;
                hideLabels1();
            }
            if (player[0].Bankrupt == true & player[1].Bankrupt == true & player[3].Bankrupt == true)
            {
                gameFinished = true;
                winner = player[2].Name;
                labelWinner.BackColor = p2;
                labelWinner.Text = winner + " wins!";
                labelWinner.Visible = true;
                buttonEndTurn.Visible = false;
                buttonRollDice.Visible = false;
                diceText.Visible = false;
                diceTextNum.Visible = false;
                labelPlayerTurnName.Visible = false;
                labelPlayerTurnText.Visible = false;
                imageDice1.Visible = false;
                imageDice2.Visible = false;
                buttonJailFree.Visible = false;
                buttonJailFee.Visible = false;
                hideLabels1();

            }
            if (player[0].Bankrupt == true & player[2].Bankrupt == true & player[3].Bankrupt == true)
            {
                gameFinished = true;
                winner = player[1].Name;
                labelWinner.BackColor = p1;
                labelWinner.Text = winner + " wins!";
                labelWinner.Visible = true;
                buttonEndTurn.Visible = false;
                buttonRollDice.Visible = false;
                diceText.Visible = false;
                diceTextNum.Visible = false;
                labelPlayerTurnName.Visible = false;
                labelPlayerTurnText.Visible = false;
                imageDice1.Visible = false;
                imageDice2.Visible = false;
                buttonJailFree.Visible = false;
                buttonJailFee.Visible = false;
                hideLabels1();
            }
            if (player[1].Bankrupt == true & player[2].Bankrupt == true & player[3].Bankrupt == true)
            {
                gameFinished = true;
                winner = player[0].Name;
                labelWinner.BackColor = p0;
                labelWinner.Text = winner + " wins!";
                labelWinner.Visible = true;
                buttonEndTurn.Visible = false;
                buttonRollDice.Visible = false;
                diceText.Visible = false;
                diceTextNum.Visible = false;
                labelPlayerTurnName.Visible = false;
                labelPlayerTurnText.Visible = false;
                imageDice1.Visible = false;
                imageDice2.Visible = false;
                buttonJailFree.Visible = false;
                buttonJailFee.Visible = false;
                hideLabels1();
            }
        }
        public void bankruptCheck()
        {
            if (player[0].Bankrupt == true)
            {
                moneyCurrency1.Visible = false;
                moneyPlayer1.Visible = false;
                labelBankrupt1.Visible = true;
                token1.Visible = false;
            }
            if (player[1].Bankrupt == true)
            {
                moneyCurrency2.Visible = false;
                moneyPlayer2.Visible = false;
                labelBankrupt2.Visible = true;
                token2.Visible = false;
            }
            if (player[2].Bankrupt == true)
            {
                moneyCurrency3.Visible = false;
                moneyPlayer3.Visible = false;
                labelBankrupt3.Visible = true;
                token3.Visible = false;
            }
            if (player[3].Bankrupt == true)
            {
                moneyCurrency4.Visible = false;
                moneyPlayer4.Visible = false;
                labelBankrupt4.Visible = true;
                token4.Visible = false;

            }
            unownedCheck();
            unownedImagesCheck();
        }
        public void unownedCheck()
        {
            for (int i = 0; i <= 27; i++)
            {
                if (property[i].OwnedBy == 0 & player[0].Bankrupt == true)
                {
                    property[i].isOwned = false;
                    property[i].Owner = "Not Owned";
                    property[i].OwnedBy = -1;
                    property[i].HouseNum = 0;
                }
                if (property[i].OwnedBy == 1 & player[1].Bankrupt == true)
                {
                    property[i].isOwned = false;
                    property[i].Owner = "Not Owned";
                    property[i].OwnedBy = -1;
                    property[i].HouseNum = 0;
                }
                if (property[i].OwnedBy == 2 & player[2].Bankrupt == true)
                {
                    property[i].isOwned = false;
                    property[i].Owner = "Not Owned";
                    property[i].OwnedBy = -1;
                    property[i].HouseNum = 0;

                }
                if (property[i].OwnedBy == 3 & player[3].Bankrupt == true)
                {
                    property[i].isOwned = false;
                    property[i].Owner = "Not Owned";
                    property[i].OwnedBy = -1;
                    property[i].HouseNum = 0;
                }
            }
        }
        public void unownedImagesCheck()
        {
            for (int i = 0; i <=27; i++)
            {
                if (property[i].isOwned == false)
                {
                    ownedColours[i].Visible = false;
                }
            }
            #region houseIfStatements
            if (property[0].isOwned == false)
            {
                propertyHouses1.Visible = false;
            }
            if (property[1].isOwned == false)
            {
                propertyHouses2.Visible = false;
            }
            if (property[3].isOwned == false)
            {
                propertyHouses3.Visible = false;
            }
            if (property[4].isOwned == false)
            {
                propertyHouses4.Visible = false;
            }
            if (property[5].isOwned == false)
            {
                propertyHouses5.Visible = false;
            }
            if (property[6].isOwned == false)
            {
                propertyHouses6.Visible = false;
            }
            if (property[8].isOwned == false)
            {
                propertyHouses7.Visible = false;
            }
            if (property[9].isOwned == false)
            {
                propertyHouses8.Visible = false;
            }
            if (property[11].isOwned == false)
            {
                propertyHouses9.Visible = false;
            }
            if (property[12].isOwned == false)
            {
                propertyHouses10.Visible = false;
            }
            if (property[13].isOwned == false)
            {
                propertyHouses11.Visible = false;
            }
            if (property[14].isOwned == false)
            {
                propertyHouses12.Visible = false;
            }
            if (property[15].isOwned == false)
            {
                propertyHouses13.Visible = false;
            }
            if (property[16].isOwned == false)
            {
                propertyHouses14.Visible = false;
            }
            if (property[18].isOwned == false)
            {
                propertyHouses15.Visible = false;
            }
            if (property[19].isOwned == false)
            {
                propertyHouses16.Visible = false;
            }
            if (property[21].isOwned == false)
            {
                propertyHouses17.Visible = false;
            }
            if (property[22].isOwned == false)
            {
                propertyHouses18.Visible = false;
            }
            if (property[23].isOwned == false)
            {
                propertyHouses19.Visible = false;
            }
            if (property[24].isOwned == false)
            {
                propertyHouses20.Visible = false;
            }
            if (property[26].isOwned == false)
            {
                propertyHouses21.Visible = false;
            }
            if (property[27].isOwned == false)
            {
                propertyHouses22.Visible = false;
            }
            #endregion
        }
        public Monopoly()
        {
            InitializeComponent();
            SetBoardSpaces();
            setOwnedColours();
            setPropertyInfoPictures();
            startGame();
  
        }
        public void startGame()
        {
            SetPlayers();
            resetProperties();
            SetStartPositions();
        }
        public int diceRoll()
        {
            Random DiceNum = new Random();
            rollDouble = false;
            int diceNum1 = DiceNum.Next(1, 7); // Create random number for the first dice
            int diceNum2 = DiceNum.Next(1, 7); // Create random number for the second dice
            if (diceNum1 == diceNum2)
            {
                rollDouble = true;
            }
            else
            {
                rollDouble = false;
            }
            diceTotal = diceNum1 + diceNum2; // Calculate the number of both dice added together
            diceTextNum.Text = diceTotal.ToString(); // Convert the dice total into a string and display it as text to the user 
            #region SetDiceImages
            if (diceNum1 == 1)
            {
                imageDice1.Image = MonopolyV1.Properties.Resources.d1;
            }
            if (diceNum1 == 2)
            {
                imageDice1.Image = MonopolyV1.Properties.Resources.d2;
            }
            if (diceNum1 == 3)
            {
                imageDice1.Image = MonopolyV1.Properties.Resources.d3;
            }
            if (diceNum1 == 4)
            {
                imageDice1.Image = MonopolyV1.Properties.Resources.d4;
            }
            if (diceNum1 == 5)
            {
                imageDice1.Image = MonopolyV1.Properties.Resources.d5;
            }
            if (diceNum1 == 6)
            {
                imageDice1.Image = MonopolyV1.Properties.Resources.d6;
            }
            // Above -- Rolls the Dice and changes the PictureBox for the first dice| Below -- Rolls the Dice and changes the PictureBox for the second dice
            if (diceNum2 == 1)
            {
                imageDice2.Image = MonopolyV1.Properties.Resources.d1;
            }
            if (diceNum2 == 2)
            {
                imageDice2.Image = MonopolyV1.Properties.Resources.d2;
            }
            if (diceNum2 == 3)
            {
                imageDice2.Image = MonopolyV1.Properties.Resources.d3;
            }
            if (diceNum2 == 4)
            {
                imageDice2.Image = MonopolyV1.Properties.Resources.d4;
            }
            if (diceNum2 == 5)
            {
                imageDice2.Image = MonopolyV1.Properties.Resources.d5;
            }
            if (diceNum2 == 6)
            {
                imageDice2.Image = MonopolyV1.Properties.Resources.d6;
            }
            #endregion
            return diceTotal;
        } // Roll Dice function
        public void updatePlayerBoardPosition()
        {
            int playerPos = player[currentPlayer].boardPosition;
            if (player[currentPlayer].inJail == false)
            {

                playerPos = playerPos + diceTotal;
                if (playerPos > 39 & playerPos != 30)
                {
                    playerPos = playerPos - 40;
                    goPassedGo.Visible = true;
                    player[currentPlayer].Money = player[currentPlayer].Money + 200;
                    updateMoney();
                }
                else if (playerPos == 30)
                {
                    player[currentPlayer].inJail = true;
                    playerPos = 40;
                    labelJailLandText.Visible = true;
                }
                player[currentPlayer].boardPosition = playerPos;
            }
            else if (player[currentPlayer].inJail == true)
            {
                player[currentPlayer].boardPosition = playerPos;
            }
        }
        public void updateMoney()
        {
            moneyPlayer1.Text = player[0].Money.ToString();
            moneyPlayer2.Text = player[1].Money.ToString();
            moneyPlayer3.Text = player[2].Money.ToString();
            moneyPlayer4.Text = player[3].Money.ToString();
            if (player[currentPlayer].Money < 1)
            {
                player[currentPlayer].Bankrupt = true;
            }
        }
        public void updateToken()
        {
            switch (currentPlayer)
            {
                case 0:
                    token1.Location = new Point(boardspace[player[currentPlayer].boardPosition].CoordX, boardspace[player[currentPlayer].boardPosition].CoordY);
                    break;
                case 1:
                    token2.Location = new Point(boardspace[player[currentPlayer].boardPosition].CoordX + 40, boardspace[player[currentPlayer].boardPosition].CoordY);
                    break;
                case 2:
                    token3.Location = new Point(boardspace[player[currentPlayer].boardPosition].CoordX, boardspace[player[currentPlayer].boardPosition].CoordY + 40);
                    break;
                case 3:
                    token4.Location = new Point(boardspace[player[currentPlayer].boardPosition].CoordX + 40, boardspace[player[currentPlayer].boardPosition].CoordY + 40);
                    break;
            }
            if (player[1].boardPosition == 10)
            {
                token2.Location = new Point(23, 843);
            }

        }
        public void propertyCheck()
        {
            for (int i = 0; i <= 27; i++)
            {
                if (player[currentPlayer].boardPosition == property[i].boardPos)
                {
                    propertyInfoPicture.Image = propertyInfo[i];
                    propertyInfoPicture.Visible = true;
                    if (property[i].isOwned == false)
                    {
                        chanceChestSecondBool = true;
                        buttonEndTurn.Visible = false;
                        buttonRollDice.Visible = false;
                        purchasePropertyName.Text = property[i].StreetName;
                        purchasePropertyName.Visible = true;
                        purchaseText1.Visible = true;
                        buyPropertyYes.Visible = true;
                        buyPropertyNo.Visible = true;
                        currentProperty = i;

                        // If it isn't owned, hide the dice roll button and show the purchase options
                        // If it is owned, do nothing
                    }
                    else if (property[i].isOwned == true)
                    {

                        if (property[i].OwnedBy != currentPlayer)
                        {
                            int rentValue = 0;

                            labelOwnedBy.Visible = true;
                            labelOwnedByName.Text = property[i].Owner;
                            labelOwnedByName.Visible = true;
                            if (property[i].boardPos == 5 || property[i].boardPos == 15 || property[i].boardPos == 25 || property[i].boardPos == 35)
                            {
                                int amountOfTrains = 0;
                                if (property[i].OwnedBy == property[2].OwnedBy)
                                {
                                    amountOfTrains++;
                                }
                                if (property[i].OwnedBy == property[10].OwnedBy)
                                {
                                    amountOfTrains++;
                                }
                                if (property[i].OwnedBy == property[17].OwnedBy)
                                {
                                    amountOfTrains++;
                                }
                                if (property[i].OwnedBy == property[25].OwnedBy)
                                {
                                    amountOfTrains++;
                                }
                                if (amountOfTrains == 1 || amountOfTrains == 2)
                                {
                                    rentValue = amountOfTrains * 25;
                                }
                                else if (amountOfTrains == 3)
                                {
                                    rentValue = 100;
                                }
                                else if (amountOfTrains == 4)
                                {
                                    rentValue = 200;
                                }
                            }
                            else if (property[i].boardPos == 12 || property[i].boardPos == 28)
                            {
                                int amountOfUtilities = 0;
                                if (property[i].OwnedBy == property[7].OwnedBy)
                                {
                                    amountOfUtilities++;
                                }
                                if (property[i].OwnedBy == property[20].OwnedBy)
                                {
                                    amountOfUtilities++;
                                }

                                if (amountOfUtilities == 1)
                                {
                                    rentValue = diceTotal * 4;
                                }
                                else if (amountOfUtilities == 2)
                                {
                                    rentValue = diceTotal * 10;
                                }
                            }
                            else
                            {
                                if (property[i].HouseNum == 0)
                                {
                                    rentValue = property[i].Rent;
                                }
                                if (property[i].HouseNum == 1)
                                {
                                    rentValue = property[i].RentHouse1;
                                }
                                if (property[i].HouseNum == 2)
                                {
                                    rentValue = property[i].RentHouse2;
                                }
                                if (property[i].HouseNum == 3)
                                {
                                    rentValue = property[i].RentHouse3;
                                }
                                if (property[i].HouseNum == 4)
                                {
                                    rentValue = property[i].RentHouse4;
                                }
                                if (property[i].HouseNum == 5)
                                {
                                    rentValue = property[i].RentHotel;
                                }
                            }
                            int payTo = property[i].OwnedBy;
                            labelRentText.Visible = true;
                            labelRentTextNum.Text = rentValue.ToString();
                            labelRentTextNum.Visible = true;
                            player[currentPlayer].Money = player[currentPlayer].Money - rentValue;
                            player[payTo].Money = player[payTo].Money + rentValue;
                            updateMoney();
                        }
                        else
                        {
                            labelOwnedBy.Visible = true;
                            labelOwnedByName.Text = "you!";
                            labelOwnedByName.Visible = true;
                        }


                    }
                }
            }
        }
        public void setPropertyInfoPictures()
        {
            propertyInfo[0] = MonopolyV1.Properties.Resources.brown1;
            propertyInfo[1] = MonopolyV1.Properties.Resources.brown2;
            propertyInfo[2] = MonopolyV1.Properties.Resources.train1;
            propertyInfo[3] = MonopolyV1.Properties.Resources.grey1;
            propertyInfo[4] = MonopolyV1.Properties.Resources.grey2;
            propertyInfo[5] = MonopolyV1.Properties.Resources.grey3;
            propertyInfo[6] = MonopolyV1.Properties.Resources.pink1;
            propertyInfo[7] = MonopolyV1.Properties.Resources.utility1;
            propertyInfo[8] = MonopolyV1.Properties.Resources.pink2;
            propertyInfo[9] = MonopolyV1.Properties.Resources.pink3;
            propertyInfo[10] = MonopolyV1.Properties.Resources.train2;
            propertyInfo[11] = MonopolyV1.Properties.Resources.orange1;
            propertyInfo[12] = MonopolyV1.Properties.Resources.orange2;
            propertyInfo[13] = MonopolyV1.Properties.Resources.orange3;
            propertyInfo[14] = MonopolyV1.Properties.Resources.red1;
            propertyInfo[15] = MonopolyV1.Properties.Resources.red2;
            propertyInfo[16] = MonopolyV1.Properties.Resources.red3;
            propertyInfo[17] = MonopolyV1.Properties.Resources.train3;
            propertyInfo[18] = MonopolyV1.Properties.Resources.yellow1;
            propertyInfo[19] = MonopolyV1.Properties.Resources.yellow2;
            propertyInfo[20] = MonopolyV1.Properties.Resources.utility2;
            propertyInfo[21] = MonopolyV1.Properties.Resources.yellow3;
            propertyInfo[22] = MonopolyV1.Properties.Resources.green1;
            propertyInfo[23] = MonopolyV1.Properties.Resources.green2;
            propertyInfo[24] = MonopolyV1.Properties.Resources.green3;
            propertyInfo[25] = MonopolyV1.Properties.Resources.train4;
            propertyInfo[26] = MonopolyV1.Properties.Resources.blue1;
            propertyInfo[27] = MonopolyV1.Properties.Resources.blue2;

        }
        public void buyProperty()
        {
            player[currentPlayer].Money = player[currentPlayer].Money - property[currentProperty].Price;
            property[currentProperty].isOwned = true;
            property[currentProperty].Owner = player[currentPlayer].Name;
            property[currentProperty].OwnedBy = currentPlayer;
            switch (currentPlayer)
            {
                case 0:
                    ownedColours[currentProperty].BackColor = p0;
                    ownedColours[currentProperty].Visible = true;
                    break;
                case 1:
                    ownedColours[currentProperty].BackColor = p1;
                    ownedColours[currentProperty].Visible = true;
                    break;
                case 2:
                    ownedColours[currentProperty].BackColor = p2;
                    ownedColours[currentProperty].Visible = true;
                    break;
                case 3:
                    ownedColours[currentProperty].BackColor = p3;
                    ownedColours[currentProperty].Visible = true;
                    break;
            }
        }
        public void setOwnedColours()
        {
            ownedColours[0] = property0OwnerColour;
            ownedColours[1] = property1OwnerColour;
            ownedColours[2] = property2OwnerColour;
            ownedColours[3] = property3OwnerColour;
            ownedColours[4] = property4OwnerColour;
            ownedColours[5] = property5OwnerColour;
            ownedColours[6] = property6OwnerColour;
            ownedColours[7] = property7OwnerColour;
            ownedColours[8] = property8OwnerColour;
            ownedColours[9] = property9OwnerColour;
            ownedColours[10] = property10OwnerColour;
            ownedColours[11] = property11OwnerColour;
            ownedColours[12] = property12OwnerColour;
            ownedColours[13] = property13OwnerColour;
            ownedColours[14] = property14OwnerColour;
            ownedColours[15] = property15OwnerColour;
            ownedColours[16] = property16OwnerColour;
            ownedColours[17] = property17OwnerColour;
            ownedColours[18] = property18OwnerColour;
            ownedColours[19] = property19OwnerColour;
            ownedColours[20] = property20OwnerColour;
            ownedColours[21] = property21OwnerColour;
            ownedColours[22] = property22OwnerColour;
            ownedColours[23] = property23OwnerColour;
            ownedColours[24] = property24OwnerColour;
            ownedColours[25] = property25OwnerColour;
            ownedColours[26] = property26OwnerColour;
            ownedColours[27] = property27OwnerColour;
        }
        public class Property
        {
            private string group;
            private string streetName;
            private int price;
            private int rent;
            private int boardPosition;
            private string owner;
            private bool owned;
            private int ownedBy;
            private int housePrice;
            private int rentHouse1;
            private int rentHouse2;
            private int rentHouse3;
            private int rentHouse4;
            private int rentHotel;
            private int houseNum;
            public Property(string group, string streetName, int price, int rent, int boardPosition, string owner, bool owned, int ownedBy, int housePrice, int rentHouse1, int rentHouse2, int rentHouse3, int rentHouse4, int rentHotel, int houseNum)
            {
                this.group = group;
                this.streetName = streetName;
                this.price = price;
                this.rent = rent;
                this.boardPosition = boardPosition;
                this.owner = owner;
                this.owned = owned;
                this.ownedBy = ownedBy;
                this.housePrice = housePrice;
                this.rentHouse1 = rentHouse1;
                this.rentHouse2 = rentHouse2;
                this.rentHouse3 = rentHouse3;
                this.rentHouse4 = rentHouse4;
                this.rentHotel = rentHotel;
                this.houseNum = houseNum;
            }
            public int HouseNum
            {
                get { return this.houseNum; }
                set { this.houseNum = value; }
            }
            public int OwnedBy
            {
                get { return this.ownedBy; }
                set { this.ownedBy = value; }
            }
            public string StreetName
            {
                get { return this.streetName; }
            }
            public int boardPos
            {
                get { return this.boardPosition; }
            }
            public int Price
            {
                get { return this.price; }
                set { this.price = value; }
            }
            public int Rent
            {
                get { return this.rent; }
            }
            public string Owner
            {
                get { return this.owner; }
                set { this.owner = value; }
            }
            public bool isOwned
            {
                get { return this.owned; }
                set { this.owned = value; }
            }
            public int HousePrice
            {
                get { return this.housePrice; }
                set { this.housePrice = value; }
            }
            public int RentHouse1
            {
                get { return this.rentHouse1; }
                set { this.rentHouse1 = value; }
            }
            public int RentHouse2
            {
                get { return this.rentHouse2; }
                set { this.rentHouse2 = value; }
            }
            public int RentHouse3
            {
                get { return this.rentHouse3; }
                set { this.rentHouse3 = value; }
            }
            public int RentHouse4
            {
                get { return this.rentHouse4; }
                set { this.rentHouse4 = value; }
            }
            public int RentHotel
            {
                get { return this.rentHotel; }
                set { this.rentHotel = value; }
            }

        }
        public void resetProperties()
        {
            property[0] = new Property("brown", "Old Kent Road", 60, 2, 1, "Not Owned", false, -1, 50, 10, 30, 90, 160, 250,0); // change 1 to -1
            property[1] = new Property("brown", "Whitechapel Road", 60, 4, 3, "Not Owned", false, -1, 50, 20,60,180,320,450,0);

            property[2] = new Property("train", "Kings Cross Station", 200, 25, 5, "Not Owned", false, -1, 0,0,0,0,0,0,0);

            property[3] = new Property("grey", "The Angel Islington", 100, 6, 6, "Not Owned", false, -1, 50,30,90,270,400,550,0);
            property[4] = new Property("grey", "Euston Road", 100, 6, 8, "Not Owned", false, -1, 50, 30, 90, 270, 400, 550,0);
            property[5] = new Property("grey", "Pentonville Road", 120, 8, 9, "Not Owned", false, -1, 50, 40, 100, 300, 450, 600,0);
            property[6] = new Property("pink", "Pall Mall", 140, 10, 11, "Not Owned", false, -1, 100, 50, 150,450,625,750,0);

            property[7] = new Property("utlity", "Electric Company", 150, 0, 12, "Not Owned", false, -1, 0,0,0,0,0,0,0);

            property[8] = new Property("pink", "Whitehall", 140, 10, 13, "Not Owned", false, -1, 100, 50, 150, 450, 625, 750,0);
            property[9] = new Property("pink", "Northumberland Avenue", 160, 12, 14, "Not Owned", false, -1, 100, 60, 180, 500, 700, 900,0);

            property[10] = new Property("train", "Marylebone Station", 200, 25, 15, "Not Owned", false, -1,0,0,0,0,0,0,0);

            property[11] = new Property("orange", "Bow Street", 180, 14, 16, "Not Owned", false, -1, 100, 70, 200, 550, 750, 950,0);
            property[12] = new Property("orange", "Marlborough Street", 180, 14, 18, "Not Owned", false, -1, 100, 70, 200, 550, 750, 950,0);
            property[13] = new Property("orange", "Vine Street", 200, 16, 19, "Not Owned", false, -1, 100, 80, 220, 600, 800, 1000,0);
            property[14] = new Property("red", "Strand", 220, 18, 21, "Not Owned", false, -1, 150, 90, 250, 700, 875, 1050,0);
            property[15] = new Property("red", "Fleet Street", 220, 18, 23, "Not Owned", false, -1, 150, 90, 250, 700, 875, 1050,0);
            property[16] = new Property("red", "Trafalgar Square", 240, 20, 24, "Not Owned", false, -1, 150, 100, 300, 750, 925, 1100,0);

            property[17] = new Property("train", "Fenchurch St Station", 200, 25, 25, "Not Owned", false, -1,0,0,0,0,0,0,0);

            property[18] = new Property("yellow", "Leicester Square", 260, 22, 26, "Not Owned", false, -1, 150, 110, 330, 800, 975, 1150,0);
            property[19] = new Property("yellow", "Coventry Street", 260, 22, 27, "Not Owned", false, -1, 150, 110, 330, 800, 975, 1150,0);

            property[20] = new Property("utility", "Water Works", 150, 0, 28, "Not Owned", false, -1,0,0,0,0,0,0,0);

            property[21] = new Property("yellow", "Piccadilly", 280, 24, 29, "Not Owned", false, -1, 150, 120, 360, 850, 1025, 1200,0);
            property[22] = new Property("green", "Regent Street", 300, 26, 31, "Not Owned", false, -1, 200, 130, 390, 900, 1100, 1275,0);
            property[23] = new Property("green", "Oxford Street", 300, 26, 32, "Not Owned", false, -1, 200, 130, 390, 900, 1100, 1275,0);
            property[24] = new Property("green", "Bond Street", 320, 28, 34, "Not Owned", false, -1, 200, 150, 450, 1000, 1200, 1400,0);

            property[25] = new Property("train", "Liverpool St Station", 200, 25, 35, "Not Owned", false, -1,0,0,0,0,0,0,0);

            property[26] = new Property("blue", "Park Lane", 350, 35, 37, "Not Owned", false, -1, 200, 175, 500, 1100, 1300, 1500,0);
            property[27] = new Property("blue", "Mayfair", 400, 50, 39, "Not Owned", false, -1, 200, 200, 600, 1400, 1700, 2000,0);

        }
        public class BoardSpace
        {
            private int position;
            private int coordX;
            private int coordY;


            public BoardSpace(int position, int coordX, int coordY)
            {
                this.position = position;
                this.coordX = coordX;
                this.coordY = coordY;

            }

            #region 'GET' the co-ordinate values (using boardspace[0].Player1X etc)
            public int Position
            {
                get { return this.position; }
            }
            public int CoordX
            {
                get { return this.coordX; }
            }
            public int CoordY
            {
                get { return this.coordY; }
            }
            #endregion 

        }
        public void taxCheck() // board space 4 & 38
        {
            if (player[currentPlayer].boardPosition == 4)
            {
                chanceChestSecondBool = true;
                labelTax1.Visible = true;
                player[currentPlayer].Money = player[currentPlayer].Money - 200;
                updateMoney();
            }
            if (player[currentPlayer].boardPosition == 38)
            {
                labelTax2.Visible = true;
                player[currentPlayer].Money = player[currentPlayer].Money - 100;
                updateMoney();
            }
        }
        public void chanceCheck()
        {
            if (player[currentPlayer].boardPosition == 7 || player[currentPlayer].boardPosition == 22 || player[currentPlayer].boardPosition == 36)
            {
                labelChanceText.Visible = true;
                chanceActive.Visible = true;
                buttonEndTurn.Visible = false;
                buttonRollDice.Visible = false;
            }
        }
        public void chestCheck()
        {
            if (player[currentPlayer].boardPosition == 2 || player[currentPlayer].boardPosition == 17 || player[currentPlayer].boardPosition == 33)
            {
                labelChestText.Visible = true;
                chestActive.Visible = true;
                buttonEndTurn.Visible = false;
                buttonRollDice.Visible = false;
            }
        }
        public void SetBoardSpaces() // Defines the data for each instance of the BoardSpace array, giving each space co-ordinates for every player.
        {
            boardspace[0] = new BoardSpace(0, 977, 853);
            boardspace[1] = new BoardSpace(1, 872, 882);
            boardspace[2] = new BoardSpace(2, 783, 870);
            boardspace[3] = new BoardSpace(3, 695, 882);
            boardspace[4] = new BoardSpace(4, 612, 870);
            boardspace[5] = new BoardSpace(5, 528, 871);
            boardspace[6] = new BoardSpace(6, 437, 889);
            boardspace[7] = new BoardSpace(7, 351, 867);
            boardspace[8] = new BoardSpace(8, 259, 889);
            boardspace[9] = new BoardSpace(9, 171, 877);
            boardspace[10] = new BoardSpace(10, 22, 889);
            boardspace[11] = new BoardSpace(11, 45, 757);
            boardspace[12] = new BoardSpace(12, 45, 681);
            boardspace[13] = new BoardSpace(13, 45, 603);
            boardspace[14] = new BoardSpace(14, 45, 526);
            boardspace[15] = new BoardSpace(15, 45, 449);
            boardspace[16] = new BoardSpace(16, 45, 372);
            boardspace[17] = new BoardSpace(17, 45, 295);
            boardspace[18] = new BoardSpace(18, 45, 218);
            boardspace[19] = new BoardSpace(19, 45, 141);
            boardspace[20] = new BoardSpace(20, 45, 64);
            boardspace[21] = new BoardSpace(21, 164, 34);
            boardspace[22] = new BoardSpace(22, 261, 34);
            boardspace[23] = new BoardSpace(23, 351, 34);
            boardspace[24] = new BoardSpace(24, 437, 34);
            boardspace[25] = new BoardSpace(25, 527, 34);
            boardspace[26] = new BoardSpace(26, 616, 34);
            boardspace[27] = new BoardSpace(27, 704, 34);
            boardspace[28] = new BoardSpace(28, 795, 34);
            boardspace[29] = new BoardSpace(29, 881, 34);
            boardspace[30] = new BoardSpace(30, 1008, 60);
            boardspace[31] = new BoardSpace(31, 1024, 144);
            boardspace[32] = new BoardSpace(32, 1024, 221);
            boardspace[33] = new BoardSpace(33, 1024, 294);
            boardspace[34] = new BoardSpace(34, 1024, 367);
            boardspace[35] = new BoardSpace(35, 1024, 440);
            boardspace[36] = new BoardSpace(36, 1024, 523);
            boardspace[37] = new BoardSpace(37, 1024, 596);
            boardspace[38] = new BoardSpace(38, 1024, 679);
            boardspace[39] = new BoardSpace(39, 1024, 752);
            boardspace[40] = new BoardSpace(40, 76, 833);

        }
        public class Player
        {
            private int money;
            private int boardposition;
            private int positionX;
            private int positionY;
            private string name;
            private bool injail;
            private bool hasjailcard;
            private bool bankrupt;

            public Player(int money, int boardposition, int positionX, int positionY, string name, bool injail, bool jailcard, bool bankrupt)
            {
                this.money = money;
                this.boardposition = boardposition;
                this.positionX = positionX;
                this.positionY = positionY;
                this.name = name;
                this.bankrupt = bankrupt;
            }
            public string Name
            {
                get { return this.name; }
                set { this.name = value; }
            }
            public bool Bankrupt
            {
                get { return this.bankrupt; }
                set { this.bankrupt = value; }
            }
            public int Money
            {
                get { return this.money; }
                set { this.money = value; }
            }
            public int boardPosition
            {
                get { return this.boardposition; }
                set { this.boardposition = value; }
            }
            public int PositionX
            {
                get { return this.positionX; }
                set { this.positionX = value; }
            }
            public int PositionY
            {
                get { return this.positionY; }
                set { this.positionY = value; }
            }
            public bool inJail
            {
                get { return this.injail; }
                set { this.injail = value; }
            }
            public bool hasJailCard
            {
                get { return this.hasjailcard; }
                set { this.hasjailcard = value; }
            }
        }
        public void SetPlayers()
        {
            // Instantiate the player objects with the money value, X and Y co-ordinate values and the name value
            player[0] = new Player(1500, 0, boardspace[0].CoordX, boardspace[0].CoordY, "Player 1", false, false, false);
            player[1] = new Player(1500, 0, boardspace[0].CoordX + 40, boardspace[0].CoordY, "Player 2", false, false, false);
            player[2] = new Player(1500, 0, boardspace[0].CoordX, boardspace[0].CoordY + 40, "Player 3", false, false, false);
            player[3] = new Player(1500, 0, boardspace[0].CoordX + 40, boardspace[0].CoordY + 40, "Player 4", false, false, false);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Start Game button is pressed, all relevant labels and pictureboxes become visible, all irrelevant become invisible
            SetNames();
            SetMoney();
            buttonPropertyHelp.Visible = true;
            labelPlayerTurnName.Text = player[currentPlayer].Name;

            // Changes player labels to the input playernames
            #region Label Visibility
            labelPlayer1.Visible = true;
            labelPlayer2.Visible = true;
            labelPlayer3.Visible = true;
            labelPlayer4.Visible = true;
            icontoken1.Visible = true;
            icontoken2.Visible = true;
            icontoken3.Visible = true;
            icontoken4.Visible = true;
            token1.Visible = true;
            token2.Visible = true;
            token3.Visible = true;
            token4.Visible = true;
            labelEnterNames.Visible = false;
            labelEnterName1.Visible = false;
            labelEnterName2.Visible = false;
            labelEnterName3.Visible = false;
            labelEnterName4.Visible = false;
            player1Name.Visible = false;
            player2Name.Visible = false;
            player3Name.Visible = false;
            player4Name.Visible = false;
            buttonStart.Visible = false;
            moneyPlayer1.Visible = true;
            moneyPlayer2.Visible = true;
            moneyPlayer3.Visible = true;
            moneyPlayer4.Visible = true;
            moneyCurrency1.Visible = true;
            moneyCurrency2.Visible = true;
            moneyCurrency3.Visible = true;
            moneyCurrency4.Visible = true;
            buttonRollDice.Visible = true;
            imageDice1.Visible = true;
            imageDice2.Visible = true;
            diceText.Visible = true;
            diceTextNum.Visible = true;
            buttonPlay.Visible = false;
            labelPlayerTurnName.Visible = true;
            labelPlayerTurnText.Visible = true;
            #endregion
        }
        public void SetNames()
        {
            // Update player name attributes to what is in the textbox
            player[0].Name = player1Name.Text;
            player[1].Name = player2Name.Text;
            player[2].Name = player3Name.Text;
            player[3].Name = player4Name.Text;

            // Update player labels to the names stored in the name attributes
            labelPlayer1.Text = player[0].Name;
            labelPlayer2.Text = player[1].Name;
            labelPlayer3.Text = player[2].Name;
            labelPlayer4.Text = player[3].Name;
        }
        public void SetMoney()
        {
            // Set the money labels to the values stored in the player class
            moneyPlayer1.Text = player[0].Money.ToString();
            moneyPlayer2.Text = player[1].Money.ToString();
            moneyPlayer3.Text = player[2].Money.ToString();
            moneyPlayer4.Text = player[3].Money.ToString();
        }
        public void SetStartPositions()
        {
            // Initialize the player tokens to the starting position
            token1.Location = new Point(player[0].PositionX, player[0].PositionY);
            token2.Location = new Point(player[1].PositionX, player[1].PositionY);
            token3.Location = new Point(player[2].PositionX, player[2].PositionY);
            token4.Location = new Point(player[3].PositionX, player[3].PositionY);
        }
        #region unused functions
        private void labelPlayer1_Click(object sender, EventArgs e)
        {

        }


        private void labelDice_Click(object sender, EventArgs e)
        {

        }

        private void boardChest_Click(object sender, EventArgs e)
        {

        }

        private void board_Click(object sender, EventArgs e)
        {

        }

        

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }
        #endregion
        public void jailCheck()
        {
            if (player[currentPlayer].inJail == true)
            {
                labelJailText.Visible = true;
                buttonJailFee.Visible = true;

            }
        }
        private void buttonRollDice_Click(object sender, EventArgs e)
        {
            hideLabels1();
            jailCheck();
            diceRoll();
            if (player[currentPlayer].inJail == false)
            {
                if (rollDouble == true)
                {
                    doubleCount++;
                    if (doubleCount == 3)
                    {
                        doubleText.Visible = false;
                        player[currentPlayer].inJail = true;
                        player[currentPlayer].boardPosition = 40;
                        labelJailDouble.Visible = true;
                        buttonRollDice.Visible = false;
                        buttonEndTurn.Visible = true;
                        updateToken();
                    }
                    else if (doubleCount != 3)
                    {
                        doubleText.Visible = true;
                        labelJailText.Visible = false;
                        buttonJailFee.Visible = false;
                        updatePlayerBoardPosition();
                        updateToken();
                        propertyCheck();
                        chanceCheck();
                        chestCheck();
                        taxCheck();
                    }
                }
                else
                {
                    doubleText.Visible = false;
                    buttonRollDice.Visible = false;
                    buttonEndTurn.Visible = true;
                    updatePlayerBoardPosition();
                    updateToken();
                    propertyCheck();
                    chanceCheck();
                    chestCheck();
                    taxCheck();
                }
            }
            else if (player[currentPlayer].inJail == true)
            {
                
                if (rollDouble == true)
                {
                    labelOutOfJail.Visible = true;
                    buttonJailFee.Visible = false;
                    labelJailText.Visible = false;
                    buttonRollDice.Visible = false;
                    buttonEndTurn.Visible = true;
                    player[currentPlayer].inJail = false;
                    player[currentPlayer].boardPosition = 10;
                    updateToken();
                }
                else
                {
                    doubleText.Visible = false;
                    buttonRollDice.Visible = false;
                    buttonEndTurn.Visible = true;
                }
            }

        }
        private void buttonPlay_Click(object sender, EventArgs e)
        {
            labelEnterNames.Visible = true;
            labelEnterName1.Visible = true;
            labelEnterName2.Visible = true;
            labelEnterName3.Visible = true;
            labelEnterName4.Visible = true;
            player1Name.Visible = true;
            player2Name.Visible = true;
            player4Name.Visible = true;
            player3Name.Visible = true;
            buttonStart.Visible = true;
            buttonPlay.Visible = false;
        }

        private void diceTextNum_Click(object sender, EventArgs e)
        {

        }

        private void buyPropertyYes_Click(object sender, EventArgs e)
        {
            buyProperty();
            updateMoney();
            buyPropertyYes.Visible = false;
            buyPropertyNo.Visible = false;
            purchaseText1.Visible = false;
            purchasePropertyName.Visible = false;

            if (rollDouble == true)
            {
                buttonRollDice.Visible = true;
                buttonEndTurn.Visible = false;
            }
            else
            {
                buttonRollDice.Visible = false;
                buttonEndTurn.Visible = true;
            }

        }

        private void buyPropertyNo_Click(object sender, EventArgs e)
        {
            buyPropertyYes.Visible = false;
            buyPropertyNo.Visible = false;
            buttonRollDice.Visible = true;
            buttonEndTurn.Visible = true;
            purchaseText1.Visible = false;
            purchasePropertyName.Visible = false;
            if (rollDouble == true)
            {
                buttonEndTurn.Visible = false;
                buttonRollDice.Visible = true;
            }
            else
            {
                buttonRollDice.Visible = false;
                buttonEndTurn.Visible = true;
            }
        }

        private void End_Turn_Click(object sender, EventArgs e)
        {
            doubleCount = 0;
            currentPlayer++;
            turnCheck();
            bankruptCheck();
            winnerCheck();
            labelPlayerTurnName.Text = player[currentPlayer].Name;
            buttonRollDice.Visible = true;
            if (gameFinished == true)
            {
                buttonRollDice.Visible = false;
            }
            buttonEndTurn.Visible = false;
            if (player[currentPlayer].inJail == true & player[currentPlayer].hasJailCard == true)
            {
                buttonJailFree.Visible = true;
                buttonRollDice.Visible = false;
            }
            else if (player[currentPlayer].inJail == true & player[currentPlayer].hasJailCard == false)
                {
                    labelJailText.Visible = true;
                    buttonJailFee.Visible = true;
                }
            else
            {
                labelJailText.Visible = false;
                buttonJailFee.Visible = false;
            }
            hideLabels1();


        }
        public void hideLabels1()
        {
            goPassedGo.Visible = false;
            propertyInfoPicture.Visible = false;
            labelOwnedBy.Visible = false;
            labelOwnedByName.Visible = false;
            labelRentText.Visible = false;
            labelRentTextNum.Visible = false;
            labelJailLandText.Visible = false;
            labelOutOfJail.Visible = false;
            labelTax1.Visible = false;
            labelTax2.Visible = false;
            labelJailDouble.Visible = false;
            labelChanceText.Visible = false;
            boardChance.BorderStyle = BorderStyle.FixedSingle;
            boardChest.BorderStyle = BorderStyle.FixedSingle;
            cardPicture.Visible = false;
            chanceChestBool = false;
            chanceChestSecondBool = false;
            houseBuy = 0;
            houseBuyYes.Visible = false;
            houseBuyNo.Visible = false;
            buyHouseCost.Visible = false;
            buyHouseText1.Visible = false;

        }
        private void propertyInfoPicture_Click(object sender, EventArgs e)
        {

        }

        private void buttonJailFee_Click(object sender, EventArgs e)
        {
            player[currentPlayer].Money = player[currentPlayer].Money - 50;
            player[currentPlayer].inJail = false;
            player[currentPlayer].boardPosition = 10;
            updateToken();
            updateMoney();
            buttonJailFee.Visible = false;
            labelJailText.Visible = false;
            buttonRollDice.Visible = false;
            buttonEndTurn.Visible = true;

        }

        private void boardChance_Click(object sender, EventArgs e)
        {

        }
        public void chanceSelect()
        {
            Random chanceRandom = new Random();
            int chanceNum = chanceRandom.Next(0, 14);
            goPassedGo.Visible = false;
            switch (chanceNum)
            {
                case 0: // Move Straight to GO
                    // Chance Image Visible
                    cardPicture.Image = MonopolyV1.Properties.Resources.chanceGO;
                    cardPicture.Visible = true;
                    player[currentPlayer].boardPosition = 0;
                    goPassedGo.Visible = true;
                    player[currentPlayer].Money = player[currentPlayer].Money + 200;
                    updateMoney();
                    updateToken();
                    break;
                case 1: // Go straight to Jail
                    // Chance Image Visible
                    cardPicture.Image = MonopolyV1.Properties.Resources.chanceJail;
                    cardPicture.Visible = true;
                    player[currentPlayer].inJail = true;
                    player[currentPlayer].boardPosition = 40;
                    updateToken();
                    break;
                case 2: // Go to Pall Mall
                    cardPicture.Image = MonopolyV1.Properties.Resources.chancePallMall;
                    cardPicture.Visible = true;
                    if (player[currentPlayer].boardPosition != 7)
                    {
                        goPassedGo.Visible = true;
                        player[currentPlayer].Money = player[currentPlayer].Money + 200;
                        updateMoney();
                    }
                    player[currentPlayer].boardPosition = 11;
                    updateToken();
                    propertyCheck();
                    if (chanceChestSecondBool == true)
                    {
                        chanceChestBool = true;
                    }
                    break;
                case 3:
                    cardPicture.Image = MonopolyV1.Properties.Resources.chanceMaryleboneStation;
                    cardPicture.Visible = true;
                    if (player[currentPlayer].boardPosition == 22 || player[currentPlayer].boardPosition == 36)
                    {
                        goPassedGo.Visible = true;
                        player[currentPlayer].Money = player[currentPlayer].Money + 200;
                        updateMoney();
                    }
                    player[currentPlayer].boardPosition = 15;
                    updateToken();
                    propertyCheck();
                    if (chanceChestSecondBool == true)
                    {
                        chanceChestBool = true;
                    }
                    break;
                case 4:
                    cardPicture.Image = MonopolyV1.Properties.Resources.chanceTrafalgarSq;
                    cardPicture.Visible = true;
                    if (player[currentPlayer].boardPosition == 36)
                    {
                        goPassedGo.Visible = true;
                        player[currentPlayer].Money = player[currentPlayer].Money + 200;
                        updateMoney();
                    }
                    player[currentPlayer].boardPosition = 24;
                    updateToken();
                    propertyCheck();
                    if (chanceChestSecondBool == true)
                    {
                        chanceChestBool = true;
                    }
                    break;

                case 5:
                    cardPicture.Image = MonopolyV1.Properties.Resources.chanceMayfair;
                    cardPicture.Visible = true;
                    player[currentPlayer].boardPosition = 39;
                    updateToken();
                    propertyCheck();
                    if (chanceChestSecondBool == true)
                    {
                        chanceChestBool = true;
                    }
                    break;

                case 6:
                    cardPicture.Image = MonopolyV1.Properties.Resources.chanceGoBack;
                    cardPicture.Visible = true;
                    player[currentPlayer].boardPosition = player[currentPlayer].boardPosition - 3;
                    updateToken();
                    propertyCheck();
                    if ( chanceChestSecondBool == true)
                    {
                        chanceChestBool = true;
                    }
                    chestCheck();
                    taxCheck();
                    break;

                case 7:
                    cardPicture.Image = MonopolyV1.Properties.Resources.chanceSchoolFees;
                    cardPicture.Visible = true;
                    player[currentPlayer].Money = player[currentPlayer].Money - 150;
                    updateMoney();
                    break;

                case 8:
                    cardPicture.Image = MonopolyV1.Properties.Resources.chanceLoitering20;
                    cardPicture.Visible = true;
                    player[currentPlayer].Money = player[currentPlayer].Money - 20;
                    updateMoney();
                    break;

                case 9:
                    cardPicture.Image = MonopolyV1.Properties.Resources.chanceSpeeding15;
                    cardPicture.Visible = true;
                    player[currentPlayer].Money = player[currentPlayer].Money - 15;
                    updateMoney();

                    break;

                case 10:
                    cardPicture.Image = MonopolyV1.Properties.Resources.chanceFunding150;
                    cardPicture.Visible = true;
                    player[currentPlayer].Money = player[currentPlayer].Money + 150;
                    updateMoney();

                    break;

                case 11:
                    cardPicture.Image = MonopolyV1.Properties.Resources.chanceCrossword100;
                    cardPicture.Visible = true;
                    player[currentPlayer].Money = player[currentPlayer].Money + 100;
                    updateMoney();

                    break;

                case 12:
                    cardPicture.Image = MonopolyV1.Properties.Resources.chanceBank50;
                    cardPicture.Visible = true;
                    player[currentPlayer].Money = player[currentPlayer].Money + 50;
                    updateMoney();


                    break;

                case 13:
                    cardPicture.Image = MonopolyV1.Properties.Resources.chanceJailFree;
                    cardPicture.Visible = true;
                    player[currentPlayer].hasJailCard = true;
                    break;
            }
        }
        private void chanceActive_Click(object sender, EventArgs e)
        {
            chanceActive.Visible = false;
            labelChanceText.Visible = false;
            boardChance.BorderStyle = BorderStyle.Fixed3D;
            chanceSelect();
            if (rollDouble == false)
            {
                buttonEndTurn.Visible = true;
            }
            else if (rollDouble == true)
            {
                buttonRollDice.Visible = true;
            }
            if (chanceChestBool == true)
            {
                buttonEndTurn.Visible = false;
            }
        }

        private void buttonJailFree_Click(object sender, EventArgs e)
        {
            player[currentPlayer].hasJailCard = false;
            player[currentPlayer].inJail = false;
            player[currentPlayer].boardPosition = 10;
            updateToken();
            buttonJailFree.Visible = false;
            labelJailText.Visible = false;
            buttonEndTurn.Visible = true;
            

            
        }

        private void chestActive_Click(object sender, EventArgs e)
        {
            
            chestActive.Visible = false;
            labelChestText.Visible = false;
            boardChest.BorderStyle = BorderStyle.Fixed3D;
            chestSelect();
            if (rollDouble == false)
            {
                buttonEndTurn.Visible = true;
            }
            else if (rollDouble == true)
            {
                buttonRollDice.Visible = true;
            }
            if (chanceChestBool == true)
            {
                buttonEndTurn.Visible = false;
            }
        }
        public void chestSelect()
        {
            Random chestRandom = new Random();
            int chestNum = chestRandom.Next(0, 16);
            goPassedGo.Visible = false;
            switch (chestNum)
            {
                case 0: // Advance to GO
                    cardPicture.Image = MonopolyV1.Properties.Resources.chestGO;
                    cardPicture.Visible = true;
                    player[currentPlayer].boardPosition = 0;
                    goPassedGo.Visible = true;
                    player[currentPlayer].Money = player[currentPlayer].Money + 200;
                    updateMoney();
                    updateToken();
                    break;
                case 1: // Go straight to Jail
                    cardPicture.Image = MonopolyV1.Properties.Resources.chestJail;
                    cardPicture.Visible = true;
                    player[currentPlayer].inJail = true;
                    player[currentPlayer].boardPosition = 40;
                    updateToken();
                    break;
                case 2:
                    cardPicture.Image = MonopolyV1.Properties.Resources.chestOldKentRoad;
                    cardPicture.Visible = true;
                    player[currentPlayer].boardPosition = 1;
                    updateToken();
                    propertyCheck();
                    if (chanceChestSecondBool == true)
                    {
                        chanceChestBool = true;
                    }
                    break;
                case 3:
                    cardPicture.Image = MonopolyV1.Properties.Resources.chestHospitalFine100;
                    cardPicture.Visible = true;
                    player[currentPlayer].Money = player[currentPlayer].Money - 100;
                    updateMoney();
                    break;
                case 4:
                    cardPicture.Image = MonopolyV1.Properties.Resources.chestDoctorFine50;
                    cardPicture.Visible = true;
                    player[currentPlayer].Money = player[currentPlayer].Money - 50;
                    updateMoney();
                    break;

                case 5:
                    cardPicture.Image = MonopolyV1.Properties.Resources.chestInsuranceFine50;
                    cardPicture.Visible = true;
                    player[currentPlayer].Money = player[currentPlayer].Money - 50;
                    updateMoney();
                    break;

                case 6:
                    cardPicture.Image = MonopolyV1.Properties.Resources.chestBankError200;
                    cardPicture.Visible = true;
                    player[currentPlayer].Money = player[currentPlayer].Money + 200;
                    updateMoney();
                    break;

                case 7:
                    cardPicture.Image = MonopolyV1.Properties.Resources.chestAnnuity100;
                    cardPicture.Visible = true;
                    player[currentPlayer].Money = player[currentPlayer].Money + 100;
                    updateMoney();
                    break;

                case 8:
                    cardPicture.Image = MonopolyV1.Properties.Resources.chestInherit100;
                    cardPicture.Visible = true;
                    player[currentPlayer].Money = player[currentPlayer].Money + 100;
                    updateMoney();
                    break;

                case 9:
                    cardPicture.Image = MonopolyV1.Properties.Resources.chestStock50;
                    cardPicture.Visible = true;
                    player[currentPlayer].Money = player[currentPlayer].Money + 50;
                    updateMoney();

                    break;

                case 10:
                    cardPicture.Image = MonopolyV1.Properties.Resources.chestShares25;
                    cardPicture.Visible = true;
                    player[currentPlayer].Money = player[currentPlayer].Money + 25;
                    updateMoney();

                    break;

                case 11:
                    cardPicture.Image = MonopolyV1.Properties.Resources.chestTaxRefund;
                    cardPicture.Visible = true;
                    player[currentPlayer].Money = player[currentPlayer].Money + 20;
                    updateMoney();

                    break;

                case 12:
                    cardPicture.Image = MonopolyV1.Properties.Resources.chestBeautyContest;
                    cardPicture.Visible = true;
                    player[currentPlayer].Money = player[currentPlayer].Money + 10;
                    updateMoney();


                    break;

                case 13:
                    cardPicture.Image = MonopolyV1.Properties.Resources.chestJailFree;
                    cardPicture.Visible = true;
                    player[currentPlayer].hasJailCard = true;
                    break;
                case 14:
                    cardPicture.Image = MonopolyV1.Properties.Resources.chestBirthday;
                    cardPicture.Visible = true;
                    player[currentPlayer].Money = player[currentPlayer].Money + 40;
                    player[0].Money = player[0].Money - 10;
                    player[1].Money = player[1].Money - 10;
                    player[2].Money = player[2].Money - 10;
                    player[3].Money = player[3].Money - 10;
                    updateMoney();
                    break;
                case 15:
                    cardPicture.Image = MonopolyV1.Properties.Resources.chest10FineChance;
                    cardPicture.Visible = true;
                    buttonChestChance.Visible = true;
                    buttonChestFine.Visible = true;
                    buttonEndTurn.Visible = false;
                    chanceChestBool = true;
                    break;
            }
        }

        private void buttonChestFine_Click(object sender, EventArgs e)
        {
            buttonChestFine.Visible = false;
            buttonChestChance.Visible = false;
            buttonEndTurn.Visible = true;
            player[currentPlayer].Money = player[currentPlayer].Money - 10;
            updateMoney();
        }

        private void buttonChestChance_Click(object sender, EventArgs e)
        {
            chanceChestBool = false;
            buttonChestChance.Visible = false;
            buttonChestFine.Visible = false;
            labelChanceText.Visible = true;
            chanceActive.Visible = true;
            buttonEndTurn.Visible = false;
            buttonRollDice.Visible = false;
        }

        private void buttonPropertyHelp_Click(object sender, EventArgs e)
        {

            if (buttonPropertyHelp.Text != "Close")
            {
                labelHouseHelp.Visible = true;
                buttonPropertyHelp.Text = "Close";
            }
            else
            {
                labelHouseHelp.Visible = false;
                buttonPropertyHelp.Text = "House Help";
            }

            
        }
        public void showHousePurchase()
        {
            buyHouseCost.Text = buyHouseCost.Text + "?";
            buyHouseCost.Visible = true;
            buyHouseText1.Visible = true;
            houseBuyNo.Visible = true;
            houseBuyYes.Visible = true;

        }
        #region buyHouses
        private void boardBrown1_Click(object sender, EventArgs e)
        {
            if (property[0].OwnedBy == currentPlayer & property[1].OwnedBy == currentPlayer & property[0].HouseNum <5)
            {
                propertyInfoPicture.Image = propertyInfo[0];
                propertyInfoPicture.Visible = true;
                buyHouseCost.Text = property[0].HousePrice.ToString();
                showHousePurchase();
                houseBuy = 1;
            }
        }

        private void boardBrown2_Click(object sender, EventArgs e)
        {
            if(property[0].OwnedBy == currentPlayer & property[1].OwnedBy == currentPlayer & property[1].HouseNum < 5)
            {
                propertyInfoPicture.Image = propertyInfo[1];
                propertyInfoPicture.Visible = true;
                buyHouseCost.Text = property[1].HousePrice.ToString();
                showHousePurchase();
                houseBuy = 2;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void houseBuyNo_Click(object sender, EventArgs e)
        {
            propertyInfoPicture.Visible = false;
            buyHouseCost.Visible = false;
            buyHouseText1.Visible = false;
            houseBuy = 0;
        }
        private void houseBuyYes_Click(object sender, EventArgs e)
        {
            propertyInfoPicture.Visible = false;
            buyHouseCost.Visible = false;
            buyHouseText1.Visible = false;
            houseBuyNo.Visible = false;
            houseBuyYes.Visible = false;

            switch (houseBuy)
            {
                case 1:
                    property[0].HouseNum++;
                    player[currentPlayer].Money = player[currentPlayer].Money - property[0].HousePrice;
                    if (property[0].HouseNum == 1)
                    {
                        propertyHouses1.Image = MonopolyV1.Properties.Resources.brown11;
                        propertyHouses1.Visible = true;
                    }
                    if (property[0].HouseNum == 2)
                    {
                        propertyHouses1.Image = MonopolyV1.Properties.Resources.brown21;
                        propertyHouses1.Visible = true;
                    }
                    if (property[0].HouseNum == 3)
                    {
                        propertyHouses1.Image = MonopolyV1.Properties.Resources.brown3;
                        propertyHouses1.Visible = true;
                    }
                    if (property[0].HouseNum == 4)
                    {
                        propertyHouses1.Image = MonopolyV1.Properties.Resources.brown4;
                        propertyHouses1.Visible = true;
                    }
                    if (property[0].HouseNum == 5)
                    {
                        propertyHouses1.Image = MonopolyV1.Properties.Resources.brown5;
                        propertyHouses1.Visible = true;
                    }
                    break;
                case 2:
                    property[1].HouseNum++;
                    player[currentPlayer].Money = player[currentPlayer].Money - property[1].HousePrice;
                    if (property[1].HouseNum == 1)
                    {
                        propertyHouses2.Image = MonopolyV1.Properties.Resources.brown11;
                        propertyHouses2.Visible = true;
                    }
                    if (property[1].HouseNum == 2)
                    {
                        propertyHouses2.Image = MonopolyV1.Properties.Resources.brown21;
                        propertyHouses2.Visible = true;
                    }
                    if (property[1].HouseNum == 3)
                    {
                        propertyHouses2.Image = MonopolyV1.Properties.Resources.brown3;
                        propertyHouses2.Visible = true;
                    }
                    if (property[1].HouseNum == 4)
                    {
                        propertyHouses2.Image = MonopolyV1.Properties.Resources.brown4;
                        propertyHouses2.Visible = true;
                    }
                    if (property[1].HouseNum == 5)
                    {
                        propertyHouses2.Image = MonopolyV1.Properties.Resources.brown5;
                        propertyHouses2.Visible = true;
                    }

                    break;
                case 3:
                    property[3].HouseNum++;
                    player[currentPlayer].Money = player[currentPlayer].Money - property[3].HousePrice;
                    if (property[3].HouseNum == 1)
                    {
                        propertyHouses3.Image = MonopolyV1.Properties.Resources.grey11;
                        propertyHouses3.Visible = true;
                    }
                    if (property[3].HouseNum == 2)
                    {
                        propertyHouses3.Image = MonopolyV1.Properties.Resources.grey21;
                        propertyHouses3.Visible = true;
                    }
                    if (property[3].HouseNum == 3)
                    {
                        propertyHouses3.Image = MonopolyV1.Properties.Resources.grey31;
                        propertyHouses3.Visible = true;
                    }
                    if (property[3].HouseNum == 4)
                    {
                        propertyHouses3.Image = MonopolyV1.Properties.Resources.grey4;
                        propertyHouses3.Visible = true;
                    }
                    if (property[3].HouseNum == 5)
                    {
                        propertyHouses3.Image = MonopolyV1.Properties.Resources.grey5;
                        propertyHouses3.Visible = true;
                    }
                    break;
                case 4:
                    property[4].HouseNum++;
                    player[currentPlayer].Money = player[currentPlayer].Money - property[4].HousePrice;
                    if (property[4].HouseNum == 1)
                    {
                        propertyHouses4.Image = MonopolyV1.Properties.Resources.grey11;
                        propertyHouses4.Visible = true;
                    }
                    if (property[4].HouseNum == 2)
                    {
                        propertyHouses4.Image = MonopolyV1.Properties.Resources.grey21;
                        propertyHouses4.Visible = true;
                    }
                    if (property[4].HouseNum == 3)
                    {
                        propertyHouses4.Image = MonopolyV1.Properties.Resources.grey31;
                        propertyHouses4.Visible = true;
                    }
                    if (property[4].HouseNum == 4)
                    {
                        propertyHouses4.Image = MonopolyV1.Properties.Resources.grey4;
                        propertyHouses4.Visible = true;
                    }
                    if (property[4].HouseNum == 5)
                    {
                        propertyHouses4.Image = MonopolyV1.Properties.Resources.grey5;
                        propertyHouses4.Visible = true;
                    }
                    break;
                case 5:
                    property[5].HouseNum++;
                    player[currentPlayer].Money = player[currentPlayer].Money - property[5].HousePrice;
                    if (property[5].HouseNum == 1)
                    {
                        propertyHouses5.Image = MonopolyV1.Properties.Resources.grey11;
                        propertyHouses5.Visible = true;
                    }
                    if (property[5].HouseNum == 2)
                    {
                        propertyHouses5.Image = MonopolyV1.Properties.Resources.grey21;
                        propertyHouses5.Visible = true;
                    }
                    if (property[5].HouseNum == 3)
                    {
                        propertyHouses5.Image = MonopolyV1.Properties.Resources.grey31;
                        propertyHouses5.Visible = true;
                    }
                    if (property[5].HouseNum == 4)
                    {
                        propertyHouses5.Image = MonopolyV1.Properties.Resources.grey4;
                        propertyHouses5.Visible = true;
                    }
                    if (property[5].HouseNum == 5)
                    {
                        propertyHouses5.Image = MonopolyV1.Properties.Resources.grey5;
                        propertyHouses5.Visible = true;
                    }
                    break;
                case 6:
                    property[6].HouseNum++;
                    player[currentPlayer].Money = player[currentPlayer].Money - property[6].HousePrice;
                    if (property[6].HouseNum == 1)
                    {
                        propertyHouses6.Image = MonopolyV1.Properties.Resources.pink11;
                        propertyHouses6.Visible = true;
                    }
                    if (property[6].HouseNum == 2)
                    {
                        propertyHouses6.Image = MonopolyV1.Properties.Resources.pink21;
                        propertyHouses6.Visible = true;
                    }
                    if (property[6].HouseNum == 3)
                    {
                        propertyHouses6.Image = MonopolyV1.Properties.Resources.pink31;
                        propertyHouses6.Visible = true;
                    }
                    if (property[6].HouseNum == 4)
                    {
                        propertyHouses6.Image = MonopolyV1.Properties.Resources.pink4;
                        propertyHouses6.Visible = true;
                    }
                    if (property[6].HouseNum == 5)
                    {
                        propertyHouses6.Image = MonopolyV1.Properties.Resources.pink5;
                        propertyHouses6.Visible = true;
                    }
                    break;
                case 7:
                    property[8].HouseNum++;
                    player[currentPlayer].Money = player[currentPlayer].Money - property[8].HousePrice;
                    if (property[8].HouseNum == 1)
                    {
                        propertyHouses7.Image = MonopolyV1.Properties.Resources.pink11;
                        propertyHouses7.Visible = true;
                    }
                    if (property[8].HouseNum == 2)
                    {
                        propertyHouses7.Image = MonopolyV1.Properties.Resources.pink21;
                        propertyHouses7.Visible = true;
                    }
                    if (property[8].HouseNum == 3)
                    {
                        propertyHouses7.Image = MonopolyV1.Properties.Resources.pink31;
                        propertyHouses7.Visible = true;
                    }
                    if (property[8].HouseNum == 4)
                    {
                        propertyHouses7.Image = MonopolyV1.Properties.Resources.pink4;
                        propertyHouses7.Visible = true;
                    }
                    if (property[8].HouseNum == 5)
                    {
                        propertyHouses7.Image = MonopolyV1.Properties.Resources.pink5;
                        propertyHouses7.Visible = true;
                    }
                    break;
                case 8:
                    property[9].HouseNum++;
                    player[currentPlayer].Money = player[currentPlayer].Money - property[9].HousePrice;
                    if (property[9].HouseNum == 1)
                    {
                        propertyHouses8.Image = MonopolyV1.Properties.Resources.pink11;
                        propertyHouses8.Visible = true;
                    }
                    if (property[9].HouseNum == 2)
                    {
                        propertyHouses8.Image = MonopolyV1.Properties.Resources.pink21;
                        propertyHouses8.Visible = true;
                    }
                    if (property[9].HouseNum == 3)
                    {
                        propertyHouses8.Image = MonopolyV1.Properties.Resources.pink31;
                        propertyHouses8.Visible = true;
                    }
                    if (property[9].HouseNum == 4)
                    {
                        propertyHouses8.Image = MonopolyV1.Properties.Resources.pink4;
                        propertyHouses8.Visible = true;
                    }
                    if (property[9].HouseNum == 5)
                    {
                        propertyHouses8.Image = MonopolyV1.Properties.Resources.pink5;
                        propertyHouses8.Visible = true;
                    }
                    break;
                case 9:
                    property[11].HouseNum++;
                    player[currentPlayer].Money = player[currentPlayer].Money - property[11].HousePrice;
                    if (property[11].HouseNum == 1)
                    {
                        propertyHouses9.Image = MonopolyV1.Properties.Resources.orange11;
                        propertyHouses9.Visible = true;
                    }
                    if (property[11].HouseNum == 2)
                    {
                        propertyHouses9.Image = MonopolyV1.Properties.Resources.orange21;
                        propertyHouses9.Visible = true;
                    }
                    if (property[11].HouseNum == 3)
                    {
                        propertyHouses9.Image = MonopolyV1.Properties.Resources.orange31;
                        propertyHouses9.Visible = true;
                    }
                    if (property[11].HouseNum == 4)
                    {
                        propertyHouses9.Image = MonopolyV1.Properties.Resources.orange4;
                        propertyHouses9.Visible = true;
                    }
                    if (property[11].HouseNum == 5)
                    {
                        propertyHouses9.Image = MonopolyV1.Properties.Resources.orange5;
                        propertyHouses9.Visible = true;
                    }
                    break;
                case 10:
                    property[12].HouseNum++;
                    player[currentPlayer].Money = player[currentPlayer].Money - property[12].HousePrice;
                    if (property[12].HouseNum == 1)
                    {
                        propertyHouses10.Image = MonopolyV1.Properties.Resources.orange11;
                        propertyHouses10.Visible = true;
                    }
                    if (property[12].HouseNum == 2)
                    {
                        propertyHouses10.Image = MonopolyV1.Properties.Resources.orange21;
                        propertyHouses10.Visible = true;
                    }
                    if (property[12].HouseNum == 3)
                    {
                        propertyHouses10.Image = MonopolyV1.Properties.Resources.orange31;
                        propertyHouses10.Visible = true;
                    }
                    if (property[12].HouseNum == 4)
                    {
                        propertyHouses10.Image = MonopolyV1.Properties.Resources.orange4;
                        propertyHouses10.Visible = true;
                    }
                    if (property[12].HouseNum == 5)
                    {
                        propertyHouses10.Image = MonopolyV1.Properties.Resources.orange5;
                        propertyHouses10.Visible = true;
                    }
                    break;
                case 11:
                    property[13].HouseNum++;
                    player[currentPlayer].Money = player[currentPlayer].Money - property[13].HousePrice;
                    if (property[13].HouseNum == 1)
                    {
                        propertyHouses11.Image = MonopolyV1.Properties.Resources.orange11;
                        propertyHouses11.Visible = true;
                    }
                    if (property[13].HouseNum == 2)
                    {
                        propertyHouses11.Image = MonopolyV1.Properties.Resources.orange21;
                        propertyHouses11.Visible = true;
                    }
                    if (property[13].HouseNum == 3)
                    {
                        propertyHouses11.Image = MonopolyV1.Properties.Resources.orange31;
                        propertyHouses11.Visible = true;
                    }
                    if (property[13].HouseNum == 4)
                    {
                        propertyHouses11.Image = MonopolyV1.Properties.Resources.orange4;
                        propertyHouses11.Visible = true;
                    }
                    if (property[13].HouseNum == 5)
                    {
                        propertyHouses11.Image = MonopolyV1.Properties.Resources.orange5;
                        propertyHouses11.Visible = true;
                    }
                    break;
                case 12:
                    property[14].HouseNum++;
                    player[currentPlayer].Money = player[currentPlayer].Money - property[14].HousePrice;
                    if (property[14].HouseNum == 1)
                    {
                        propertyHouses12.Image = MonopolyV1.Properties.Resources.red11;
                        propertyHouses12.Visible = true;
                    }
                    if (property[14].HouseNum == 2)
                    {
                        propertyHouses12.Image = MonopolyV1.Properties.Resources.red21;
                        propertyHouses12.Visible = true;
                    }
                    if (property[14].HouseNum == 3)
                    {
                        propertyHouses12.Image = MonopolyV1.Properties.Resources.red31;
                        propertyHouses12.Visible = true;
                    }
                    if (property[14].HouseNum == 4)
                    {
                        propertyHouses12.Image = MonopolyV1.Properties.Resources.red4;
                        propertyHouses12.Visible = true;
                    }
                    if (property[14].HouseNum == 5)
                    {
                        propertyHouses12.Image = MonopolyV1.Properties.Resources.red5;
                        propertyHouses12.Visible = true;
                    }
                    break;
                case 13:
                    property[15].HouseNum++;
                    player[currentPlayer].Money = player[currentPlayer].Money - property[15].HousePrice;
                    if (property[15].HouseNum == 1)
                    {
                        propertyHouses13.Image = MonopolyV1.Properties.Resources.red11;
                        propertyHouses13.Visible = true;
                    }
                    if (property[15].HouseNum == 2)
                    {
                        propertyHouses13.Image = MonopolyV1.Properties.Resources.red21;
                        propertyHouses13.Visible = true;
                    }
                    if (property[15].HouseNum == 3)
                    {
                        propertyHouses13.Image = MonopolyV1.Properties.Resources.red31;
                        propertyHouses13.Visible = true;
                    }
                    if (property[15].HouseNum == 4)
                    {
                        propertyHouses13.Image = MonopolyV1.Properties.Resources.red4;
                        propertyHouses13.Visible = true;
                    }
                    if (property[15].HouseNum == 5)
                    {
                        propertyHouses13.Image = MonopolyV1.Properties.Resources.red5;
                        propertyHouses13.Visible = true;
                    }
                    break;
                case 14:
                    property[16].HouseNum++;
                    player[currentPlayer].Money = player[currentPlayer].Money - property[16].HousePrice;
                    if (property[16].HouseNum == 1)
                    {
                        propertyHouses14.Image = MonopolyV1.Properties.Resources.red11;
                        propertyHouses14.Visible = true;
                    }
                    if (property[16].HouseNum == 2)
                    {
                        propertyHouses14.Image = MonopolyV1.Properties.Resources.red21;
                        propertyHouses14.Visible = true;
                    }
                    if (property[16].HouseNum == 3)
                    {
                        propertyHouses14.Image = MonopolyV1.Properties.Resources.red31;
                        propertyHouses14.Visible = true;
                    }
                    if (property[16].HouseNum == 4)
                    {
                        propertyHouses14.Image = MonopolyV1.Properties.Resources.red4;
                        propertyHouses14.Visible = true;
                    }
                    if (property[16].HouseNum == 5)
                    {
                        propertyHouses14.Image = MonopolyV1.Properties.Resources.red5;
                        propertyHouses14.Visible = true;
                    }
                    break;
                case 15:
                    property[18].HouseNum++;
                    player[currentPlayer].Money = player[currentPlayer].Money - property[18].HousePrice;
                    if (property[18].HouseNum == 1)
                    {
                        propertyHouses15.Image = MonopolyV1.Properties.Resources.yellow11;
                        propertyHouses15.Visible = true;
                    }
                    if (property[18].HouseNum == 2)
                    {
                        propertyHouses15.Image = MonopolyV1.Properties.Resources.yellow21;
                        propertyHouses15.Visible = true;
                    }
                    if (property[18].HouseNum == 3)
                    {
                        propertyHouses15.Image = MonopolyV1.Properties.Resources.yellow31;
                        propertyHouses15.Visible = true;
                    }
                    if (property[18].HouseNum == 4)
                    {
                        propertyHouses15.Image = MonopolyV1.Properties.Resources.yellow4;
                        propertyHouses15.Visible = true;
                    }
                    if (property[18].HouseNum == 5)
                    {
                        propertyHouses15.Image = MonopolyV1.Properties.Resources.yellow5;
                        propertyHouses15.Visible = true;
                    }
                    break;
                case 16:
                    property[19].HouseNum++;
                    player[currentPlayer].Money = player[currentPlayer].Money - property[19].HousePrice;
                    if (property[19].HouseNum == 1)
                    {
                        propertyHouses16.Image = MonopolyV1.Properties.Resources.yellow11;
                        propertyHouses16.Visible = true;
                    }
                    if (property[19].HouseNum == 2)
                    {
                        propertyHouses16.Image = MonopolyV1.Properties.Resources.yellow21;
                        propertyHouses16.Visible = true;
                    }
                    if (property[19].HouseNum == 3)
                    {
                        propertyHouses16.Image = MonopolyV1.Properties.Resources.yellow31;
                        propertyHouses16.Visible = true;
                    }
                    if (property[19].HouseNum == 4)
                    {
                        propertyHouses16.Image = MonopolyV1.Properties.Resources.yellow4;
                        propertyHouses16.Visible = true;
                    }
                    if (property[19].HouseNum == 5)
                    {
                        propertyHouses16.Image = MonopolyV1.Properties.Resources.yellow5;
                        propertyHouses16.Visible = true;
                    }
                    break;
                case 17:
                    property[21].HouseNum++;
                    player[currentPlayer].Money = player[currentPlayer].Money - property[21].HousePrice;
                    if (property[21].HouseNum == 1)
                    {
                        propertyHouses17.Image = MonopolyV1.Properties.Resources.yellow11;
                        propertyHouses17.Visible = true;
                    }
                    if (property[21].HouseNum == 2)
                    {
                        propertyHouses17.Image = MonopolyV1.Properties.Resources.yellow21;
                        propertyHouses17.Visible = true;
                    }
                    if (property[21].HouseNum == 3)
                    {
                        propertyHouses17.Image = MonopolyV1.Properties.Resources.yellow31;
                        propertyHouses17.Visible = true;
                    }
                    if (property[21].HouseNum == 4)
                    {
                        propertyHouses17.Image = MonopolyV1.Properties.Resources.yellow4;
                        propertyHouses17.Visible = true;
                    }
                    if (property[21].HouseNum == 5)
                    {
                        propertyHouses17.Image = MonopolyV1.Properties.Resources.yellow5;
                        propertyHouses17.Visible = true;
                    }
                    break;
                case 18:
                    property[22].HouseNum++;
                    player[currentPlayer].Money = player[currentPlayer].Money - property[22].HousePrice;
                    if (property[22].HouseNum == 1)
                    {
                        propertyHouses18.Image = MonopolyV1.Properties.Resources.green11;
                        propertyHouses18.Visible = true;
                    }
                    if (property[22].HouseNum == 2)
                    {
                        propertyHouses18.Image = MonopolyV1.Properties.Resources.green21;
                        propertyHouses18.Visible = true;
                    }
                    if (property[22].HouseNum == 3)
                    {
                        propertyHouses18.Image = MonopolyV1.Properties.Resources.green31;
                        propertyHouses18.Visible = true;
                    }
                    if (property[22].HouseNum == 4)
                    {
                        propertyHouses18.Image = MonopolyV1.Properties.Resources.green4;
                        propertyHouses18.Visible = true;
                    }
                    if (property[22].HouseNum == 5)
                    {
                        propertyHouses18.Image = MonopolyV1.Properties.Resources.green5;
                        propertyHouses18.Visible = true;
                    }
                    break;
                case 19:
                    property[23].HouseNum++;
                    player[currentPlayer].Money = player[currentPlayer].Money - property[23].HousePrice;
                    if (property[23].HouseNum == 1)
                    {
                        propertyHouses19.Image = MonopolyV1.Properties.Resources.green11;
                        propertyHouses19.Visible = true;
                    }
                    if (property[23].HouseNum == 2)
                    {
                        propertyHouses19.Image = MonopolyV1.Properties.Resources.green21;
                        propertyHouses19.Visible = true;
                    }
                    if (property[23].HouseNum == 3)
                    {
                        propertyHouses19.Image = MonopolyV1.Properties.Resources.green31;
                        propertyHouses19.Visible = true;
                    }
                    if (property[23].HouseNum == 4)
                    {
                        propertyHouses19.Image = MonopolyV1.Properties.Resources.green4;
                        propertyHouses19.Visible = true;
                    }
                    if (property[23].HouseNum == 5)
                    {
                        propertyHouses19.Image = MonopolyV1.Properties.Resources.green5;
                        propertyHouses19.Visible = true;
                    }
                    break;
                case 20:
                    property[24].HouseNum++;
                    player[currentPlayer].Money = player[currentPlayer].Money - property[24].HousePrice;
                    if (property[24].HouseNum == 1)
                    {
                        propertyHouses20.Image = MonopolyV1.Properties.Resources.green11;
                        propertyHouses20.Visible = true;
                    }
                    if (property[24].HouseNum == 2)
                    {
                        propertyHouses20.Image = MonopolyV1.Properties.Resources.green21;
                        propertyHouses20.Visible = true;
                    }
                    if (property[24].HouseNum == 3)
                    {
                        propertyHouses20.Image = MonopolyV1.Properties.Resources.green31;
                        propertyHouses20.Visible = true;
                    }
                    if (property[24].HouseNum == 4)
                    {
                        propertyHouses20.Image = MonopolyV1.Properties.Resources.green4;
                        propertyHouses20.Visible = true;
                    }
                    if (property[24].HouseNum == 5)
                    {
                        propertyHouses20.Image = MonopolyV1.Properties.Resources.green5;
                        propertyHouses20.Visible = true;
                    }
                    break;
                case 21:
                    property[26].HouseNum++;
                    player[currentPlayer].Money = player[currentPlayer].Money - property[26].HousePrice;
                    if (property[26].HouseNum == 1)
                    {
                        propertyHouses21.Image = MonopolyV1.Properties.Resources.blue11;
                        propertyHouses21.Visible = true;
                    }
                    if (property[26].HouseNum == 2)
                    {
                        propertyHouses21.Image = MonopolyV1.Properties.Resources.blue21;
                        propertyHouses21.Visible = true;
                    }
                    if (property[26].HouseNum == 3)
                    {
                        propertyHouses21.Image = MonopolyV1.Properties.Resources.blue3;
                        propertyHouses21.Visible = true;
                    }
                    if (property[26].HouseNum == 4)
                    {
                        propertyHouses21.Image = MonopolyV1.Properties.Resources.blue4;
                        propertyHouses21.Visible = true;
                    }
                    if (property[26].HouseNum == 5)
                    {
                        propertyHouses21.Image = MonopolyV1.Properties.Resources.blue5;
                        propertyHouses21.Visible = true;
                    }
                    break;
                case 22:
                    property[27].HouseNum++;
                    player[currentPlayer].Money = player[currentPlayer].Money - property[27].HousePrice;
                    if (property[27].HouseNum == 1)
                    {
                        propertyHouses22.Image = MonopolyV1.Properties.Resources.blue11;
                        propertyHouses22.Visible = true;
                    }
                    if (property[27].HouseNum == 2)
                    {
                        propertyHouses22.Image = MonopolyV1.Properties.Resources.blue21;
                        propertyHouses22.Visible = true;
                    }
                    if (property[27].HouseNum == 3)
                    {
                        propertyHouses22.Image = MonopolyV1.Properties.Resources.blue3;
                        propertyHouses22.Visible = true;
                    }
                    if (property[27].HouseNum == 4)
                    {
                        propertyHouses22.Image = MonopolyV1.Properties.Resources.blue4;
                        propertyHouses22.Visible = true;
                    }
                    if (property[27].HouseNum == 5)
                    {
                        propertyHouses22.Image = MonopolyV1.Properties.Resources.blue5;
                        propertyHouses22.Visible = true;
                    }
                    break;
            }
            updateMoney();

        }

        private void boardGrey1_Click(object sender, EventArgs e)
        {
            if(property[3].OwnedBy == currentPlayer & property[4].OwnedBy == currentPlayer & property[5].OwnedBy == currentPlayer & property[3].HouseNum < 5)
            {
                propertyInfoPicture.Image = propertyInfo[3];
                propertyInfoPicture.Visible = true;
                buyHouseCost.Text = property[3].HousePrice.ToString();
                showHousePurchase();
                houseBuy = 3;
            }
            
        }

        private void boardGrey2_Click(object sender, EventArgs e)
        {
            if (property[3].OwnedBy == currentPlayer & property[4].OwnedBy == currentPlayer & property[5].OwnedBy == currentPlayer & property[4].HouseNum < 5)
            {
                propertyInfoPicture.Image = propertyInfo[4];
                propertyInfoPicture.Visible = true;
                buyHouseCost.Text = property[4].HousePrice.ToString();
                showHousePurchase();
                houseBuy = 4;
            }
        }

        private void boardGrey3_Click(object sender, EventArgs e)
        {
            if (property[3].OwnedBy == currentPlayer & property[4].OwnedBy == currentPlayer & property[5].OwnedBy == currentPlayer & property[5].HouseNum < 5)
            {
                propertyInfoPicture.Image = propertyInfo[5];
                propertyInfoPicture.Visible = true;
                buyHouseCost.Text = property[5].HousePrice.ToString();
                showHousePurchase();
                houseBuy = 5;
            }
        }

        private void boardPink1_Click(object sender, EventArgs e)
        {
            if (property[6].OwnedBy == currentPlayer & property[8].OwnedBy == currentPlayer & property[9].OwnedBy == currentPlayer & property[6].HouseNum < 5)
            {
                propertyInfoPicture.Image = propertyInfo[6];
                propertyInfoPicture.Visible = true;
                buyHouseCost.Text = property[6].HousePrice.ToString();
                showHousePurchase();
                houseBuy = 6;
            }
        }

        private void boardPink2_Click(object sender, EventArgs e)
        {
            if (property[6].OwnedBy == currentPlayer & property[8].OwnedBy == currentPlayer & property[9].OwnedBy == currentPlayer & property[8].HouseNum < 5)
            {
                propertyInfoPicture.Image = propertyInfo[8];
                propertyInfoPicture.Visible = true;
                buyHouseCost.Text = property[8].HousePrice.ToString();
                showHousePurchase();
                houseBuy = 7;
            }
        }

        private void boardPink3_Click(object sender, EventArgs e)
        {
            if (property[6].OwnedBy == currentPlayer & property[8].OwnedBy == currentPlayer & property[9].OwnedBy == currentPlayer & property[9].HouseNum < 5)
            {
                propertyInfoPicture.Image = propertyInfo[9];
                propertyInfoPicture.Visible = true;
                buyHouseCost.Text = property[9].HousePrice.ToString();
                showHousePurchase();
                houseBuy = 8;
            }
        }

        private void boardOrange1_Click(object sender, EventArgs e)
        {
            if (property[11].OwnedBy == currentPlayer & property[12].OwnedBy == currentPlayer & property[13].OwnedBy == currentPlayer & property[11].HouseNum < 5)
            {
                propertyInfoPicture.Image = propertyInfo[11];
                propertyInfoPicture.Visible = true;
                buyHouseCost.Text = property[11].HousePrice.ToString();
                showHousePurchase();
                houseBuy = 9;
            }
        }

        private void boardOrange2_Click(object sender, EventArgs e)
        {
            if (property[11].OwnedBy == currentPlayer & property[12].OwnedBy == currentPlayer & property[13].OwnedBy == currentPlayer & property[12].HouseNum < 5)
            {
                propertyInfoPicture.Image = propertyInfo[12];
                propertyInfoPicture.Visible = true;
                buyHouseCost.Text = property[12].HousePrice.ToString();
                showHousePurchase();
                houseBuy = 10;
            }
        }

        private void boardOrange3_Click(object sender, EventArgs e)
        {
            if (property[11].OwnedBy == currentPlayer & property[12].OwnedBy == currentPlayer & property[13].OwnedBy == currentPlayer & property[13].HouseNum < 5)
            {
                propertyInfoPicture.Image = propertyInfo[13];
                propertyInfoPicture.Visible = true;
                buyHouseCost.Text = property[13].HousePrice.ToString();
                showHousePurchase();
                houseBuy = 11;
            }
        }
        private void boardRed1_Click(object sender, EventArgs e)
        {
            if (property[14].OwnedBy == currentPlayer & property[15].OwnedBy == currentPlayer & property[16].OwnedBy == currentPlayer & property[14].HouseNum < 5)
            {
                propertyInfoPicture.Image = propertyInfo[14];
                propertyInfoPicture.Visible = true;
                buyHouseCost.Text = property[14].HousePrice.ToString();
                showHousePurchase();
                houseBuy = 12;
            }
        }

        private void boardRed2_Click(object sender, EventArgs e)
        {
            if (property[14].OwnedBy == currentPlayer & property[15].OwnedBy == currentPlayer & property[16].OwnedBy == currentPlayer & property[15].HouseNum < 5)
            {
                propertyInfoPicture.Image = propertyInfo[15];
                propertyInfoPicture.Visible = true;
                buyHouseCost.Text = property[15].HousePrice.ToString();
                showHousePurchase();
                houseBuy = 13;
            }

        }

        private void boardRed3_Click(object sender, EventArgs e)
        {
            if (property[14].OwnedBy == currentPlayer & property[15].OwnedBy == currentPlayer & property[16].OwnedBy == currentPlayer & property[16].HouseNum < 5)
            {
                propertyInfoPicture.Image = propertyInfo[16];
                propertyInfoPicture.Visible = true;
                buyHouseCost.Text = property[16].HousePrice.ToString();
                showHousePurchase();
                houseBuy = 14;
            }
        }

        private void boardYellow1_Click(object sender, EventArgs e)
        {
            if (property[18].OwnedBy == currentPlayer & property[19].OwnedBy == currentPlayer & property[21].OwnedBy == currentPlayer & property[18].HouseNum < 5)
            {
                propertyInfoPicture.Image = propertyInfo[18];
                propertyInfoPicture.Visible = true;
                buyHouseCost.Text = property[18].HousePrice.ToString();
                showHousePurchase();
                houseBuy = 15;
            }
        }

        private void boardYellow2_Click(object sender, EventArgs e)
        {
            if (property[18].OwnedBy == currentPlayer & property[19].OwnedBy == currentPlayer & property[21].OwnedBy == currentPlayer & property[19].HouseNum < 5)
            {
                propertyInfoPicture.Image = propertyInfo[19];
                propertyInfoPicture.Visible = true;
                buyHouseCost.Text = property[19].HousePrice.ToString();
                showHousePurchase();
                houseBuy = 16;
            }
        }

        private void boardYellow3_Click(object sender, EventArgs e)
        {
            if (property[18].OwnedBy == currentPlayer & property[19].OwnedBy == currentPlayer & property[21].OwnedBy == currentPlayer & property[21].HouseNum < 5)
            {
                propertyInfoPicture.Image = propertyInfo[21];
                propertyInfoPicture.Visible = true;
                buyHouseCost.Text = property[21].HousePrice.ToString();
                showHousePurchase();
                houseBuy = 17;
            }
        }

        private void boardGreen1_Click(object sender, EventArgs e)
        {
            if (property[22].OwnedBy == currentPlayer & property[23].OwnedBy == currentPlayer & property[24].OwnedBy == currentPlayer & property[22].HouseNum < 5)
            {
                propertyInfoPicture.Image = propertyInfo[22];
                propertyInfoPicture.Visible = true;
                buyHouseCost.Text = property[22].HousePrice.ToString();
                showHousePurchase();
                houseBuy = 18;
            }
        }

        private void boardGreen2_Click(object sender, EventArgs e)
        {
            if (property[22].OwnedBy == currentPlayer & property[23].OwnedBy == currentPlayer & property[24].OwnedBy == currentPlayer & property[23].HouseNum < 5)
            {
                propertyInfoPicture.Image = propertyInfo[23];
                propertyInfoPicture.Visible = true;
                buyHouseCost.Text = property[23].HousePrice.ToString();
                showHousePurchase();
                houseBuy = 19;
            }
        }

        private void boardGreen3_Click(object sender, EventArgs e)
        {
            if (property[22].OwnedBy == currentPlayer & property[23].OwnedBy == currentPlayer & property[24].OwnedBy == currentPlayer & property[24].HouseNum < 5)
            {
                propertyInfoPicture.Image = propertyInfo[24];
                propertyInfoPicture.Visible = true;
                buyHouseCost.Text = property[24].HousePrice.ToString();
                showHousePurchase();
                houseBuy = 20;
            }
        }

        private void boardBlue1_Click(object sender, EventArgs e)
        {
            if (property[26].OwnedBy == currentPlayer & property[27].OwnedBy == currentPlayer & property[26].HouseNum < 5)
            {
                propertyInfoPicture.Image = propertyInfo[26];
                propertyInfoPicture.Visible = true;
                buyHouseCost.Text = property[26].HousePrice.ToString();
                showHousePurchase();
                houseBuy = 21;
            }
        }

        private void boardBlue2_Click(object sender, EventArgs e)
        {
            if (property[26].OwnedBy == currentPlayer & property[27].OwnedBy == currentPlayer & property[27].HouseNum < 5)
            {
                propertyInfoPicture.Image = propertyInfo[27];
                propertyInfoPicture.Visible = true;
                buyHouseCost.Text = property[27].HousePrice.ToString();
                showHousePurchase();
                houseBuy = 22;
            }
        }
#endregion
    }

}
