namespace Blazor.OneClick.Models
{
    public class Language
    {
        public string code { get; set; }
        public string name { get; set; }
    }



    public static class LanguageStaff
    {
        public static List<Language> Languages { get; set; } = new List<Language> {
            new Language
            {
                code = "ru", name = "Русский"
            },

            new Language
            {
                code = "en", name = "English"
            },
             new Language
            {
                code = "af", name = "Afrikaans"
            },
              new Language
            {
                code = "be", name = "Беларуская"
            },
             new Language
            {
                code = "bg", name = "Български"
            },
              new Language
            {
                code = "da", name = "Dansk"
            },
               new Language
            {
                code = "de", name = "Deutsch"
            },
             new Language
            {
                code = "et", name = "Eesti"
            },
              new Language
            {
                code = "es", name = "Eespanol"
            },
              new Language
            {
                code = "eu", name = "Euskara"
            },
               new Language
            {
                code = "id", name = "Indonesia"
            },
             new Language
            {
                code = "it", name = "Italiano"
            },
            new Language
            {
                code = "fr", name = "Francais"
            },
            new Language
            {
                code = "pl", name = "Polski"
            },
            new Language
            {
                code = "pt", name = "Portugues"
            },
             new Language
            {
                code = "ro", name = "Romana"
            },
             new Language
            {
                code = "sr", name = "Српски"
            },
              new Language
            {
                code = "sq", name = "Shqip"
            },
               new Language
            {
                code = "fi", name = "Suomi"
            },
               new Language
            {
                code = "sv", name = "Svenska"
            },
             new Language
            {
                code = "sw", name = "Kiswahili"
            },


             new Language
            {
                code = "nl", name = "Nederlands"
            },



             new Language
            {
                code = "lv", name = "Latviesu"
            },
             new Language
            {
                code = "lt", name = "Lietuviu"
            },
             new Language
            {
                code = "mk", name = "Македонски"
            },
             new Language
            {
                code = "mn", name = "Монгол"
            },



              new Language
            {
                code = "tt", name = "Татар"
            },
              new Language
            {
                code = "tr", name = "Turkce"
            },
              new Language
            {
                code = "uk", name = "Українська"
            },


               new Language
            {
                code = "hr", name = "Hrvatski"
            },




        };
    }
}
