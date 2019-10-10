using Google.Apis.Calendar.v3.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace e_Office.Models
{
    public class EventCalendar
    {
        [Key]
        public int EventId { get; set; }

        public EventDateTime EventStart { get; set; }
        public EventDateTime EventEnd { get; set; }

        public string Description { get; set; }
        public string Location { get; set; }
        public string Status { get; set; }
        public List<EventAttendee> Attendees { get; set; }
    }

    public class UpcomingEventsViewModel
    {
        /// <summary>
        /// Gets or sets a sequence of event groups to display.
        /// </summary>
        [Required]
        public IEnumerable<CalendarEventGroup> EventGroups { get; set; }
    }

    public class CalendarEventGroup
    {
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets a string to show above the group of events.
        /// </summary>
        [Required]
        public string GroupTitle { get; set; }
        /// <summary>
        /// Gets or sets a sequence of calendar events to show under the group title.
        /// </summary>
        [Required]
        public IEnumerable<Event> Events { get; set; }
    }
}