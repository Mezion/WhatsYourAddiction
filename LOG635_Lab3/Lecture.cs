using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace LOG635_Lab3
{
    class Lecture
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\Mart\Documents\GitHub\WhatsYourAddiction\Evaluations.csv";
            string pathOut = @"C:\Users\Mart\Documents\GitHub\WhatsYourAddiction\Evaluationsoutput.txt";

            String input = File.ReadAllText(path);
            Char splitAt = ',';

            //Dimensions /////////////////////////////////////////////////////////
            int columns = 32;
            int rows = File.ReadLines(path).Count();    //997 dans notre fichier de depart
            Console.WriteLine(rows);
            //////////////////////////////////////////////////////////////////////

            int i = 0, j = 0;
            string[,] result = new string[rows, columns];

            foreach (var row in input.Split('\n')) //Regex.Split(input, "(,\r\n)").Where(p => !string.IsNullOrEmpty(p)).ToArray())//       //ROW 
            {
                j = 0;
                foreach (var col in row.Trim().Split(','))    //COLUMN
                {
                    if (j != 32)    //On skip la 33ieme car c'est un espace vide apres le dernier ','
                    {
                        result[i, j] = col.Trim();
                        //Console.WriteLine(result[i, j]);
                    }
                    j++;
                }
                i++;
            }

            //////////////////////////////////////////////////////////////////////
            /*Get the Average of each line where we can
            foreach (var row in )
            {
               // double average = ((Array[i,1] + ArrayArray[i,2] + etc. )/ rowCount);
               //Console.Write(average);
            }
            */ //////////////////////////////////////////////////////////////////////


            //////////////////////////////////////////////////////////////////////
            //Check for unusable data -> if number, average.
            //Check for range (min/max) -> if under/above -> bring back to min/max
            Console.WriteLine("//////////////////////////////////////////////////////////////////////");

            string[,] newData = new string[rows, columns];

            //Iterate the array

            //Column
            for (int newCol = 0; newCol < (columns); newCol++)      //result.GetLength(1)
            {
                //Row
                for (int newRow = 0; newRow < (rows); newRow++)        //result.GetLength(0)
                {
                    //If not the first row (title) or first column (ID)
                    if (newRow != 0 && newCol != 0)
                    {
                        switch (newCol)
                        {
                        case 0: //ID
                            newData[newRow, newCol] = result[newRow, newCol];
                            break;
                        case 1: //AGE
                            newData[newRow, newCol] = (Age(result[newRow, newCol])).ToString();
                            break;
                        case 2: //GENDER
                            newData[newRow, newCol] = (Gender(result[newRow, newCol])).ToString();
                            break;
                        case 3: //EDUCATION
                            newData[newRow, newCol] = (Education(result[newRow, newCol])).ToString();
                            break;
                        case 4: //PAY
                            newData[newRow, newCol] = (Pays(result[newRow, newCol])).ToString();
                            break;
                        case 5: //ETHNICITE
                            newData[newRow, newCol] = (Ethnicite(result[newRow, newCol])).ToString();
                            break;
                        case 6:
                        case 7:
                        case 8:
                        case 9:
                        case 10: //
                            newData[newRow, newCol] = (Normal(result[newRow, newCol], 12, 60)).ToString();
                            break;
                        case 11:
                        case 12://%
                            newData[newRow, newCol] = (Normal(Fix(result[newRow, newCol]), 0, 20)).ToString();
                            break;
                        case 13:
                        case 14:
                        case 15:
                        case 16:
                        case 17:
                        case 18:
                        case 19:
                        case 20:
                        case 21:
                        case 22:
                        case 23:
                        case 24:
                        case 25:
                        case 26:
                        case 27:
                        case 28:
                        case 29:
                        case 30:
                        case 31:
                                newData[newRow, newCol] = (Normal(result[newRow, newCol], 0, 6)).ToString();
                            break;
                        }
                    }

                    Console.Write(newData[newRow, newCol] + " ");
                }
            }
            /* //////////////////////////////////////////////////////////////////////
            // ----------------------------------------------------------------------------------------------------
            //0 - Id                        [Inimportant]                           -> [X]
            //1 - Age                       [6][18-24                                               -> [0]
                                                25-34                                               -> [0.2]                                               
                                                35-44                                               -> [0.4]
                                                45-54                                               -> [0.6]
                                                55-64                                               -> [0.8]
                                                65+                                                 -> [1]

            //2 - Genre                     [Male/Female]                           -> [1/0]
            //3 - Education                 [9][À quitté l'école avant 16 ans                       -> [0]
                                                À quitté l'école à 16 ans                           -> [0.2]
                                                À quitté l'école à 17 ans                           -> [0.3]
                                                À quitté l'école à 18 ans                           -> [0.4]
                                                Collège ou université aucun certificat ou diplome   -> [0.5]
                                                Certificat ou diplome professionel                  -> [0.6]
                                                Université                                          -> [0.7]
                                                Matrise                                             -> [0.8]
                                                Doctorat                                            -> [1]

            //4 - Pays                      [7][Autre                                               -> [0]
                                                Australie                                           -> [0.17]
                                                Canada                                              -> [0.34]
                                                Nouvelle Zelande                                    -> [0.51]
                                                UK                                                  -> [0.68]
                                                USA                                                 -> [0.85]
                                                Republique d'Ireland                                -> [1]

            //5 - Ethnicité                 [7][Autre                                               -> [0]
                                                Asiatique                                           -> [0.17]
                                                Blanc                                               -> [0.34]
                                                Mixed-Blanc/Asiatique                               -> [0.51]
                                                Mixed-Blanc/Noir                                    -> [0.68]
                                                Mixed-Noir/Asiatique                                -> [0.85]
                                                Noir                                                -> [1]

            //6 - Neuroticisme              [14-60]                                 -> [0-1] (12 min, max 60, ramener a [0-1]
            //7 - Extraversion              [16-58]                                 -> [...]
            //8 - Ouverture                 [24-60]                                 -> [...]
            //9 - Agréabilité               [12-59]                                 -> [...]
            //10 - Conscienciosité          [19-59]                                 -> [...]

            //11 - Impulsivité              [0.37%-18.83%]                          -> []   (min 0, max 20)
            //12 - Recherche de sensations  [3.77%-13.21%]                          -> []
            // ----------------------------------------------------------------------------------------------------
            //13 - Alcohol                  [0-6]                                   -> [0/0.2/.../1] (0 min, max 6, ramener a [0-1]
            //14 - Amphetamines             [...]                                   -> [...]
            //15 - Amyl nitrite
            //16 - Benzodiazepine
            //17 - Caffeine
            //18 - Cannabis
            //19 - Chocolate
            //20 - Cocaine
            //21 - Crack
            //22 - Ecstasy
            //23 - Heroin
            //24 - Ketamine
            //25 - Legal highs
            //26 - LSD
            //27 - Methadone
            //28 - Magic mushrooms
            //29 - Nicotine
            //30 - Semeron
            //31 - Volatile substance abuse
            // ----------------------------------------------------------------------------------------------------
            ////////////////////////////////////////////////////////////////////// */
             
            //Output
            Output(newData, columns, rows, pathOut);

            //Console stays open
            Console.Read();
        }

        //////////////////////////////////////////////////////////////////////
        //OUTPUT
        static public void Output(string[,] newData, int col, int row, string pathOut)
        {
            //1D Array      ex: string[] table = { x, y, z };
            //System.IO.File.WriteAllLines("c:\\output.txt", table);

            //2D Array
            List<string> linesToWrite = new List<string>();
            for(int rowIndex = 0; rowIndex< row; rowIndex++)
            {
                StringBuilder line = new StringBuilder();
                for(int colIndex = 0; colIndex< col; colIndex++)
                    line.Append(newData[rowIndex, colIndex]).Append(" ");
                linesToWrite.Add(line.ToString());
            }

            System.IO.File.WriteAllLines(pathOut, linesToWrite.ToArray());
        }


        //////////////////////////////////////////////////////////////////////
        //AGE
        static public float Age(String age)
        {
            float x = 0;
            switch (age)
            {
                case "18-24":
                    x = 0;
                    break;
                case "25-34":
                    x = 0.2f;
                    break;
                case "35-44":
                    x = 0.4f;
                    break;
                case "45-54":
                    x = 0.6f;
                    break;
                case "55-64":
                    x = 0.8f;
                    break;
                case "65+":
                    x = 1f;
                    break;
                default:
                    x = 0.5f;
                    break;
            }
            return x;
        }

        //////////////////////////////////////////////////////////////////////
        //GENDER
        static public int Gender(String gender)
        {
            int x = 0;
            if (gender == "Female")
                x = 0;
            else
                x = 1;
            return x;
        }

        //////////////////////////////////////////////////////////////////////
        //EDUCATION
        static public float Education(String edu)
        {
            float x = 0;
            switch (edu)
            {
                case "À quitté l'école avant 16 ans":
                    x = 0;
                    break;
                case "À quitté l'école à 16 ans":
                    x = 0.2f;
                    break;
                case "À quitté l'école à 17 ans":
                    x = 0.3f;
                    break;
                case "À quitté l'école à 18 ans":
                    x = 0.4f;
                    break;
                case "Collège ou université aucun certificat ou diplome":
                    x = 0.5f;
                    break;
                case "Certificat ou diplome professionel":
                    x = 0.6f;
                    break;
                case "Université":
                    x = 0.7f;
                    break;
                case "Matrise":
                    x = 0.8f;
                    break;
                case "Doctorat":
                    x = 1f;
                    break;
                default:
                    x = 0.5f;
                    break;
            }
            return x;
        }

        //////////////////////////////////////////////////////////////////////
        //PAYS
        static public float Pays(String pay)
        {
            float x = 0;
            switch (pay)
            {
                case "Autre":
                    x = 0;
                    break;
                case "Australie":
                    x = 0.17f;
                    break;
                case "Canada":
                    x = 0.34f;
                    break;
                case "Nouvelle Zelande":
                    x = 0.51f;
                    break;
                case "UK":
                    x = 0.68f;
                    break;
                case "USA":
                    x = 0.85f;
                    break;
                case "Republique d'Ireland":
                    x = 1f;
                    break;
                default:
                    x = 0f;
                    break;
            }
            return x;
        }

        //////////////////////////////////////////////////////////////////////
        //ETHNICITE
        static public float Ethnicite(String Eth)
        {
            float x = 0;
            switch (Eth)
            {
                case "Autre":
                    x = 0;
                    break;
                case "Asiatique":
                    x = 0.17f;
                    break;
                case "Blanc":
                    x = 0.34f;
                    break;
                case "Mixed-Blanc/Asiatique":
                    x = 0.51f;
                    break;
                case "Mixed-Blanc/Noir":
                    x = 0.68f;
                    break;
                case "Mixed-Noir/Asiatique":
                    x = 0.85f;
                    break;
                case "Noir":
                    x = 1f;
                    break;
                default:
                    x = 0f;
                    break;
            }
            return x;
        }

        //////////////////////////////////////////////////////////////////////
        //Normalize
        // Zi=Xi−min(X)/ max(X)−min(X)
        static public float Normal(String toNorm, float min, float max)
        {
            if (toNorm == "")
                toNorm = "0";
            float x = float.Parse(toNorm);
            x = (x - min) / (max - min);

            //si donnee aberrante
            if (x > 1)
                x = 1;
            if (x < 0)
                x = 0;

            return x;
        }

        //////////////////////////////////////////////////////////////////////
        //Fix (%)
        static public String Fix(String toFix)
        {
            toFix = toFix.Replace(@"%", "");

            return toFix;
        }

    }

}
