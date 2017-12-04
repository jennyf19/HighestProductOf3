using System;
using System.Collections.Generic;
using System.Linq;

namespace HighestProduct
{
    public class Meeting
    {
        public int StartTime { get; }

        public int EndTime { get; }

        public Meeting(int startTime, int endTime)
        {
            // Number of 30 min blocks past 9:00 am
            StartTime = startTime;
            EndTime = endTime;
        }

        public override string ToString()
        {
            return $"({StartTime}, {EndTime})";
        }

        public List<Meeting> MergeRanges(List<Meeting> meetings)
        {
            // make a copy and sort by start time
            var sortedMeetings = meetings.Select(m => new Meeting(m.StartTime, m.EndTime)).OrderBy(m => m.StartTime).ToList();

            // Initialize mergedMeetings with the earliest meeting
            var mergedMeetings = new List<Meeting> { sortedMeetings[0] };

            foreach(var currentMeeting in sortedMeetings)
            {
                var lastMergedMeeting = mergedMeetings.Last();

                // if the current and last meetings overlap, use the latest end time
                if(currentMeeting.StartTime <= lastMergedMeeting.EndTime)
                {
                    lastMergedMeeting = new Meeting(lastMergedMeeting.StartTime, Math.Max(lastMergedMeeting.EndTime,
                        currentMeeting.EndTime));
                    mergedMeetings[mergedMeetings.Count - 1] = lastMergedMeeting;
                }
                else
                {
                    // Current meeting doesn't overlap - add it
                    mergedMeetings.Add(currentMeeting);
                }
            }
            return mergedMeetings;
        }
    }
}
