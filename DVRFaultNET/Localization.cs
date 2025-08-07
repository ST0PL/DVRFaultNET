using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DVRFaultNET
{
    class Localization
    {
        private static List<Localization> _defaultLocales =
            new List<Localization>
                {
                 new Localization("ru-RU",
                     new Dictionary<string, string>
                     {
                         { "Input", "Введите URL камеры" },
                         { "Uid", "Логин" },
                         { "Role", "Роль" },
                         { "ResultCode", "Код результата"},
                         { "Password", "Пароль" },
                         { "ExitDialog", "Нажмите на любую кнопку для выхода или Enter для продолжения." },
                         { "ExitMessage", "Выход..."}

                     }),
                 new Localization("en-US",
                     new Dictionary<string, string>
                     {
                         { "Input", "Enter camera URL" },
                         { "Uid", "Username" },
                         { "Password", "Password" },
                         { "Role", "Role" },
                         { "ResultCode", "Result code"},
                         { "ExitDialog", "Press any button for exit or Enter for continue." },
                         { "ExitMessage", "Exiting..."}

                     })

                };
        public string LocaleName { get; set; }
        public Dictionary<string,string> LocaleValues { get; set; }
        public Localization(string LocaleName, Dictionary<string,string> LocaleValues)
        {
            this.LocaleName = LocaleName;
            this.LocaleValues = LocaleValues;
        }
        public static List<Localization> GetLocale()
        {
            List<Localization> localization;
            if (File.Exists("locale.json"))
            {

                using (StreamReader streamReader = new StreamReader("locale.json"))
                {
                    string JsonLocale = streamReader.ReadToEnd();
                    localization = JsonConvert.DeserializeObject<List<Localization>>(JsonLocale);
                }
                return localization;
            }
            WriteLocale(_defaultLocales);
            return _defaultLocales;

        }
        public static string WriteLocale(List<Localization> localization)
        {
            string JsonLocale;
            using (Stream fileStream = new FileStream("locale.json", FileMode.OpenOrCreate))
            {
                JsonLocale = JsonConvert.SerializeObject(localization);
                byte[] buffer = Encoding.UTF8.GetBytes(JsonLocale);
                fileStream.Write(buffer, 0, buffer.Length);
            }
            return JsonLocale;
        }
    }
}

