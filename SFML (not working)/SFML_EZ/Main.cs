using static EZCodeLanguage.EZHelp;
using SFML;
using SFML.Window;

namespace SFML_EZ
{
    public static class Main
    {
        public static Window CreateWindow(object _width, object _height, object _title)
        {
            try
            {
                var x = GetParameter<int>(_width);
                var y = GetParameter<int>(_height);
                var title = GetParameter<string>(_title);
                var videoMode = new VideoMode((uint)x, (uint)y);
                var window = new Window(videoMode, title);
                window.Closed += Window_Closed;
                return window;
            }
            catch (Exception ex)
            {
                throw ThrowError(ex);
            }
        }
        public static bool WindowIsOpen(object _window)
        {
            try
            {
                var window = GetParameter<Window>(_window);
                return window.IsOpen;
            }
            catch (Exception ex)
            {
                throw ThrowError(ex);
            }
        }

        private static void Window_Closed(object? sender, EventArgs e)
        {
            try
            {
                var window = (Window)sender;
                window.Close();
            }
            catch (Exception ex)
            {
                throw ThrowError(ex);
            }
        }
    }
}
