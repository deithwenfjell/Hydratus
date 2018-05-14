using System;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace Hydratus
{
    public static class Nastavenie
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        #region Setting Constants

        private const string klucVaha = "vaha_kluc";
        private const string klucVyska = "vyska_kluc";
        private const string klucPohlavie = "pohlavie_kluc";
        private static readonly string SettingsDefault = string.Empty;

        #endregion


        public static string PosledneNastavenieVahy
        {
            get
            {
                return AppSettings.GetValueOrDefault(klucVaha, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(klucVaha, value);
            }
        }

        public static string PosledneNastavenieVysky
        {
            get
            {
                return AppSettings.GetValueOrDefault(klucVyska, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(klucVyska, value);
            }
        }

        public static string PosledneNastaveniePohlavia
        {
            get
            {
                return AppSettings.GetValueOrDefault(klucPohlavie, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(klucPohlavie, value);
            }
        }
    }
}
