using EZCodeLanguage;

namespace io_package
{
    public class IO
    {
        public static string FixPath(string path) => path.Replace("/", "\\").Replace(" : \\", ":\\");
        public static string FileRead(object _path)
        {
            try
            {
                string path = EZHelp.GetParameter<string>(_path, "str");
                path = FixPath(path);
                return File.ReadAllText(path);
            }
            catch (Exception e) 
            {
                throw EZHelp.ThrowError(e);
            }
        }
        public static void FileWrite(object _path, object _text)
        {
            try
            {
                string path = EZHelp.GetParameter<string>(_path, "str");
                string text = EZHelp.GetParameter<string>(_text, "str");
                path = FixPath(path);
                File.WriteAllText(path, text);
            }
            catch (Exception e) 
            {
                throw EZHelp.ThrowError(e);
            }
        }
        public static void FileCreate(object _path)
        {
            try
            {
                string path = EZHelp.GetParameter<string>(_path, "str");
                path = FixPath(path);
                File.Create(path).Close();
            }
            catch (Exception e) 
            {
                throw EZHelp.ThrowError(e);
            }
        }
    }
}
