﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using Helper = HAW_Tool.HAW.Native.Helper;

namespace HAW_Tool.HAW.Depending
{
    public class CalendarWeek : DependencyObject
    {
        public CalendarWeek()
        {
            Days = new ObservableCollection<Day>();
        }

        public bool IsCurrent
        {
            get
            {
                var a = Helper.StartOfWeek(Week, Year);
                var b = Helper.EndOfWeek(Week, Year);
                return (DateTime.Now.Date >= a & DateTime.Now <= b);
            }
        }

        public void InitializeDays()
        {
            for (int i = 0; i < 7; i++)
            {
                var d = new Day { Date = Helper.StartOfWeek(Week, Year).AddDays(i), DOW = (DayOfWeek)i };
                Days.Add(d);
            }
        }

        public int Year
        {
            get { return (int)GetValue(YearProperty); }
            set { SetValue(YearProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Year.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty YearProperty =
            DependencyProperty.Register("Year", typeof(int), typeof(CalendarWeek), new UIPropertyMetadata(0));



        public int Week
        {
            get { return (int)GetValue(WeekProperty); }
            set { SetValue(WeekProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Week.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WeekProperty =
            DependencyProperty.Register("Week", typeof(int), typeof(CalendarWeek), new UIPropertyMetadata(0));



        public SeminarGroup SeminarGroup
        {
            get { return (SeminarGroup)GetValue(SeminarGroupProperty); }
            set { SetValue(SeminarGroupProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SeminarGroup.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SeminarGroupProperty =
            DependencyProperty.Register("SeminarGroup", typeof(SeminarGroup), typeof(CalendarWeek), new UIPropertyMetadata(default(SeminarGroup)));

        public ObservableCollection<Day> Days { get; set; }

        public string LabelShort
        {
            get { return string.Format("KW-{0}", Week); }
        }

        public string Label
        {
            get { return string.Format("Woche {0} vom {1} bis {2}", Week, Helper.StartOfWeek(this.Week, this.Year).ToShortDateString(), Helper.EndOfWeek(this.Week, this.Year).ToShortDateString()); }
        }

        public DateTime GetDateOfWeekday(int day)
        {
            return Helper.StartOfWeek(Week, Year).AddDays(day);
        }
    }
}
