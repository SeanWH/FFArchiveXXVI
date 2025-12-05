using System;
using System.Collections;
using System.Collections.Generic;

using System.Text;
using System.Windows.Forms;

using FFArchive.LocalFiles.Collections;
using FFArchive.LocalFiles.Objects;

namespace FFArchive.LocalFiles
{
    public static class LocalFileDisplay
    {
        public static void AddFile(LocalFile file, ref TreeView _tv)
        {
            int i = getSiteIndex(file, ref _tv);
            int j;
            int k;
            int m;


            if (i == -1)
            {
                i = _tv.Nodes.Add(new TreeNode(file.WebSite));
                j = _tv.Nodes[i].Nodes.Add(new TreeNode(file.Universe));
                k = _tv.Nodes[i].Nodes[j].Nodes.Add(new TreeNode(file.Author));
                m = _tv.Nodes[i].Nodes[j].Nodes[k].Nodes.Add(new TreeNode(file.Title));
                AddNewFile(i, j, k, m, file, ref _tv);
            }
            else
            {
                j = getGenreIndex(i, file, ref _tv);
                if (j == -1)
                {
                    j = _tv.Nodes[i].Nodes.Add(new TreeNode(file.Universe));
                    k = _tv.Nodes[i].Nodes[j].Nodes.Add(new TreeNode(file.Author));
                    m = _tv.Nodes[i].Nodes[j].Nodes[k].Nodes.Add(new TreeNode(file.Title));
                    AddNewFile(i, j, k, m, file,ref _tv);
                }
                else
                {
                    k = getAuthorIndex(i, j, file, ref _tv);
                    if (k == -1)
                    {
                        k = _tv.Nodes[i].Nodes[j].Nodes.Add(new TreeNode(file.Author));
                        m = _tv.Nodes[i].Nodes[j].Nodes[k].Nodes.Add(new TreeNode(file.Title));
                        AddNewFile(i, j, k, m, file, ref _tv);
                    }
                    else
                    {
                        m = getTitleIndex(i, j, k, file, ref _tv);
                        if (m == -1)
                        {
                            m = _tv.Nodes[i].Nodes[j].Nodes[k].Nodes.Add(new TreeNode(file.Title));
                            AddNewFile(i, j, k, m, file, ref _tv);
                        }
                        else
                        {
                            int n = getFileIndex(i, j, k, m, file, ref _tv);
                            if (n == -1)
                            {
                                AddNewFile(i, j, k, m, file, ref _tv);
                            }
                        }
                    }
                }
            }

        }

        private static void AddNewFile(int root, int genre, int author, int title, LocalFile file, ref TreeView _tv)
        {
            _tv.Nodes[root].Nodes[genre].Nodes[author].Nodes[title].Nodes.Add(file);
        }

        public static void RemoveFile(LocalFile file, ref TreeView _tv)
        {
            int i = getSiteIndex(file, ref _tv);
            int j = getGenreIndex(i, file, ref _tv);
            int k = getAuthorIndex(i, j, file, ref _tv);
            int m = getTitleIndex(i, j, k, file, ref _tv);
            int n = getFileIndex(i, j, k, m, file, ref _tv);

            _tv.Nodes[i].Nodes[j].Nodes[k].Nodes[m].Nodes[n].Remove();
        }

        public static void InitTreeView(SiteCollection _local, ref TreeView _tv)
        {
            foreach (string site in _local.Keys)
            {
                TreeNode node = new TreeNode(site);
                node.Name = site;
                int n0 = _tv.Nodes.Add(node);
                GenreCollection genre = (GenreCollection)_local[site];
                foreach (string g in genre.Keys)
                {
                    TreeNode gn = new TreeNode(g);
                    gn.Name = g;
                    int n1 = _tv.Nodes[n0].Nodes.Add(gn);
                    AuthorCollection authors = (AuthorCollection)genre[g];
                    foreach (string a in authors.Keys)
                    {
                        TreeNode an = new TreeNode(a);
                        an.Name = a;
                        int n2 = _tv.Nodes[n0].Nodes[n1].Nodes.Add(an);
                        TitleCollection titles = (TitleCollection)authors[a];
                        foreach (string t in titles.Keys)
                        {
                            TreeNode tn = new TreeNode(t);
                            tn.Name = t;
                            int n3 = _tv.Nodes[n0].Nodes[n1].Nodes[n2].Nodes.Add(tn);
                            FileCollection files = (FileCollection)titles[t];
                            foreach (ArrayList f in files.Values)
                            {
                                for (int i = 0; i < f.Count; i++)
                                {
                                    _tv.Nodes[n0].Nodes[n1].Nodes[n2].Nodes[n3].Nodes.Add((LocalFile)f[i]);
                                }
                            }
                        }
                    }
                }
            }




        }

        private static int getSiteIndex(LocalFile file, ref TreeView _tv)
        {
            for (int i = 0; i < _tv.Nodes.Count; i++)
            {
                if (file.WebSite.Equals(_tv.Nodes[i].Text))
                {
                    return i;
                }
            }
            return -1;
        }

        private static int getGenreIndex(int root, LocalFile file, ref TreeView _tv)
        {
            for (int j = 0; j < _tv.Nodes[root].Nodes.Count; j++)
            {
                if (file.Universe.Equals(_tv.Nodes[root].Nodes[j].Text))
                {
                    return j;
                }
            }
            return -1;
        }

        private static int getAuthorIndex(int root, int genre, LocalFile file, ref TreeView _tv)
        {

            for (int k = 0; k < _tv.Nodes[root].Nodes[genre].Nodes.Count; k++)
            {
                if (file.Author.Equals(_tv.Nodes[root].Nodes[genre].Nodes[k].Text))
                {
                    return k;
                }
            }

            return -1;
        }

        private static int getTitleIndex(int root, int genre, int author, LocalFile file, ref TreeView _tv)
        {
            for (int m = 0; m < _tv.Nodes[root].Nodes[genre].Nodes[author].Nodes.Count; m++)
            {
                if (file.Title.Equals(_tv.Nodes[root].Nodes[genre].Nodes[author].Nodes[m].Text))
                {
                    return m;
                }
            }

            return -1;
        }

        private static int getFileIndex(int root, int genre, int author, int title, LocalFile file, ref TreeView _tv)
        {
            for (int n = 0; n < _tv.Nodes[root].Nodes[genre].Nodes[author].Nodes[title].Nodes.Count; n++)
            {
                if (_tv.Nodes[root].Nodes[genre].Nodes[author].Nodes[title].Nodes[n].Text.Equals(file.Filename, StringComparison.OrdinalIgnoreCase))
                {
                    return n;
                }
            }

            return -1;
        }
    }
}
