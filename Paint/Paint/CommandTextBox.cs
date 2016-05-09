using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint
{
    /// <summary>
    /// Выполняет действия, связанные с отображением элемента управления TextBox для текста
    /// </summary>
    public class CommandTextBox : Command
    {
        private MyTextBox myTextBox;
        private string commandName;

        public CommandTextBox(MyTextBox myTextBox, string commandName)
        {
            this.myTextBox = myTextBox;
            this.commandName = commandName;
        }

        public override void UnExecute(HistoryData historyData)
        {
            if (ReverseExecute() == "Добавление")
            {
                myTextBox.TextBox.Visible = true;
            }
            else
            {
                myTextBox.TextBox.Visible = false;
            }
        }

        public override void Execute(HistoryData historyData)
        {
            if (commandName == "Добавление")
            {
                myTextBox.TextBox.Visible = true;
            }
            else
            {
                myTextBox.TextBox.Visible = false;
            }
        }

        /// <summary>
        /// Заменяет команду на противоположную: если было удаление, то теперь считается, что это добавление, и наоборот
        /// </summary>
        private string ReverseExecute()
        {
            return (commandName == "Добавление") ? "Удаление" : "Добавление";
        }
    }
}
