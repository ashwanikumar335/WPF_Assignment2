using System;
using System.Collections.Generic;
using System.Text;
using WPF_Assignment2.Data;

namespace WPF_Assignment2.Model
{
    public class NoticeBusinessModel
    {
        List<Notice> Notice { get; set; }
        public NoticeBusinessModel()
        {
            Notice = DatabaseLayer.GetNoticeList();
        }

        public List<Notice> GetNotice()
        {
            return Notice = DatabaseLayer.GetNoticeList();
        }

        public EventHandler NoticeChanged { get; internal set; }

        public void AddNotice(Notice notice)
        {
            DatabaseLayer.InsertNotice(notice);
            OnNoticeChanged();
        }

        public void UpdateNotice(Notice notice)
        {
            DatabaseLayer.UpdateNotice(notice);
            OnNoticeChanged();
        }

        public void DeleteNotice(Notice notice)
        {
            DatabaseLayer.DeleteNotice(notice);
            OnNoticeChanged();
        }

        void OnNoticeChanged()
        {
            if (NoticeChanged != null)
                NoticeChanged(this, null);
        }
    }
}
