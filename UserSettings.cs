namespace ZapperAssessment
{
    public class UserSettings
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Settings> Settings { get; set; }
        
        public UserSettings() { Id = Guid.NewGuid(); }
        public UserSettings(string firstName, string lastName, List<Settings> settings)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            Settings = settings;
        }

        public bool CheckSettings(string settings, string setting)
        {
            if(string.IsNullOrEmpty(settings) || string.IsNullOrEmpty(setting))
                return false;
            if(settings.Length != 8)
                return false;
            if (!int.TryParse(setting, out int settingIndex))
                return false;
            if(settingIndex > 8)
                return false;

            char[] charSettings = settings.ToCharArray();
            return charSettings[settingIndex - 1].Equals('1'); //Minus one cos of zero index arrays
        }

        public void WriteSettingsToFile()
        {
            string settingsFile = "Settings.txt";
            
            if (!File.Exists(settingsFile))
            {
                using (StreamWriter streamWriter = new StreamWriter(File.Create(settingsFile)));
            }
            using (StreamWriter streamWriter = new StreamWriter(settingsFile))
            {
                streamWriter.WriteLine($"{Id} \t{string.Join(",", Settings)}");
            }
        }

        public string ReadSettings()
        {
            string settingsFile = "Settings.txt";

            if (!File.Exists(settingsFile))
                return string.Empty;

            string[] settings = File.ReadAllLines(settingsFile);
            return settings[settings.Length - 1].ToString();
        }
    }

    public enum Settings
    {
        SMSNotificationsEnabled = 1,
        PushNotificationEnabled = 2,
        BioMetricsEnabled = 3,
        CameraEnabled = 4,
        LocationEnabled = 5,
        NFCEnabled = 6,
        VouchersEnabled = 7,
        LoyaltyENabled = 8
    }
}
