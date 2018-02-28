using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace MSSQLDatabaseDocGen
{
    /// <summary>
    /// Lớp xử lý các thao tác liên quan đến file
    /// </summary>
    /// <Modifield>
    /// Người tạo                   ngày tạo            chú thích
    /// Nguyễn Trung Tuyến          9/04/2009           Tạo mới
    /// </Modifield>
    class ClsFileFunction
    {
        public ClsFileFunction() { }
        ~ClsFileFunction() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        /// <Modifield>
        /// Người tạo                   ngày tạo            chú thích
        /// Nguyễn Trung Tuyến          9/04/2009           Tạo mới
        /// </Modifield>
        public String ReadFileToString(String filename)
        {
            String strtemp = string.Empty;
            if (File.Exists(filename))
            {
                try
                {
                    FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    StreamReader reader = new StreamReader(fs);
                    strtemp = reader.ReadToEnd();
                    reader.Close();
                    fs.Close();
                   
                }
                catch
                {
                    
                }
            }
            return strtemp;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        /// <Modifield>
        /// Người tạo                   ngày tạo            chú thích
        /// Nguyễn Trung Tuyến          9/04/2009           Tạo mới
        /// </Modifield>
        public Boolean WriteContentToFile(String filename, String content)
        {
            try
            {
                FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
                StreamWriter writer = new StreamWriter(fs, System.Text.Encoding.UTF8);
                writer.Write(content);
                writer.Flush();
                writer.Close();
                fs.Close();
                return true;
            }
            catch
            {

            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        /// <Modifield>
        /// Người tạo                   ngày tạo            chú thích
        /// Nguyễn Trung Tuyến          9/04/2009           Tạo mới
        /// </Modifield>
        public Boolean DeleteFile(String filename)
        {
            try
            {
                if (File.Exists(filename))
                {
                    File.Delete(filename);
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
            }
            return false;
        }

        public bool CopyFile(String sourfile, String destfile)
        {
            try
            {
                if (File.Exists(destfile))
                    DeleteFile(destfile);
               
                if (File.Exists(sourfile))
                {
                    File.Copy(sourfile, destfile);
                    return true;
                }
                else
                    return false;
               

            }
            catch (Exception ex)
            {

            }
            return false;
        }
    }
}
