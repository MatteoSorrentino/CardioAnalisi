﻿using System;
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
        [DataRow(58, 56, 60, 56, 57, 57.4)]  //battiti giorno 1, giorno 2, giorno 3, giorno 4, giorno 5, battiti a riposo
        [DataRow(56, 60, 55, 58, 50, 55.8)]

        public void TestBattitiRiposo(double battiti_1, double battiti_2, double battiti_3, double battiti_4, double battiti_5, double battiti_riposo_aspettati)
        {
            double battiti_riposo = CardioLibrary.DataCardio.BattitiRiposo(battiti_1, battiti_2, battiti_3, battiti_4, battiti_5);

            Assert.AreEqual(battiti_riposo_aspettati, battiti_riposo);
        }
    }
}
