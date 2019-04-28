using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataCardio.Test
{
    [TestClass]
    public class DataCardio_Test
    {
        //script 1
        [DataTestMethod]
        [DataRow(15, 143.5, 184.5)]  //età, battitti minimi, battiti massimi 
        [DataRow(20, 140, 180)]
        [DataRow(25, 136.5, 175.5)]
        [DataRow(30, 133, 171)]
        [DataRow(0, 0, 0)]
        [DataRow(-1, 0, 0)]

        public void TestBattitiMinimiMassimi(int età, double battiti_min_aspettati, double battiti_max_aspettati)
        {
            double battiti_min = CardioLibrary.DataCardio.Btminimi(età);
            Assert.AreEqual(battiti_min, battiti_min_aspettati);

            double battiti_max = CardioLibrary.DataCardio.Btmassimi(età);
            Assert.AreEqual(battiti_max, battiti_max_aspettati);
        }

        //script 2
        [DataTestMethod]
        [DataRow(40, "Bradicardia")]  //battiti, frequenza cardiaca a riposo
        [DataRow(50, "Bradicardia")]
        [DataRow(60, "Normale")]
        [DataRow(100, "Normale")]
        [DataRow(120, "Tachicardia")]
        [DataRow(140, "Tachicardia")]
        [DataRow(-10, "Errore")]
        [DataRow(0, "Errore")]

        public void TestValoriFrequenzaCardiacaRiposo(double battiti, string frequenza_cardiaca_riposo_aspettati)
        {
            string frequenza_cardiaca_riposo = CardioLibrary.DataCardio.FrequenzaCardiacaRiposo(battiti);

            Assert.AreEqual(frequenza_cardiaca_riposo, frequenza_cardiaca_riposo_aspettati);
        }

        //script 3
        [DataTestMethod]
        [DataRow("M", 80, 75, 40, 60, 263.40)]  //sesso, frequenza cardiaca media, peso, anni, durata sessione allenamento, calorie bruciate aspettate
        [DataRow("F", 60, 65, 30, 60, 6.59)]

        public void TestCalorieBruciate(string sesso, double frequenza_cardiaca, double peso, int anni, double tempo, double calorie_bruciate_aspettate)
        {
            double calorie_bruciate = CardioLibrary.DataCardio.CalorieBruciate(sesso, frequenza_cardiaca, peso, anni, tempo);

            Assert.AreEqual(calorie_bruciate_aspettate, calorie_bruciate);
        }

        //script 4
        [DataTestMethod]
        [DataRow("Corsa", 10, 80, 720)]  //tipo di attività, km percorsi, peso corporeo, spesa energetica
        [DataRow("Camminata", 20, 70, 700)]

        public void TestSpesaEnergetica(string attività, double km_percorsi, double peso_corporeo, double spesa_energetica_aspettata)
        {
            double spesa_energetica = CardioLibrary.DataCardio.SpesaEnergetica(attività, km_percorsi, peso_corporeo);

            Assert.AreEqual(spesa_energetica_aspettata, spesa_energetica);
        }

        //script 5
        [DataTestMethod]
        [DataRow(60, 110, 100, 90)]  //battiti a riposo, battiti massimi, battiti di recupero, media giornaliera
        [DataRow(55, 120, 90, 88.3)]

        public void TestBattitiGiornalieri(double battiti_riposo, double battiti_massimi, double battiti_recupero, double battiti_giornalieri_aspettati)
        {
            double battiti_giornalieri = CardioLibrary.DataCardio.BattitiGiornalieri(battiti_riposo, battiti_massimi, battiti_recupero);

            Assert.AreEqual(battiti_giornalieri_aspettati, battiti_giornalieri);
        }

        [DataTestMethod]
        [DataRow(58, 56, 60, 56, 57, 56)]  //battiti giorno 1, giorno 2, giorno 3, giorno 4, giorno 5, battiti a riposo
        [DataRow(56, 60, 55, 58, 50, 50)]

        public void TestBattitiRiposo(double battiti_1, double battiti_2, double battiti_3, double battiti_4, double battiti_5, double battiti_riposo_aspettati)
        {
            double battiti_riposo = CardioLibrary.DataCardio.BattitiRiposo(battiti_1, battiti_2, battiti_3, battiti_4, battiti_5);

            Assert.AreEqual(battiti_riposo_aspettati, battiti_riposo);
        }

        [DataTestMethod]
        [DataRow(56, 58, 60, 50, 55, 10)]  //battiti giorno 1, giorno 2, giorno 3, giorno 4, giorno 5, variabilità del battito
        [DataRow(57, 55, 56, 59, 58, 4)]

        public void TestVariabilitàBattito(double battiti_1, double battiti_2, double battiti_3, double battiti_4, double battiti_5, double variabilità_battito_aspettato)
        {
            double variabilità_battito = CardioLibrary.DataCardio.VariabilitàBattito(battiti_1, battiti_2, battiti_3, battiti_4, battiti_5);

            Assert.AreEqual(variabilità_battito_aspettato, variabilità_battito);
        }


        [DataTestMethod]
        [DataRow(60, 65, 100, 62, "60, 62, 65, 100")]  //battiti mattutini - battiti pomeridiani - battiti durante attività - battiti serali, battiti ordinati in ordine crescente
        [DataRow(62, 66, 110, 65, "62, 65, 66, 110")]

        public void TestBattitiCrescenti(double battiti_mattutini, double battiti_pomeridiani, double battiti_attività, double battiti_serali, string battiti_ordinati_aspettati)
        {
            string battiti_ordinati = CardioLibrary.DataCardio.OrdineBattiti(battiti_mattutini, battiti_pomeridiani, battiti_attività, battiti_serali);

            Assert.AreEqual(battiti_ordinati_aspettati, battiti_ordinati);
        }
    }
}
