﻿using Newtonsoft.Json.Bson;
using scan_manga.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scan_manga.Utilities
{
    public class MangaUtility
    {
        public static string[] Sort(List<string> listIn, string separator, string toAdd, bool IsPage)
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

        public static List<string> SetChapters(List<Chapter> chaptersIn)
        {
            List<string> chaptersOut = new();

            foreach (Chapter chapter in chaptersIn)
            {
                chaptersOut.Add(chapter.NameChapter);
            }

            return chaptersOut;
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
            if (root != null)
            {
                CreateDirectory(root, "Manga");
                CreateDirectory(root, "Temp");
                CreateDirectory(root, "Backup");
            }
        }

        public static string? GetPage(string[] directory, string page)
        {
            return directory.Where(e => Path.GetFileNameWithoutExtension(e).Replace('_', ' ') == page).FirstOrDefault();
        }

        public static Manga GetManga(string name, List<Manga> mangaList)
        {
            return mangaList.Where(e=>e.Nom==name).First();
        }

        public static Chapter GetChapter(string name, List<Chapter> chapterList)
        {
            return chapterList.Where(e => e.NameChapter == name).First();
        }


    }
}
