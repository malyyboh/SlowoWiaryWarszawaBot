namespace SlowoWiaryWarszawaBot.Resources;

/// <summary>
/// Команди бота та їх описи
/// </summary>
public static class BotCommands
{
    public const string Start = "/start";
    public const string Help = "/help";

    /// <summary>
    /// Адміністративні команди (доступні тільки для адмінів)
    /// </summary>
    public static class Admin
    {
        public const string AddEvent = "/add_event";
        public const string DeleteEvent = "/delete_event";
        public const string ListEvents = "/list_events";
        public const string Statistics = "/stats";
        public const string Broadcast = "/broadcast"; 
    }

    /// <summary>
    /// Описи команд для BotFather
    /// </summary>
    public static class Descriptions
    {
        public const string Start = "Головне меню";
        public const string Help = "Довідка бота";
        
        // Admin descriptions
        public const string AddEvent = "Додати подію (тільки для адмінів)";
        public const string DeleteEvent = "Видалити подію";
        public const string ListEvents = "Список подій";
        public const string Statistics = "Статистика бота";
        public const string Broadcast = "Розсилка повідомлення";
    }
    /// <summary>
    /// Отримати список команд для користувачів (для BotFather)
    /// </summary>
    public static string GetUserCommandsList()
    {
        return $"{Start} - {Descriptions.Start}\n" +
               $"{Help} - {Descriptions.Help}";
    }
    /// <summary>
    /// Отримати список команд для адмінів (для BotFather)
    /// </summary>
    public static string GetAdminCommandsList()
    {
        return GetUserCommandsList() + "\n" +
               $"{Admin.AddEvent} - {Descriptions.AddEvent}" +
               $"{Admin.DeleteEvent} - {Descriptions.DeleteEvent}" +
               $"{Admin.ListEvents} - {Descriptions.ListEvents}" +
               $"{Admin.Statistics} - {Descriptions.Statistics}" +
               $"{Admin.Broadcast} - {Descriptions.Broadcast}";
    }
}

