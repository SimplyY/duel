using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace duel
{
    class GameStatus
    {
        private static string statusInfo;

        public static void SetStatusInfo(string status)
        {
            statusInfo = status;
        }

        public static void SetErrorInfo(string errorInfo)
        {
            statusInfo = errorInfo;
        }

        public static void ShowGameStatus(System.Windows.Forms.TextBox showStatusBox)
        {
            showStatusBox.Text = statusInfo;
        }
    }
}
