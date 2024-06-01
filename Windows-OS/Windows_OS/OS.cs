using Microsoft.Win32;
using System.Diagnostics;
using System.Reflection;
using static EZCodeLanguage.EZHelp;

namespace Windows_OS
{
    public class OS
    {
        // OS Package:
        //     include os
        public void RegistrySetKey(object _keyName, object _key, object _value)
        {
            try
            {
                string keyName = GetParameter<string>(_keyName),
                    key = GetParameter<string>(_key);
                object value = GetParameter<string>(_value);

                using (var v = Registry.CurrentUser.CreateSubKey(keyName))
                {
                    Type type = value.GetType();
                    if (type == typeof(int))
                    {
                        value = $"_ {value}";
                    }
                    v.SetValue(key, value);
                }
            }
            catch (Exception ex)
            {
                throw ThrowError(ex);
            }
        }
        public object RegistryGetKey(object _keyName, object _key)
        {
            try
            {
                string keyName = GetParameter<string>(_keyName),
                    key = GetParameter<string>(_key);

                using (var v = Registry.CurrentUser.OpenSubKey(keyName))
                {
                    if (v != null)
                    {
                        return v.GetValue(key);
                    }
                    else
                    {
                        throw new Exception($"Could not find registry key at '{Path.Combine(keyName, key)}'");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ThrowError(ex);
            }
        }
        public string RegistryLocalMachine() => Registry.LocalMachine.ToString();
        public string RegistryCurrentUser() => Registry.CurrentUser.ToString();
        public string RegistryUsers() => Registry.Users.ToString();
        public string RegistryClassesRoot() => Registry.ClassesRoot.ToString();
        public string RegistryPerformanceData() => Registry.PerformanceData.ToString();
        public string RegistryCurrentConfig() => Registry.CurrentConfig.ToString();
        public Process ProcessStart(object _path, object? _arguments)
        {
            try
            {
                string path = FixDirPath(GetParameter<string>(_path));
                object? arguments = Try(() => GetParameter<string>(_arguments));

                if (arguments != null)
                {
                    return Process.Start(path, arguments.ToString());
                }
                else
                {
                    return Process.Start(path);
                }
            }
            catch (Exception ex)
            {
                throw ThrowError(ex);
            }
        }
        public string ProcessName(object _process) => (GetParameter(_process, "process") as Process).ProcessName;
        public Process ProcessGetCurrentProcess() => Process.GetCurrentProcess();
        public Process ProcessGetProcessById(object _id, object? _machineName)
        {
            try
            {
                int id = GetParameter<int>(_id);
                object? machineName = Try(() => GetParameter<string>(_machineName));

                if (machineName != null)
                {
                    return Process.GetProcessById(id, machineName.ToString());
                }
                else
                {
                    return Process.GetProcessById(id);
                }
            }
            catch (Exception ex)
            {
                throw ThrowError(ex);
            }
        }
        public Process[] ProcessGetProcesses(object? _machineName)
        {
            try
            {
                object? machineName = Try(() => GetParameter<string>(_machineName));

                if (machineName != null)
                {
                    return Process.GetProcesses(machineName.ToString());
                }
                else
                {
                    return Process.GetProcesses();
                }
            }
            catch (Exception ex)
            {
                throw ThrowError(ex);
            }
        }
        public Process[] ProcessGetProcessByName(object _name, object? _machineName)
        {
            try
            {
                string name = GetParameter<string>(_name);
                object? machineName = Try(() => GetParameter<string>(_machineName));

                if (machineName != null)
                {
                    return Process.GetProcessesByName(name, machineName.ToString());
                }
                else
                {
                    return Process.GetProcessesByName(name);
                }
            }
            catch (Exception ex)
            {
                throw ThrowError(ex);
            }
        }
        public void ProcessKill(object _process) => (GetParameter(_process, "process") as Process).Kill();
        public object? ProcessGetProperty(object _process, object _property)
        {
            try
            {
                var process = GetParameter(_process, "process") as Process;
                var property = GetParameter<string>(_property);

                if (process == null)
                {
                    throw new ArgumentNullException(nameof(_process), "The process object is null.");
                }

                PropertyInfo propertyInfo = typeof(Process).GetProperty(property, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
                if (propertyInfo == null)
                {
                    throw new ArgumentException($"Property \"{property}\" not found on type \"Process\".");
                }

                return propertyInfo.GetValue(process);
            }
            catch (Exception ex)
            {
                throw ThrowError(ex);
            }
        }
        public object? ProcessRunFunction(object _process, object _function)
        {
            try
            {
                var process = GetParameter(_process, "process") as Process;
                var function = GetParameter<string>(_function);

                if (process == null)
                {
                    throw new ArgumentNullException(nameof(_process), "The process object is null.");
                }

                MethodInfo methodInfo = typeof(Process).GetMethod(function, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
                if (methodInfo == null)
                {
                    throw new ArgumentException($"Method \"{function}\" not found on type \"Process\".");
                }

                return methodInfo.Invoke(process, null);
            }
            catch (Exception ex)
            {
                throw ThrowError(ex);
            }
        }

    }
}
