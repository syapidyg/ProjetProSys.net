﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using KitchenRoom.controller;
using KitchenRoom.model;
using KitchenRoom.view;


namespace KitchenRoom
{
    internal static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            KitchenModel model = new KitchenModel();
            KitchenView view = new KitchenView(model);
            KitchenController controller = new KitchenController(model, view);

            controller.Start();
        }
    }
}
