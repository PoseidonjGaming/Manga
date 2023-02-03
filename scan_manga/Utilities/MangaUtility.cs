﻿using Newtonsoft.Json.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scan_manga.Utilities
{
    public class MangaUtility
    {
        public string[] Sort(List<string> listIn, string separator, string toAdd, bool IsPage)
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

        public string GetPath(params string[] parts)
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

        public List<string> SetChapters(List<Chapter> chaptersIn)
        {
            List<string> chaptersOut = new();

            foreach (Chapter chapter in chaptersIn)
            {
                chaptersOut.Add(chapter.NameChapter);
            }

            return chaptersOut;
        }

        public void DeleteDirectory(params string[] parts)
        {
            string path = GetPath(parts);
            if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
            }
        }

        public void CreateDirectory(params string[] parts)
        {
            string path = GetPath(parts);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        public void StartPack(string root)
        {
            if (root != null)
            {
                CreateDirectory(root, "Manga");
                CreateDirectory(root, "Temp");
                CreateDirectory(root, "Backup");
            }

        }

        public string[] GetChapter(string separator, string toAdd, params string[] parts)
        {
            return Sort(Directory.GetDirectories(GetPath(parts)).ToList(), separator, toAdd, false);
        }
    }
}
