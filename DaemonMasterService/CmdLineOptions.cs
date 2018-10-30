﻿using CommandLine;

namespace DaemonMasterService
{
    public abstract class GlobalOptions
    {

    }

    [Verb("general", HelpText = "General options like deleteAllServices, etc.")]
    public class GeneralOptions : GlobalOptions
    {
        [Option("deleteAllServices", Required = false, HelpText = "Delete all installed services that are using this .exe to work.", Default = false)]
        public bool DeleteAllServices { get; set; }

        [Option("killAllServices", Required = false, HelpText = "Kill all installed services that are using this .exe to work.", Default = false)]
        public bool KillAllServices { get; set; }
    }

    [Verb("service", HelpText = "Start the .exe in service mode.")]
    public class ServiceOptions : GlobalOptions
    {
        [Option('p', "enablePause", Required = false, HelpText = "Enable the pause function (so that the service can be paused / NOT recommended).", Default = false)]
        public bool EnablePause { get; set; }
    }


    public abstract class CommonEditInstallOptions : GlobalOptions
    {
        [Option("displayName", Required = true, HelpText = "", Default = null)]
        public string DisplayName { get; set; }

        [Option("description", Required = false, HelpText = "Here you can give the service a description.", Default = "")]
        public string Description { get; set; }


        [Option("args", Required = false, HelpText = "Here you can give argumments that  ar for the service.", Default = "")]
        public string Arguments { get; set; }

        [Option("fullPath", Required = true, HelpText = "The full path to the file that should started as service", Default = null)]
        public string FullPath { get; set; }


        [Option("username", SetName = "CustomUser", Required = false, HelpText = "Only local users (Exampel: '.\\Alfred')", Default = "")]
        public string Username { get; set; }

        [Option("pw", SetName = "CustomUser", Required = false, HelpText = "Password if it should start with custom user account.")]
        public string Password { get; set; }


        [Option("maxRestarts", Required = false, HelpText = "", Default = 3)]
        public int MaxRestarts { get; set; }

        [Option("startType", Required = true, HelpText = "", Default = 3)]
        public int StartType { get; set; }

        [Option("processKillTime", Required = false, HelpText = "", Default = 9500)]
        public int ProcessKillTime { get; set; }

        [Option("processRestartDelay", Required = false, HelpText = "", Default = 2000)]
        public int ProcessRestartDelay { get; set; }

        [Option("counterResetTime", Required = false, HelpText = "", Default = 43200)]
        public int CounterResetTime { get; set; }

        [Option("consoleApp", Required = false, HelpText = "", Default = false)]
        public bool ConsoleApplication { get; set; }

        [Option("ctrlC", Required = false, HelpText = "", Default = false)]
        public bool UseCtrlC { get; set; }

        [Option("canInteractWithDesktop", SetName = "LocalUser", Required = false, HelpText = "Can only be used with supported windows versions and also NOT with a custom user.", Default = false)]
        public bool CanInteractWithDesktop { get; set; }
    }

    [Verb("edit", HelpText = "Edit an installed service.")]
    public class EditOptions : CommonEditInstallOptions
    {
        [Option("serviceName", Required = true, HelpText = "Name of the the service that should be edited.", Default = null)]
        public string ServiceName { get; set; }
    }

    [Verb("install", HelpText = "Create a new service.")]
    public class InstallOptions : CommonEditInstallOptions
    {
        [Option("serviceName", Required = true, HelpText = "Name of the new Service", Default = null)]
        public string ServiceName { get; set; }
    }

    [Verb("installDmdf", HelpText = "Create a new service with an DMDF file.")]
    public class InstallDmdfOptions : GlobalOptions
    {
        [Option("path", Required = true, HelpText = "Path to the dmdf file (JSON format).", Default = "")]
        public string Path { get; set; }

        [Option("pw", Required = false, HelpText = "Password if it should start with custom user account. Required when a Username is defined!", Default = null)]
        public string Password { get; set; }
    }
}
