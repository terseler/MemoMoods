using System;
using Xamarin.Essentials;

public static class StreakManager
{
    private const string StreakCountKey = "StreakCount";
    private const string LastEntryDateKey = "LastEntryDate";

    public static int GetStreakCount()
    {
        return Preferences.Get(StreakCountKey, 0);
    }

    public static void IncrementStreakCount()
    {
        Preferences.Set(StreakCountKey, GetStreakCount() + 1);
    }

    public static void ResetStreakCount()
    {
        Preferences.Set(StreakCountKey, 0);
    }

    public static DateTime GetLastEntryDate()
    {
        return Preferences.Get(LastEntryDateKey, DateTime.MinValue);
    }

    public static void SetLastEntryDate(DateTime date)
    {
        Preferences.Set(LastEntryDateKey, date);
    }
}
