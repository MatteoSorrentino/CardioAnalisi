using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardioLibrary
{
    public class DataCardio
    {
        //script 1
        public static double Btminimi(int età)
        {
            double battiti = 0;

            if (età <= 0)
            {
                battiti = 0;
            }
            else
            {
                int frequenza = 220 - età;

                battiti = frequenza * 0.7;
            }

            return battiti;
        }

        public static double Btmassimi(int età)
        {
            double battiti = 0;

            if (età <= 0)
            {
                battiti = 0;
            }
            else
            {
                int frequenza = 220 - età;

                battiti = frequenza * 0.9;
            }

            return battiti;
        }

        //script 2
        public static string FrequenzaCardiacaRiposo(double battiti)
        {
            string risultato = "";

            if(battiti <= 0)
            {
                risultato = "Errore";
            }
            else
            {
                if (battiti < 60)
                {
                    risultato = "Bradicardia";
                }

                if (battiti >= 60 && battiti <= 100)
                {
                    risultato = "Normale";
                }

                if (battiti > 100)
                {
                    risultato = "Tachicardia";
                }
            }

            return risultato;
        }

        //script 3
        public static double CalorieBruciate(string sesso, double frequenza_cardiaca, double peso, int anni, double tempo)
        {
            double calorie_bruciate = 0;

            if (sesso == "M")
            {
                calorie_bruciate = ((anni * 0.2017) + (peso * 0.199) + (frequenza_cardiaca * 0.6309) - 55.0969) * tempo / 4.184;
                calorie_bruciate = Math.Round(calorie_bruciate, 2);
            }

            if (sesso == "F")
            {
                calorie_bruciate = ((anni * 0.074) - (peso * 0.126) + (frequenza_cardiaca * 0.4472) - 20.4022) * tempo / 4.184;
                calorie_bruciate = Math.Round(calorie_bruciate, 2);
            }

            return calorie_bruciate;
        }

        //script 4
        public static double SpesaEnergetica(string attività, double km_percorsi, double peso_corporeo)
        {
            double risultato = 0;

            if (attività == "Corsa")
            {
                risultato = (0.9 * km_percorsi) * peso_corporeo;
            }

            if (attività == "Camminata")
            {
                risultato = (0.50 * km_percorsi) * peso_corporeo;
            }

            return risultato;
        }

        //script 5
        public static double BattitiGiornalieri(double battiti_riposo, double battiti_massimi, double battiti_recupero)
        {
            double battiti_giornalieri = 0;

            battiti_giornalieri = (battiti_riposo + battiti_massimi + battiti_recupero) / 3;

            battiti_giornalieri = Math.Round(battiti_giornalieri, 1);

            return battiti_giornalieri;
        }

        public static double BattitiRiposo(double battiti_1, double battiti_2, double battiti_3, double battiti_4, double battiti_5)
        {
            double battiti_riposo = 0;
            double[] battiti = { battiti_1, battiti_2, battiti_3, battiti_4, battiti_5 };
            double min = 0;

            for (int i = 0; i < 5; i++)
            {
                if (i == 0)
                {
                    min = battiti[i];
                }

                if (battiti[i] < min)
                {
                    min = battiti[i];
                }
            }

            battiti_riposo = min;

            return battiti_riposo;
        }

        public static double VariabilitàBattito(double battiti_1, double battiti_2, double battiti_3, double battiti_4, double battiti_5)
        {
            double variazione = 0;
            double[] battiti = { battiti_1, battiti_2, battiti_3, battiti_4, battiti_5 };
            double max = 0, min = 0;

            for(int i = 0; i < 5; i++)
            {
                if (i == 0)
                {
                    max = battiti[i];
                    min = battiti[i];
                }

                if (battiti[i] < min)
                {
                    min = battiti[i];
                }

                if (battiti[i] > max)
                {
                    max = battiti[i];
                }
            }

            variazione = max - min;

            return variazione;
        }

        public static string OrdineBattiti(double battiti_mattutini, double battiti_pomeridiani, double battiti_attività, double battiti_serali)
        {
            string battiti_ordinati = "";

            string risultato = "";

            double[] battiti = { battiti_mattutini, battiti_pomeridiani, battiti_attività, battiti_serali };

            Array.Sort(battiti);

            for(int i = 0; i < 4; i++)
            {
                if (i != 3)
                {
                    battiti_ordinati = Convert.ToString(battiti[i] + ", ");
                }
                else
                {
                    battiti_ordinati = Convert.ToString(battiti[i]);
                }

                risultato = risultato + battiti_ordinati;
            }

            return risultato;
        }

        //extra
        public static string CalcoloIMC(double altezza, double peso)
        {
            string categoria_imc = "";
            double risultato_imc = 0;

            risultato_imc = peso / (altezza * altezza);
            risultato_imc = Math.Round(risultato_imc, 1);

            if (risultato_imc < 19)
            {
                categoria_imc = "Sottopeso";
            }

            if (risultato_imc >= 19 && risultato_imc <= 24)
            {
                categoria_imc = "Medio";
            }

            if (risultato_imc >= 25 && risultato_imc <= 30)
            {
                categoria_imc = "Sovrappeso";
            }

            if (risultato_imc > 30)
            {
                categoria_imc = "Obesità";
            }

            return categoria_imc;
        }
    }
}
