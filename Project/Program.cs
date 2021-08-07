﻿using Project.Forms.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Project
{
    static class Program
    {
        static LoginForm login;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            login = new LoginForm();
            Application.Run(login);
            Application.ThreadException += Exception_Handle;
            if (login.DialogResult.Equals(DialogResult.OK))
            {
                Application.Run(new MainForm());
            }
        }

        public static void Exception_Handle(object sender, ThreadExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}