using System;
using System.Collections.Generic;
using System.Text;

namespace GeneratingAnnexToTheDocumentNames
{
    struct NamesForAnnexToTheDocument
    {
        private string nameForAnnexToTheDocument;
        private char[] usedRussianLiterals;
        private char[] usedAmericanLiterals;
        private List<int> usedNumericLiterals;
        private string currentLiteral;
        private int countRussianLiterals;
        private int countAmericanLiterals;


        public string NameForAnnexToTheDocument
        {
            get
            {
                return nameForAnnexToTheDocument;
            }
            set
            {
                string currentLiteral = this.CutLiteralForNameForAnnexToTheDocument(value);
                if (this.usedNumericLiterals == null)
                {
                    this.usedNumericLiterals = new List<int>();
                }

                if (this.usedRussianLiterals == null)
                {
                    this.usedRussianLiterals = new char[25];
                }

                if (this.usedAmericanLiterals == null)
                {
                    this.usedAmericanLiterals = new char[48];
                }

                if (value.Remove(value.IndexOf(' ')) != "Приложение")
                {
                    throw new Exception("Неверное значение Приложения");
                }

                if (!(this.LiteralValidation(currentLiteral)))
                {
                    throw new Exception("Неверное значение литерала");
                }

                this.LiteralValidationAndAddUsedLiteral(currentLiteral);
                this.currentLiteral = currentLiteral;
                this.nameForAnnexToTheDocument = value;
            }
        }

        private string CutLiteralForNameForAnnexToTheDocument(string name)
        {
            return name.Remove(0, name.IndexOf(' ') + 1);
        }

        private bool LiteralValidationAndAddUsedLiteral(string literal)
        {
            if (literal.Length == 1)
            {
                if (((this.countRussianLiterals == 25) && (this.countAmericanLiterals == 48)) && this.IsNumericLiteral(literal) && !(this.usedNumericLiterals.Contains(int.Parse(literal))))
                {

                    this.usedNumericLiterals.Add(int.Parse(literal));
                    return true;
                }

                if (this.IsRussianLiteral(literal))
                {

                    if ((this.countRussianLiterals < 25) && (true))
                    {

                        this.usedRussianLiterals[this.countRussianLiterals] = literal[0];
                        this.countRussianLiterals++;
                        return true;
                    }
                }
                if (this.countRussianLiterals == 25 && this.IsAmericanLiteral(literal))
                {

                    if ((this.countAmericanLiterals < 48) && (true))
                    {
                        this.usedAmericanLiterals[this.countRussianLiterals] = literal[0];
                        this.countAmericanLiterals++;
                        return true;
                    }
                }
            }

            if (literal.Length > 1 && countRussianLiterals == 25 && countAmericanLiterals == 48 && IsNumericLiteral(literal))
            {

                if (!this.usedNumericLiterals.Contains(int.Parse(literal)))

                {
                    this.usedNumericLiterals.Add(int.Parse(literal));
                    return true;
                }
            }

            return false;
        }

        bool IsRussianLiteral(string literal)
        {
            if (literal.Length > 1)
            {
                return false;
            }

            return (((literal[0] >= 'А') && (literal[0] <= 'Я')) && (literal[0] != 'Ё' && literal[0] != 'З' && literal[0] != 'Й' && literal[0] != 'О' && literal[0] != 'Ч' && literal[0] != 'Ь' && literal[0] != 'Ы' && literal[0] != 'Ъ'));
        }

        bool IsAmericanLiteral(string literal)
        {
            if (literal.Length > 1)
            {
                return false;
            }

            return ((literal[0] >= 'A') && (literal[0] <= 'Z') || ((literal[0] >= 'a') && (literal[0] <= 'z'))) && (literal[0] != 'i' && literal[0] != 'o');
        }

        bool IsNumericLiteral(string literal)
        {
            if (literal.Length == 1)
            {
                return (literal[0] >= '0' && literal[0] <= 9);
            }

            foreach (char symbol in literal)
            {
                if (!((symbol >= '0') && (symbol <= '9')))
                {
                    return false;
                }
            }

            return true;
        }
        private bool LiteralValidation(string literal)
        {
            if (literal.Length == 1)
            {
                if (((this.countRussianLiterals == 25) && (this.countAmericanLiterals == 48)) && this.IsNumericLiteral(literal) && !(this.usedNumericLiterals.Contains(int.Parse(literal))))
                {


                    return true;
                }

                if (this.IsRussianLiteral(literal))
                {

                    if ((this.countRussianLiterals < 25) && (true))
                    {

                        return true;
                    }
                }
                if (this.countRussianLiterals == 25 && this.IsAmericanLiteral(literal))
                {

                    if ((this.countAmericanLiterals < 48) && (true))
                    {

                        return true;
                    }
                }
            }

            if (literal.Length > 1 && countRussianLiterals == 25 && countAmericanLiterals == 48 && IsNumericLiteral(literal))
            {

                if (!this.usedNumericLiterals.Contains(int.Parse(literal)))

                {

                    return true;
                }
            }

            return false;
        }
        public override string ToString()
        {
            if (this.NameForAnnexToTheDocument == null)
            {
                return "Нет номера приложения";
            }
            return this.NameForAnnexToTheDocument;
        }

        public string AssigningTheNextNumberToTheAnnexToTheDocument(string name)
        {
            if (this.usedNumericLiterals == null)
            {
                this.usedNumericLiterals = new List<int>();
            }

            if (this.usedRussianLiterals == null)
            {
                this.usedRussianLiterals = new char[25];
            }

            if (this.usedAmericanLiterals == null)
            {
                this.usedAmericanLiterals = new char[48];
            }


            string currentLiteral = this.CutLiteralForNameForAnnexToTheDocument(name);

            if (name.Remove(name.IndexOf(' ')) != "Приложение")
            {
                throw new Exception("Неверное значение Приложения");
            }

            if (!(this.LiteralValidation(currentLiteral)))
            {
                throw new Exception("Неверное значение литерала");
            }

            string nextLiteral = string.Empty;
            char symbol;
            if (this.IsRussianLiteral(currentLiteral))
            {
                if (currentLiteral[0] == 'Я')
                {
                    nextLiteral = "A";
                }
                else
                {
                    symbol = (char)((int)currentLiteral[0] + 1);
                    nextLiteral = nextLiteral + symbol;
                }
                }
                if (this.IsAmericanLiteral(currentLiteral))
                {
                    if (currentLiteral[0] == 'Z')
                    {
                        nextLiteral = "a";
                    }
                    else
                         if (currentLiteral[0] == 'z')
                    {
                        nextLiteral = "0";
                    }
                           else
                          {
                        symbol = (char)((int)currentLiteral[0] + 1);
                        nextLiteral = nextLiteral + symbol;
                         }

                }
            if (this.IsNumericLiteral(currentLiteral))
            {
                int number = int.Parse(currentLiteral) + 1;
                    nextLiteral = nextLiteral + Convert.ToString(number);
                }

            if (!(this.LiteralValidation(nextLiteral)))
            {
                throw new Exception("Неверное значение литерала");
            }

            this.NameForAnnexToTheDocument = "Приложение " + nextLiteral;

            return this.NameForAnnexToTheDocument;
        }
        }
    }
