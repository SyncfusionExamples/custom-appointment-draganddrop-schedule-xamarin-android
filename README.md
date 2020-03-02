# How to enable drag and drop for custom appointments in Xamarin.Android Schedule(SfSchedule)

You can enable drag and drop for custom appointments in SfSchedule by implementing the [INotifyPropertyChanged](https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.inotifypropertychanged?view=netframework-4.8) for your event.

Implements the INotifyPropertyChanged in custom appointment class and raise property changed notifier for all the properties used for appointment mapping.  

``` c#
public class Meeting : INotifyPropertyChanged
{
        private string eventname;
        private Calendar from;
        private Calendar to;
        private bool isAllDay;
        private int color;
 
        public string EventName
        {
            get { return eventname; }
            set
            {
                eventname = value;
                this.RaisePropertyChanged("EventName");
            }
        }
 
        public Calendar From
        {
            get { return from; }
            set
            {
                from = value;
                this.RaisePropertyChanged("From");
            }
        }
 
        public Calendar To
        {
            get { return to; }
            set
            {
                to = value;
                this.RaisePropertyChanged("To");
            }
        }
 
        public bool IsAllDay
        {
            get { return isAllDay; }
            set
            {
                isAllDay = value;
                this.RaisePropertyChanged("IsAllDay");
            }
        }
 
        public int Color
        {
            get { return color; }
            set
            {
                color = value;
                this.RaisePropertyChanged("Color");
            }
        }
 
        public event PropertyChangedEventHandler PropertyChanged;
 
        private void RaisePropertyChanged(String property)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs(property));
        }  
}
```
Enable appointment drag and drop support in schedule using [AllowAppointmentDrag](https://help.syncfusion.com/cr/cref_files/xamarin-android/Syncfusion.SfSchedule.Android~Com.Syncfusion.Schedule.SfSchedule~AllowAppointmentDrag.html?_ga=2.114993991.1589356100.1583125428-1204678185.1570168583) property of Schedule.
``` c#
schedule.AllowAppointmentDrag = true;
```
Map the custom appointment properties with the SfSchedule using [AppointmentMapping](https://help.syncfusion.com/cr/xamarin-android/Syncfusion.SfSchedule.Android~Com.Syncfusion.Schedule.AppointmentMapping.html).
``` c#
AppointmentMapping dataMapping = new AppointmentMapping();
dataMapping.Subject = "EventName";
dataMapping.StartTime = "From";
dataMapping.EndTime = "To";
dataMapping.Color = "Color";
dataMapping.IsAllDay = "IsAllDay";
schedule.AppointmentMapping = dataMapping;
```

