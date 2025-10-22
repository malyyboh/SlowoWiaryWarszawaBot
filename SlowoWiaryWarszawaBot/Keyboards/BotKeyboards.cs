using Telegram.Bot.Types.ReplyMarkups;
using SlowoWiaryWarszawaBot.Resources;


namespace SlowoWiaryWarszawaBot.Keyboards;

/// <summary>
/// Генератор клавіатур для бота
/// </summary>
public static class BotKeyboards
{
    /// <summary>
    /// Головне меню (Reply клавіатура)
    /// </summary>
    public static ReplyKeyboardMarkup GetMainMenuKeyboard()
    {
        return new ReplyKeyboardMarkup(new[]
        {
            new KeyboardButton[]
            {
                BotButtons.MainMenu.AboutChurch,
                BotButtons.MainMenu.Ministry
            },
            new KeyboardButton[]
            {
                BotButtons.MainMenu.SocialMedia,
                BotButtons.MainMenu.Events
            },
            new KeyboardButton[]
            {
                BotButtons.MainMenu.Donation,
                BotButtons.MainMenu.Contact
            }
        })
        {
            ResizeKeyboard = true,
            InputFieldPlaceholder = "Оберіть розділ меню"
        };
    }

    /// <summary>
    /// Меню "Про церкву" (Inline клавіатура)
    /// </summary>
    public static InlineKeyboardMarkup GetAboutChurchKeyboard()
    {
        return new InlineKeyboardMarkup(new[]
        {
            new[]
            {
                InlineKeyboardButton.WithCallbackData(
                    BotButtons.Church.About,
                    "church_about"),
                InlineKeyboardButton.WithCallbackData(
                    BotButtons.Church.AboutChurchMission,
                    "church_mission"),
            },
            new[]
            {
                InlineKeyboardButton.WithCallbackData(
                    BotButtons.Church.AboutChurchDoctrine,
                    "church_doctrine"),
                InlineKeyboardButton.WithCallbackData(
                    BotButtons.Church.AboutChurchPastors,
                    "church_pastors"),
            },
            new[]
            {
                InlineKeyboardButton.WithCallbackData(
                    BotButtons.Church.AboutChurchHistory,
                    "church_history"),
                InlineKeyboardButton.WithCallbackData(
                    BotButtons.Navigation.BackToStart,
                    "back_to_start")
            }
        });
    }

    /// <summary>
    /// Меню "Служіння" (Inline клавіатура)
    /// </summary>
    public static InlineKeyboardMarkup GetMinistryKeyboard()
    {
        return new InlineKeyboardMarkup(new[]
        {
            new[]
            {
                InlineKeyboardButton.WithCallbackData(
                    BotButtons.Ministry.Sunday,
                    "ministry_sunday"),
                InlineKeyboardButton.WithCallbackData(
                    BotButtons.Ministry.HomeGroups,
                    "ministry_home_groups"), 
            },
            new[]
            {
                InlineKeyboardButton.WithCallbackData(
                    BotButtons.Ministry.Prayer,
                    "ministry_prayer"),
                InlineKeyboardButton.WithCallbackData(
                    BotButtons.Ministry.Youth,
                    "ministry_youth"), 
            },
            new[]
            {
                InlineKeyboardButton.WithCallbackData(
                    BotButtons.Ministry.Teenagers,
                    "ministry_teenagers"), 
                InlineKeyboardButton.WithCallbackData(
                    BotButtons.Ministry.Kindergarten,
                    "ministry_kindergarten"), 
            },
            new[]
            {
                InlineKeyboardButton.WithCallbackData(
                    BotButtons.Navigation.BackToStart,
                    "back_to_start"), 
            }
        });
    }

    /// <summary>
    /// Клавіатура повернення з підрозділу церкви
    /// </summary>
    public static InlineKeyboardMarkup GetBackToAboutChurchKeyboard()
    {
        return new InlineKeyboardMarkup(new[]
        {
            new[]
            {
                InlineKeyboardButton.WithCallbackData(
                    BotButtons.Navigation.Back,
                    "back_to_church_menu"),
                InlineKeyboardButton.WithCallbackData(
                    BotButtons.Navigation.BackToStart,
                    "back_to_start"), 
            }
        });
    }

    /// <summary>
    /// Клавіатура повернення з підрозділу служіння
    /// </summary>
    public static InlineKeyboardMarkup GetBackToMinistryKeyboard()
    {
        return new InlineKeyboardMarkup(new[]
        {
            new[]
            {
                InlineKeyboardButton.WithCallbackData(
                    BotButtons.Navigation.Back,
                    "back_to_ministry_menu"),
                InlineKeyboardButton.WithCallbackData(
                    BotButtons.Navigation.BackToStart,
                    "back_to_start"),
            }
        });
    }

    /// <summary>
    /// Клавіатура повернення на початок
    /// </summary>
    public static InlineKeyboardMarkup GetBackToStartKeyboard()
    {
        return new InlineKeyboardMarkup(new[]
        {
            new[]
            {
                InlineKeyboardButton.WithCallbackData(
                    BotButtons.Navigation.BackToStart,
                    "back_to_start"),
            }
        });
    }

    /// <summary>
    /// Видалити клавіатуру (приховати Reply клавіатуру)
    /// </summary>
    public static ReplyKeyboardRemove RemoveKeyboard()
    {
        return new ReplyKeyboardRemove();
    }
}