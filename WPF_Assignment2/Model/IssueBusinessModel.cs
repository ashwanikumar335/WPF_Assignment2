using System;
using System.Collections.Generic;
using System.Text;
using WPF_Assignment2.Data;

namespace WPF_Assignment2.Model
{
    public class IssueBusinessModel
    {
        List<Issue> Issue { get; set; }
        public IssueBusinessModel()
        {
            Issue = DatabaseLayer.GetIssueList();
        }

        public List<Issue> GetIssues()
        {
            return Issue = DatabaseLayer.GetIssueList();
        }
        List<PriorityCollection> PriorityCollection { get; set; }
        public EventHandler IssueChanged { get; internal set; }

        public List<PriorityCollection> GetPriority()
        {
            return PriorityCollection = DatabaseLayer.GetPriority();
        }

        public void AddIssue(Issue issue)
        {
            DatabaseLayer.InsertIssue(issue);
            OnIssueChanged();
        }

        public void UpdateIssue(Issue issue)
        {
            DatabaseLayer.UpdateIssue(issue);
            OnIssueChanged();
        }

        public void DeleteIssue(Issue issue)
        {
            DatabaseLayer.DeleteIssue(issue);
            OnIssueChanged();
        }

        void OnIssueChanged()
        {
            if (IssueChanged != null)
                IssueChanged(this, null);
        }
    }
}
