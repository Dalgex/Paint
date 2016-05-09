using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint
{
    /// <summary>
    /// Выполняет действия, связанные с определением параметров инструмента "текст"
    /// </summary>
    public class CommandText : Command
    {
        private MyTextBox myTextBox;
        private TextSettings textSettings;

        public CommandText(MyTextBox myTextBox, TextSettings textSettings)
        {
            this.myTextBox = myTextBox;
            this.textSettings = textSettings;
        }

        public override void UnExecute(HistoryData historyData)
        {
            historyData.TextSettings.Pop();
            myTextBox.InitializeTextBox(historyData.TextSettings.Peek());
        }

        public override void Execute(HistoryData historyData)
        {
            historyData.TextSettings.Push(textSettings);
            myTextBox.InitializeTextBox(historyData.TextSettings.Peek());
        }
    }
}
