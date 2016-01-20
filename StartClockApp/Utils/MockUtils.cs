using System;
using System.Collections.Generic;

namespace StartClockApp
{
    internal class MockUtils
    {
        internal static List<StartEntry> GenerateStartEntryList()
        {
            List<StartEntry> items = new List<StartEntry>();

            items.Add(new StartEntry
            {
                Compeditor = new CompeditorInfo { Name = "Steve Joeman" },
                StartTime = new StartTimeInfo { StartTime = new DateTime(2016, 01, 06, 15, 0, 0) }
            });

            return items;
        }
    }
}