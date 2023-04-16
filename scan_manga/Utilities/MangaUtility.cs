using scan_manga.Models;
using scan_manga.Utilities.BackgroudWorker;
using scan_manga.Utilities.BackgroudWorker.BackgroundCore;
using scan_manga.Properties;
using static System.Windows.Forms.Design.AxImporter;
using System.Text.RegularExpressions;

namespace scan_manga.Utilities
{
    public class MangaUtility
    {
        public static string Root
        {
            get => Settings.Default.Root;
            set => Settings.Default.Root = value;
        }

        public static string Temp { get => GetPath(Directory.GetCurrentDirectory(), "Temp"); }

        public static List<Manga> Mangas
        {
            get => Settings.Default.Manga;
            set => Settings.Default.Manga = value;
        }

        public static string RootManga
        {
            get => GetPath(Root, "Manga");
        }

        public static void Save(string root, List<Manga> list)
        {
            Root = root;
            Mangas = list;
            Settings.Default.Save();
        }



        public static string[] Sort(string[] listIn, string separator, bool IsPage)
        {
            List<string> listOut = new();
            List<float> nums = new();
            Dictionary<float, string> toAdd = new();
            foreach (string item in listIn)
            {
                string itemName = Path.GetFileNameWithoutExtension(item);
                string[] split = itemName.Split(separator);
                toAdd.Add(float.Parse(split.Last()), split.First());
                nums.Add(float.Parse(split.Last()));
            }
            nums.Sort();

            foreach (float num in nums)
            {
                if (IsPage)
                {
                    if (num < 10)
                    {
                        listOut.Add(GetName(toAdd[num] + " 0" + num.ToString().Replace(',', '.')));
                    }
                    else
                    {
                        listOut.Add(GetName(toAdd[num]) + " " + num.ToString().Replace(',', '.'));
                    }
                }
                else
                {
                    listOut.Add(GetName(toAdd[num]) + " Chapitre " + num.ToString().Replace(',', '.'));
                }
            }

            return listOut.ToArray();
        }

        public static string GetPath(params string[] parts)
        {
            string path = string.Empty;
            for (int i = 0; i < parts.Length - 1; i++)
            {
                path += parts[i] + "\\";
            }
            return path + parts.Last();
        }



        public static void DeleteDirectory(params string[] parts)
        {
            string path = GetPath(parts);
            if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
            }
        }

        public static void CreateDirectory(params string[] parts)
        {
            string path = GetPath(parts);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        public static void StartPack()
        {
            if (Root != string.Empty)
            {
                CreateDirectory(Root, "Manga");
                CreateDirectory(Root, "Temp");
                CreateDirectory(Root, "Backup");
                if (Settings.Default.Manga != null)
                {
                    foreach (Manga manga in Mangas)
                    {
                        CreateDirectory(Root, "Manga", manga.Nom);
                    }
                }
            }
        }

        public static string GetPage(string page, params string[] directory)
        {
            return Get(directory).Where(e => Path.GetFileNameWithoutExtension(e).Replace('_', ' ').Equals(page)).First();
        }

        public static Manga GetManga(string name, List<Manga> mangaList)
        {
            return mangaList.Where(e => e.Nom == name).First();
        }

        public static Chapter GetChapter(string name, List<Chapter> chapterList)
        {
            return chapterList.Where(e => e.NameChapter == name).First();
        }

        public static string[] GetSortedChapters(params string[] parts)
        {
            return Sort(Get(GetPath(parts)), " Chapitre ", false);
        }
        public static string[] GetSortedPages(params string[] parts)
        {
            return Sort(Get(GetPath(parts)), "_", true);
        }

        public static string[] Get(params string[] parts)
        {
            if (Directory.GetDirectories(GetPath(parts)).Length == 0)
            {
                return Directory.GetFiles(GetPath(parts));
            }
            return Directory.GetDirectories(GetPath(parts));
        }



        public static void Progress(BaseBackGroundWorker bg, Form formParent)
        {
            FormProgress form = new(bg);
            form.ShowDialog(formParent);
        }

        public static string GetName(string path)
        {
            return Path.GetFileName(path);
        }

        public static string GetTempPath(string path, string nameChapter, string sourcePage)
        {
            return GetPath(path, nameChapter, GetName(sourcePage));
        }

        public static string GetNum<M>(List<M> list, Func<M, bool> predicate)
        {
            int index = list.IndexOf(list.Where(predicate).First()) + 1;
            if (index < 10)
            {
                return "0" + index;
            }
            else
            {
                return index.ToString();
            }
        }

        public static void Scan(Manga manga, bool scanAll, Form form, int num = 1)
        {
            BackGroundScan backGroundWorker = new(manga, scanAll, num);
            if (!backGroundWorker.Worker.IsBusy)
            {
                Progress(backGroundWorker, form);
                if (!backGroundWorker.isCancelled && backGroundWorker.GetChapters().Count > 0)
                {
                    FormDownload formDownload = new(backGroundWorker.GetChapters(), manga.Nom);
                    formDownload.ShowDialog();
                }
            }
        }


        public static string GetSite(string toMatch)
        {
            return Regex.Matches(toMatch, @"https:\/{2}w{3}\..*\..{2,3}", RegexOptions.Multiline).First().Value;
        }

    }
}
