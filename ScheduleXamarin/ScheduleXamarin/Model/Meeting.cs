using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Util;

namespace ScheduleXamarin
{
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
}