using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FFArchive.History
{
    public enum HistoryManagerState { Read, Write, Update, Init }

    public enum HistoryManagerStatus { Dirty, Clean }

    public class HistoryManager
    {
        private HistoryByDateCollection _history;

        private HistoryManagerState _state;
        private HistoryManagerStatus _status;
        private readonly List<string> _sites;

        private TreeView _tv;
        private bool _init;

        public HistoryManager(ref TreeView tv, List<string> sites)
        {
            _tv = tv;
            _sites = sites;
            _history = new HistoryByDateCollection();
        }

        public HistoryManagerStatus Status
        {
            get => _status;
            private set => _status = value;
        }

        public HistoryManagerState State
        {
            get => _state;
            set
            {
                _state = value;
                StateChanged();
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
                    Status = HistoryManagerStatus.Dirty;
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

                Status = HistoryManagerStatus.Dirty;
                if (!_init) HistoryDisplay.AddNewHistoryEntry(he, ref _tv);
            }
        }

        private bool FindEntry(HistoryEntry he)
        {
            string date = he.Date.ToShortDateString();
            HistoryList hc = _history[date];

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

        private void StateChanged()
        {
            switch (_state)
            {
                case HistoryManagerState.Read:
                    _history = HistoryFile.ReadFile(_sites);
                    _status = HistoryManagerStatus.Clean;
                    break;

                case HistoryManagerState.Write:
                    HistoryFile.WriteFile(_history, _sites);
                    _status = HistoryManagerStatus.Clean;
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
                    _status = HistoryManagerStatus.Clean;
                    _init = false;
                    break;
            }
        }
    }
}