// See https://aka.ms/new-console-template for more information
using ZapperAssessment;

List<Settings> settings = new List<Settings>() { 
                                                Settings.SMSNotificationsEnabled,
                                                Settings.PushNotificationEnabled, 
                                                Settings.LocationEnabled, 
                                                Settings.VouchersEnabled, 
                                                Settings.LoyaltyENabled
                                               };
UserSettings MandisaNomda = new UserSettings("Mandisa", "Nomda", settings);

Console.WriteLine(MandisaNomda.CheckSettings("00000000", "7"));
Console.WriteLine(MandisaNomda.CheckSettings("00000010", "7"));
Console.WriteLine(MandisaNomda.CheckSettings("11111111", "7"));

MandisaNomda.WriteSettingsToFile();
Console.WriteLine(MandisaNomda.ReadSettings());

Console.ReadLine();