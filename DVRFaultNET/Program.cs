using System;
using System.Net;
using System.Text;
using System.Linq;
using System.Globalization;
using System.Collections.Generic;
using DVRFaultNET;

namespace DVRFault
{
    public class Program
    {
        static RespondModel Result = null;
        static Localization Localization = null;
        static void Main(string[] args)
        {
            List<Localization> locales = Localization.GetLocale();
            Localization = locales.First(x=>x.LocaleName==CultureInfo.CurrentUICulture.Name);
            PrintLogo();
            Console.Write($"{Localization.LocaleValues["Input"]}: ");
            string Address = Console.ReadLine();
            GetCameraInfo(Address);
            Console.WriteLine($"\n\n{Localization.LocaleValues["ExitDialog"]}");
            switch (Console.ReadKey().Key.ToString())
            {
                case "Enter":
                    Console.Clear();
                    Main(null);
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine(Localization.LocaleValues["ExitMessage"]);
                    break;
            }
        }
        
        public static void GetCameraInfo(string Address)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Dictionary<string, string>[] Buffer;
            try { Result = ClientUrl.DVRReq(Address); }
            catch (Exception ex)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
                return;
            }
            Buffer = new Dictionary<string, string>[Result.list.Length];
            if(Buffer.Length > 1)
            {
                StringBuilder sb = new StringBuilder();
                for(int x = 0; x< Result.list.Length; x++)
                {
                    sb.AppendLine("");
                    sb.AppendLine(
                            $"\n{Localization.LocaleValues["Uid"]}: {Result.list[x]["uid"]}" +
                            $"\n{Localization.LocaleValues["Password"]}: {Result.list[x]["pwd"]}" +
                            $"\n{Localization.LocaleValues["Role"]}: {Result.list[x]["role"]}" +
                            $"\n{Localization.LocaleValues["ResultCode"]}: {Result.result}" +
                            $"\nenmac: {Result.list[x]["enmac"]}" +
                            $"\nmac: {Result.list[x]["mac"]}" +
                            $"\nplayback: {Result.list[x]["playback"]}" +
                            $"\nview: {Result.list[x]["view"]}" +
                            $"\nrview: {Result.list[x]["rview"]}" +
                            $"\nptz: {Result.list[x]["ptz"]}" +
                            $"\nbackup: {Result.list[x]["backup"]}" +
                            $"\nopt: {Result.list[x]["opt"]}"
                            );
                }
                Console.WriteLine(sb);
                return;
            }
            Console.WriteLine(
                $"\n{Localization.LocaleValues["Uid"]}: {Result.list[0]["uid"]}" +
                $"\n{Localization.LocaleValues["Password"]}: {Result.list[0]["pwd"]}" +
                $"\n{Localization.LocaleValues["Role"]}: {Result.list[0]["role"]}" +
                $"\n{Localization.LocaleValues["ResultCode"]}: {Result.result}" +
                $"\nenmac: {Result.list[0]["enmac"]}" +
                $"\nmac: {Result.list[0]["mac"]}" +
                $"\nplayback: {Result.list[0]["playback"]}" +
                $"\nview: {Result.list[0]["view"]}" +
                $"\nrview: {Result.list[0]["rview"]}" +
                $"\nptz: {Result.list[0]["ptz"]}" +
                $"\nbackup: {Result.list[0]["backup"]}" +
                $"\nopt: {Result.list[0]["opt"]}"
                );
            Console.ResetColor();
        }
        public static void PrintLogo()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine(
                @"
    ____ _    ______  ______            ____       
   / __ \ |  / / __ \/ ____/___ ___  __/ / /_      
  / / / / | / / /_/ / /_  / __ `/ / / / / __/      
 / /_/ /| |/ / _, _/ __/ / /_/ / /_/ / / /_        
/_____/ |___/_/ |_/_/    \__,_/\__,_/_/\__/        
                                                   
    __             _______________  ____        __ 
   / /_  __  __   / ___/_  __/ __ \/ __ \      / / 
  / __ \/ / / /   \__ \ / / / / / / /_/ /_____/ /  
 / /_/ / /_/ /   ___/ // / / /_/ / ____/_____/ /___
/_.___/\__, /   /____//_/  \____/_/         /_____/
      /____/                                       
                ");
            Console.ResetColor();
        }
    }
}
