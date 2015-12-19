using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint
{
    /// <summary>
    /// Выполняет действия, связанные с фигурами
    /// </summary>
    class CommandShape : Command
    {
        private Shape shape;
        private string commandName;

        /// <summary>
        /// Создает команду вида: фигура и что с ней сделали (добавили/удалили)
        /// </summary>
        public CommandShape(Shape shape, string commandName)
        {
            this.shape = shape;
            this.commandName = commandName;
        }

        public override void UnExecute(HistoryData historyData)
        {
            if (ReverseExecute() == "Добавление")
            {
                historyData.Shapes.Add(shape);
            }
            else
            {
                historyData.Shapes.RemoveAt(historyData.Shapes.Count - 1);
            }
        }

        public override void Execute(HistoryData historyData)
        {
            if (commandName == "Добавление")
            {
                historyData.Shapes.Add(shape);
            }
            else
            {
                historyData.Shapes.RemoveAt(historyData.Shapes.Count - 1);
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
