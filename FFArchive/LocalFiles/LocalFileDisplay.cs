using FFArchive.LocalFiles.Collections;
using FFArchive.LocalFiles.Objects;

using System;
using System.Collections;
using System.Windows.Forms;

namespace FFArchive.LocalFiles
{
    public static class LocalFileDisplay
    {
        public static void AddFile(LocalFile file, ref TreeView localFileTree)
        {
            int siteIndex = GetSiteIndex(file, ref localFileTree);
            int genreIndex;
            int authorIndex;
            int titleIndex;

            if (siteIndex == -1)
            {
                siteIndex = localFileTree.Nodes.Add(new TreeNode(file.WebSite));
                genreIndex = localFileTree.Nodes[siteIndex].Nodes.Add(new TreeNode(file.Universe));
                authorIndex = localFileTree.Nodes[siteIndex].Nodes[genreIndex].Nodes.Add(new TreeNode(file.Author));
                titleIndex = localFileTree.Nodes[siteIndex].Nodes[genreIndex].Nodes[authorIndex].Nodes.Add(new TreeNode(file.Title));
                AddNewFile(siteIndex, genreIndex, authorIndex, titleIndex, file, ref localFileTree);
            }
            else
            {
                genreIndex = GetGenreIndex(siteIndex, file, ref localFileTree);
                if (genreIndex == -1)
                {
                    genreIndex = localFileTree.Nodes[siteIndex].Nodes.Add(new TreeNode(file.Universe));
                    authorIndex = localFileTree.Nodes[siteIndex].Nodes[genreIndex].Nodes.Add(new TreeNode(file.Author));
                    titleIndex = localFileTree.Nodes[siteIndex].Nodes[genreIndex].Nodes[authorIndex].Nodes.Add(new TreeNode(file.Title));
                    AddNewFile(siteIndex, genreIndex, authorIndex, titleIndex, file, ref localFileTree);
                }
                else
                {
                    authorIndex = GetAuthorIndex(siteIndex, genreIndex, file, ref localFileTree);
                    if (authorIndex == -1)
                    {
                        authorIndex = localFileTree.Nodes[siteIndex].Nodes[genreIndex].Nodes.Add(new TreeNode(file.Author));
                        titleIndex = localFileTree.Nodes[siteIndex].Nodes[genreIndex].Nodes[authorIndex].Nodes.Add(new TreeNode(file.Title));
                        AddNewFile(siteIndex, genreIndex, authorIndex, titleIndex, file, ref localFileTree);
                    }
                    else
                    {
                        titleIndex = GetTitleIndex(siteIndex, genreIndex, authorIndex, file, ref localFileTree);
                        if (titleIndex == -1)
                        {
                            titleIndex = localFileTree.Nodes[siteIndex].Nodes[genreIndex].Nodes[authorIndex].Nodes.Add(new TreeNode(file.Title));
                            AddNewFile(siteIndex, genreIndex, authorIndex, titleIndex, file, ref localFileTree);
                        }
                        else
                        {
                            int fileIndex = GetFileIndex(siteIndex, genreIndex, authorIndex, titleIndex, file, ref localFileTree);
                            if (fileIndex == -1)
                            {
                                AddNewFile(siteIndex, genreIndex, authorIndex, titleIndex, file, ref localFileTree);
                            }
                        }
                    }
                }
            }
        }

        private static void AddNewFile(int root, int genre, int author, int title, LocalFile file, ref TreeView localFileTree)
        {
            localFileTree.Nodes[root].Nodes[genre].Nodes[author].Nodes[title].Nodes.Add(file);
        }

        public static void RemoveFile(LocalFile file, ref TreeView localFileTree)
        {
            int siteIndex = GetSiteIndex(file, ref localFileTree);
            int genreIndex = GetGenreIndex(siteIndex, file, ref localFileTree);
            int authorIndex = GetAuthorIndex(siteIndex, genreIndex, file, ref localFileTree);
            int titleIndex = GetTitleIndex(siteIndex, genreIndex, authorIndex, file, ref localFileTree);
            int fileIndex = GetFileIndex(siteIndex, genreIndex, authorIndex, titleIndex, file, ref localFileTree);

            localFileTree.Nodes[siteIndex].Nodes[genreIndex].Nodes[authorIndex].Nodes[titleIndex].Nodes[fileIndex].Remove();
        }

        public static void InitTreeView(SiteCollection siteCollection, ref TreeView localFileTree)
        {
            foreach (string site in siteCollection.Keys)
            {
                TreeNode node = new TreeNode(site) { Name = site };
                int nodeIndex = localFileTree.Nodes.Add(node);
                GenreCollection genre = siteCollection[site];
                foreach (string genreKey in genre.Keys)
                {
                    TreeNode genreNode = new TreeNode(genreKey) { Name = genreKey };
                    int genreIndex = localFileTree.Nodes[nodeIndex].Nodes.Add(genreNode);
                    AuthorCollection authors = genre[genreKey];
                    foreach (string authorKey in authors.Keys)
                    {
                        TreeNode authorNode = new TreeNode(authorKey) { Name = authorKey };
                        int authorIndex = localFileTree.Nodes[nodeIndex].Nodes[genreIndex].Nodes.Add(authorNode);
                        TitleCollection titles = authors[authorKey];
                        foreach (string titleKey in titles.Keys)
                        {
                            TreeNode titleNode = new TreeNode(titleKey) { Name = titleKey };
                            int titleIndex = localFileTree.Nodes[nodeIndex].Nodes[genreIndex].Nodes[authorIndex].Nodes.Add(titleNode);
                            FileCollection files = titles[titleKey];
                            foreach (ArrayList fileArray in files.Values)
                            {
                                foreach (object file in fileArray)
                                {
                                    localFileTree.Nodes[nodeIndex].Nodes[genreIndex].Nodes[authorIndex].Nodes[titleIndex].Nodes.Add((LocalFile)file);
                                }
                            }
                        }
                    }
                }
            }
        }

        private static int GetSiteIndex(LocalFile file, ref TreeView localFileTree)
        {
            for (int siteIndex = 0; siteIndex < localFileTree.Nodes.Count; siteIndex++)
            {
                if (file.WebSite.Equals(localFileTree.Nodes[siteIndex].Text))
                {
                    return siteIndex;
                }
            }
            return -1;
        }

        private static int GetGenreIndex(int root, LocalFile file, ref TreeView localFileTree)
        {
            for (int genreIndex = 0; genreIndex < localFileTree.Nodes[root].Nodes.Count; genreIndex++)
            {
                if (file.Universe.Equals(localFileTree.Nodes[root].Nodes[genreIndex].Text))
                {
                    return genreIndex;
                }
            }
            return -1;
        }

        private static int GetAuthorIndex(int root, int genre, LocalFile file, ref TreeView localFileTree)
        {
            for (int authorIndex = 0; authorIndex < localFileTree.Nodes[root].Nodes[genre].Nodes.Count; authorIndex++)
            {
                if (file.Author.Equals(localFileTree.Nodes[root].Nodes[genre].Nodes[authorIndex].Text))
                {
                    return authorIndex;
                }
            }

            return -1;
        }

        private static int GetTitleIndex(int root, int genre, int author, LocalFile file, ref TreeView localFileTree)
        {
            for (int titleIndex = 0; titleIndex < localFileTree.Nodes[root].Nodes[genre].Nodes[author].Nodes.Count; titleIndex++)
            {
                if (file.Title.Equals(localFileTree.Nodes[root].Nodes[genre].Nodes[author].Nodes[titleIndex].Text))
                {
                    return titleIndex;
                }
            }

            return -1;
        }

        private static int GetFileIndex(int root, int genre, int author, int title, LocalFile file, ref TreeView localFileTree)
        {
            for (int fileIndex = 0; fileIndex < localFileTree.Nodes[root].Nodes[genre].Nodes[author].Nodes[title].Nodes.Count; fileIndex++)
            {
                if (localFileTree.Nodes[root].Nodes[genre].Nodes[author].Nodes[title].Nodes[fileIndex].Text.Equals(file.Filename, StringComparison.OrdinalIgnoreCase))
                {
                    return fileIndex;
                }
            }

            return -1;
        }
    }
}