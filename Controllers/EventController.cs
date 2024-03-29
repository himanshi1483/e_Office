﻿using e_Office.Models;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace e_Office.Controllers
{
    internal static class CalendarScopes
    {
        public static string[] Scopes
        {
            get
            {
                return new[] {
                    "openid",
                    "email",
                    CalendarService.Scope.Calendar, CalendarService.Scope.CalendarEvents
                    //CalendarService.Scope.CalendarReadonly,
                };
            }
        }
    }

    internal static class MyClientSecrets
    {
        public const string ClientId = "386766609952-jg6mglmbo59qr0jam0bsvg4235lknm7q.apps.googleusercontent.com";
        public const string ClientSecret = "g9b-RPF7j32WnVGal3x79pRn";
    }

    internal static class MyClaimTypes
    {
        public const string GoogleUserId = "support@aarushsystems.com";
    }
    public class EventController : Controller
    {
        //  static string[] Scopes = {CalendarService.Scope.Calendar, CalendarService.Scope.CalendarEvents };
        static string ApplicationName = "e-Office";
        ApplicationDbContext db = new ApplicationDbContext();

        // GET: Event
        public ActionResult Index()
        {
            return View();
        }

        //private readonly IDataStore dataStore = new FileDataStore(GoogleWebAuthorizationBroker.Folder);

        //private async Task<UserCredential> GetCredentialForApiAsync()
        //{
        //    var initializer = new GoogleAuthorizationCodeFlow.Initializer
        //    {
        //        ClientSecrets = new ClientSecrets
        //        {
        //            ClientId = MyClientSecrets.ClientId,
        //            ClientSecret = MyClientSecrets.ClientSecret,
        //        },
        //        Scopes = CalendarScopes.Scopes,
        //    };
        //    var flow = new GoogleAuthorizationCodeFlow(initializer);

        //    var identity = await HttpContext.GetOwinContext().Authentication.GetExternalIdentityAsync(
        //        DefaultAuthenticationTypes.ApplicationCookie);
        //    var userId = identity.FindFirstValue(MyClaimTypes.GoogleUserId);

        //    var token = await dataStore.GetAsync<TokenResponse>(userId);
        //    return new UserCredential(flow, userId, token);
        //}


        public ActionResult UpcomingEvents()
        {
            UserCredential credential;
            string credPath1 = @"~\Documents\credentials.json";
            using (var stream =
                 new FileStream(Server.MapPath(credPath1), FileMode.Open, FileAccess.ReadWrite))
            {
                string credPath = Server.MapPath(@"~\Documents\token.json");
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    CalendarScopes.Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, false)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }
            // Create Drive API service.
            var service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            //const int MaxEventsPerCalendar = 20;
            //const int MaxEventsOverall = 50;

            var model = new UpcomingEventsViewModel();

            // Fetch the list of calendars.
            //var calendars = service.CalendarList.List().Execute();

            //Fetch some events from each calendar.
            //var fetchTasks = new List<Task<Google.Apis.Calendar.v3.Data.Events>>(calendars.Items.Count);
            //foreach (var calendar in calendars.Items)
            //{
            //    var request = service.Events.List(calendar.Id);
            //    request.MaxResults = MaxEventsPerCalendar;
            //    request.SingleEvents = true;
            //    request.TimeMin = DateTime.Now;
            //    fetchTasks.Add(request.Execute());
            //}
            //var fetchResults = fetchTasks;
            //Sort the events and put them in the model.
            //var upcomingEvents = from result in fetchResults
            //                     from evt in result.Items
            //                     where evt.Start != null
            //                     let date = evt.Start.DateTime.HasValue ?
            //                         evt.Start.DateTime.Value.Date :
            //                         DateTime.ParseExact(evt.Start.Date, "yyyy-MM-dd", null)
            //                     let sortKey = evt.Start.DateTimeRaw ?? evt.Start.Date
            //                     orderby sortKey
            //                     select new { evt, date };
            //var eventsByDate = from result in upcomingEvents.Take(MaxEventsOverall)
            //                   group result.evt by result.date into g
            //                   orderby g.Key
            //                   select g;

            //var eventGroups = new List<CalendarEventGroup>();
            //foreach (var grouping in eventsByDate)
            //{
            //    eventGroups.Add(new CalendarEventGroup
            //    {
            //        GroupTitle = grouping.Key.ToLongDateString(),
            //        Events = grouping,
            //    });
            //}

           // model.EventGroups = eventGroups;
            return View(model);
        }

        [HttpPost]
        public ActionResult AddEvent(UpcomingEventsViewModel model)
        {
            UserCredential credential;
            string credPath1 = @"~\Documents\credentials.json";
            using (var stream =
                 new FileStream(Server.MapPath(credPath1), FileMode.Open, FileAccess.ReadWrite))
            {
                string credPath = Server.MapPath(@"~\Documents\token.json");
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    CalendarScopes.Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, false)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }
            // Create Drive API service.
            var service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            var _event = new Event();
            _event.Start = new EventDateTime()
            {
                DateTime = DateTime.Parse(model.NewEvent.EventStart.Value.ToLongDateString()),
                TimeZone = "Asia/Kolkata"
            };
            _event.End = new EventDateTime()
            {
                DateTime = DateTime.Parse(model.NewEvent.EventEnd.Value.ToLongDateString()),
                TimeZone = "Asia/Kolkata"
            };
            var _list = new List<EventAttendee>();
            if (model.NewEvent.Attendees[0] == "")
            {
                var att = new EventAttendee()
                {
                    Email = "support@aarushsystems.com"
                };
                _list.Add(att);               
            }
            else
            {
                foreach (var item in model.NewEvent.Attendees[0].Split(','))
                {
                    var attendee = new EventAttendee();
                    attendee.Email = item;
                    _list.Add(attendee);
                }
            }
            _event.Attendees = _list;
           
            _event.Description = model.NewEvent.Description;
            _event.GuestsCanSeeOtherGuests = true;
            //_event.Location = model.NewEvent.Location;
            _event.Kind = "calendar#event";
            _event.Summary = model.NewEvent.EventName;
            _event.ColorId = "4";
            _event.Reminders = new Event.RemindersData()
            {
                UseDefault = false,
                Overrides = new EventReminder[] {
            new EventReminder() { Method = "email", Minutes = 24 * 60 }
                }
            };
            //var result = service.Events.Insert(_event, "support@aarushsystems.com");
            EventsResource.InsertRequest request = service.Events.Insert(_event, "support@aarushsystems.com");
            Event createdEvent = request.Execute();

            db.EventCalendar.Add(model.NewEvent);
            db.SaveChanges();
            return View("UpcomingEvents");

        }
    }
}