using System;
using System.Windows.Forms;

namespace FFArchive.History
{
    public static class HistoryDisplay
    {
        public static void Update(HistoryByDateCollection historyByDateCollection, ref TreeView treeView)
        {
            foreach (string date in historyByDateCollection.Keys)
            {
                HistoryList historyCollection = historyByDateCollection[date];
                int dateNodeIndex = FindDateNodeIndex(date, ref treeView);
                int siteNodeIndex;
                int categoryNodeIndex;
                if (dateNodeIndex == -1)
                {
                    dateNodeIndex = AddNewDateNode(date, ref treeView);
                    foreach (HistoryEntry historyEntry in historyCollection)
                    {
                        siteNodeIndex = FindSiteNodeIndex(dateNodeIndex, historyEntry.Site, ref treeView);
                        if (siteNodeIndex == -1)
                        {
                            siteNodeIndex = AddNewSiteNode(dateNodeIndex, historyEntry.Site, ref treeView);
                        }
                        else
                        {
                            categoryNodeIndex = FindCategoryNodeIndex(dateNodeIndex, siteNodeIndex, historyEntry.EntryCategory, ref treeView);
                            if (categoryNodeIndex == -1)
                            {
                                categoryNodeIndex = AddNewCategoryNode(dateNodeIndex, siteNodeIndex, historyEntry.EntryCategory, ref treeView);
                                treeView.Nodes[dateNodeIndex].Nodes[siteNodeIndex].Nodes[categoryNodeIndex].Nodes.Add(historyEntry);
                            }
                            else
                            {
                                treeView.Nodes[dateNodeIndex].Nodes[siteNodeIndex].Nodes[categoryNodeIndex].Nodes.Add(historyEntry);
                            }
                        }
                    }
                }
                else
                {
                    foreach (HistoryEntry he in historyCollection)
                    {
                        siteNodeIndex = FindSiteNodeIndex(dateNodeIndex, he.Site, ref treeView);
                        if (siteNodeIndex == -1)
                        {
                            siteNodeIndex = AddNewSiteNode(dateNodeIndex, he.Site, ref treeView);
                            categoryNodeIndex = FindCategoryNodeIndex(dateNodeIndex, siteNodeIndex, he.EntryCategory, ref treeView);
                            if (categoryNodeIndex == -1)
                            {
                                categoryNodeIndex = AddNewCategoryNode(dateNodeIndex, siteNodeIndex, he.EntryCategory, ref treeView);
                                treeView.Nodes[dateNodeIndex].Nodes[siteNodeIndex].Nodes[categoryNodeIndex].Nodes.Add(he);
                            }
                            else
                            {
                                treeView.Nodes[dateNodeIndex].Nodes[siteNodeIndex].Nodes[categoryNodeIndex].Nodes.Add(he);
                            }
                        }
                        else
                        {
                            categoryNodeIndex = FindCategoryNodeIndex(dateNodeIndex, siteNodeIndex, he.EntryCategory, ref treeView);
                            if (categoryNodeIndex == -1)
                            {
                                categoryNodeIndex = AddNewCategoryNode(dateNodeIndex, siteNodeIndex, he.EntryCategory, ref treeView);
                                treeView.Nodes[dateNodeIndex].Nodes[siteNodeIndex].Nodes[categoryNodeIndex].Nodes.Add(he);
                            }
                            else
                            {
                                treeView.Nodes[dateNodeIndex].Nodes[siteNodeIndex].Nodes[categoryNodeIndex].Nodes.Add(he);
                            }
                        }
                    }
                }
            }
        }

        public static void AddNewHistoryEntry(HistoryEntry historyEntry, ref TreeView treeView)
        {
            int siteNodeIndex;
            int categoryNodeIndex;

            string date = historyEntry.Date.ToShortDateString();
            int dateNodeIndex = FindDateNodeIndex(date, ref treeView);
            if (dateNodeIndex == -1)
            {
                dateNodeIndex = AddNewDateNode(date, ref treeView);
                siteNodeIndex = AddNewSiteNode(dateNodeIndex, historyEntry.Site, ref treeView);
                categoryNodeIndex = AddNewCategoryNode(dateNodeIndex, siteNodeIndex, historyEntry.EntryCategory, ref treeView);
                treeView.Nodes[dateNodeIndex].Nodes[siteNodeIndex].Nodes[categoryNodeIndex].Nodes.Add(historyEntry);
            }
            else
            {
                siteNodeIndex = FindSiteNodeIndex(dateNodeIndex, historyEntry.Site, ref treeView);
                if (siteNodeIndex == -1)
                {
                    siteNodeIndex = AddNewSiteNode(dateNodeIndex, historyEntry.Site, ref treeView);
                    categoryNodeIndex = AddNewCategoryNode(dateNodeIndex, siteNodeIndex, historyEntry.EntryCategory, ref treeView);
                    treeView.Nodes[dateNodeIndex].Nodes[siteNodeIndex].Nodes[categoryNodeIndex].Nodes.Add(historyEntry);
                }
                else
                {
                    categoryNodeIndex = FindCategoryNodeIndex(dateNodeIndex, siteNodeIndex, historyEntry.EntryCategory, ref treeView);
                    if (categoryNodeIndex == -1)
                    {
                        categoryNodeIndex = AddNewCategoryNode(dateNodeIndex, siteNodeIndex, historyEntry.EntryCategory, ref treeView);
                        treeView.Nodes[dateNodeIndex].Nodes[siteNodeIndex].Nodes[categoryNodeIndex].Nodes.Add(historyEntry);
                    }
                    else
                    {
                        treeView.Nodes[dateNodeIndex].Nodes[siteNodeIndex].Nodes[categoryNodeIndex].Nodes.Add(historyEntry);
                    }
                }
            }
        }

        /// <summary>
        /// Returns -1 if date not found, otherwise returns the index of the node
        /// with that date.
        /// </summary>
        /// <param name="date"></param>
        /// <param name="treeView"></param>
        /// <returns></returns>
        private static int FindDateNodeIndex(string date, ref TreeView treeView)
        {
            for (int nodeIndex = 0; nodeIndex < treeView.Nodes.Count; nodeIndex++)
            {
                if (treeView.Nodes[nodeIndex].Text.Equals(date, StringComparison.OrdinalIgnoreCase))
                {
                    return nodeIndex;
                }
            }
            return -1;
        }

        private static int AddNewDateNode(string date, ref TreeView treeView)
        {
            return treeView.Nodes.Add(new TreeNode(date));
        }

        private static int FindSiteNodeIndex(int rootNodeIndex, string siteToFind, ref TreeView treeView)
        {
            for (int nodeIndex = 0; nodeIndex < treeView.Nodes[rootNodeIndex].Nodes.Count; nodeIndex++)
            {
                if (treeView.Nodes[rootNodeIndex].Nodes[nodeIndex].Text.Equals(siteToFind, StringComparison.OrdinalIgnoreCase))
                {
                    return nodeIndex;
                }
            }
            return -1;
        }

        private static int AddNewSiteNode(int rootNodeIndex, string siteToAdd, ref TreeView treeView)
        {
            return treeView.Nodes[rootNodeIndex].Nodes.Add(new TreeNode(siteToAdd));
        }

        private static int FindCategoryNodeIndex(int root, int site, HistoryEntryCategory category, ref TreeView treeView)
        {
            for (int nodeIndex = 0; nodeIndex < treeView.Nodes[root].Nodes[site].Nodes.Count; nodeIndex++)
            {
                switch (category)
                {
                    case HistoryEntryCategory.Author:
                        if (treeView.Nodes[root].Nodes[site].Nodes[nodeIndex].Text.Equals("Authors"))
                        {
                            return nodeIndex;
                        }
                        break;

                    case HistoryEntryCategory.C2:
                        if (treeView.Nodes[root].Nodes[site].Nodes[nodeIndex].Text.Equals("C2 Groups"))
                        {
                            return nodeIndex;
                        }
                        break;

                    case HistoryEntryCategory.Story:
                        if (treeView.Nodes[root].Nodes[site].Nodes[nodeIndex].Text.Equals("Stories"))
                        {
                            return nodeIndex;
                        }
                        break;
                }
            }
            return -1;
        }

        private static int AddNewCategoryNode(int root, int site, HistoryEntryCategory category, ref TreeView treeView)
        {
            int nodeIndex = 0;
            switch (category)
            {
                case HistoryEntryCategory.Author:
                    nodeIndex = treeView.Nodes[root].Nodes[site].Nodes.Add(new TreeNode("Authors"));
                    break;

                case HistoryEntryCategory.C2:
                    nodeIndex = treeView.Nodes[root].Nodes[site].Nodes.Add(new TreeNode("C2 Groups"));
                    break;

                case HistoryEntryCategory.Story:
                    nodeIndex = treeView.Nodes[root].Nodes[site].Nodes.Add(new TreeNode("Stories"));
                    break;
            }

            return nodeIndex;
        }
    }
}