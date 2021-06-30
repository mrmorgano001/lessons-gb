using System;

namespace seasons
{
    enum Seasons

    {
        Winter,
        Spring,
        Autumn,
        Summer
    }
    public class CheckSeasons
    {
        public static string choiseSeason(int selection)
        {
            string seasonTitle = String.Empty;
                        switch (selection)
                        {
                            case 12:
                            case 1:
                            case 2:
                                seasonTitle = "Winter";
                                break;
                            case 3:
                            case 4:
                            case 5:
                                seasonTitle = "Spring";
                                break;
                            case 6:
                            case 7:
                            case 8:
                                seasonTitle = "Summer";
                                break;
                            case 9:
                            case 10:
                            case 11:
                                seasonTitle = "Autumn";
                                break;
                        }

                        return seasonTitle;
        }

        public static string finalSeason(string seasonTitle)
        {
            string finalTitle = String.Empty;
            if (seasonTitle == "Winter")
                finalTitle = "Зима";
            if (seasonTitle == "Spring")
                finalTitle = "Весна"; 
            if (seasonTitle == "Summer")
                finalTitle = "Лето";
            if (seasonTitle == "Autumn")
                finalTitle = "Осень";
            return finalTitle;
        }
    }
    
}