using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4gewinnt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Button[,] viergewinnt = new Button[5, 6];
        Button[] Felder = new Button[6];
        Color winner;
        
        List<int> schritte = new List<int>();
        List<int> along = new List<int>();
        
        private void Form1_Load(object sender, EventArgs e)
        {
            Buttonarray();
        }

        private void Buttonarray()
        {

            viergewinnt[0, 0] = button1;
            viergewinnt[0, 1] = button2;
            viergewinnt[0, 2] = button3;
            viergewinnt[0, 3] = button4;
            viergewinnt[0, 4] = button5;
            viergewinnt[0, 5] = button6;

            viergewinnt[1, 0] = button7;
            viergewinnt[1, 1] = button8;
            viergewinnt[1, 2] = button9;
            viergewinnt[1, 3] = button10;
            viergewinnt[1, 4] = button11;
            viergewinnt[1, 5] = button12;

            viergewinnt[2, 0] = button15;
            viergewinnt[2, 1] = button16;
            viergewinnt[2, 2] = button17;
            viergewinnt[2, 3] = button18;
            viergewinnt[2, 4] = button19;
            viergewinnt[2, 5] = button20;

            viergewinnt[3, 0] = button21;
            viergewinnt[3, 1] = button22;
            viergewinnt[3, 2] = button23;
            viergewinnt[3, 3] = button24;
            viergewinnt[3, 4] = button25;
            viergewinnt[3, 5] = button26;

            viergewinnt[4, 0] = button27;
            viergewinnt[4, 1] = button28;
            viergewinnt[4, 2] = button29;
            viergewinnt[4, 3] = button30;
            viergewinnt[4, 4] = button31;
            viergewinnt[4, 5] = button32;
            // Felder array
            Felderarray();

        }

        private void Felderarray()
        {
            Felder[0] = feld1;
            Felder[1] = feld2;
            Felder[2] = feld3;
            Felder[3] = feld4;
            Felder[4] = feld5;
            Felder[5] = feld6;
        }

        Color AktPlayer = Color.Yellow;
        private void feld1_Click(object sender, EventArgs e)
        {

            feld_Click(1);
        }

        private void Playerfarbe()
        {
            if (AktPlayer == Color.Red)
            {
                AktPlayer = Color.Yellow;
                player1.BackColor = Color.Yellow;
                player2.BackColor = Color.White;
            }
            else
            {
                AktPlayer = Color.Red;
                player1.BackColor = Color.White;
                player2.BackColor = Color.Red;
            }
        }

        private void feld2_Click(object sender, EventArgs e)
        {

            feld_Click(2);
        }

        private void feld3_Click(object sender, EventArgs e)
        {
            feld_Click(3);
        }

        private void feld4_Click(object sender, EventArgs e)
        {

            feld_Click(4);
        }

        private void feld5_Click(object sender, EventArgs e)
        {

            feld_Click(5);
        }

        private void feld6_Click(object sender, EventArgs e)
        {

            feld_Click(6);
        }

        //private void feld_Click(int spalte)
        //{
        //    feld_Click(spalte, false);
            
        //} 
        //hier wird die Funktion vreeinfacht, damit man mehrere Angaben ....
        private void feld_Click(int spalte, bool isfwdorbwd = false)
        {
            spalte--;

            if (viergewinnt[0, spalte].BackColor == Color.White)
            {

                for (int zeile = 4; zeile >= 0; zeile--)
                {
                    if (viergewinnt[zeile, spalte].BackColor == Color.White)
                    {
                        viergewinnt[zeile, spalte].BackColor = AktPlayer;
                        schritte.Add(spalte);
                        if (isfwdorbwd == false)
                        {
                            along.Clear();
                        }
                        break;
                    }
                }
                Playerfarbe();
            }

            Felder_Deaktivieren();
            Suchegewinner();
        }

        private void Suchegewinner()
        {
            bool isgewinner = false;
            // in zeilen suchen
            for (int zeile = 0; zeile < 5; zeile++)
            {
                for (int zm = 0; zm < 3; zm++)
                {

                    if (viergewinnt[zeile, zm + 0].BackColor != Color.White &&
                        (viergewinnt[zeile, zm + 0].BackColor == viergewinnt[zeile, zm + 1].BackColor) &&
                        (viergewinnt[zeile, zm + 0].BackColor == viergewinnt[zeile, zm + 2].BackColor) &&
                        (viergewinnt[zeile, zm + 0].BackColor == viergewinnt[zeile, zm + 3].BackColor))
                    {
                        winner = viergewinnt[zeile, zm + 0].BackColor;
                        if (winner == Color.Red)
                        {
                            Gewinner.Text = ("Der Gewinner ist Red");
                            isgewinner = true;
                            break;
                        }
                        else if (winner == Color.Yellow)
                        {
                            Gewinner.Text = ("Der Gewinner ist Gelb");
                            isgewinner = true;
                            break;
                        }
                    }
                }
            }
            //in Spalte suchen
            for (int spalte = 0; spalte < 6; spalte++)
            {
                for (int sm = 0; sm < 2; sm++)
                {
                    if (viergewinnt[0 + sm, spalte].BackColor != Color.White &&
                        (viergewinnt[0 + sm, spalte].BackColor == viergewinnt[1 + sm, spalte].BackColor) &&
                        (viergewinnt[0 + sm, spalte].BackColor == viergewinnt[2 + sm, spalte].BackColor) &&
                        (viergewinnt[0 + sm, spalte].BackColor == viergewinnt[3 + sm, spalte].BackColor))
                    {
                        winner = viergewinnt[1 + sm, spalte].BackColor;
                        if (winner == Color.Red)
                        {
                            Gewinner.Text = ("Der Gewinner ist Red");
                            isgewinner = true;
                            break;
                        }
                        else if (winner == Color.Yellow)
                        {
                            Gewinner.Text = ("Der Gewinner ist Gelb");
                            isgewinner = true;
                            break;
                        }
                    }
                }
            }
            // Diagonal
            for (int zeile = 0; zeile < 2; zeile++)
            {
                for (int spalte = 0; spalte < 3; spalte++)
                {
                    if (viergewinnt[zeile, spalte].BackColor != Color.White &&
                         (viergewinnt[zeile, spalte].BackColor == viergewinnt[zeile + 1, spalte + 1].BackColor) &&
                        (viergewinnt[zeile, spalte].BackColor == viergewinnt[zeile + 2, spalte + 2].BackColor) &&
                        (viergewinnt[zeile, spalte].BackColor == viergewinnt[zeile + 3, spalte + 3].BackColor))
                    {
                        winner = viergewinnt[zeile, spalte].BackColor;
                        if (winner == Color.Red)
                        {
                            Gewinner.Text = ("Der Gewinner ist Red");
                            isgewinner = true;
                            break;
                        }
                        else if (winner == Color.Yellow)
                        {
                            Gewinner.Text = ("Der Gewinner ist Gelb");
                            isgewinner = true;
                            break;
                        }
                    }
                    if (viergewinnt[zeile, spalte + 3].BackColor != Color.White &&
                        (viergewinnt[zeile, spalte + 3].BackColor == viergewinnt[zeile + 1, spalte + 2].BackColor) &&
                        (viergewinnt[zeile, spalte + 3].BackColor == viergewinnt[zeile + 2, spalte + 1].BackColor) &&
                        (viergewinnt[zeile, spalte + 3].BackColor == viergewinnt[zeile + 3, spalte + 0].BackColor))
                    {
                        winner = viergewinnt[zeile, spalte + 3].BackColor;
                        if (winner == Color.Red)
                        {
                            Gewinner.Text = ("Der Gewinner ist Rot");
                            isgewinner = true;
                            break;
                        }
                        else if (winner == Color.Yellow)
                        {
                            Gewinner.Text = ("Der Gewinner ist Gelb");
                            isgewinner = true;
                            break;
                        }
                    }
                }
            }
            if (isgewinner)
            {
                timer1.Enabled = true;
                Felderaktivieren(false);
                player1.BackColor = Color.White;
                player2.BackColor = Color.White;
                button_pc.Enabled = false;
                button14.Enabled = false;
                button33.Enabled = false;
            }
            bool SucheEnde = true;
            for (int feld = 0; feld < Felder.Length; feld++)
            {

                if (Felder[feld].BackColor != Color.Black)
                {
                    SucheEnde = false;
                    break;

                }
            }
            if (SucheEnde)
            {
                button_pc.Enabled = false;
                player1.BackColor = Color.White;
                player2.BackColor = Color.White;
                button14.Enabled = false;
                button33.Enabled = false;
            }


        }

        private void button13_Click(object sender, EventArgs e)
        {
            //Reset
            schritte.Clear();
            ResetFeler();
            timer1.Enabled = false;
            button14.Enabled = true;
            button33.Enabled = true;
        }

        private void ResetFeler()
        {
            //feld1.Color = Color.White;
            button1.BackColor = Color.White;
            button2.BackColor = Color.White;
            button3.BackColor = Color.White;
            button4.BackColor = Color.White;
            button5.BackColor = Color.White;
            button6.BackColor = Color.White;
            button7.BackColor = Color.White;
            button8.BackColor = Color.White;
            button9.BackColor = Color.White;
            button10.BackColor = Color.White;

            button11.BackColor = Color.White;
            button12.BackColor = Color.White;
            button_pc.BackColor = Color.White;
            button15.BackColor = Color.White;
            button16.BackColor = Color.White;
            button17.BackColor = Color.White;
            button18.BackColor = Color.White;
            button19.BackColor = Color.White;
            button20.BackColor = Color.White;

            button21.BackColor = Color.White;
            button22.BackColor = Color.White;
            button23.BackColor = Color.White;
            button24.BackColor = Color.White;
            button25.BackColor = Color.White;
            button26.BackColor = Color.White;
            button27.BackColor = Color.White;
            button28.BackColor = Color.White;
            button29.BackColor = Color.White;
            button30.BackColor = Color.White;
            button31.BackColor = Color.White;
            button32.BackColor = Color.White;
            Felderaktivieren(true);

            Gewinner.Text = "Who win?";
            panel1.BackColor = Color.Transparent;
            label1.Text = "0";


            Playerfarbe();
        }

        private void Felderaktivieren(bool enabled)
        {
            feld1.Enabled = enabled;
            feld2.Enabled = enabled;
            feld3.Enabled = enabled;
            feld4.Enabled = enabled;
            feld5.Enabled = enabled;
            feld6.Enabled = enabled;
            button_pc.Enabled = enabled;


            feld1.BackColor = Color.FromArgb(0, 192, 0);
            feld1.Text = "Feld 1";
            feld2.BackColor = Color.FromArgb(0, 192, 0);
            feld2.Text = "Feld 2";
            feld3.BackColor = Color.FromArgb(0, 192, 0);
            feld3.Text = "Feld 3";
            feld4.BackColor = Color.FromArgb(0, 192, 0);
            feld4.Text = "Feld 4";
            feld5.BackColor = Color.FromArgb(0, 192, 0);
            feld5.Text = "Feld 5";
            feld6.BackColor = Color.FromArgb(0, 192, 0);
            feld6.Text = "Feld 6";

        }

        private void textBox3_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {

            // in zeilen suchen
            bool gewinnergefunden = false;
            gewinnergefunden = Sucheende(gewinnergefunden, AktPlayer);
            if (!gewinnergefunden)
            {
                Random();
            }

        }

        private bool Sucheende(bool gewinnergefunden, Color Spieler)
        {
            for (int zeile = 4; zeile >= 0; zeile--)
            {
                if (gewinnergefunden == false)
                {
                    for (int zm = 0; zm < 3; zm++)
                    {

                        if (ZeilenSuche(Spieler, zeile, zm, 0))         // steht für Zeilen und zeile +1 damit sie eine nach unten mitrechnet, ob es leer ist oder nicht. 
                        {
                            feld_Click(zm + 0 + 1);     // +1 überall bei den Spalten, damit sie auf Spalte 4 auch kommt , weil wir am Anfang immer -1 gemacht haben 
                            gewinnergefunden = true;
                            break;
                        }
                        if ((Spieler == viergewinnt[zeile, zm + 0].BackColor) &&
                            (viergewinnt[zeile, zm + 0].BackColor == viergewinnt[zeile, zm + 2].BackColor) &&
                            (viergewinnt[zeile, zm + 0].BackColor == viergewinnt[zeile, zm + 3].BackColor) &&
                            (viergewinnt[zeile, zm + 1].BackColor == Color.White) &&
                            (zeile == 4 || viergewinnt[zeile + 1, zm + 1].BackColor != Color.White))

                        {
                            feld_Click(zm + 1 + 1);
                            gewinnergefunden = true;
                            break;
                        }
                        if ((Spieler == viergewinnt[zeile, zm + 0].BackColor) &&
                            (viergewinnt[zeile, zm + 0].BackColor == viergewinnt[zeile, zm + 1].BackColor) &&
                               (viergewinnt[zeile, zm + 0].BackColor == viergewinnt[zeile, zm + 3].BackColor) &&
                               (viergewinnt[zeile, zm + 2].BackColor == Color.White) &&
                               (zeile == 4 || viergewinnt[zeile + 1, zm + 2].BackColor != Color.White))
                        {
                            feld_Click(zm + 2 + 1);

                            gewinnergefunden = true;
                            break;
                        }
                        if ((Spieler == viergewinnt[zeile, zm + 0].BackColor) &&
                            (viergewinnt[zeile, zm + 0].BackColor == viergewinnt[zeile, zm + 1].BackColor) &&
                           (viergewinnt[zeile, zm + 0].BackColor == viergewinnt[zeile, zm + 2].BackColor) &&
                           (viergewinnt[zeile, zm + 3].BackColor == Color.White) &&
                           (zeile == 4 || viergewinnt[zeile + 1, zm + 3].BackColor != Color.White))
                        {
                            feld_Click(zm + 3 + 1);
                            gewinnergefunden = true;
                            break;
                        }
                    }
                }
                else
                {
                    break;
                }
            }
            // in Spalte
            if (!gewinnergefunden)
            {
                for (int spalte = 5; spalte >= 0; spalte--)
                {
                    if (gewinnergefunden == false)
                    {
                        for (int sm = 0; sm < 2; sm++)
                        {
                            if (viergewinnt[0 + sm, spalte].BackColor == Color.White &&
                                viergewinnt[1 + sm, spalte].BackColor == Spieler &&
                                viergewinnt[2 + sm, spalte].BackColor == Spieler &&
                                viergewinnt[3 + sm, spalte].BackColor == Spieler)
                            {
                                feld_Click(1 + spalte);
                                gewinnergefunden = true;
                                break;
                            }
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
            // Diagonal von lins nach rechts
            if (!gewinnergefunden)
            {
                for (int zeile = 0; zeile < 2; zeile++)
                {
                    for (int spalte = 0; spalte < 3; spalte++)
                    {
                        if ((Spieler == viergewinnt[zeile + 1, spalte + 1].BackColor) &&
                            (viergewinnt[zeile + 1, spalte + 1].BackColor == viergewinnt[zeile + 2, spalte + 2].BackColor) &&
                            (viergewinnt[zeile + 1, spalte + 1].BackColor == viergewinnt[zeile + 3, spalte + 3].BackColor) &&
                            (viergewinnt[zeile + 0, spalte + 0].BackColor == Color.White) &&
                            (viergewinnt[zeile + 1, spalte + 0].BackColor != Color.White))
                        {
                            feld_Click(1 + spalte + 0);
                            gewinnergefunden = true;
                            break;
                        }
                        if ((Spieler == viergewinnt[zeile, spalte].BackColor) &&
                          (viergewinnt[zeile, spalte].BackColor == viergewinnt[zeile + 2, spalte + 2].BackColor) &&
                          (viergewinnt[zeile, spalte].BackColor == viergewinnt[zeile + 3, spalte + 3].BackColor) &&
                          (viergewinnt[zeile + 1, spalte + 1].BackColor == Color.White) &&
                          (viergewinnt[zeile + 2, spalte + 1].BackColor != Color.White))
                        {
                            feld_Click(1 + spalte + 1);
                            gewinnergefunden = true;
                            break;
                        }
                        if ((Spieler == viergewinnt[zeile, spalte].BackColor) &&
                          (viergewinnt[zeile, spalte].BackColor == viergewinnt[zeile + 1, spalte + 1].BackColor) &&
                          (viergewinnt[zeile, spalte].BackColor == viergewinnt[zeile + 3, spalte + 3].BackColor) &&
                          (viergewinnt[zeile + 2, spalte + 2].BackColor == Color.White) &&
                          (viergewinnt[zeile + 3, spalte + 2].BackColor != Color.White))
                        {
                            feld_Click(1 + spalte + 2);
                            gewinnergefunden = true;
                            break;
                        }
                        if ((Spieler == viergewinnt[zeile, spalte].BackColor) &&
                           (viergewinnt[zeile, spalte].BackColor == viergewinnt[zeile + 1, spalte + 1].BackColor) &&
                           (viergewinnt[zeile, spalte].BackColor == viergewinnt[zeile + 2, spalte + 2].BackColor) &&
                           (viergewinnt[zeile + 3, spalte + 3].BackColor == Color.White) &&

                           ((zeile + 3 == 4) ||
                            (viergewinnt[zeile + 4, spalte + 3].BackColor != Color.White)))

                        {
                            feld_Click(1 + spalte + 3);
                            gewinnergefunden = true;
                            break;
                        }


                    }
                }


            }
            // Diagonal von rechts nach links

            if (!gewinnergefunden)
            {
                for (int zeile = 0; zeile < 2; zeile++)
                {
                    for (int spalte = 5; spalte > 2; spalte--)
                    {
                        if ((Spieler == viergewinnt[zeile + 1, spalte - 1].BackColor) &&
                            (viergewinnt[zeile + 1, spalte - 1].BackColor == viergewinnt[zeile + 2, spalte - 2].BackColor) &&
                            (viergewinnt[zeile + 1, spalte - 1].BackColor == viergewinnt[zeile + 3, spalte - 3].BackColor) &&
                            (viergewinnt[zeile + 0, spalte + 0].BackColor == Color.White) &&
                            (viergewinnt[zeile + 1, spalte + 0].BackColor != Color.White))
                        {
                            feld_Click(1 + spalte + 0);
                            gewinnergefunden = true;
                            break;
                        }
                        if ((Spieler == viergewinnt[zeile + 0, spalte + 0].BackColor) &&
                          (viergewinnt[zeile + 0, spalte + 0].BackColor == viergewinnt[zeile + 2, spalte - 2].BackColor) &&
                          (viergewinnt[zeile + 0, spalte + 0].BackColor == viergewinnt[zeile + 3, spalte - 3].BackColor) &&
                          (viergewinnt[zeile + 1, spalte - 1].BackColor == Color.White) &&
                          (viergewinnt[zeile + 2, spalte - 1].BackColor != Color.White))
                        {
                            feld_Click(1 + spalte - 1);
                            gewinnergefunden = true;
                            break;
                        }
                        if ((Spieler == viergewinnt[zeile + 0, spalte + 0].BackColor) &&
                          (viergewinnt[zeile + 0, spalte + 0].BackColor == viergewinnt[zeile + 1, spalte - 1].BackColor) &&
                          (viergewinnt[zeile + 0, spalte + 0].BackColor == viergewinnt[zeile + 3, spalte - 3].BackColor) &&
                          (viergewinnt[zeile + 2, spalte - 2].BackColor == Color.White) &&
                          (viergewinnt[zeile + 3, spalte - 2].BackColor != Color.White))
                        {
                            feld_Click(1 + spalte - 2);
                            gewinnergefunden = true;
                            break;
                        }
                        if ((Spieler == viergewinnt[zeile + 0, spalte + 0].BackColor) &&
                           (viergewinnt[zeile + 0, spalte + 0].BackColor == viergewinnt[zeile + 1, spalte - 1].BackColor) &&
                           (viergewinnt[zeile + 0, spalte + 0].BackColor == viergewinnt[zeile + 2, spalte - 2].BackColor) &&
                           (viergewinnt[zeile + 3, spalte - 3].BackColor == Color.White) &&
                           ((zeile + 3 == 4) ||
                            (viergewinnt[zeile + 4, spalte - 3].BackColor != Color.White)))
                        {
                            feld_Click(1 + spalte - 3);
                            gewinnergefunden = true;
                            break;

                        }
                    }
                }
            }

            // Gegner blockieren
            // in Zeilen
            if (!gewinnergefunden)
            {
                for (int zeile = 4; zeile >= 0; zeile--)
                {
                    if (gewinnergefunden == false)
                    {
                        for (int zm = 0; zm < 3; zm++)
                        {

                            if ((viergewinnt[zeile, zm + 1].BackColor != Color.White) &&
                                (viergewinnt[zeile, zm + 1].BackColor == viergewinnt[zeile, zm + 2].BackColor) &&
                                (viergewinnt[zeile, zm + 1].BackColor == viergewinnt[zeile, zm + 3].BackColor) &&
                                (viergewinnt[zeile, zm + 0].BackColor == Color.White) &&
                                (zeile == 4 || viergewinnt[zeile + 1, zm + 0].BackColor != Color.White))
                            {
                                feld_Click(zm + 0 + 1);
                                gewinnergefunden = true;
                                break;
                            }
                            if ((viergewinnt[zeile, zm + 0].BackColor != Color.White) &&
                                (viergewinnt[zeile, zm + 0].BackColor == viergewinnt[zeile, zm + 2].BackColor) &&
                                (viergewinnt[zeile, zm + 0].BackColor == viergewinnt[zeile, zm + 3].BackColor) &&
                                (viergewinnt[zeile, zm + 1].BackColor == Color.White) &&

                                (zeile == 4 || viergewinnt[zeile + 1, zm + 1].BackColor != Color.White))

                            {
                                feld_Click(zm + 1 + 1);
                                gewinnergefunden = true;
                                break;
                            }
                            if ((viergewinnt[zeile, zm + 0].BackColor != Color.White) &&
                                (viergewinnt[zeile, zm + 0].BackColor == viergewinnt[zeile, zm + 1].BackColor) &&
                                   (viergewinnt[zeile, zm + 0].BackColor == viergewinnt[zeile, zm + 3].BackColor) &&
                                   (viergewinnt[zeile, zm + 2].BackColor == Color.White) &&

                                   (zeile == 4 || viergewinnt[zeile + 1, zm + 2].BackColor != Color.White))
                            {
                                feld_Click(zm + 2 + 1);
                                gewinnergefunden = true;
                                break;
                            }
                            if ((viergewinnt[zeile, zm + 0].BackColor != Color.White) &&
                                (viergewinnt[zeile, zm + 0].BackColor == viergewinnt[zeile, zm + 1].BackColor) &&
                               (viergewinnt[zeile, zm + 0].BackColor == viergewinnt[zeile, zm + 2].BackColor) &&
                               (viergewinnt[zeile, zm + 3].BackColor == Color.White) &&

                               (zeile == 4 || viergewinnt[zeile + 1, zm + 3].BackColor != Color.White))
                            {
                                feld_Click(zm + 3 + 1);
                                gewinnergefunden = true;
                                break;
                            }
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
            //  in Spalte blockieren
            if (!gewinnergefunden)
            {
                for (int spalte = 5; spalte >= 0; spalte--)
                {
                    if (gewinnergefunden == false)
                    {
                        for (int sm = 0; sm < 2; sm++)
                        {
                            if ((viergewinnt[1 + sm, spalte].BackColor != Color.White) &&
                                (viergewinnt[0 + sm, spalte].BackColor == Color.White) &&
                                (viergewinnt[1 + sm, spalte].BackColor == viergewinnt[2 + sm, spalte].BackColor) &&
                                (viergewinnt[1 + sm, spalte].BackColor == viergewinnt[3 + sm, spalte].BackColor))
                            {
                                feld_Click(1 + spalte);
                                gewinnergefunden = true;
                                break;
                            }
                        }
                    }
                    else
                    {
                        break;
                    }
                }

            }
            // in Diagonal von Links nach rechts  blockieren
            if (!gewinnergefunden)
            {
                for (int zeile = 0; zeile < 2; zeile++)
                {
                    for (int spalte = 0; spalte < 3; spalte++)
                    {
                        if ((viergewinnt[zeile + 1, spalte + 1].BackColor != Color.White) &&
                            (viergewinnt[zeile + 1, spalte + 1].BackColor == viergewinnt[zeile + 2, spalte + 2].BackColor) &&
                            (viergewinnt[zeile + 1, spalte + 1].BackColor == viergewinnt[zeile + 3, spalte + 3].BackColor) &&
                            (viergewinnt[zeile + 0, spalte + 0].BackColor == Color.White) &&
                            (viergewinnt[zeile + 1, spalte + 0].BackColor != Color.White))
                        {
                            feld_Click(1 + spalte + 0);
                            gewinnergefunden = true;
                            break;
                        }
                        if ((viergewinnt[zeile, spalte].BackColor != Color.White) &&
                          (viergewinnt[zeile, spalte].BackColor == viergewinnt[zeile + 2, spalte + 2].BackColor) &&
                          (viergewinnt[zeile, spalte].BackColor == viergewinnt[zeile + 3, spalte + 3].BackColor) &&
                          (viergewinnt[zeile + 1, spalte + 1].BackColor == Color.White) &&
                          (viergewinnt[zeile + 2, spalte + 1].BackColor != Color.White))
                        {
                            feld_Click(1 + spalte + 1);
                            gewinnergefunden = true;
                            break;
                        }
                        if ((viergewinnt[zeile, spalte].BackColor != Color.White) &&
                          (viergewinnt[zeile, spalte].BackColor == viergewinnt[zeile + 1, spalte + 1].BackColor) &&
                          (viergewinnt[zeile, spalte].BackColor == viergewinnt[zeile + 3, spalte + 3].BackColor) &&
                          (viergewinnt[zeile + 2, spalte + 2].BackColor == Color.White) &&
                          (viergewinnt[zeile + 3, spalte + 2].BackColor != Color.White))
                        {
                            feld_Click(1 + spalte + 2);
                            gewinnergefunden = true;
                            break;
                        }
                        if ((viergewinnt[zeile, spalte].BackColor != Color.White) &&
                           (viergewinnt[zeile, spalte].BackColor == viergewinnt[zeile + 1, spalte + 1].BackColor) &&
                           (viergewinnt[zeile, spalte].BackColor == viergewinnt[zeile + 2, spalte + 2].BackColor) &&
                           (viergewinnt[zeile + 3, spalte + 3].BackColor == Color.White) &&

                           ((zeile + 3 == 4) ||
                            (viergewinnt[zeile + 4, spalte + 3].BackColor != Color.White)))

                        {
                            feld_Click(1 + spalte + 3);
                            gewinnergefunden = true;
                            break;
                        }
                    }
                }
            }

            // in Diagonal von rechts nach links blockieren 
            if (!gewinnergefunden)
            {
                for (int zeile = 0; zeile < 2; zeile++)
                {
                    for (int spalte = 5; spalte > 2; spalte--)
                    {
                        if ((viergewinnt[zeile + 1, spalte - 1].BackColor != Color.White) &&
                            (viergewinnt[zeile + 1, spalte - 1].BackColor == viergewinnt[zeile + 2, spalte - 2].BackColor) &&
                            (viergewinnt[zeile + 1, spalte - 1].BackColor == viergewinnt[zeile + 3, spalte - 3].BackColor) &&
                            (viergewinnt[zeile + 0, spalte + 0].BackColor == Color.White) &&
                            (viergewinnt[zeile + 1, spalte + 0].BackColor != Color.White))
                        {
                            feld_Click(1 + spalte + 0);
                            gewinnergefunden = true;
                            break;
                        }
                        if ((viergewinnt[zeile + 0, spalte + 0].BackColor != Color.White) &&
                           (viergewinnt[zeile + 0, spalte + 0].BackColor == viergewinnt[zeile + 2, spalte - 2].BackColor) &&
                           (viergewinnt[zeile + 0, spalte + 0].BackColor == viergewinnt[zeile + 3, spalte - 3].BackColor) &&
                           (viergewinnt[zeile + 1, spalte - 1].BackColor == Color.White) &&
                           (viergewinnt[zeile + 2, spalte - 1].BackColor != Color.White))
                        {
                            feld_Click(1 + spalte - 1);
                            gewinnergefunden = true;
                            break;
                        }
                        if ((viergewinnt[zeile + 0, spalte + 0].BackColor != Color.White) &&
                          (viergewinnt[zeile + 0, spalte + 0].BackColor == viergewinnt[zeile + 1, spalte - 1].BackColor) &&
                          (viergewinnt[zeile + 0, spalte + 0].BackColor == viergewinnt[zeile + 3, spalte - 3].BackColor) &&
                          (viergewinnt[zeile + 2, spalte - 2].BackColor == Color.White) &&
                          (viergewinnt[zeile + 3, spalte - 2].BackColor != Color.White))
                        {
                            feld_Click(1 + spalte - 2);
                            gewinnergefunden = true;
                            break;
                        }
                        if ((viergewinnt[zeile + 0, spalte + 0].BackColor != Color.White) &&
                           (viergewinnt[zeile + 0, spalte + 0].BackColor == viergewinnt[zeile + 1, spalte - 1].BackColor) &&
                           (viergewinnt[zeile + 0, spalte + 0].BackColor == viergewinnt[zeile + 2, spalte - 2].BackColor) &&
                           (viergewinnt[zeile + 3, spalte - 3].BackColor == Color.White) &&
                           ((zeile + 3 == 4) ||
                            (viergewinnt[zeile + 4, spalte - 3].BackColor != Color.White)))
                        {
                            feld_Click(1 + spalte - 3);
                            gewinnergefunden = true;
                            break;
                        }
                    }
                }
            }

            return gewinnergefunden;

        }

        private bool ZeilenSuche(Color Spieler, int zeile, int zm, int zuPrf)
        {
            int index = 0;
            int[] mgl = new int[3];
            for (int i = 0; i < 4; i++)
            {
                if (zuPrf != i)
                {
                    mgl[index] = i;
                    index++;
                }
            }
            return Spieler == viergewinnt[zeile, zm + mgl[0]].BackColor &&
                  (Spieler == viergewinnt[zeile, mgl[1]].BackColor) &&
                  (Spieler == viergewinnt[zeile, zm + mgl[2]].BackColor) &&
                  (viergewinnt[zeile, zm + zuPrf].BackColor == Color.White) &&
                  (zeile == 4 || viergewinnt[zeile + 1, zm + zuPrf].BackColor != Color.White);

            /*
             Spieler == viergewinnt[zeile, zm + 1].BackColor &&
                                        (viergewinnt[zeile, zm + 1].BackColor == viergewinnt[zeile, 2].BackColor) &&
                                        (viergewinnt[zeile, zm + 1].BackColor == viergewinnt[zeile, zm + 3].BackColor) &&
                                        (viergewinnt[zeile, zm + 0].BackColor == Color.White) &&
                                        (zeile == 4 || viergewinnt[zeile + 1, zm + 0].BackColor != Color.White)


             (Spieler == viergewinnt[zeile, zm + 0].BackColor) &&
                            (viergewinnt[zeile, zm + 0].BackColor == viergewinnt[zeile, zm + 2].BackColor) &&
                            (viergewinnt[zeile, zm + 0].BackColor == viergewinnt[zeile, zm + 3].BackColor) &&
                            (viergewinnt[zeile, zm + 1].BackColor == Color.White) &&
                            (zeile == 4 || viergewinnt[zeile + 1, zm + 1].BackColor != Color.White)

            (Spieler == viergewinnt[zeile, zm + 0].BackColor) &&
                            (viergewinnt[zeile, zm + 0].BackColor == viergewinnt[zeile, zm + 1].BackColor) &&
                               (viergewinnt[zeile, zm + 0].BackColor == viergewinnt[zeile, zm + 3].BackColor) &&
                               (viergewinnt[zeile, zm + 2].BackColor == Color.White) &&
                               (zeile == 4 || viergewinnt[zeile + 1, zm + 2].BackColor != Color.White)

            (Spieler == viergewinnt[zeile, zm + 0].BackColor) &&
                            (viergewinnt[zeile, zm + 0].BackColor == viergewinnt[zeile, zm + 1].BackColor) &&
                           (viergewinnt[zeile, zm + 0].BackColor == viergewinnt[zeile, zm + 2].BackColor) &&
                           (viergewinnt[zeile, zm + 3].BackColor == Color.White) &&
                           (zeile == 4 || viergewinnt[zeile + 1, zm + 3].BackColor != Color.White)
             */
        }

        private void Random()
        {
            bool nichtleer = false;
            while (nichtleer == false)
            {
                Random number = new Random();
                int zahlauswahl = number.Next(1, 7);
                label1.Text = Convert.ToString(zahlauswahl);
                if (Felder[zahlauswahl - 1].BackColor != Color.Black)
                {
                    feld_Click(zahlauswahl);
                    nichtleer = true;
                }


            }
        }

        private void Felder_Deaktivieren()
        {
            if (button1.BackColor != Color.White)

            {
                feld1.Enabled = false;
                feld1.BackColor = Color.Black;
            }
            if (button2.BackColor != Color.White)

            {
                feld2.Enabled = false;
                feld2.BackColor = Color.Black;
            }
            if (button3.BackColor != Color.White)

            {
                feld3.Enabled = false;
                feld3.BackColor = Color.Black;
            }
            if (button4.BackColor != Color.White)

            {
                feld4.Enabled = false;
                feld4.BackColor = Color.Black;
            }
            if (button5.BackColor != Color.White)

            {
                feld5.Enabled = false;
                feld5.BackColor = Color.Black;
            }
            if (button6.BackColor != Color.White)

            {
                feld6.Enabled = false;
                feld6.BackColor = Color.Black;
            }

        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            if (panel1.BackColor != winner)
            {
                panel1.BackColor = winner;
            }
            else
            {
                panel1.BackColor = Color.Transparent;
            }
        }

        private void button14_Click_1(object sender, EventArgs e)
        {
            if(schritte.Count>0)
            {
                for (int zeile = 0; zeile <= 4; zeile++)
                {
                    if (viergewinnt[zeile, schritte.Last()].BackColor != Color.White)
                    {
                        if(Felder[schritte.Last()].Enabled == false)
                        {
                            Felder[schritte.Last()].Enabled = true;
                            Felder[schritte.Last()].BackColor = Color.FromArgb(0, 192, 0);
                        }
                        viergewinnt[zeile, schritte.Last()].BackColor = Color.White;
                        along.Add(schritte.Last());
                        schritte.RemoveAt(schritte.Count - 1);
                        Playerfarbe();
                        break;
                    }
                }
            }           
        }

        private void button33_Click(object sender, EventArgs e)
        {
            if (along.Count > 0)
            {
                feld_Click(along.Last() + 1,true);
                along.RemoveAt(along.Count - 1);

            }
        }
    }

}
