using EZCodeLanguage;
using System.Drawing;
using System.Windows.Forms;
using static EZCodeLanguage.EZHelp;

namespace WinFormsEZCodeLibrary
{
    public static class WinForms
    {
        public static void EnableDefaultSettings()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
            }
            catch (Exception ex)
            {
                SetError(ex);
            }
        }
        public static void StartApplication(object window)
        {
            try
            {
                Application.Run((GetParameter(window, "window") as Form)!);
            }
            catch (Exception ex)
            {
                SetError(ex);
            }
        }
        public static Form CreateWindowInstance(object _left, object _top, object _width, object _height, object _text)
        {
            try
            {
                int left = int.Parse(GetParameter(_left, "int").ToString()!),
                    top = int.Parse(GetParameter(_top, "int").ToString()!),
                    width = int.Parse(GetParameter(_width, "int").ToString()!),
                    height = int.Parse(GetParameter(_height, "int").ToString()!);
                string text = GetParameter(_text, "int").ToString()!;

                return new Form()
                {
                    Left = left,
                    Top = top,
                    Width = width,
                    Height = height,
                    Text = text,
                };
            }
            catch (Exception ex)
            {
                throw SetError(ex);
            }
        }
        public static void OpenWindow(object window)
        {
            try
            {
                (GetParameter(window, "window") as Form)?.Show();
            }
            catch (Exception ex)
            {
                SetError(ex);
            }
        }
        public static void CloseWindow(object window)
        {
            try
            {
                (GetParameter(window, "window") as Form)?.Close();
            }
            catch (Exception ex)
            {
                SetError(ex);
            }
        }
        public static void DestroyWindow(object window)
        {
            try
            {
                (GetParameter(window, "window") as Form)?.Dispose();
            }
            catch (Exception ex)
            {
                SetError(ex);
            }
        }
    }
}
