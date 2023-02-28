using Newtonsoft.Json.Bson;
using scan_manga.Models;
using scan_manga.Properties;
using scan_manga.Utilities.BackgroudWorker;
using scan_manga.Utilities.BackgroudWorker.BackgroundCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace scan_manga.Utilities
{
    public class MangaUtility
    {
        public static string Root = Settings.Default.Root;
        public static string Temp = GetPath(Directory.GetCurrentDirectory(), "Temp");
        public static string[] Sort(string[] listIn, string separator, string toAdd, bool IsPage)
        {
            List<string> listOut = new();
            List<float> nums = new();
            foreach (string item in listIn)
            {
                string itemName = Path.GetFileNameWithoutExtension(item);
                float num = float.Parse(itemName.Split(separator).Last());
                nums.Add(num);
            }
            nums.Sort();

            foreach (float num in nums)
            {
                if (IsPage)
                {
                    if (num < 10)
                    {
                        listOut.Add(toAdd + "0" + num.ToString().Replace(',', '.'));
                    }
                    else
                    {
                        listOut.Add(toAdd + num.ToString().Replace(',', '.'));
                    }
                }
                else
                {
                    listOut.Add(toAdd + num.ToString().Replace(',', '.'));
                }

            }

            return listOut.ToArray();
        }

        public static string GetPath(params string[] parts)
        {
            string path = string.Empty;
            foreach (string part in parts)
            {
                if (!(parts.Last() == part))
                {
                    path += part + "\\";
                }
                else
                {
                    path += part;

                }

            }
            return path;
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

        public static void StartPack(string root)
        {
            if (root != null && Settings.Default.Manga != null)
            {
                CreateDirectory(root, "Manga");
                CreateDirectory(root, "Temp");
                CreateDirectory(root, "Backup");
                foreach (Manga manga in Settings.Default.Manga)
                {
                    CreateDirectory(root, "Manga", manga.Nom);
                }
            }
        }

        public static string? GetPage(string page, params string[] directory)
        {
            return Directory.GetFiles(GetPath(directory)).Where(e => Path.GetFileNameWithoutExtension(e).Replace('_', ' ') == page).FirstOrDefault();
        }

        public static string[] GetPages(params string[] part)
        {
            return Sort(Get(GetPath(part)), "_", "page ", true);
        }

        public static Manga GetManga(string name, List<Manga> mangaList)
        {
            return mangaList.Where(e => e.Nom == name).First();
        }

        public static Chapter GetChapter(string name, List<Chapter> chapterList)
        {
            return chapterList.Where(e => e.NameChapter == name).First();
        }

        public static string[] GetSortedChapters(string separator, string toAdd, params string[] parts)
        {
            return Sort(Get(GetPath(parts)), separator, toAdd, false);
        }

        public static string[] Get(params string[] parts)
        {
            if (Directory.GetDirectories(GetPath(parts)).Length == 0)
            {
                return Directory.GetFiles(GetPath(parts));
            }
            return Directory.GetDirectories(GetPath(parts));
        }



        public static void Progress(BaseBackGroundWorker bg)
        {
            FormProgress form = new(bg);
            form.ShowDialog();
        }

        public static string GetName(string path)
        {
            return Path.GetFileName(path);
        }

        public static string GetTempPath(string path, string nameChapter, string sourcePage)
        {
            return GetPath(path, nameChapter, GetName(sourcePage));
        }

        public static string GetNum<T, M>(T item, List<M> list, Func<M, bool> predicate)
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

        public static void Scan(Manga manga, bool scanAll, string source, int num = 1)
        {
            BackGroundScan backGroundWorker = new(manga, source, scanAll, num);
            if (!backGroundWorker.Worker.IsBusy)
            {
                Progress(backGroundWorker);
                if (!backGroundWorker.isCancelled && backGroundWorker.GetChapters().Count > 0)
                {
                    FormDownload formDownload = new(backGroundWorker.GetChapters(), manga.Nom);
                    formDownload.ShowDialog();
                }

            }
        }
    }
}
