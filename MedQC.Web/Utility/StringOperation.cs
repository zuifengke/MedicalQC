using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedQC.Web.Utility
{
    public class StringOperation
    {
        /// <summary>
        /// 將ASCⅡ碼轉為字符
        /// </summary>
        /// <param name="asc">ASCⅡ碼</param>
        /// <returns></returns>
        public static string IntToChar(int asc)
        {
            return ((char)asc).ToString();
        }

        /// <summary>
        /// 獲取文件後綴名
        /// </summary>
        /// <param name="fileName">fileName文件名</param>
        /// <returns>文件後綴名(例:"zip")</returns>
        public static string GetFileExtension(string fileName)
        {
            return fileName.Split('.')[fileName.Split('.').Length - 1];
        }

        /// <summary>
        /// 從文件完整路徑獲取文件名
        /// </summary>
        /// <param name="fileFullName">文件完整路徑</param>
        /// <returns>文件名</returns>
        public static string GetFileName(string fileFullName)
        {
            int lastSeparateIndex =
                fileFullName.LastIndexOf('\\') > fileFullName.LastIndexOf('/') ?
                fileFullName.LastIndexOf('\\') : fileFullName.LastIndexOf('/');
            return fileFullName.Substring(lastSeparateIndex + 1);
        }

        /// <summary>
        /// 獲取文件所在文件夾
        /// </summary>
        /// <param name="filePath">文件完整路徑</param>
        /// <returns></returns>
        public static string GetFileDirectory(string filePath)
        {
            filePath = filePath.Replace('/', '\\');
            return filePath.Substring(0, filePath.LastIndexOf("\\"));
        }

        /// <summary>
        /// 計算文件大小,將字節數轉化為字符串輸出
        /// </summary>
        /// <param name="contentLength">文件大小(字節)</param>
        /// <returns>文件大小</returns>
        public static string CountFileSize(int contentLength)
        {
            if (contentLength < 1024)
            {
                return contentLength.ToString() + "B";
            }
            else if (contentLength / 1024 < 1024)
            {
                return (contentLength / 1024).ToString() + "KB";
            }
            else
            {
                return (contentLength / 1024 / 1024).ToString() + "MB";
            }
        }
        public static string GetSummary(string content,int length)
        {
            if (content == null)
                return string.Empty;
            else if (content.Length <= length)
                return content;
            else
                return content.Substring(0, length);
        }

        public static string IntToStringTime(int num)
        {
            if (num == 0)
            {
                return "00:00:00";
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                //xiaoshi
                int h = (num / 60) / 60;
                if (h >= 1)
                {
                    sb.Append(Temp(h.ToString()) + ":");
                }
                else
                {
                    sb.Append("00:");
                }

                //fengzhong 
                int m = num / 60;
                if (m >= 1)
                {
                    sb.Append(Temp((m - h * 60).ToString()) + ":");
                }
                else
                {
                    sb.Append("00:");
                }
                //miao
                int s = num % 60;
                if (s == 0)
                {
                    sb.Append("00");
                }
                else
                {
                    sb.Append(Temp(s.ToString()));
                }
                return sb.ToString();
            }
        }
        private static string Temp(string temp)
        {
            if (temp.Length == 1)
            {
                return "0" + temp;
            }
            return temp;
        }

        /// <summary>
        /// 判断数组中是否有该字符串
        /// </summary>
        /// <param name="Str"></param>
        /// <param name="KeyWords"></param>
        /// <returns></returns>
        public static bool IsHaveKeyWord(string Str, string[] KeyWords)
        {
            
            for (int i = 0; i < KeyWords.Length; i++)
            {
                if (Str.IndexOf(KeyWords[i]) > -1)
                    return true;
            }

            return false;
        }
        /// <summary>
        /// 取两个字符串最大公因子串
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <returns></returns>
        public static string LCS(string str1, string str2)
        {
            if (str1 == "" || str2 == "") return "";
            int[] c = new int[str1.Length];
            int max = 0; int maxj = 0;

            for (int i = 0; i < str2.Length; i++)
            {
                for (int j = str1.Length - 1; j > 0; j--)
                {
                    if (str2.ToCharArray()[i] == str1.ToCharArray()[j])
                    {
                        if (i == 0 || j == 0)
                            c[j] = 1;
                        else
                            c[j] = c[j - 1] + 1;
                    }
                    else
                        c[j] = 0;

                    if (c[j] >= max)//把>改成>=则返回最后一个最长匹配子串
                    {
                        //更新标志变量
                        max = c[j];
                        maxj = j;
                    }
                }
            }
            if (max == 0) return "";
            return str1.Substring(maxj - max + 1, max);
        }
    }
}
