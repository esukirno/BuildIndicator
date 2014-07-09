﻿using System.Configuration;
using BuildIndicator.Core;
using BuildIndicator.Notifier.Arduino;
using BuildIndicator.Notifier.Growl;

namespace BuildIndicator.Console
{
    class Program
    {
        private static void Main(string[] args)
        {
            new Program().Run();
        }

        public void Run()
        {
            System.Console.WriteLine("Press any key to stop the service.");
            var planKey = ConfigurationManager.AppSettings["PlanKey"];
            var bambooUri = ConfigurationManager.AppSettings["BambooRestApiUri"];

            var bamboo = new Bamboo(bambooUri);
            var notifications = new NotificationProvider(planKey, bamboo);
            var notifier = new StateAwareNotifier(new CompositeBuildNotifier(new GrowlBuildNotifier(),
                new ArduinoBuildNotifier()));
            var checkpointer = new ResultCheckpointer();
            var dispatcher = new BuildNotificationDispatcher(notifications, checkpointer, notifier);

            dispatcher.Start();

            System.Console.ReadKey();
            dispatcher.Stop();
        }
    }
}
