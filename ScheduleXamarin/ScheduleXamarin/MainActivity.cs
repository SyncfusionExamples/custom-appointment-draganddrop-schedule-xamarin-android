using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Com.Syncfusion.Schedule;
using Com.Syncfusion.Schedule.Enums;
using Java.Util;
using Android.Graphics;
using System.Collections.ObjectModel;

namespace ScheduleXamarin
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        SfSchedule schedule;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            schedule = new SfSchedule(this);
            schedule.ScheduleView = ScheduleView.WeekView;
            schedule.AllowAppointmentDrag = true;

            AppointmentMapping dataMapping = new AppointmentMapping();
            dataMapping.Subject = "EventName";
            dataMapping.StartTime = "From";
            dataMapping.EndTime = "To";
            dataMapping.Color = "Color";
            dataMapping.IsAllDay = "IsAllDay";
            schedule.AppointmentMapping = dataMapping;

            this.AddAppointments();
            SetContentView(schedule);
        }

        /// <summary>
        /// Add appointments into schedule ItemsSource
        /// </summary>
        private void AddAppointments()
        {
            var Meetings = new ObservableCollection<Meeting>();
            Calendar currentDate = Calendar.Instance;
            Calendar startTime = (Calendar)currentDate.Clone();

            startTime.Set(currentDate.Get(CalendarField.Year),
                          currentDate.Get(CalendarField.Month),
                          currentDate.Get(CalendarField.DayOfMonth),
                          10, 0, 0);

            Calendar endTime = (Calendar)currentDate.Clone();

            endTime.Set(currentDate.Get(CalendarField.Year),
                        currentDate.Get(CalendarField.Month),
                        currentDate.Get(CalendarField.DayOfMonth),
                        11, 0, 0);

            var meeting = new Meeting();
            meeting.From = startTime;
            meeting.To = endTime;
            meeting.EventName = "Meeting";
            meeting.Color = Color.Red;
            Meetings.Add(meeting);

            var allDay = new Meeting();
            allDay.From = startTime;
            allDay.To = endTime;
            allDay.EventName = "All day Meeting";
            allDay.Color = Color.GreenYellow;
            allDay.IsAllDay = true;
            Meetings.Add(allDay);

            schedule.ItemsSource = Meetings;
        }
    }
}