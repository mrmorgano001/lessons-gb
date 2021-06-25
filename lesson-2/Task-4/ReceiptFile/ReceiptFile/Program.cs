using System;

namespace ReceiptFile
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var shopName = "Обособленное подразделение 'ООО ДНС плюс'";
            var shopAddres = "603000 г.Н.Новгород ул.Телеграфная д.53";
            var product = "7688909 Смартфон Apple iPhone 8 128 Gb";
            var finalPrice = 56980;
            var cashierFIO = "Веденеев А.С.                   #7958";
            var inn = "5257129767";
            var fn = "8710000100662088";
            var date = "18.09.17 13:15";
            var cash = 57000;
            Console.WriteLine("            Товарный чек");
            Console.WriteLine($"{shopName}");
            Console.WriteLine($"{shopAddres}");
            Console.WriteLine("Документ В-00021727");
            Console.WriteLine("**************************************");
            Console.WriteLine($"{product}");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Адрес сервисного центра:");
            Console.WriteLine("1. Сервисные центры: ул. Петрищева дом 18.");
            Console.WriteLine("Тел.: 8-831-288-88-01 с 10 до 20 ежедневно");
            Console.WriteLine("********************************************");
            Console.WriteLine($"ИТОГО К ОПЛАТЕ                     ={finalPrice}.00");
            Console.WriteLine($"ИТОГ                               ={finalPrice}.00");
            Console.WriteLine($"НАЛИЧНЫМИ                          ={cash}.00");
            Console.WriteLine("СДАЧА                                 =20.00");
            Console.WriteLine("А:НДС 18%                           =8691.86");
            Console.WriteLine($"РН ККТ:0000594664009410       {date}");
            Console.WriteLine("ЗН ККТ:0459050001005532     СМЕНА: 89 ЧЕК:20");
            Console.WriteLine("КАССОВЫЙ ЧЕК/ПРИХОД");
            Console.WriteLine($"ИНН:{inn}           ФН:{fn}");
            Console.WriteLine($"КАССИР {cashierFIO}");
            Console.WriteLine("Сайт ФНС:                       www.nalog.ru");
            Console.WriteLine("ОФД:                        ООО 'Эвотор ОФД'");
            Console.WriteLine("Сайт ОФД:               ofdp.platformaofd.ru");
            Console.WriteLine("CH0:ОСН                ФД:7783 ФП:2452610800");
            Console.ReadKey();
        }
    }
}