using Prism.Mvvm;
using System;
using System.IO;

namespace DEVWeekCharity.Model
{
    public class StartingScreen : BindableBase
    {
        private int remainingSum = GetRemainingSumFromFile();
        private string infoMessage = SetInitialMessage();

        private static string SetInitialMessage()
        {
            if (GetRemainingSumFromFile() > 0)
                return Constants.CanDonate;
            else
                return Constants.CannotDonate;
        }

        public int RemainingSum
        {
            get { return remainingSum; }
            set
            {

                SetProperty(ref remainingSum, value);
            }
        }

        public string InfoMessage
        {
            get { return infoMessage; }
            set
            {
                SetProperty(ref infoMessage, value);
            }
        }
        private static int GetRemainingSumFromFile()
        {
            string text = File.ReadAllText(Path.GetFullPath(Constants.RecourseRelativePath));
            if (Convert.ToInt32(text) <= 0)
                return 0;
            else
                return Convert.ToInt32(text);

        }
    }
}
