/*
Jason lu
Nov, 27, 2017
Assignment2
this is a program to show TryParse, and random generators
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment2__Unit2_
{
    public partial class Form1 : Form
    {
        //Generate random enemy
        Random Create = new Random();
        int generate;
        //Ai Attack generator 
        Random AiFight = new Random();
        int AiAttack;
        //Ai Magic Attack generator
        Random AiMagic = new System.Random();
        int AiFightMagic;
        //Magic Attack generator
        Random Magic = new System.Random();
        int FightMagic;
        //Attack generator
        Random Fight = new Random();
        int Attack;
        //Heal generator
        Random Heal = new System.Random();
        int HealMe;
        //Ai Heal generator
        Random AiHeal = new System.Random();
        int AiHealMe;
        //AI moves
        Random Move = new Random();
        int playerMove;
        const int ATTACK = 0, MAGICBOOST = 1, HEAL = 2, ATTACKBOOST = 3, MAGICATTACK = 4;
        int aiSaveMagic, aiSaveHealth;
        int aiAttackBoostCounter;
        bool aiAttackCounter;
        //Stat creation
        string attack, defense, magic, health;
        int realAttack, realDefense, realMagic, realHealth;
        int calculate;
        int saveMagic;
        int saveHealth;
        int attackBoostCounter;
        bool attackCounter;
        //Enemy Stat creation
        int aiAttack, aiDefense, aiMagic, aiHealth;
        //Win Screen
        int winCounter;
        bool Winner;

        public Form1()
        {
            InitializeComponent();
            //text to tell players where to input their stats
            lblTitle.Text = "Create your \r\n character";
            lblAttack.Text = "Attack Stat";
            lblDefense.Text = "Defense Stat";
            lblHealth.Text = "Health pool";
            lblMagic.Text = "Magic Stat";
            //Error message
            lblError.Text = "Make sure\r\nyour stats\r\nequal 400";
            //all the tutorial text
            lblMessages.Text = "Hello! I'm the tiny Pikachu\r\nyou are currently in\r\na battle for your life\r\ndon't worry I can help\r\nclick on ME to continue!";
            lblAttckTutorial.Text = "This button is for attacking\r\nThis is one of 2 ways to destroy your enemy\r\npress it and see what happens\r\nnow click me again";
            lblMagicBoostTutorial.Text = "The Magic Attack button is for\r\nlaunching magic\r\nthe other button lets you\r\ngain magic\r\nabout press them\r\nand see what happens\r\nnow click me again";
            lblHealTutorial.Text = "This button is for healing\r\nuse it when your low on health\r\npress it and see what happens\r\nnow click me once more";
            lblAttackBoostTutorial.Text = "This button is for boosting your attack value\r\nuse it to attacks upgrade your attack power\r\npress it and see what happens\r\nnow click on me for the final time!";
            //hides all the pictures, panels, text, and buttons
            picDigimon2.Hide();
            picDigimon3.Hide();
            picDigimon1.Hide();
            btnAttack.Hide();
            btnMagicBoost.Hide();
            btnAttackBoost.Hide();
            btnHeal.Hide();
            lblAttckTutorial.Hide();
            picButton2.Hide();
            picButton3.Hide();
            lblMagicBoostTutorial.Hide();
            picButton4.Hide();
            picButton5.Hide();
            lblHealTutorial.Hide();
            lblAttackBoostTutorial.Hide();
            picButton6.Hide();
            btnMagicAttack.Hide();
            pnl3.Hide();
            pnl4.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //hide panel 2
            pnl2.Hide();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //convert the typed in numbers into the stats
            attack = txtAttack.Text;

            int.TryParse(txtAttack.Text, out realAttack);

             defense = txtDefense.Text;

            int.TryParse(txtDefense.Text, out realDefense);

             magic = txtMagic.Text;

            int.TryParse(txtMagic.Text, out realMagic);
            int.TryParse(txtMagic.Text, out saveMagic);

             health = txtHealth.Text;

            int.TryParse(txtHealth.Text, out realHealth);
            int.TryParse(txtHealth.Text, out saveHealth);

            //adding all the stats to see if they equal 400
            calculate = (realAttack + realDefense + realHealth + realMagic);

            //all the other error messages 
            if (realAttack < 0)
            {
                lblError.Text = "Error!\r\nAttack power must be\r\nat least 0";
            }

            else if (realMagic < 0)
            {
                lblError.Text = "Error!\r\nMagic stat must be\r\nat least 0";
            }

            else if (realHealth < 10)
            {
                lblError.Text = "Error!\r\nHealth stat must be\r\nat least 10";
            }

            else if (realDefense < 1)
            {
                lblError.Text = "Error!\r\nDefense stat must be\r\nat least 1";
            }

            else if (calculate != 400)
            {
                lblError.Text = "Error! Total stats must\r\nequal 400";
            }

            //if every thing equals 400 the program continues 
            else if (calculate == 400)
            {
                pnl1.Hide();
                pnl2.Show();

                GenerateEnemy();

                realHealth = realHealth * 15;
                lblPlayerHpBar.Text = "Hp:" + realHealth.ToString();

                saveHealth = realHealth;
                lblPlayerHpBar.Text = "Hp:" + realHealth.ToString();

                lblPlayerMpBar.Text = "Mp:" + realMagic.ToString();

                saveMagic = realMagic;
                lblPlayerMpBar.Text = "Mp:" + realMagic.ToString();

                Winner = true;
            }   
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            //hides the giant picture
            picTitleScreen.Hide();
        }

        private void txtHealth_TextChanged(object sender, EventArgs e)
        {

        }

        //Attack tutorial
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            btnAttack.Show();
            lblMessages.Hide();
            picButton.Hide();
            lblAttckTutorial.Show();
            picButton2.Show();
        }
        
        //Magic tutorial
        private void picButton2_Click(object sender, EventArgs e)
        {
            btnMagicAttack.Show();
            btnMagicBoost.Show();
            btnAttack.Hide();
            lblAttckTutorial.Hide();
            picButton2.Hide();
            lblMagicBoostTutorial.Show();
            picButton3.Show();
        }

        //Heal tutorial
        private void picButton3_Click(object sender, EventArgs e)
        {
            btnMagicAttack.Hide();
            btnHeal.Show();
            btnMagicBoost.Hide();
            lblMagicBoostTutorial.Hide();
            picButton3.Hide();
            lblHealTutorial.Show();
            picButton4.Show();
        }

        //Defense tutorial
        private void picButton4_Click(object sender, EventArgs e)
        {
            btnAttackBoost.Show();
            btnHeal.Hide();
            lblHealTutorial.Hide();
            picButton4.Hide();
            lblAttackBoostTutorial.Show();
            picButton5.Show();
        }

        //Battle options
        private void picButton5_Click(object sender, EventArgs e)
        {
            btnAttack.Show();
            btnHeal.Show();
            btnMagicBoost.Show();
            picButton6.Show();
            picButton5.Hide();
            lblAttackBoostTutorial.Hide();
            btnMagicAttack.Show();
        }
        // creates an enemy to fight
        void GenerateEnemy()
        {

            generate = Create.Next(0, 3);

            //first enemy
            if (generate == 0)
            {
                WinScreen();

                aiHealth = 2250;
                lblHpBar.Text = "Hp:" + aiHealth.ToString();

                aiMagic = 50;
                lblMpBar.Text = "Mp:" + aiMagic.ToString();

                aiDefense = 100;

                aiAttack = 100;

                picDigimon2.Hide();
                picDigimon1.Show();
                picDigimon3.Hide();
            }

            //second enemy
            else if (generate == 1)
            {
                WinScreen();

                aiHealth = 3750;
                lblHpBar.Text = "Hp:" + aiHealth.ToString();

                aiMagic = 50;
                lblMpBar.Text = "Mp:" + aiMagic.ToString();

                aiDefense = 50;

                aiAttack = 50;

                picDigimon2.Show();
                picDigimon1.Hide();
                picDigimon3.Hide();
            }

            //third enemy
            else if (generate == 2)
            {
                WinScreen();

                aiHealth = 4500;
                lblHpBar.Text = "Hp:" + aiHealth.ToString();

                aiMagic = 0;
                lblMpBar.Text = "Mp:" + aiMagic.ToString();

                aiDefense = 25;

                aiAttack = 25;

                picDigimon2.Hide();
                picDigimon1.Hide();
                picDigimon3.Show(); 
            }

            aiSaveHealth = aiHealth;
            aiSaveMagic = aiMagic;
            lblHpBar.Text = "Hp:" + aiHealth.ToString();
            lblMpBar.Text = "Mp:" + aiMagic.ToString();
        }

         //Attack boost counter
        void AttackCounter()
        {
            if (attackCounter == true)
            {
                attackBoostCounter = attackBoostCounter + 1;
                if (attackBoostCounter > 2)
                {
                    attackCounter = false;
                }
            }
        }

        //ai attack boost counter
        void AiAttackCounter()
        {
            if (aiAttackCounter == true)
            {
                aiAttackBoostCounter = aiAttackBoostCounter + 1;
                if (aiAttackBoostCounter > 2)
                {
                    aiAttackCounter = false;
                }
            }
        }

        //win screen sub program
        void WinScreen()
        {
            if (Winner == true)
            {
                winCounter = winCounter + 1;

                if (winCounter >= 3)
                {
                    Winner = false;
                    if (Winner == false)
                    {
                        pnl2.Hide();
                        pnl3.Show();
                    }
                }
            }
        }

        //lose screen sub program
        void LoseScreen()
        {
            if (realHealth <= 0)
            {
                pnl2.Hide();
                pnl4.Show();
            }
        }

        //the computer moves subprograms
        void computerMoveAttack()
        {
            AiAttack = Fight.Next(100, 151);

            int attackBoostFactor = 1;
            if (aiAttackCounter)
            {
                attackBoostFactor = 2;
            }

           int aiDamage = (((aiAttack + AiAttack) - realDefense) * attackBoostFactor);
            realHealth = realHealth - aiDamage;
            lblPlayerHpBar.Text = "Hp:" + realHealth.ToString();
            lblBattleBox2.Text = "Monster dealt " + (aiDamage) + " damge to you";

            AiAttackCounter();
        }

        void computerMoveMagicAttack()
        {
            if (aiMagic >= 20)
            {
                aiMagic = aiMagic - 20;
                lblMpBar.Text = "Mp:" + aiMagic.ToString();

                AiFightMagic = AiMagic.Next(400, 601);

                AiAttackCounter();

                realHealth = realHealth - AiFightMagic;
                lblPlayerHpBar.Text = "Hp:" + realHealth.ToString();

                lblBattleBox2.Text = "Monster delt " + AiFightMagic + " damge to you";

            }

            else
            {
                lblBattleBox2.Text = "Enemy's magic attack failed";
            }
        }

        void computerMoveMagicBoost()
        {
            if (aiMagic < aiSaveMagic)
            {
                aiMagic = aiMagic + 20;
                if (aiMagic > aiSaveMagic)
                {
                    aiMagic = aiSaveMagic;
                }
                lblMpBar.Text = "Mp:" + aiMagic.ToString();
                lblBattleBox2.Text = "Enemy gained 20 Mana";

                AiAttackCounter();
            }
            else
            {
                lblBattleBox2.Text = "Enemy's magic boost failed";
            }
        }

        void computerMoveHeal()
        {
            if (aiMagic >= 10 && aiHealth <= aiSaveHealth)
            {
                aiMagic = aiMagic - 10;
                if (aiMagic < 0)
                {
                    aiMagic = 0;
                }
                lblMpBar.Text = "Mp:" + aiMagic.ToString();

                HealMe = Heal.Next(50, 201);
                aiHealth = aiHealth + HealMe;
                if (aiHealth > aiSaveHealth)
                {
                    aiHealth = aiSaveHealth;
                }
                lblHpBar.Text = "Hp:" + aiHealth.ToString();

                lblBattleBox2.Text = "enemy healed " + HealMe + " Hp";

                AiAttackCounter();
            }
            else
            {
                lblBattleBox2.Text = "enemy healed 0 Hp";
            }
        }

        void computerMoveAttackBoost()
        {
            if (aiMagic >= 5)
            {
                aiAttackCounter = true;
                aiAttackBoostCounter = 0;
                aiMagic = aiMagic - 5;
                lblMpBar.Text = "Mp:" + aiMagic.ToString();
                lblBattleBox2.Text = "enemy did a attack boost";
            }

            else
            {
                aiAttack = aiAttack + 0;
                lblHpBar.Text = "Hp:" + aiHealth.ToString();
                lblBattleBox2.Text = "enemy attack boost failed";
            }
        }

        //this makes things easier to look at, its basiclly like sub programs and the generator still picks one of the 5 moves
        void ComputerMove()
        {
            switch(Move.Next(0, 5))
            {
                case ATTACK:
                    computerMoveAttack();
                    break;

                case MAGICATTACK:
                    computerMoveMagicAttack();
                    break;

                case MAGICBOOST:
                    computerMoveMagicBoost();
                    break;

                case HEAL:
                    computerMoveHeal();
                    break;

                case ATTACKBOOST:
                    computerMoveAttackBoost();
                    break;
            }

            LoseScreen();
        }
        

        private void lblHpBar_Click(object sender, EventArgs e)
        {

        }

        //player moves
        //player magic boost
        private void btnMagic_Click(object sender, EventArgs e)
        {
            if (realMagic < saveMagic)
            {
                realMagic = realMagic + 20;
                lblPlayerMpBar.Text = "Mp:" + realMagic.ToString();
                lblBattleBox1.Text = "You gained 20 Mana";

                AttackCounter();

                if (aiHealth <= 0)
                {
                    GenerateEnemy();
                    lblBattleBox2.Text = "A new Monster has appered";
                }

                else
                {
                    ComputerMove();
                }
            }

            if (realMagic > saveMagic)
            {
                lblBattleBox1.Text = "Your Magic is full, choose another move";
            }
        }

        //player attack
        private void btnAttack_Click(object sender, EventArgs e)
        {
            Attack = Fight.Next(100, 151);

            int attackBoostFactor = 1;
            if (attackCounter)
            {
                attackBoostFactor = 2;
            }

            int damage = ((realAttack + Attack) - aiDefense) * attackBoostFactor;
            aiHealth = aiHealth - damage;
            lblHpBar.Text = "Hp:" + aiHealth.ToString();

            lblBattleBox1.Text = "you delt " + damage + " damge to Monster";

            AttackCounter();

            if (aiHealth <= 0)
            {
                GenerateEnemy();
                lblBattleBox1.Text = "A new Monster has appered";
            }

            else
            {
                ComputerMove();
            }
        }

        //Player heal
        private void btnHeal_Click(object sender, EventArgs e)
        {
            if (realMagic >= 10 && realHealth < saveHealth)
            {
                HealMe = Heal.Next(50, 201);
                realMagic = realMagic - 10;
                lblPlayerMpBar.Text = "Mp:" + realMagic.ToString();

                realHealth = realHealth + HealMe;
                if (realHealth > saveHealth)
                {
                    realHealth = saveHealth;
                }
                lblPlayerHpBar.Text = "Hp:" + realHealth.ToString();
                lblBattleBox1.Text = "you healed " + HealMe + " Hp";

                AttackCounter();

                if (aiHealth <= 0)
                {
                    GenerateEnemy();
                    lblBattleBox1.Text = "A new Monster has appered";
                }

                else
                {
                    ComputerMove();
                }
            }         

            else
            {
                realHealth = realHealth + 0;
                lblPlayerHpBar.Text = "Hp:" + realHealth.ToString();
                lblBattleBox1.Text = "No mana";
            }
        }

        //player attack boost
        private void btnAttackBoost_Click(object sender, EventArgs e)
        {

            if (realMagic >= 5)
            {
                attackCounter = true;
                attackBoostCounter = 0;
                realMagic = realMagic - 5;
                lblPlayerMpBar.Text = "Mp:" + realMagic.ToString();
                lblBattleBox1.Text = "Your attack now does X2 damage for 2 turns";
            }

            else
            {
                realAttack = realAttack + 0;
                lblPlayerHpBar.Text = "Hp:" + realHealth.ToString();
                lblBattleBox1.Text = "No mana";
            }


            if (aiHealth <= 0)
            {
                GenerateEnemy();
            }

            else
            {
                ComputerMove();
            }
        }     

        //Player Magic attack
        private void btnMagicAttack_Click(object sender, EventArgs e)
        {

            if (realMagic >= 20)
            {
                realMagic = realMagic - 20;
                lblPlayerMpBar.Text = "Mp:" + realMagic.ToString();

                FightMagic = Magic.Next(400, 601);

                aiHealth = aiHealth - FightMagic;
                lblHpBar.Text = "Hp:" + aiHealth.ToString();

                lblBattleBox1.Text = "You delt " + FightMagic + " To your enemy";

                AttackCounter();

                if (aiHealth <= 0)
                {
                    GenerateEnemy();
                    lblBattleBox1.Text = "A new Monster has appered";
                }

                else
                {
                    ComputerMove();
                }
            }

            else
            {
                lblBattleBox1.Text = "Not enough Mana";
            }
        }
    }
}
