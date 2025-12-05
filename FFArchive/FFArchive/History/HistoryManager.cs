using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace FFArchive.History
{
    public enum HistoryManagerState { Read, Write, Update, Init }
    public enum HistoryManagerStatus { Dirty, Clean }

    public class HistoryManager
    {

        private HistoryByDateCollection _history;
                
        private HistoryManagerState _state;
        private HistoryManagerStatus _status;
        private StringCollection _sites;

        private TreeView _tv;
        private bool _init = false;

        public HistoryManager(ref TreeView tv, StringCollection sites) 
        {
            _tv = tv;
            _sites = sites;
            _history = new HistoryByDateCollection();
        }

        public HistoryManagerStatus Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public HistoryManagerState State
        {
            get { return _state; }
            set { 
                _state = value; 
                stateChanged(); 
            }
        }

        public void AddHistoryEntry(DateTime date, string site, string address, string title)
        {
            try
            {
                HistoryEntry he = new HistoryEntry(date, site, address, title);
                if (!FindEntry(he))
                {
                    _history.Add(date, he);
                    HistoryDisplay.AddNewHistoryEntry(he, ref _tv);
                    this.Status = HistoryManagerStatus.Dirty;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "AddHistoryEntry Error");
            }
        }

        public void AddHistoryEntry(HistoryEntry he)
        {
            if (!FindEntry(he))
            {
                _history.Add(he.Date, he);

                this.Status = HistoryManagerStatus.Dirty;
                if (!_init) HistoryDisplay.AddNewHistoryEntry(he, ref _tv);
            }
                
        }

        private bool FindEntry(HistoryEntry he)
        {
            string date = he.Date.ToShortDateString();
            HistoryCollection hc = (HistoryCollection)_history[date];

            if (hc != null)
            {
                foreach (HistoryEntry h in hc)
                {
                    if (h.Text.Equals(he.Text))
                    {
                        if (h.Address.Equals(he.Address))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private void stateChanged() 
        {
            switch (_state)
            {
                case HistoryManagerState.Read:
                    _history = HistoryFile.ReadFile(_sites);
                    this._status = HistoryManagerStatus.Clean;
                    break;
                case HistoryManagerState.Write:
                    HistoryFile.WriteFile(_history, _sites);
                    this._status = HistoryManagerStatus.Clean;
                    break;
                case HistoryManagerState.Init:
                    _init = true;
                    _history = HistoryFile.ReadFile(_sites);
                    if (_history != null)
                    {
                        HistoryDisplay.Update(_history, ref _tv);
                    }
                    else
                    {
                        _history = new HistoryByDateCollection();
                    }
                    this._status = HistoryManagerStatus.Clean;
                    _init = false;
                    break;
                
            }
        }
    }
}
